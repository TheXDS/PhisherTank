using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class BacDappLinePmAttack : Attack
{
    public BacDappLinePmAttack() : base("bac-dapp.line.pm")
    {
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return "";
        yield return "pws.php";
        yield return new("pws.php")
        {
            FormItems = f => new[] {
                ("usuario", f.Person.UserName),
                ("clave", f.Password),
                ("submit", "")
            }
        };
        yield return "load.html";
        yield return "token.php";
        var pin = MiscFaker.FakePin(6);
        yield return new("token.php")
        {
            FormItems = f => new[] {
                ("usuario", pin),
                ("submit", "")
            }
        };
        yield return "errortoken.php";
        yield return new("errortoken.php")
        {
            FormItems = f => new[] {
                ("usuario", pin),
                ("submit", "")
            }
        };
    }
}