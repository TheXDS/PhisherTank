namespace ConsoleApp1.Models;

internal class Status
{
    private readonly object syncLock = new();

    public string Name { get; init; } = string.Empty;

    public int SuccessCounter { get; private set; }

    public int FailureCounter { get; private set; }

    public string? StatusDetails { get; private set; }

    public void Success() { lock (syncLock) SuccessCounter++; }

    public void Failure(string message) { lock (syncLock) FailureCounter++; StatusDetails = message; }
    
    public override string ToString() => $"Success: {SuccessCounter}, failures: {FailureCounter} (Last error: {StatusDetails ?? "none"})";
}
