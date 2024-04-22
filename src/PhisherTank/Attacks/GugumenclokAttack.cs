using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class GugumenclokAttack() : Attack("gugumenclok.steelersafcshop.com")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return "";
        yield return Form("/dashboard/process", _ => [("submit", "ok")]);
        yield return Form("/data/first", GetFullData);
        yield return Form("/data/process", GetCcInfo);
        yield return Form("/data/process", GetNewCcInfo);
    }

    private static (string, string)[] GetFullData(DataBase f)
    {
        var usAddr = MiscFaker.GetUsaAddress();
        return [
            ("ssn", $"{MiscFaker.FakePin(3)}-{MiscFaker.FakePin(2)}-{MiscFaker.FakePin(4)}"),
            ("dob", f.Person.Birth.ToString("MM/dd/yyyy")),
            ("address", usAddr.AddressLine.Replace(' ', '+')),
            ("city", usAddr.City.Split(',')[0].Replace(' ', '+')),
            ("state", usAddr.City.Split(',')[1].Replace(' ', '+')),
            ("zip", usAddr.Zip.ToString()),
            ("driverlicense", MiscFaker.FakePin(9)),
            ("phnumber", $"({MiscFaker.FakePin(3)}) {MiscFaker.FakePin(3)}-{MiscFaker.FakePin(4)}"),
            ("email", f.Email),
            ("submit", "submit")            
        ];
    }
    private static (string, string)[] GetCcInfo(DataBase f)
    {
        var ccnum = f.CreditCard.Number;
        return [
            ("cname", f.Person.Name.Replace(' ', '+')),
            ("cnum", $"{ccnum[0..4]}+{ccnum[4..8]}+{ccnum[8..12]}+{ccnum[12..]}"),
            ("exp", $"{f.CreditCard.ExpMonth:00}/{f.CreditCard.Number[2..]}"),
            ("cvv", f.CreditCard.CVV),
        ];
    }

    private static (string, string)[] GetNewCcInfo(DataBase f)
    {
        var newCC = new CreditCard(f.Person);
        var ccnum = newCC.Number;
        return [
            ("cname", f.Person.Name.Replace(' ', '+')),
            ("ccn", $"{ccnum[0..4]}+{ccnum[4..8]}+{ccnum[8..12]}+{ccnum[12..]}"),
            ("exp", $"{newCC.ExpMonth:00}/{newCC.Number[2..]}"),
            ("cvv", newCC.CVV),
        ];
    }
}
