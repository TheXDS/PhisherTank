namespace TheXDS.PhisherTank.Models;

internal class RawDataAttackItem(string route, Func<DataBase, string> rawData) : AttackItem(route)
{
    private readonly Func<DataBase, string> RawData = rawData;

    public override HttpContent? GetContent(DataBase context)
    {
        return new StringContent(RawData.Invoke(context));
    }
}