using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class MicrosotfAttack() : LiveBlog365AttackFamily("resetmicrosotf.hstn.me")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        //GetCookie(context);
        context.AddReferrer();
        yield return "?i=1";
        context.CheckResponse("resetmicrosotf.hstn.me");
        context.AddReferrer();
        yield return Form("seguridad.php", EmailPasswordForm("uno", "dos"));
        context.AddReferrer();
        yield return "seguridad-p2p.html";
        context.AddReferrer();
        yield return Form("seguridad.php", f => [("tres", f.Otp), ("cuatro", f.Otp)]);
    }
}
