using TheXDS.MCART.Types;
using TheXDS.PhisherTank.Component;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks.Base;

internal abstract class GoogleFirebaseUpdateAttack(string appId, string dbName, string originUrl, string fireVersion = "8.6.5") : GoogleFirebaseAttack(appId, dbName, originUrl, fireVersion)
{
    protected record UpdateMessage(string EntryId, NamedObject<object?>[] Values);    

    protected abstract UpdateMessage GetUpdateMessage(DataBase data);

    protected override string BuildWriteMessage(string dbName, DataBase data)
    {
        var msg = GetUpdateMessage(data);
        return  $"{{\"streamToken\":\"{MiscFaker.RandomChars(12)}\",\"writes\":[{{\"update\":{{\"name\":\"{dbName}/{msg.EntryId}\",\"fields\":{{ {GetFields(msg.Values)}}}}}}}]}}";
    }

    private static string GetFields(IEnumerable<NamedObject<object?>> data)
    {
        return string.Join(",", data.Select(ToKeyValue));
    }

    private static string ToKeyValue(NamedObject<object?> p)
    {
        var valueExpr = p.Value switch
        {
            null => "{\"nullValue\":\"NULL_VALUE\"}",
            bool b => $"{{\"booleanValue\":{b.ToString().ToLower()}}}",
            int i => $"{{\"integerValue\":{i}}}",
            string s => $"{{\"stringValue\":\"{s}\"}}",
            _ => throw new NotImplementedException(p.Value.GetType().Name)
        };
        return $"\"{p.Name}\":{valueExpr}";
    }
}
