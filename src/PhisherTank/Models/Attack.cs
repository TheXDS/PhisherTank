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

    protected static Func<DataBase, (string, string)[]> EmailPasswordForm(string emailField = "email", string passwordField = "password", params (string, string)[] extraFields)
    {
        return f => [
            (emailField, f.Email),
            (passwordField, f.Password),
            .. extraFields
        ];
    }

    protected static AttackItem GetForward(IAttackContext context)
    {
        //HACK: Patch for forwarding simulation
        if (context.Client is null) return "< Some forwarded URL >";

        if (!((int)(context.LastResponse?.StatusCode ?? 0)).IsBetween(300, 399)) throw new Exception("Invalid redirect response");
        return new(context.LastResponse!.Headers.GetValues("Location").First());
    }

    protected static FormDataAttackItem Form(string route, Func<DataBase, (string, string)[]> contentBuilder)
    {
        return new(route, contentBuilder);
    }

    protected static RawDataAttackItem Raw(string route, Func<DataBase, string> contentBuilder)
    {
        return new(route, contentBuilder);
    }
}
