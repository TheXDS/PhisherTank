using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class ComunicadoSeguridadAttack : TelegramBotAttack
{
    //                                         👇 Yup... this API key is all yours to take.
    public ComunicadoSeguridadAttack() : base("5850433487:AAEHA09KWjR_3V-h8OmL-bGPTi0J-wgxJJI", 5821810273)
    {
        MiscFaker.SetDomains("hotmail.com", "hotmail.com", "outlook.com", "hotmail.es", "hotmail.com");
    }
    protected override string GetMessage(DataBase data)
    {
        return $"Correo: {data.Email} Contra: {data.Password}  IP: {MiscFaker.RandomIp()}";
    }
}
