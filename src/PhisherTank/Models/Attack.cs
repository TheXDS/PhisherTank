using TheXDS.MCART.Helpers;

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


    protected static void AddCookie(IAttackContext context)
    {
        if (context.LastResponse is { Headers: { } h } && h.TryGetValues("Set-Cookie", out var values))
        {
            context.Headers.Add("Cookie", values.ToArray()[0].Split(';')[0]);
        }
    }

    protected static AttackItem GetForward(IAttackContext context)
    {
        if (!((int)(context.LastResponse?.StatusCode ?? 0)).IsBetween(300, 399)) throw new Exception("Invalid redirect response");
        return new(context.LastResponse!.Headers.GetValues("Location").First());
    }
}
