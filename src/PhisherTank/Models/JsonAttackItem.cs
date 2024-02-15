namespace TheXDS.PhisherTank.Models;

internal class JsonAttackItem(string route, Func<DataBase, string> stringData) : AttackItem(route)
{
    private readonly Func<DataBase, string> stringData = stringData;

    private static StringContent FromString(string rawData)
    {
        return new StringContent(rawData, System.Text.Encoding.UTF8, "application/json");
    }

    public override HttpContent? GetContent(DataBase context)
    {
        return FromString(stringData.Invoke(context));
    }
}
