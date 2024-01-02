﻿using System.CommandLine;
using System.Net;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Commands;

internal class AttackCommand : PhisherCommand
{
    private record struct SpecialFailureCase(int Delay, string Message);

    private static volatile bool keepRunning = true;

    private static readonly Dictionary<HttpStatusCode, SpecialFailureCase> specialFailureCases = new()
    {
        {HttpStatusCode.TooManyRequests, new (1800000, $"Too many request. Ratelimiting by 1800 seconds.")}
    };

    public override Command GetCommand()
    {
        var attackNameArg = GetArgument<string>("attackName");
        var attackDataOption = GetOption<AttackData>("data");
        var timeoutOption = GetOption<int>("timeout");
        var threadsOption = new Option<int>(["--threads", "-T"], () => Environment.ProcessorCount, "Specifies the number of attack threads to generate. Defualts to the number of available CPUs on the system.");
        var httpsOption = GetOption<bool>("https");
        var attackCmd = new Command("attack", "Initiates a flooding attack.");
        attackCmd.AddArgument(attackNameArg);
        attackCmd.AddOption(timeoutOption);
        attackCmd.AddOption(threadsOption);
        attackCmd.AddOption(httpsOption);
        attackCmd.AddOption(attackDataOption);
        attackCmd.SetHandler(AttackCommandHandler, attackNameArg, timeoutOption, threadsOption, httpsOption, attackDataOption);
        return attackCmd;
    }

    private static Task AttackCommandHandler(string attackName, int timeout, int threads, bool https, AttackData attackData)
    {
        if (!KnownAttacks.TryGetValue(attackName, out var attackType) || attackType.New<Attack>() is not { } attack)
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
        context.SwitchServer(attack.Server, attack);
        foreach (var item in attack.GetAttacks(context))
        {
            using var request = item.NewRequest(context.Data);
            context.AddHeaders(request);
            context.LastResponse = await context.Client!.SendAsync(request, cancellationToken).ConfigureAwait(false);
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
        else if (context.LastResponse?.StatusCode is { } c && specialFailureCases.TryGetValue(c, out var specialCase))
        {
            counter.Failure(specialCase.Message);
            Thread.Sleep(specialCase.Delay);
        }
        else
        {
            counter.Failure($"{context.LastResponse?.ReasonPhrase ?? context.LastResponse?.StatusCode.ToString() ?? "Invalid attack"} on {context.LastResponse?.RequestMessage?.RequestUri?.ToString() ?? "<Unknown>"}");
            Thread.Sleep(2000);
        }
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
}