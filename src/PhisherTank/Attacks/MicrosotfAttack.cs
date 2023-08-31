using ConsoleApp1.Models;

namespace ConsoleApp1.Attacks;

internal class MicrosotfAttack : LiveBlog365AttackFamily
{
    public MicrosotfAttack() : base("resetmicrosotf.hstn.me")
    {
    }


    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return new("");
        GetCookie(context);
        context.AddReferrer();
        yield return new("?i=1");
        context.AddReferrer();
        yield return new("seguridad.php")
        {
            FormItems = f => new[]
            {
                ("uno", f.Email),
                ("dos", f.Password)
            }
        };
        context.AddReferrer();
        yield return new("seguridad-p2p.html");
        context.AddReferrer();
        yield return new("seguridad.php")
        {
            FormItems = f => new[]
            {
                ("tres", f.Otp),
                ("cuatro", f.Otp)
            }
        };
    }
}
