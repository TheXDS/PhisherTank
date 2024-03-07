namespace TheXDS.PhisherTank.Models;

[Flags]
public enum LogLevel : byte
{
    Quiet,
    Summary,
    Threads,
    Detailed
}