using TheXDS.MCART.Types.Extensions;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class CelebratorsPkAttack() : Attack("celebrators.pk")
{
    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        yield return "";
        yield return Form("cargando.php", GetCargandoForm);
        var pin = MiscFaker.FakePin(6);
        yield return Form("gege.php", faux => [("C1", pin)]);
        yield return Form("gege.php", faux => [("C2", pin)]);
        yield return Form("gege2.php", EmailPasswordForm("D1", "D2"));
    }

    private (string, string)[] GetCargandoForm(DataBase f)
    {
        return [
            ("D2", f.Person.UserName),
            ("D1", MiscFaker._rnd.CoinFlip() ? FauxData.GenerateRandomPassword() : f.Password),
        ];
    }
}

internal class BacCredomaticComprasAttack() : Attack("baccredomaticcompras.weebly.com")
{
    private string GetRedirectButton(HttpResponseMessage response)
    {
        return "5367420a-2d4c-42b8-b76b-39c6056f4873-00-lw6fyscf8jox.worf.replit.dev";
        //int buttonLocation = 328;

        //using var rs = response.Content.ReadAsStream();
        //using var sr = new StreamReader(rs);

        //while (buttonLocation-- > 0) { var l = sr.ReadLine(); }
        //return sr.ReadLine()!.ChopStartAny("<a href='https://", "<a href='http://").ChopEnd("' target='_blank'>");
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        //yield return "";
        var newServer = GetRedirectButton(context.LastResponse!);
        context.SwitchServer(newServer, this);
        context.Headers.Add("Host", newServer);
        context.Headers.Add("Origin", $"https://{newServer}");
        context.Headers.Add("Referer", $"https://{newServer}");
        yield return "";
        yield return Form("rgcrgs.php", GetRgcrgs);
        yield return "oucls.php";
        yield return Form("oucls2.php", GetOuCls);
        yield return Form("oucls3.php", GetOuCls);
        yield return Form("trufs.php", GetOuCls);
    }

    private (string, string)[] GetRgcrgs(DataBase f)
    {
        return [
            ("country", "HN"),
            ("caraqueño", f.Person.UserName),
            ("pequeñiso", f.Password),
            ("passtemp", ""),
            ("token", ""),
            ("signatureDataHash", ""),
            ("persistent", MiscFaker._rnd.CoinFlip() ? "y":"n"),
            ("confirm", "")
        ];
    }

    private (string, string)[] GetOuCls(DataBase _)
    {
        return [
            ("caraqueñAZO", MiscFaker.FakePin(6)),
            ("precari0", MiscFaker.FakePin(6)),
        ];
    }
}