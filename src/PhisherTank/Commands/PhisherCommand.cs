using System.CommandLine;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Models;
using static TheXDS.MCART.Helpers.ReflectionHelpers;

namespace TheXDS.PhisherTank.Commands;

internal abstract class PhisherCommand
{
    public static IEnumerable<Command> GetCommands()
    {
        return GetTypes<PhisherCommand>(true)
            .Select(TypeExtensions.New<PhisherCommand>)
            .Select(p => p.GetCommand());
    }

    protected static Option<T> GetOption<T>(string name)
    {
        return (Option<T>)CommonOptions[name];
    }
    protected static Argument<T> GetArgument<T>(string name)
    {
        return (Argument<T>)CommonArguments[name];
    }

    protected static Dictionary<string, Argument> CommonArguments { get; } = [];

    protected static Dictionary<string, Option> CommonOptions { get; } = [];

    protected static Dictionary<string, Type> KnownAttacks { get; } = new(GetTypes<Attack>(true).Select(p => new KeyValuePair<string, Type>(p.Name.ChopEnd("Attack"), p)));

    static PhisherCommand()
    {
        CommonArguments.Add("attackName", new Argument<string>("attackName").FromAmong([.. KnownAttacks.Keys]));
        CommonOptions.Add("data", new Option<AttackData>(["--attack-data", "-d"], () => AttackData.Faux, "Specifies the kind of data to send."));
        CommonOptions.Add("https", new Option<bool>(["--https", "-s"], "Indicates that the attack must be executed using HTTPS requests."));
        CommonOptions.Add("timeout", new Option<int>(["--timeout", "-t"], () => 30, "Specifies the desired timeout for all requests, in seconds."));
    }

    public abstract Command GetCommand();

    protected static DataBase Map(AttackData data)
    {
        return data switch
        {
            AttackData.Faux => new FauxData(),
            AttackData.Garbage => new GarbageData(),
            AttackData.Truckload => new TruckloadData(),
            AttackData.Test => new TestData(),
            AttackData.UsFaux => new UsFauxData(),
            _ => throw new NotImplementedException(),
        };
    }
}
