using System.CommandLine;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Commands;

internal class TryCommand : PhisherCommand
{
    public override Command GetCommand()
    {
        var cmd = new Command("try", "Tries a single attack loop on a target to see if it's still up.");
        var attackArg = GetArgument<string>("attackName");
        var attackDataOpt = GetOption<AttackData>("data");
        var httpsOption = GetOption<bool>("https");
        var timeoutOption = GetOption<int>("timeout");
        cmd.AddArgument(attackArg);
        cmd.AddOption(attackDataOpt);
        cmd.AddOption(httpsOption);
        cmd.AddOption(timeoutOption);
        cmd.SetHandler(TryCommandHandler, attackArg, attackDataOpt, timeoutOption, httpsOption);
        return cmd;
    }

    private async Task TryCommandHandler(string attackName, AttackData data, int timeout, bool https)
    {
        if (!KnownAttacks.TryGetValue(attackName, out var attackType) || attackType.New<Attack>() is not { } attack)
        {
            throw new Exception("Unknown attack.");
        }
        attack.Scheme = https ? "https" : "http";
        attack.Timeout = timeout;

        CancellationTokenSource cts = new();
        Console.CancelKeyPress += (_, __) =>
        {
            Console.WriteLine("Stopping...");
            cts.Cancel();
            Environment.Exit(0);
        };
        using AttackContext context = new(Map(data));
        context.SwitchServer(attack.Server, attack);
        Console.WriteLine($"Attack on host {attack.Server}");
        Console.WriteLine(new string('-', attack.Server.Length + 15));
        foreach (var item in attack.GetAttacks(context))
        {
            using var request = item.NewRequest(context.Data);
            context.AddHeaders(request);
            try
            {
                Console.WriteLine($"{request.Method.Method} /{request.RequestUri}...");
                if ((context.LastResponse = await context.Client!.SendAsync(request, cts.Token).ConfigureAwait(false)) is not null && context.CheckResponse())
                { 
                    Console.WriteLine($"Attack step failed: {context.LastResponse.StatusCode}");
                    return;
                }
            }
            catch (InvalidDataException)
            {
                context.LastResponse = null;
                Console.WriteLine("Response did not apper to be a valid Web response. (is site down?)");
                return;
            }
            catch (HttpRequestException)
            {
                context.LastResponse = null;
                Console.WriteLine("Could not execute request (Host might finally be down).");
                return;
            }
            catch (TaskCanceledException)
            {
                context.LastResponse = null;
                Console.WriteLine("Attack stopped.");
                return;
            }
            catch (Exception ex)
            {
                context.LastResponse = null;
                Console.WriteLine($"Unknown error ({ex.Message}) (is site down?).");
                return;
            }
        }
        Console.WriteLine("Phishing site is still up :(");
    }
}
