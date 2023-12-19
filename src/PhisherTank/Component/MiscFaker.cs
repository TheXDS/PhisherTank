using System.Reflection;
using System.Runtime.InteropServices;
using System;
using System.Text;
using TheXDS.MCART.Math;
using TheXDS.MCART.Types.Extensions;
using TheXDS.Triton.Faker;
using static TheXDS.MCART.Types.Extensions.RandomExtensions;
using ConsoleApp1.Models;
using CreditCardValidator;

namespace ConsoleApp1.Component;

internal class MiscFaker
{
    public static readonly Random _rnd = new();
    private static string[]? fakeDomains;
    private static string[]? resolutions;
    private static Dictionary<string, string[]>? usRegions;

    public static void SetDomains(params string[] domains)
    {
        fakeDomains = domains;
    }

    private static string[] LoadDomains()
    {
        return ["hotmail.com", "hotmail.com", "live.com", "hotmail.com", "hotmail.com", "hotmail.es", "hotmail.com", "gmail.com", "gmail.com", "gmail.com", "gmail.com", "hotmail.com", "outlook.com", "yahoo.com", "yahoo.com", "yahoo.com", "gmail.com", "yahoo.es",];
    }
    private static Dictionary<string, string[]> LoadUsRegions()
    {
        return new()
        {
            {"Alabama", new[] { "Birmingham", "Montgomery", "Mobile", "Huntsville", "Tuscaloosa" } },
            {"Alaska", new[] { "Anchorage", "Fairbanks", "Juneau", "Sitka", "Ketchikan" } },
            {"Arizona", new[] { "Phoenix", "Tucson", "Mesa", "Chandler", "Scottsdale" } },
            {"Arkansas", new[] { "Little Rock", "Fort Smith", "Fayetteville", "Springdale", "Jonesboro" } },
            {"California", new[] { "Los Angeles", "San Diego", "San Jose", "San Francisco", "Fresno" } },
            {"North Carolina", new[] { "Charlotte", "Raleigh", "Greensboro", "Durham", "Winston-Salem" } },
            {"South Carolina", new[] { "Columbia", "Charleston", "North Charleston", "Greenville", "Rock Hill" } },
            {"Colorado", new[] { "Denver", "Colorado Springs", "Aurora", "Fort Collins", "Lakewood" } },
            {"Connecticut", new[] { "Bridgeport", "New Haven", "Stamford", "Hartford", "Waterbury" } },
            {"North Dakota", new[] { "Fargo", "Bismarck", "Grand Forks", "Minot", "West Fargo" } },
            {"South Dakota", new[] { "Sioux Falls", "Rapid City", "Aberdeen", "Brookings", "Watertown" } },
            {"Delaware", new[] { "Wilmington", "Dover", "Newark", "Middletown", "Smyrna" } },
            {"Florida", new[] { "Jacksonville", "Miami", "Tampa", "Orlando", "St. Petersburg" } },
            {"Georgia", new[] { "Atlanta", "Augusta", "Columbus", "Savannah", "Athens" } },
            {"Hawaii", new[] { "Honolulu", "Pearl City", "Hilo", "Kailua", "Waipahu" } },
            {"Idaho", new[] { "Boise", "Meridian", "Nampa", "Idaho Falls", "Pocatello" } },
            {"Illinois", new[] { "Chicago", "Aurora", "Rockford", "Joliet", "Naperville" } },
            {"Indiana", new[] { "Indianapolis", "Fort Wayne", "Evansville", "South Bend", "Carmel" } },
            {"Iowa", new[] { "Des Moines", "Cedar Rapids", "Davenport", "Sioux City", "Iowa City" } },
            {"Kansas", new[] { "Wichita", "Overland Park", "Kansas City", "Topeka", "Olathe" } },
            {"Kentucky", new[] { "Louisville", "Lexington", "Bowling Green", "Owensboro", "Covington" } },
            {"Louisiana", new[] { "New Orleans", "Baton Rouge", "Shreveport", "Lafayette", "Lake Charles" } },
            {"Maine", new[] { "Portland", "Lewiston", "Bangor", "South Portland", "Auburn" } },
            {"Maryland", new[] { "Baltimore", "Frederick", "Rockville", "Gaithersburg", "Bowie" } },
            {"Massachusetts", new[] { "Boston", "Worcester", "Springfield", "Cambridge", "Lowell" } },
            {"Michigan", new[] { "Detroit", "Grand Rapids", "Warren", "Sterling Heights", "Lansing" } },
            {"Minnesota", new[] { "Minneapolis", "Saint Paul", "Rochester", "Duluth", "Bloomington" } },
            {"Mississippi", new[] { "Jackson", "Gulfport", "Southaven", "Hattiesburg", "Biloxi" } },
            {"Missouri", new[] { "Kansas City", "Saint Louis", "Springfield", "Independence", "Columbia" } },
        };
    }

    public static Person GetFemale()
    {
        Person retVal;
        do
        {
            retVal = Person.Adult();
        } while (retVal.Gender != Gender.Female);
        return retVal;
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

    public static string RandomResolution()
    {
        return  _rnd.CoinFlip()
            ? (resolutions ??=
            [
                "1024+x+768", "1280+x+720", "1280+x+800", "1152+x+864", "1366+x+768", "1280+x+960", "1440+x+960", "1680+x+1050", "1600+x+1200",
                "1920+x+1080", "1920+x+1080", "1920+x+1080", "1920+x+1080",
                "1920+x+1200", "1920+x+1200", "1920+x+1200",
                "2560+x+1440",
                "2560+x+1600",
                "3840+x+2160",
            ]).Pick()
            : "1920+x+1080";
    }

    public static string FakeEmail(Person? person)
    {
        return $"{FakeUsername(person)}@{(fakeDomains ??= LoadDomains()).Pick()}";
    }

    public static Address GetUsaAddress(bool allowUsWriteVariance = true, bool defaultToLongName = false)
    {
        var baseAddress = Address.NewAddress();
        var state = (usRegions ??= LoadUsRegions()).Keys.Pick();
        var city = usRegions[state].Pick();
        return new Address(baseAddress.AddressLine, baseAddress.AddressLine2, $"{city}, {state}", $"United States{((allowUsWriteVariance && _rnd.CoinFlip()) || defaultToLongName ? " of America" : "")}", ushort.Parse(FakePin(5)));
    }

    public static DateTime RandomDateTime()
    {
        return DateTime.FromBinary(_rnd.NextInt64(DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks));
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
