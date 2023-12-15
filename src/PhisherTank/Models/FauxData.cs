using System.Globalization;
using ConsoleApp1.Component;
using CreditCardValidator;
using TheXDS.MCART.Types.Extensions;
using TheXDS.Triton.Faker;
using static TheXDS.MCART.Types.Extensions.RandomExtensions;

namespace ConsoleApp1.Models;

internal class FauxData
{
    public Person Person { get; }
    public string Email { get; }
    public string Password { get; }
    public string Otp { get; }
    public Address Address { get; }
    public CreditCard CreditCard { get; }
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
        return new string[]
        {
            Internet.FakeUsername(Person.Someone(0, 17)),
            Internet.FakeUsername(Person.Old()),
            Internet.FakeUsername(),
            $"{new RegionInfo(CultureInfo.GetCultures(CultureTypes.SpecificCultures).Pick().Name).EnglishName.ToLower()}{"_ . - @ # * ".Pick()}{MiscFaker._rnd.Next(0, 100):00}",
            MiscFaker._rnd.RndText(MiscFaker._rnd.Next(8, 32))
        }.Pick();
    }
}
internal class CreditCard
{
    public string Number { get; }
    public string Name { get; }
    public byte ExpMonth { get; }
    public short ExpYear { get; }
    public string CVV { get; }

    public CreditCard(Person owner, byte cvvLen = 3)
    {
        var issuer = new[]
{
            CardIssuer.Visa,
        }.Pick();
        Number = CreditCardFactory.RandomCardNumber(issuer);
        Name = owner.Name;
        ExpMonth = (byte)MiscFaker._rnd.Next(1, 13);
        ExpYear = (short)MiscFaker._rnd.Next(DateTime.Today.Year + 1, DateTime.Today.Year + 10);
        CVV = MiscFaker._rnd.Next((int)Math.Pow(10, cvvLen - 1), int.Parse(new string('9', cvvLen))).ToString();
    }
}