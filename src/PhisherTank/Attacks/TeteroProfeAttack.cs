using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class TeteroProfeAttack : TelegramBotAttack
{
    //                                 👇 Yup... this API key is all yours to take.
    public TeteroProfeAttack() : base("6374298840:AAF5w92O0FwsDhcZ5JhEiTqIYuz4JJIiwBI", 5714389880)
    {
        MiscFaker.SetDomains("hotmail.com", "hotmail.com", "outlook.com", "hotmail.es", "hotmail.com");
    }

    protected override string GetMessage(DataBase data)
    {
        return $"🟦HOTMAIL🟦\n\n🆔US3R: {data.Email}\n🔐CL4V3: {data.Password}\n🔑PIN: {MiscFaker.FakePin()}\n\nIP: \n          \n{MiscFaker.GetRandomUsCity()}, US\n🟦C0DIGO PROFE0🟦";
    }
}
