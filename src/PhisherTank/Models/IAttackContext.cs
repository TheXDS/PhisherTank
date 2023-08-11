namespace ConsoleApp1.Models;

internal interface IAttackContext : IDisposable
{
    HttpResponseMessage? LastResponse { get; }

    Dictionary<string, string> Headers { get; }

    FauxData FauxData { get; }

    bool Failed { get; set; }
}
