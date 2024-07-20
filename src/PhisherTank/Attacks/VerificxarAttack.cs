using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;
using TheXDS.PhisherTank.Attacks.Base;

namespace TheXDS.PhisherTank.Attacks;

internal class VerificxarAttack : TelegramBotAttack
{
    //                                👇 Yup... this API key is all yours to take.
    public VerificxarAttack() : base("5800625750:AAEq_evKisCial1dnIzIsi20ioR_3_hS0UQ", 5718177564)
    {
        MiscFaker.UseMicrosoftDomains();
    }

    protected override string GetMessage(DataBase data)
    {
        return $"📧EMAIL: {data.Email}\n🔒Cl4v3: {data.Password}\n📌P1N: {MiscFaker.FakePin()}\nIP: \n \n\n \n\n🐺Sacrix32🐺";
    }
}