using TheXDS.MCART.Types.Base;

namespace ConsoleApp1.Models;

internal class AttackContext : Disposable, IAttackContext
{
    private HttpResponseMessage? lastResponse;

    public HttpResponseMessage? LastResponse
    {
        get => lastResponse;
        set
        {
            LastResponse?.Dispose();
            lastResponse = value;
        }
    }

    public Dictionary<string, string> Headers { get; } = new();

    public void AddHeaders(HttpRequestMessage request)
    {
        foreach (var header in Headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }
    }

    public bool Failed { get; set; }

    public FauxData FauxData { get; } = new FauxData();

    protected override void OnDispose()
    {
        LastResponse?.Dispose();
    }
}