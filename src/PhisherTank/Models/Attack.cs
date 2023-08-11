namespace ConsoleApp1.Models;

internal abstract class Attack
{
    public string Server { get; } = string.Empty;

    public string Scheme { get; init; } = "http";

    protected Attack(string server)
    {
        Server = server;
    }

    public abstract IEnumerable<AttackItem> GetAttacks(IAttackContext context);
    
    public HttpClient CreateClient()
    {
        return new HttpClient()
        {
            BaseAddress = new Uri($"{Scheme}://{Server}/"),
            Timeout = TimeSpan.FromSeconds(5)
        };
    }
}
