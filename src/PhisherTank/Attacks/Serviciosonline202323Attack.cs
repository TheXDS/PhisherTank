using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class Serviciosonline202323Attack() : LiveBlog365AttackFamily("serviciosonline202323.iceiy.com")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        GetCookie(context);
        context.AddReferrer();
        yield return "?i=1";
        context.AddReferrer();
        yield return Form("?i=1", f => [("a", f.Email)]);
        context.AddReferrer();
        yield return Form("?i=1", f => [("b", f.Password)]);
        context.AddReferrer();
        yield return Form("?i=1", f => [("c", f.Otp)]);
    }
}