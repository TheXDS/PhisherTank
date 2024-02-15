using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class PantheonSiteAttack : Attack
{
    public PantheonSiteAttack() : base("dev-msn365online.pantheonsite.io")
    {
        MiscFaker.SetDomains("hotmail.com", "hotmail.com", "outlook.com", "hotmail.es", "hotmail.com", "live.com");
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        yield return Form("1.php", EmailPasswordForm("a7fxs1","a7fxs2", ("a7fxs4", "")));
    }
}