using System.CommandLine;
using TheXDS.PhisherTank.Commands;

namespace TheXDS.PhisherTank;

internal static class Program
{
    private static Task<int> Main(string[] args)
    {
        var rootCmd = new RootCommand("PhisherTank - Phishing site flood and faux-data generator.");
        foreach (var j in PhisherCommand.GetCommands())
        {
            rootCmd.AddCommand(j);
        }
        return rootCmd.InvokeAsync(args);
    }
}