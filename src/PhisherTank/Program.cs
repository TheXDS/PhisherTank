using ConsoleApp1.Models;
using System.CommandLine;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank;

public enum AttackData : byte
{
    Faux,
    Garbage,
    Truckload,
    Test
}

internal static class Program
{
    private static volatile bool keepRunning = true;

    private static Task<int> Main(string[] args)
    {
        var rootCmd = new RootCommand("PhisherTank - Phishing site flood and faux-data generator.");
        var attackCmd = new Command("attack", "Initiates a flooding attack.");
        var attackNameArg = new Argument<string>("attackName").FromAmong(GetAttacks().Select(p => p.Name).ToArray());
        var timeoutOption = new Option<int>(["--timeout", "-t"], () => 30, "Specifies the desired timeout for all requests, in seconds.");
        var threadsOption = new Option<int>(["--threads", "-T"], () => Environment.ProcessorCount, "Specifies the number of attack threads to generate. Defualts to the number of available CPUs on the system.");
        var httpsOption = new Option<bool>(["--https", "-s"], "Indicates that the attack must be executed using HTTPS requests.");
        var attackDataOption = new Option<AttackData>(["--attack-data", "-d"], () => AttackData.Faux, "Specifies the kind of data to send.");
        var listCmd = new Command("list", "Lists all the available built-in attacks.");
        rootCmd.AddCommand(attackCmd);
        rootCmd.AddCommand(listCmd);
        attackCmd.AddArgument(attackNameArg);
        attackCmd.AddOption(timeoutOption);
        attackCmd.AddOption(threadsOption);
        attackCmd.AddOption(httpsOption);
        attackCmd.AddOption(attackDataOption);
        attackCmd.SetHandler(AttackCommandHandler, attackNameArg, timeoutOption, threadsOption, httpsOption, attackDataOption);
        listCmd.SetHandler(ListCommandHandler);
        return rootCmd.InvokeAsync(args);
    }

    private static IEnumerable<Type> GetAttacks()
    {
        return MCART.Helpers.ReflectionHelpers.GetTypes<Attack>(true);
    }

    private static void ListCommandHandler()
    {
        foreach (var j in GetAttacks()) Console.WriteLine(j.Name);
    }

    private static Task AttackCommandHandler(string attackName, int timeout, int threads, bool https, AttackData attackData)
    {
        if (GetAttacks().FirstOrDefault(p => p.Name == attackName)?.New<Attack>() is not { } attack)
        {
            throw new Exception("Unknown attack.");
        }
        attack.Scheme = https ? "https" : "http";
        attack.Timeout = timeout;

        CancellationTokenSource cts = new();
        var attackThreads = CreateAttackThreads(attack, threads, attackData, cts.Token).ToArray();
        Console.CancelKeyPress += (_, __) =>
        {
            Console.WriteLine("Stopping...");
            keepRunning = false;
            cts.Cancel();
            Environment.Exit(0);
        };
        return Task.WhenAll(attackThreads.Select(p => p.Task).Append(RefreshThread(attackThreads)));
    }

    private static async Task RefreshThread(AttackThread[] threads)
    {
        while (keepRunning)
        {
            UpdateStatus(threads);
            await Task.Delay(500);
        }
    }

    private static void UpdateStatus(AttackThread[] threads)
    {
        Console.Clear();
        Console.CursorTop = 1;
        Console.CursorLeft = 0;
        var s = 0;
        var f = 0;
        foreach (var (x, status) in threads)
        {
            Console.WriteLine($"Task ID {x.Id} -> {status}");
            s += status.SuccessCounter;
            f += status.FailureCounter;
        }
        string rate = s + f > 0 ? $"{s * 100.0 / (s + f):f1}%" : "N/A";
        Console.WriteLine($"Total -> Success: {s}, failures: {f} (success rate: {rate})");
    }

    private static IEnumerable<AttackThread> CreateAttackThreads(Attack attack, int count, AttackData data, CancellationToken cancellationToken)
    {
        var c = count;
        while (c > 0)
        {
            var counter = new Status() { Name = $"{attack.GetType().Name}-{(count - c).ToString(new string('0', count.ToString().Length))}" };
            yield return new(Spam(counter, attack, data, cancellationToken), counter);
            c--;
        }
    }

    private static async Task Spam(Status counter, Attack attack, AttackData data, CancellationToken cancellationToken)
    {
        while (keepRunning)
        {
            try
            {
                await RunAttack(attack, counter, data, cancellationToken);
            }
            catch (Exception ex)
            {
                counter.Failure(ex.Message);
                Thread.Sleep(2000);
            }
        }
    }

    private static async Task RunAttack(Attack attack, Status counter, AttackData data, CancellationToken cancellationToken)
    {
        using AttackContext context = new(Map(data));
        using var client = CreateClient(attack);
        foreach (var item in attack.GetAttacks(context))
        {
            using var request = item.NewRequest(context.Data);
            context.AddHeaders(request);
            context.LastResponse = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (!keepRunning || context.CheckResponse()) break;
        }
        UpdateStatistics(context, counter);
    }

    private static DataBase Map(AttackData data)
    {
        return data switch
        {
            AttackData.Faux => new FauxData(),
            AttackData.Garbage => new GarbageData(),
            AttackData.Truckload => new TruckloadData(),
            AttackData.Test => new TestData(),
            _ => throw new NotImplementedException(),
        };
    }

    private static HttpClient CreateClient(Attack attack)
    {
        return new HttpClient()
        {
            BaseAddress = new Uri($"{attack.Scheme}://{attack.Server}/"),
            Timeout = TimeSpan.FromSeconds(attack.Timeout)
        };
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