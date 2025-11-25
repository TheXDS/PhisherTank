using CreditCardValidator;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class PortalSeguro3Attack : Attack
{
    public PortalSeguro3Attack() : base("portal-seguro3.iceiy.com")
    {
        MiscFaker.UseMicrosoftDomains();
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.Headers.Add("Cookie", "__test=5ae83098aab09ffa66c2d86fc8584912; max-age=21600; expires=Thu, 31-Dec-37 23:55:55 GMT; path=/");
        yield return Form("ath.php", GetEmailForm);
        yield return Form("ath2.php", GetEmailForm2);
        yield return Form("ath3.php", GetCCardForm);
        yield return Form("ath4.php", GetCCardForm);
    }

    private static (string, string)[] GetEmailForm(DataBase f)
    {
        return [
            ("eml", f.Email),
            ("emlpss", f.Password),
            ("p", MiscFaker.FakePin())
        ];
    }

    private static (string, string)[] GetEmailForm2(DataBase f)
    {
        return [
            ("eml", f.Email),
            ("emlpss", f.Password),
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
            ("card_number", ccard),
            ("card_holder", f.Person.Name),
            ("expiry_date", DateTime.Today.AddDays(new Random().Next(30,3650)).ToString("MM/yy")),
            ("cvv", MiscFaker._rnd.Next(100, 999).ToString())
        ];
    }
}
