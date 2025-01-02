namespace TheXDS.PhisherTank.Models;

internal interface IAttackContext : IDisposable
{
    HttpResponseMessage? LastResponse { get; }

    string? LastResponseContent { get; }

    Dictionary<string, string> Headers { get; }

    DataBase Data { get; }

    bool Failed { get; set; }

    string? CustomFailureMessage { get; set; }

    HttpClient? Client { get; set; }

    void SwitchServer(string newServer, Attack attack);

    void Fail(string message)
    {
        Failed = true;
        CustomFailureMessage = message;
    }
}
