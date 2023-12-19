using TheXDS.Triton.Faker;

namespace TheXDS.PhisherTank.Models;

public abstract class DataBase
{
    public Person Person { get; protected init; } = null!;
    public string Email { get; protected init; } = null!;
    public string Password { get; protected init; } = null!;
    public string Otp { get; protected init; } = null!;
    public Address Address { get; protected init; } = null!;
    public CreditCard CreditCard { get; protected init; } = null!;
}
