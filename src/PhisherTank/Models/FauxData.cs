using System.Globalization;
using ConsoleApp1.Component;
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

    public FauxData()
    {
        Person = Person.Adult();
        Email = MiscFaker.FakeEmail(Person).Replace("._", ".");
        Password = new string[]
        {
            Internet.FakeUsername(Person.Someone(0, 17)),
            Internet.FakeUsername(Person.Old()),
            Internet.FakeUsername(),
            $"{new RegionInfo(CultureInfo.GetCultures(CultureTypes.SpecificCultures).Pick().Name).EnglishName.ToLower()}{"_ . - @ # * ".Pick()}{MiscFaker._rnd.Next(0,100):00}",
            MiscFaker._rnd.RndText(MiscFaker._rnd.Next(8, 32))
        }.Pick();
        Otp = MiscFaker._rnd.Next(1000, 9999).ToString();
        Address = Address.NewAddress();
    }
}
