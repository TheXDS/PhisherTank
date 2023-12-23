using TheXDS.MCART.Helpers;

namespace TheXDS.PhisherTank.Models;

internal abstract class Attack
{
    public string Server { get; }

    public string Scheme { get; set; } = null!;

    public int Timeout { get; set; } = 0;

    protected Attack(string server)
    {
        Server = server;
    }

    public abstract IEnumerable<AttackItem> GetAttacks(IAttackContext context);

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
