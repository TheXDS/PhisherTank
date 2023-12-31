namespace TheXDS.PhisherTank.Models;

internal class AttackItem(string route = "")
{
    public string Route { get; } = route;

    public virtual HttpContent? GetContent(DataBase context) => null;

    public HttpRequestMessage NewRequest(DataBase data)
    {
        var content = GetContent(data);
        return new HttpRequestMessage(content is null ? HttpMethod.Get : HttpMethod.Post, Route)
        {
            Content = content
        };
    }

    public static implicit operator AttackItem(string url) => new(url);
}
