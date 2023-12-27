using System.CommandLine;
using TheXDS.MCART.Helpers;
using TheXDS.MCART.Types.Base;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Commands;

internal class SimulateCommand : PhisherCommand
{
    private class SimulateContext(DataBase data) : Disposable, IAttackContext
    {
        public HttpResponseMessage? LastResponse => null;

        public Dictionary<string, string> Headers { get; } = [];

        public DataBase Data { get; } = data;

        public bool Failed { get; set; }

        public HttpClient? Client { get => null; set { } }

        public void SwitchServer(string newServer, Attack attack)
        {
            Console.WriteLine($" -- Attack would have switched to host '{newServer}'");
        }

        protected override void OnDispose()
        {
        }
    }

    public override Command GetCommand()
    {
        var simulateCmd = new Command("simulate", "Simulates a set of actions to be performed while executing an attack.");
        var attackArg = (Argument<string>)CommonArguments["attackName"];
        var attackDataOpt = (Option<AttackData>)CommonOptions["data"];
        simulateCmd.AddArgument(attackArg);
        simulateCmd.AddOption(attackDataOpt);
        simulateCmd.SetHandler(SimulateCommandHandler, attackArg, attackDataOpt);
        return simulateCmd;
    }

    private void SimulateCommandHandler(string attackName, AttackData data)
    {
        if (!KnownAttacks.TryGetValue(attackName, out var attackType) || attackType.New<Attack>() is not { } attack)
        {
            throw new Exception("Unknown attack.");
        }
        using SimulateContext context = new(Map(data));
        Console.WriteLine($"""
            Attack info:
            ===================
            Name: {attackName}
            Server: {attack.Server}
            Loaded domains for data generation: {string.Join(", ", MiscFaker.Domains.Distinct())}

            """);
        foreach (var (index, element) in SafeEnumerate(attack, context))
        {
            ShowAttackItemInfo(index + 1, element, context);
        }
    }

    private static IEnumerable<(int, AttackItem)> SafeEnumerate(Attack attack, IAttackContext context)
    {
        bool TryMoveNext(IEnumerator<(int, AttackItem)> e)
        {
            try
            {
                return e.MoveNext();
            }
            catch
            {
                Console.WriteLine("""


                    -------- Attack has been truncated --------
                    The Attack may contain further steps, but it's possible that I cannot enumerate them; be it because the step is heavily dependant on a response, or because of some other failure.
                    """);
                return false;
            }
        }

        using var e = attack.GetAttacks(context).WithIndex().GetEnumerator();

        while (TryMoveNext(e))
        {
            yield return e.Current;
        }
    }

    private static void ShowAttackItemInfo(int stepNumber, AttackItem item, IAttackContext context)
    {
        Console.WriteLine($"""
            
            Step {stepNumber}
            ===================
            {(IsPost(item) ? "POST" : "GET")} /{item.Route}
            {DumpRequest(item, context)}
            """);
        if (context.Headers.Count != 0)
        {
            Console.WriteLine($"""

                Headers:
                -------------------
                {DumpHeaders(context)}
                """);
        }
    }

    private static string DumpHeaders(IAttackContext context)
    {
        return string.Join(Environment.NewLine, context.Headers.Select(p => $"{p.Key}: {p.Value}"));
    }

    private static bool IsPost(AttackItem item)
    {
        return item.FormItems is not null || item.PlainData is not null;
    }

    private static string DumpRequest(AttackItem item, IAttackContext context)
    {
        return (DumpFormItems(item, context) ?? item.PlainData?.Invoke(context.Data)) is { } str ? $"""
            
            Request data:
            -------------------
            {str}
            """ : "";
    }

    private static string? DumpFormItems(AttackItem item, IAttackContext context)
    {
        if (item.FormItems is null) return null;
        return string.Join(Environment.NewLine, item.FormItems.Invoke(context.Data).Select(p => $"{p.key}: {p.value}"));
    }
}