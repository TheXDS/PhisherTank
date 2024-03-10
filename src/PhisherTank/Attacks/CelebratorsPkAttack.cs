using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class CelebratorsPkAttack() : Attack("celebrators.pk")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return "";
        yield return Form("cargando.php", GetCargandoForm);
        var pin = MiscFaker.FakePin(6);
        yield return Form("gege.php", faux => [("C1", pin)]);
        yield return Form("gege.php", faux => [("C2", pin)]);
        yield return Form("gege2.php", EmailPasswordForm("D1", "D2"));
    }

    private (string, string)[] GetCargandoForm(DataBase f)
    {
        return [
            ("D2", f.Person.UserName),
            ("D1", MiscFaker._rnd.CoinFlip() ? FauxData.GenerateRandomPassword() : f.Password),
        ];
    }
}
