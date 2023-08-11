namespace ConsoleApp1.Models;

internal static class IAttackContextExtensions
{
    public static void AddCommonBrowserHeaders(this IAttackContext context)
    {
        context.Headers.Add("Connection", "keep-alive");
        context.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 Edg/115.0.1901.183");
        context.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        context.Headers.Add("Upgrade-Insecure-Requests", "1");
        context.Headers.Add("Sec-GPC", "1");
        context.Headers.Add("Accept-Encoding", "gzip, deflate");
        context.Headers.Add("Accept-Language", "es-419,es;q=0.9,es-ES;q=0.8,en;q=0.7,en-GB;q=0.6,en-US;q=0.5");
    }

    public static void AddReferrer(this IAttackContext context)
    {
        if (context.LastResponse is not { RequestMessage.RequestUri: { } lastUri }) return;
        context.Headers.Remove("Referer");
        context.Headers.Add("Referer", lastUri.ToString());
    }

    public static bool CheckResponse(this IAttackContext context)
    {
        context.Failed = context.LastResponse is { IsSuccessStatusCode: bool success } && !success;
        return context.Failed;
    }
}