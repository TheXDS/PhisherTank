using ConsoleApp1.Component;
using ConsoleApp1.Models;

namespace ConsoleApp1.Attacks;

internal class WebcindarioAttack : Attack
{
    public WebcindarioAttack() : base("outlooklivehn.webcindario.com")
    {
    }
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return new("");
        yield return new("popeye.php")
        {
            FormItems = f => new[]
            {
                ("nm1", f.Email),
                ("nm2", f.Password),
                ("namee", MiscFaker.FakePin())
            }
        };
    }
}
