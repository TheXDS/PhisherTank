using ConsoleApp1.Component;
using ConsoleApp1.Models;
using TheXDS.PhisherTank.Models;

namespace ConsoleApp1.Attacks;

internal class LinkPcAttack : Attack
{
    public LinkPcAttack(): base("appsingin-webserv.accesamznssmanaged.linkpc.net")
    {
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return new("");
        AddCookie(context);
        context.Headers.Add("DNT", "1");
        yield return new("sign");
        yield return new("sign/process")
        {
            FormItems = f => new[]
            {
                ("screen", MiscFaker.RandomResolution()),
                ("EML", f.Email),
                ("PWD", f.Password)
            }
        };
        yield return GetForward(context);
        context.AddReferrer();
        yield return new("activity/process");
        yield return GetForward(context);
        yield return new("oauth/process")
        {
            FormItems = f => new[]
            {
                ("email", f.Email),
                ("password", f.Password)
            }
        };
        yield return GetForward(context);
        var usAddr = MiscFaker.GetUsaAddress();
        yield return new("billing/first")
        {
            FormItems = f => new[]
            {
                ("fullname", f.Person.Name.Replace(' ', '+')),
                ("address", usAddr.AddressLine.Replace(' ', '+')),
                ("cityp", usAddr.City.Split(',')[0].Replace(' ', '+')),
                ("state", usAddr.City.Split(',')[1].Replace(' ', '+')),
                ("zip", usAddr.Zip.ToString()),
                ("phone", $"+1 ({MiscFaker.FakePin(3)}) {MiscFaker.FakePin(3)}-{MiscFaker.FakePin(4)}"),
                ("dob", f.Person.Birth.ToString("MM/dd/yyyy")),
                ("mmn", MiscFaker.GetFemale().Name)
            }
        };
        yield return new("billing/process")
        {
            FormItems = f => new[]
            {
                ("ccn", f.CreditCard.Number),
                ("expmonth", f.CreditCard.ExpMonth.ToString("00")),
                ("expyear", f.CreditCard.ExpYear.ToString()),
                ("cvv", f.CreditCard.CVV),
            }
        };
        yield return GetForward(context);
        yield return new("billing/process")
        {
            FormItems = f =>
            {
                var newCC = new CreditCard(f.Person);
                return new[]
                {
                    ("ccn1", newCC.Number),
                    ("expmonth", newCC.ExpMonth.ToString("00")),
                    ("expyear", newCC.ExpYear.ToString()),
                    ("cvv", newCC.CVV),
                };
            }
        };
        yield return GetForward(context);
        yield return new("done/logout");
    }
}