namespace ConsoleApp1.Models;

internal class AttackItem
{
    public AttackItem(string route)
    {
        Route = route;
    }

    public string Route { get; }

    public Func<FauxData, IEnumerable<(string key, string value)>>? FormItems { get; init; }

    public Func<FauxData, string>? PlainData { get; init; }

    private HttpContent? GetContent(FauxData context)
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
    
    public HttpRequestMessage NewRequest(FauxData data)
    {
        var content = GetContent(data);
        return new HttpRequestMessage(content is null ? HttpMethod.Get : HttpMethod.Post, Route)
        {
            Content = content
        };
    }
}