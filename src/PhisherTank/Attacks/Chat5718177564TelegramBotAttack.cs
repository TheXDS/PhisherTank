using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;
using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.MCART.Types.Extensions;

namespace TheXDS.PhisherTank.Attacks;

internal class Chat5718177564TelegramBotAttack : TelegramBotAttack
{
    private readonly string asshole;

    //                                                              👇 Yup... this API key is all yours to take.
    public Chat5718177564TelegramBotAttack(string asshole) : base("5800625750:AAEq_evKisCial1dnIzIsi20ioR_3_hS0UQ", 5718177564)
    {
        MiscFaker.UseMicrosoftDomains();
        this.asshole = asshole;
    }

    protected override string GetMessage(DataBase data)
    {
        return $"📧EMAIL: {data.Email}\n🔒Cl4v3: {data.Password}\n📌P1N: {MiscFaker.FakePin()}\nIP: {(MiscFaker._rnd.CoinFlip() ? MiscFaker.RandomIp(): null)}\n \n\n \n\n🐺{asshole}🐺";
    }
}
