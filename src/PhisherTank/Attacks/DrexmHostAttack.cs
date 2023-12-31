using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;
using TheXDS.Triton.Faker;

namespace TheXDS.PhisherTank.Attacks;

internal class DrexmHostAttack() : Attack("drexmhost.best")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        yield return Form("cargando.php", Get1);
        AddCookie(context);
        var smsPin = MiscFaker.FakePin(8);
        yield return Form("gege.php", f => new[] { ("C1", smsPin) } );
        yield return Form("gege.php", f => new[] { ("C2", smsPin) } );
        yield return Form("gege2.php", EmailPasswordForm("D1", "D2"));
    }

    private static (string, string)[] Get1(DataBase f)
    {
        return [
            ("D1", Internet.FakeUsername(f.Person)),
            ("D2", FauxData.GenerateRandomPassword())
        ];
    }
}
