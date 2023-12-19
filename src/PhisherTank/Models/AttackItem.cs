namespace ConsoleApp1.Models;

internal class AttackItem(string route = "")
{
    public string Route { get; } = route;

    public Func<DataBase, IEnumerable<(string key, string value)>>? FormItems { get; init; }

    public Func<DataBase, string>? PlainData { get; init; }

    private HttpContent? GetContent(DataBase context)
    {
        return FormItems?.Invoke(context) is { } frm
            ? MakeForm(frm)
            : PlainData?.Invoke(context) is { } plainContent
            ? new StringContent(plainContent) : null;
    }

    private static FormUrlEncodedContent MakeForm(IEnumerable<(string key, string value)> values)
    {
        return new FormUrlEncodedContent(values.Select(p => new KeyValuePair<string, string>(p.key, p.value)).ToArray());
    }
    
    public HttpRequestMessage NewRequest(DataBase data)
    {
        var content = GetContent(data);
        return new HttpRequestMessage(content is null ? HttpMethod.Get : HttpMethod.Post, Route)
        {
            Content = content
        };
    }
}