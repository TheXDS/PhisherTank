using TheXDS.PhisherTank.Attacks.Base;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class VerificarmsnzaAttack : GoogleFirebaseUpdateAttack
{
    //                                    👇 Yup... this appId is all yours to take... maybe this as well 👇
    public VerificarmsnzaAttack() : base("1:482955984270:web:0a4b7a9f440642d6e938df", "projects/newlive-efecd/databases/(default)", "verificarmsnza.webcindario.com")
    {
        MiscFaker.UseMicrosoftDomains();
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        return new AttackItem[]
        {
            Form("http://verificarmsnza.webcindario.com/hosting__contador__visitas__unicas.php", CreateVisitaNuevaForm)
        }.Concat(base.GetAttacks(context));
    }

    private (string, string)[] CreateVisitaNuevaForm(DataBase @base)
    {
        return [
            ("visita_nueva","true"),
            ("h", "2186705"),
            ("t", "1735667025"),
            ("k", "f6c4c30d9ac6f49ed95f920881e1e1ff"),
            ("__muid", "")
        ];
    }

    protected override UpdateMessage GetUpdateMessage(DataBase data)
    {
        return new($"documents/UsuarioNewHotmail/{Guid.NewGuid()}", [
            new(data.Email, "mail"),
            new(data.Password,"pw"),
            new(MiscFaker.Random2LetterCountry(), "pais"),
            new(DateTime.Today.ToString("yyyy-MM-dd"), "FECHA"),
            new(MiscFaker.FakePin(), "pin"),
            new(MiscFaker.RandomIp().ToString(), "IP"),
            new(false, "revisado")
        ]);
    }
}
