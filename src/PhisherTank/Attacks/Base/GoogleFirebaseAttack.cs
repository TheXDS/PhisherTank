using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks.Base;

internal abstract class GoogleFirebaseAttack(string appId, string dbName, string originUrl, string fireVersion = "8.6.5") : Attack("firestore.googleapis.com")
{
    protected record FirebaseToken(string SessionId, string Sid);

    protected readonly string _dbName = dbName;
    private readonly string _originUrl = originUrl;
    protected readonly string _authRequestHeader = $"%24httpHeaders=X-Goog-Api-Client%3Agl-js%2F%20fire%2F{fireVersion}%0D%0AContent-Type%3Atext%2Fplain%0D%0AX-Firebase-GMPID%3A{appId.Replace(":", "%3A")}%0D%0A";

    private static FirebaseToken Authenticate(IAttackContext context)
    {
        try
        {
            using var br = new StreamReader(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(context.LastResponseContent!)));
            _ = br.ReadLine();
            var header = context.LastResponse!.Headers.TryGetValues("X-HTTP-Session-Id", out var x) ? x.First() : "";
            var header2 = br.ReadLine()!.Remove(0, 10).Remove(22);
            return new FirebaseToken(header, header2);
        }
        catch
        {
            context.Fail("Failed to authenticate");
            return new("gsessionid", "");
        }
    }

    private string GetUrl(FirebaseToken token, string action, params string[] extraparams)
    {
        return $"https://firestore.googleapis.com/google.firestore.v1.Firestore/{action}/channel?database={_dbName.Replace("/", "%2F")}&VER=8&{(token.SessionId == "gsessionid" ? "X-HTTP-Session-Id" : "gsessionid")}={token.SessionId}{(string.IsNullOrEmpty(token.Sid) ? null : $"&SID={token.Sid}")}&RID={MiscFaker.FakePin(5)}&CVER=22{string.Concat(extraparams.Select(p => $"&{p}"))}&AID=5&zx={MiscFaker.RandomChars(12).ToLower()}&t=1";
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        var session = new FirebaseToken("gsessionid", "");
        context.Headers.Add("Accept", "*/*");
        context.Headers.Add("Accept-Encoding", "gzip, deflate, br");
        context.Headers.Add("Accept-Language", "en-US,en;q=0.5");
        context.Headers.Add("Cache-Control", "no-cache");
        context.Headers.Add("Connection", "keep-alive");
        context.Headers.Add("DNT", "1");
        context.Headers.Add("Host", "firestore.googleapis.com");
        context.Headers.Add("Origin", $"https://{_originUrl}");
        context.Headers.Add("Pragma", "no-cache");
        context.Headers.Add("Referer", $"https://{_originUrl}/");
        context.Headers.Add("Sec-Fetch-Dest", "empty");
        context.Headers.Add("Sec-Fetch-Mode", "cors");
        context.Headers.Add("Sec-Fetch-Site", "cross-site");
        context.Headers.Add("Sec-GPC", "1");
        context.Headers.Add("TE", "trailers");
        context.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        yield return Form(GetUrl(session, "Write", _authRequestHeader), BeginWriteTransactionForm);
        session = Authenticate(context);
        yield return Form(GetUrl(session, "Write"), CommitWriteTransactionForm);
    }

    private (string, string)[] BeginWriteTransactionForm(DataBase _)
    {
        return [
            ("count", "1"),
            ("ofs", "0"),
            ("req0___data__", $"{{\"database\":\"{_dbName}\"}}")
        ];
    }

    private (string, string)[] CommitWriteTransactionForm(DataBase d)
    {
        return [
            ("count", "1"),
            ("ofs", "1"),
            ("req0___data__", BuildWriteMessage(_dbName, d))
        ];
    }

    protected abstract string BuildWriteMessage(string dbName, DataBase data);
}