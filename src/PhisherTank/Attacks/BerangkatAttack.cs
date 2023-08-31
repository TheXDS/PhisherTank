using ConsoleApp1.Component;
using ConsoleApp1.Models;
using CreditCardValidator;
using TheXDS.MCART.Types.Extensions;
using TheXDS.Triton.Faker;

namespace ConsoleApp1.Attacks;

internal class BerangkatAttack : Attack
{
    public BerangkatAttack() : base("updtsecureamaznacnt.dynnamn.ru")
    {
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return new("?berangkat");
        AddCookie(context);
        context.AddReferrer();
        yield return new("ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20");
        context.AddReferrer();
        yield return new("ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20")
        {
            FormItems = f => new[] {
                ("emailLogin", f.Email),
                ("create", "0")
            }
        };
        context.AddReferrer();
        yield return new($"ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20&pass=1&email={context.FauxData.Email}");
        context.AddReferrer();
        yield return new("ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20")
        {
            FormItems = f => new[] {
                ("create", "0"),
                ("emailLogin", f.Email),
                ("passwordLogin", f.Password)
            }
        };
        context.AddReferrer();
        yield return new("ap/billing?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20");
        context.Headers["Referer"] = $"ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20&pass=1&email={context.FauxData.Email}";
        yield return new("ap/payment?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20")
        {
            FormItems = f => new[] {
                ("country", f.Address.Country),
                ("fullname", f.Person.Name),
                ("address", f.Address.AddressLine),
                ("city", f.Address.City),
                ("state", Person.Someone().Surname),
                ("zipcode", f.Address.Zip.ToString()),
                ("phone", $"({MiscFaker._rnd.Next(100,999)}) {MiscFaker._rnd.Next(100, 999)}-{MiscFaker._rnd.Next(0, 9999):0000}"),
                ("dob", f.Person.Birth.ToString("dd/MM/yyyy")),
                ("sin", Person.Someone((int)(f.Person.Age + 17), 100).Name)
            },
        };
        context.AddReferrer();
        yield return new("ap/update_billing?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20")
        {
            FormItems = GetCCardForm
        };
        context.AddReferrer();
        yield return new("ap/payment?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20&error=1");
        context.AddReferrer();
        yield return new("ap/update_billing?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20")
        {
            FormItems = GetCCardForm
        };
    }

    private static IEnumerable<(string key, string value)> GetCCardForm(FauxData f)
    {
        var issuer = new[]
        {
            CardIssuer.Visa,
        }.Pick();
        var ccard = CreditCardFactory.RandomCardNumber(issuer);
        return new[] {
            ("ccname", f.Person.Name),
            ("ccno", ccard),
            ("exp_bulan", MiscFaker._rnd.Next(1,13).ToString("00")),
            ("exp_tahun", MiscFaker._rnd.Next(24, 33).ToString()),
            ("cvv", MiscFaker._rnd.Next(100, 999).ToString())
        };
    }
}
