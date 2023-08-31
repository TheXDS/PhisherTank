using System.Text;
using TheXDS.MCART.Types.Extensions;
using TheXDS.Triton.Faker;
using static TheXDS.MCART.Types.Extensions.RandomExtensions;

namespace ConsoleApp1.Component;

internal class MiscFaker
{
    public static readonly Random _rnd = new();
    private static string[]? fakeDomains;

    private static string[] LoadDomains()
    {
        return new[] { "hotmail.com", "hotmail.com", "live.com", "hotmail.com", "hotmail.com", "hotmail.es", "hotmail.com", "gmail.com", "gmail.com", "gmail.com", "gmail.com", "hotmail.com", "outlook.com", "yahoo.com", "yahoo.com", "yahoo.com", "gmail.com", "yahoo.es", };
    }

    public static string FakeUsername(Person? person)
    {
        person ??= Person.Someone();
        var sb = new StringBuilder();
        var rounds = _rnd.Next(1, 4);
        sb.Append(new[] { person.Surname, person.FirstName, Text.Lorem(1) }.Pick());
        do
        {
            if (_rnd.CoinFlip()) sb.Append('_');
            sb.Append(new[] { Text.Lorem(1), person.Birth.Year.ToString(), person.Birth.Year.ToString()[2..], _rnd.Next(0, 1000).ToString().PadLeft(_rnd.Next(1, 4), '0') }.Pick());
        } while (--rounds > 0);
        return sb.ToString().ToLower();
    }

    public static string FakeEmail(Person? person)
    {
        return $"{FakeUsername(person)}@{(fakeDomains ??= LoadDomains()).Pick()}";
    }

    public static string FakePin(int length = 4)
    {
        var sb = new StringBuilder();
        sb.Append(_rnd.Next(1, 10));
        while (length > 1)
        {
            sb.Append(_rnd.Next(0, 10));
            length--;
        }
        return sb.ToString();
    }
}
