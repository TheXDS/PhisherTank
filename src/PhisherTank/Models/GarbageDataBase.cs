using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.Triton.Faker;
using static TheXDS.MCART.Types.Extensions.RandomExtensions;

namespace TheXDS.PhisherTank.Models;

public abstract class GarbageDataBase : DataBase
{
    private class GarbagePerson(int size) : Person(GetTrash(size), GetTrash(size), MiscFaker._rnd.CoinFlip() ? Gender.Male : Gender.Female, MiscFaker.RandomDateTime());

    private static string GetTrash(int count)
    {
        return new string(Enumerable.Range(0, count).Select(_ => (char)MiscFaker._rnd.Next(char.MinValue, 0x10000)).ToArray());
    }

    public GarbageDataBase(int size)
    {
        Person = new GarbagePerson(size);
        Email = GetTrashEmail(size);
        Password = GetTrash(size);
        Otp = MiscFaker._rnd.Next(1000, 9999).ToString();
        Address = new Address(GetTrash(size), GetTrash(size), GetTrash(size), GetTrash(size), (ushort)MiscFaker._rnd.Next(0, ushort.MaxValue));
        CreditCard = new(Person);
    }

    private static string GetTrashEmail(int size)
    {
        static byte[] Get(int size) => Enumerable.Range(0, size).Select(_ => (byte)MiscFaker._rnd.Next(0, 0x100)).ToArray();
        var u = Get((size / 2) - 2);
        var p = Get((size / 2) - 3);
        return $"{Convert.ToBase64String(u)}@{Convert.ToBase64String(p)}.com";
    }
}
