using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class LiveDatePmAttack : Attack
{
    public LiveDatePmAttack() : base("live-date.line.pm")
    {
        MiscFaker.SetDomains("hotmail.com", "hotmail.com", "outlook.com", "hotmail.es", "hotmail.com");
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "37/home.php";
        yield return Form("37/1.php", EmailPasswordForm());
        yield return $"37/home.php?correo={context.Data.Email}";
        context.SwitchServer("pins-date.line.pm", this);
        yield return Form("37/2.php", GetFullForm);
        context.CheckResponse("outlook.live.com");
    }

    private static (string, string)[] GetFullForm(DataBase f)
    {
        var pin = MiscFaker.FakePin();
        return [
            ("correo", f.Email),
            ("pass", string.Empty),
            ("pass2", string.Empty),
            ("pin1", pin),
            ("pin2", pin)
        ];
    }
}
