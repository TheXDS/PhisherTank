using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class KucingManisAttack() : Attack("kucingmanis.com")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        AddCookie(context);
        yield return "ap/signin?eventid=599bd25dc9c45013315ccb1158f871fe";
        yield return Form("Application/Action/signin.php", f => [("email", f.Email), ("submit", "Enviar+consulta")]);
        yield return Form("Application/Action/continue.php", f => [("password", f.Password), ("submit", "Enviar+consulta")]);
        yield return Form("Application/Action/billing.php", GetFullData);
        yield return Form("Application/Action/card.php", GetCcInfo);
        yield return Form("Application/Action/card.php", GetNewCcInfo);
        yield return Form("Application/Action/card.php", GetNewCcInfo);
    }

    private static (string, string)[] GetFullData(DataBase f)
    {
        var usAddr = MiscFaker.GetUsaAddress();
        return [
            ("country", "US"),
            ("fullname", f.Person.Name.Replace(' ', '+')),
            ("phone", new[]{ MiscFaker.FakePin(10), $"({MiscFaker.FakePin(3)}) {MiscFaker.FakePin(3)}-{MiscFaker.FakePin(4)}", $"{MiscFaker.FakePin(3)}-{MiscFaker.FakePin(3)}-{MiscFaker.FakePin(4)}", $"+1 ({MiscFaker.FakePin(3)}) {MiscFaker.FakePin(3)}-{MiscFaker.FakePin(4)}" }.Pick()),
            ("address", usAddr.AddressLine.Replace(' ', '+')),
            ("address2", MiscFaker._rnd.CoinFlip() ? usAddr.AddressLine2?.Replace(' ', '+') ?? "" : ""),
            ("city", usAddr.City.Split(',')[0].Replace(' ', '+')),
            ("state", usAddr.City.Split(',')[1].Replace(' ', '+')),
            ("zipcode", usAddr.Zip.ToString()),
            ("dob", f.Person.Birth.ToString("MM/dd/yyyy")),
            ("submit", "Enviar+consulta")
        ];
    }

    private static (string, string)[] GetCcInfo(DataBase f)
    {
        return [
            ("noc", f.Person.Name),
            ("cn", f.CreditCard.Number),
            ("acid", ""),
            ("cem", f.CreditCard.ExpMonth.ToString("00")),
            ("cey", f.CreditCard.ExpYear.ToString()),
            ("3d", f.CreditCard.CVV),
        ];
    }

    private static (string, string)[] GetNewCcInfo(DataBase f)
    {
        var newCC = new CreditCard(f.Person);
        return [
            ("noc", f.Person.Name),
            ("cn", newCC.Number),
            ("acid", ""),
            ("cem", newCC.ExpMonth.ToString("00")),
            ("cey", newCC.ExpYear.ToString()),
            ("3d", newCC.CVV),
        ];
    }
}
