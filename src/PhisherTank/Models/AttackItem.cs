namespace ConsoleApp1.Models;

internal class AttackItem
{
    public AttackItem(string route)
    {
        Route = route;
    }

    public string Route { get; }

    public Func<FauxData, IEnumerable<(string key, string value)>>? FormItems { get; init; }

    private FormUrlEncodedContent? GetForm(FauxData context)
    {
        return FormItems?.Invoke(context) is { } frm ? MakeForm(frm) : null;
    }

    private static FormUrlEncodedContent MakeForm(IEnumerable<(string key, string value)> values)
    {
        return new FormUrlEncodedContent(values.Select(p => new KeyValuePair<string, string>(p.key, p.value)).ToArray());
    }
    
    public HttpRequestMessage NewRequest(FauxData data)
    {
        var content = GetForm(data);
        return new HttpRequestMessage(content is null ? HttpMethod.Get : HttpMethod.Post, Route)
        {
            Content = content
        };
    }
}
