using System.CommandLine;

namespace TheXDS.PhisherTank.Commands;

internal class ListCommand : PhisherCommand
{
    public override Command GetCommand()
    {
        var listCmd = new Command("list", "Lists all the available built-in attacks.");
        listCmd.AddAlias("ls");
        listCmd.SetHandler(ListCommandHandler);
        return listCmd;
    }

    private static void ListCommandHandler()
    {
        foreach (var j in KnownAttacks) Console.WriteLine(j.Key);
    }
}
