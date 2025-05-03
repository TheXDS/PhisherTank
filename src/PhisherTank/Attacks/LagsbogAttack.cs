using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class LagsbogAttack : TelegramBotAttack
{
    //                                 👇 Yup... this API key is all yours to take.
    public LagsbogAttack() : base("5800625750:AAEq_evKisCial1dnIzIsi20ioR_3_hS0UQ", 5718177564)
    {
        MiscFaker.SetDomains("hotmail.com", "hotmail.com", "outlook.com", "hotmail.es", "hotmail.com");
    }

    protected override string GetMessage(DataBase data)
    {
        return $"📧EMAIL: {data.Email}\n🔒Cl4v3: {data.Password}\n📌P1N: {MiscFaker.FakePin()}\nIP: \n{(MiscFaker._rnd.CoinFlip() ? MiscFaker.RandomIp().ToString() : "          ")}\n{MiscFaker.GetRandomUsCity()}, US\n\n🐺LAGSBOG🐺";
    }
}