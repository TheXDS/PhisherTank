using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks.Base;

internal abstract class HotSerguAttackFamily : Attack
{
    public HotSerguAttackFamily(string subdomain) : base($"{subdomain}.webcindario.com")
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
