using ConsoleApp1.Attacks;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        private static volatile bool keepRunning = true;

        private static void Main()
        {
            CancellationTokenSource cts = new();
            var threads = CreateAttackThreads<DrexmHostAttack>(cts.Token, 1).ToArray();
            Console.CancelKeyPress += (_, __) =>
            {
                Console.WriteLine("Stopping...");
                keepRunning = false;
                cts.Cancel();
                Environment.Exit(0);
            };
            while (keepRunning)
            {
                UpdateStatus(threads);
                Thread.Sleep(500);
            }
        }

        private static void UpdateStatus((Task AttackThread, Status AttackStatus)[] threads)
        {
            Console.Clear();
            Console.CursorTop = 1;
            Console.CursorLeft = 0;
            var s = 0;
            var f = 0;
            foreach (var (_, status) in threads)
            {
                Console.WriteLine($"{status} -> {status}");
                s += status.SuccessCounter;
                f += status.FailureCounter;
            }
            string rate = (s + f) > 0 ? $"{(s * 100.0) / (s + f):f1}%" : "N/A";
            Console.WriteLine($"Total -> Success: {s}, failures: {f} (success rate: {rate})");
        }

        private static IEnumerable<(Task AttackThread, Status AttackStatus)> CreateAttackThreads<TAttack>(CancellationToken cancellationToken, int? count = null) where TAttack : Attack, new()
        {
            return CreateAttackThreads(new TAttack(), cancellationToken, count);
        }

        private static IEnumerable<(Task AttackThread, Status AttackStatus)> CreateAttackThreads(Attack attack, CancellationToken cancellationToken, int? count = null)
        {
            var total = count ?? Environment.ProcessorCount;
            var c = total;
            while (c > 0)
            {
                var counter = new Status() {Name = $"{attack.GetType().Name}-{(total - c).ToString(new string('0', total.ToString().Length))}" };
                yield return (Spam(counter, attack, cancellationToken), counter);
                c--;
            }
        }

        private static async Task Spam(Status counter, Attack attack, CancellationToken cancellationToken)
        {
            while (keepRunning)
            {
                try
                {
                    await RunAttack(attack, counter, cancellationToken);
                }
                catch (Exception ex)
                {
                    counter.Failure(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }

        private static async Task RunAttack(Attack attack, Status counter, CancellationToken cancellationToken)
        {
            using AttackContext context = new();
            using var client = attack.CreateClient();
            foreach (var item in attack.GetAttacks(context))
            {
                using var request = item.NewRequest(context.FauxData);
                context.AddHeaders(request);
                context.LastResponse = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
                if (!keepRunning || context.CheckResponse()) break;
            }
            UpdateStatistics(context, counter);
        }

        private static void UpdateStatistics(IAttackContext context, Status counter)
        {
            if (!context.Failed)
            {
                counter.Success();
            }
            else
            {
                counter.Failure($"{context.LastResponse?.ReasonPhrase ?? context.LastResponse?.StatusCode.ToString() ?? "Invalid attack"} on {context.LastResponse?.RequestMessage?.RequestUri?.ToString() ?? "<Unknown>"}");
                Thread.Sleep(2000);
            }
        }
    }
}