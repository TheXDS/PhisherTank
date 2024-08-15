using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class Sacrix32Attack : TelegramBotAttack
{
    //                                👇 Yup... this API key is all yours to take.
    public Sacrix32Attack() : base("6731765097:AAF9qffFkAvAfmAFg3IdAFlcfNAMFW_PdH8", 5638165853)
    {
        MiscFaker.UseMicrosoftDomains();
    }

    protected override string GetMessage(DataBase data)
    {
        return $"""
        📧EMAIL: {data.Email}
        🔒Cl4v3: {data.Password}
        📌P1N: {MiscFaker.FakePin()}
        IP: {(MiscFaker._rnd.CoinFlip() ? MiscFaker.RandomIp() : null)}




        🐺Sacrix32🐺
        """;
    }
}