using System.Globalization;
using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.Triton.Faker;
using static TheXDS.MCART.Types.Extensions.RandomExtensions;

namespace TheXDS.PhisherTank.Models;

public class FauxData : DataBase
{
    public FauxData()
    {
        Person = Person.Adult();
        Email = MiscFaker.FakeEmail(Person).Replace("._", ".");
        Password = GenerateRandomPassword();
        Otp = MiscFaker._rnd.Next(1000, 9999).ToString();
        Address = Address.NewAddress();
        CreditCard = new(Person);
    }

    public static string GenerateRandomPassword()
    {
        var p = new string[]
        {
            Internet.FakeUsername(Person.Someone(0, 17)),
            Internet.FakeUsername(Person.Old()),
            Internet.FakeUsername(),
            $"{new RegionInfo(CultureInfo.GetCultures(CultureTypes.SpecificCultures).Pick().Name).EnglishName.ToLower()}{"_.-@#*".Pick()}{MiscFaker._rnd.Next(0, 100):00}",
            MiscFaker._rnd.RndText(MiscFaker._rnd.Next(8, 32))
        }.Pick().Replace(" ", "_");
        if (MiscFaker._rnd.CoinFlip())
        {
            var t = MiscFaker._rnd.Next(1, 4);
            var c = p.ToCharArray();
            while (t-- > 0)
            {
                var i = MiscFaker._rnd.Next(1, p.Length - 1);
                c[i] = char.ToUpper(c[i]);
            }
            p = new string(c);
        }
        return p[0].ToString().ToUpperInvariant() + p[1..];
    }
}
