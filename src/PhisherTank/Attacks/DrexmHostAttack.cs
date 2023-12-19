using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;
using TheXDS.Triton.Faker;

namespace TheXDS.PhisherTank.Attacks;

internal class DrexmHostAttack : Attack
{
    public DrexmHostAttack() : base("drexmhost.best")
    {
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return new("");
        yield return new("cargando.php")
        {
            FormItems = f => new[] {
                ("D1", Internet.FakeUsername(f.Person)),
                ("D2", FauxData.GenerateRandomPassword())
            }
        };
        AddCookie(context);
        var smsPin = MiscFaker.FakePin(8);
        yield return new("gege.php") { FormItems = f => new[] { ("C1", smsPin) } };
        yield return new("gege.php") { FormItems = f => new[] { ("C2", smsPin) } };
        yield return new("gege2.php")
        {
            FormItems = f => new[] {
                ("D1", f.Email),
                ("D2", f.Password)
            }
        };
    }
}
