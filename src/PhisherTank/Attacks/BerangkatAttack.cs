using CreditCardValidator;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;
using TheXDS.Triton.Faker;

namespace TheXDS.PhisherTank.Attacks;

internal class BerangkatAttack() : Attack("updtsecureamaznacnt.dynnamn.ru")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return "?berangkat";
        AddCookie(context);
        context.AddReferrer();
        yield return "ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20";
        context.AddReferrer();
        yield return Form("ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20", GetEmailForm);
        context.AddReferrer();
        yield return $"ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20&pass=1&email={context.Data.Email}";
        context.AddReferrer();
        yield return Form("ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20", EmailPasswordForm("emailLogin", "passwordLogin", ("create", "0")));
        context.AddReferrer();
        yield return "ap/billing?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20";
        context.Headers["Referer"] = $"ap/signin?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20&pass=1&email={context.Data.Email}";
        yield return Form("ap/payment?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20", GetAddressForm);
        context.AddReferrer();
        yield return Form("ap/update_billing?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20", GetCCardForm);
        context.AddReferrer();
        yield return "ap/payment?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20&error=1";
        context.AddReferrer();
        yield return Form("ap/update_billing?session=4d33334f9b5b4e00bc14eff39d329c427f79cc20", GetCCardForm);
    }

    private static (string, string)[] GetEmailForm(DataBase f)
    {
        return [
            ("emailLogin", f.Email),
            ("create", "0")
        ];
    }

    private static (string, string)[] GetAddressForm(DataBase f)
    {
        return [
            ("country", f.Address.Country),
            ("fullname", f.Person.Name),
            ("address", f.Address.AddressLine),
            ("city", f.Address.City),
            ("state", Person.Someone().Surname),
            ("zipcode", f.Address.Zip.ToString()),
            ("phone", $"({MiscFaker._rnd.Next(100, 999)}) {MiscFaker._rnd.Next(100, 999)}-{MiscFaker._rnd.Next(0, 9999):0000}"),
            ("dob", f.Person.Birth.ToString("dd/MM/yyyy")),
            ("sin", Person.Someone((int)(f.Person.Age + 17), 100).Name)
        ];
    }

    private static (string, string)[] GetCCardForm(DataBase f)
    {
        var issuer = new[]
        {
            CardIssuer.Visa,
        }.Pick();
        var ccard = CreditCardFactory.RandomCardNumber(issuer);
        return [
            ("ccname", f.Person.Name),
            ("ccno", ccard),
            ("exp_bulan", MiscFaker._rnd.Next(1, 13).ToString("00")),
            ("exp_tahun", MiscFaker._rnd.Next(24, 33).ToString()),
            ("cvv", MiscFaker._rnd.Next(100, 999).ToString())
        ];
    }
}
