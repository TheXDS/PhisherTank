using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class BacDappLinePmAttack() : Attack("bac-dapp.line.pm")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return "";
        yield return "pws.php";
        yield return Form("pws.php", GetPws);
        yield return "load.html";
        yield return "token.php";

        var pin = MiscFaker.FakePin(6);
        yield return Form("token.php", GetToken(pin));
        yield return "errortoken.php";
        yield return Form("errortoken.php", GetToken(pin));
    }

    private static (string, string)[] GetPws(DataBase f)
    {
        return [
            ("usuario", f.Person.UserName),
            ("clave", f.Password),
            ("submit", "")];
    }

    private static Func<DataBase, (string, string)[]> GetToken(string pin)
    {
        return f => new (string, string)[] { ("usuario", pin), ("submit", "")};
    }
}