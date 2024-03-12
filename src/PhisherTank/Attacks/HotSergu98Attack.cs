using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class HotSergu99Attack : Attack
{
    public HotSergu99Attack() : base("hotsergu99.webcindario.com")
    {
        MiscFaker.UseMicrosoftDomains();
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        AddCookie(context);
        yield return Form("casillero.php", EmailPasswordForm("tlVVJNECrWGtadX", "mxLRLDLOWkkKsDR", ("texecAGnXtKJrMd", "Siguiente")));
        context.CheckResponse("outlook.live.com");
    }
}