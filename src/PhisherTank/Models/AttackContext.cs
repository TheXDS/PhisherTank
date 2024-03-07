using TheXDS.MCART.Types.Base;

namespace TheXDS.PhisherTank.Models;

internal class AttackContext(DataBase data) : Disposable, IAttackContext
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

    public Dictionary<string, string> Headers { get; } = [];

    public void AddHeaders(HttpRequestMessage request)
    {
        foreach (var header in Headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }
    }

    public bool Failed { get; set; }

    public DataBase Data { get; } = data;

    public HttpClient? Client { get; set; }

    protected override void OnDispose()
    {
        LastResponse?.Dispose();
        Client?.Dispose();
    }

    public void SwitchServer(string newServer, Attack attack)
    {
        Client?.Dispose();
        Client = CreateClient(newServer, attack);
    }

    private static HttpClient CreateClient(string server, Attack attack)
    {

        return new HttpClient(new HttpClientHandler() { AllowAutoRedirect = false })
        {
            BaseAddress = new Uri($"{attack.Scheme}://{server}/"),
            Timeout = TimeSpan.FromSeconds(attack.Timeout)
        };
    }
}