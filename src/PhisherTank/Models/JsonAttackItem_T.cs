using System.Net.Http.Json;

namespace TheXDS.PhisherTank.Models;

internal class JsonAttackItem<T>(string route, Func<DataBase, T> jsonData) : AttackItem(route)
{
    private readonly Func<DataBase, T> jsonData = jsonData;

    private static JsonContent FromJson(T data)
    {
        return JsonContent.Create(data);
    }

    public override HttpContent? GetContent(DataBase context)
    {
        return FromJson(jsonData.Invoke(context));
    }
}
