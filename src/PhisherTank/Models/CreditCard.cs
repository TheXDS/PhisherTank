using ConsoleApp1.Component;
using CreditCardValidator;
using TheXDS.MCART.Types.Extensions;
using TheXDS.Triton.Faker;

namespace ConsoleApp1.Models;

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