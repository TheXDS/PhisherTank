using TheXDS.PhisherTank.Component;
using TheXDS.Triton.Faker;

namespace TheXDS.PhisherTank.Models;

public class TestData : DataBase
{
    private class TestPerson() : Person("Test", "Test", Gender.Female, DateTime.Now);
    public TestData()
    {
        Person = new TestPerson();
        Email = "test@test.com";
        Password = "Test@1234";
        Otp = MiscFaker._rnd.Next(1000, 9999).ToString();
        Address = new Address("Test", "Test", "Test", "Test", (ushort)MiscFaker._rnd.Next(0, ushort.MaxValue));
        CreditCard = new(Person);
    }
}
