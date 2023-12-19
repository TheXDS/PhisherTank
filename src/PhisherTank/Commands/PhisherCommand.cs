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

    protected static Dictionary<string, Argument> CommonArguments { get; } = [];

    protected static Dictionary<string, Option> CommonOptions { get; } = [];

    protected static Dictionary<string, Type> KnownAttacks { get; } = new(GetTypes<Attack>(true).Select(p => new KeyValuePair<string, Type>(p.Name.ChopEnd("Attack"), p)));

    static PhisherCommand()
    {
        CommonArguments.Add("attackName", new Argument<string>("attackName").FromAmong([.. KnownAttacks.Keys]));
        CommonOptions.Add("data", new Option<AttackData>(["--attack-data", "-d"], () => AttackData.Faux, "Specifies the kind of data to send."));
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
