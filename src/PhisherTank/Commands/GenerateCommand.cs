using System.CommandLine;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheXDS.PhisherTank.Models;
using TheXDS.Triton.Faker;

namespace TheXDS.PhisherTank.Commands;

internal class GenerateCommand : PhisherCommand
{
    public override Command GetCommand()
    {
        var generateCmd = new Command("generate", "Generates a set of data entries that can be sent to an attacker.");
        var countArg = new Argument<int>("count", () => 1, "Number of entries to generate.");
        var attackDataOption = (Option<AttackData>)CommonOptions["data"];
        generateCmd.AddArgument(countArg);
        generateCmd.AddOption(attackDataOption);
        generateCmd.SetHandler(GenerateCommandHandler, countArg, attackDataOption);
        return generateCmd;
    }

    private static void GenerateCommandHandler(int count, AttackData attackData)
    {
        var o = new JsonSerializerOptions() { WriteIndented = true, Converters = { new JsonStringEnumConverter<Gender>() } };
        Console.WriteLine($"[{string.Join($",{Environment.NewLine}", [.. ToJson(count, attackData, o)])}]");
    }

    private static IEnumerable<string> ToJson(int count, AttackData attackData, JsonSerializerOptions o)
    {
        while (count-- > 0)
        {
            yield return JsonSerializer.Serialize(Map(attackData), o);
        }
    }
}
