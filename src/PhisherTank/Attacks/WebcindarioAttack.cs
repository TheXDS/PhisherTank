using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class WebcindarioAttack : Attack
{
    public WebcindarioAttack() : base("outlooklivehn.webcindario.com")
    {
        MiscFaker.SetDomains("hotmail.com", "hotmail.com", "outlook.com", "hotmail.es", "hotmail.com");
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        AddCookie(context);
        yield return Form("popeye.php", EmailPasswordForm("nm1", "nm2", ("namee", MiscFaker.FakePin())));
        context.CheckResponse("www.microsoft.com");
    }
}
