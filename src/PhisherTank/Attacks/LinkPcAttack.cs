using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class LinkPcAttack() : Attack("appsingin-webserv.accesamznssmanaged.linkpc.net")
{
    private static (string, string)[] GetFullData(DataBase f)
    {
        var usAddr = MiscFaker.GetUsaAddress();
        return [
            ("fullname", f.Person.Name.Replace(' ', '+')),
            ("address", usAddr.AddressLine.Replace(' ', '+')),
            ("cityp", usAddr.City.Split(',')[0].Replace(' ', '+')),
            ("state", usAddr.City.Split(',')[1].Replace(' ', '+')),
            ("zip", usAddr.Zip.ToString()),
            ("phone", $"+1 ({MiscFaker.FakePin(3)}) {MiscFaker.FakePin(3)}-{MiscFaker.FakePin(4)}"),
            ("dob", f.Person.Birth.ToString("MM/dd/yyyy")),
            ("mmn", MiscFaker.GetFemale().Name)
        ];
    }

    private static (string, string)[] GetCcInfo(DataBase f)
    {
        return [
            ("ccn", f.CreditCard.Number),
            ("expmonth", f.CreditCard.ExpMonth.ToString("00")),
            ("expyear", f.CreditCard.ExpYear.ToString()),
            ("cvv", f.CreditCard.CVV),
        ];
    }

    private static (string, string)[] GetNewCcInfo(DataBase f)
    {
        var newCC = new CreditCard(f.Person);
        return [
            ("ccn1", newCC.Number),
            ("expmonth", newCC.ExpMonth.ToString("00")),
            ("expyear", newCC.ExpYear.ToString()),
            ("cvv", newCC.CVV),
        ];

    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return "";
        AddCookie(context);
        yield return "sign";
        yield return Form("sign/process", EmailPasswordForm("EML", "PWD", ("screen", MiscFaker.RandomResolution())));
        yield return GetForward(context);
        context.AddReferrer();
        yield return "activity/process";
        yield return GetForward(context);
        yield return Form("oauth/process", EmailPasswordForm("email", "password"));
        yield return GetForward(context);
        yield return Form("billing/first", GetFullData);
        yield return Form("billing/process", GetCcInfo);
        yield return GetForward(context);
        yield return Form("billing/process", GetNewCcInfo);
        yield return GetForward(context);
        yield return "done/logout";
    }
}