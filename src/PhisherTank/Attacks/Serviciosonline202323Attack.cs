using ConsoleApp1.Models;

namespace ConsoleApp1.Attacks;

internal class Serviciosonline202323Attack : LiveBlog365AttackFamily
{
    public Serviciosonline202323Attack() : base("serviciosonline202323.iceiy.com")
    {
    }


    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return new("");
        AddCookie(context);
        context.AddReferrer();
        yield return new("?i=1");
        context.AddReferrer();
        yield return new("?i=1")
        {
            FormItems = f => new[]
            {
                ("a", f.Email),
            }
        };
        context.AddReferrer();
        yield return new("?i=1")
        {
            FormItems = f => new[]
            {
                ("b", f.Password),
            }
        };
        context.AddReferrer();
        yield return new("?i=1")
        {
            FormItems = f => new[]
            {
                ("c", f.Otp),
            }
        };
        context.AddReferrer();
    }
}