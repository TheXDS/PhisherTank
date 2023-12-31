using System.IO.Compression;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks.Base;

internal abstract class LiveBlog365AttackFamily(string server) : Attack(server)
{
    private static byte[] ToBytes(string hex)
    {
        return Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
    }

    private static string ToHex(byte[] d)
    {
        return string.Concat(d.Select(p => p.ToString("X2"))).ToLower();
    }

    private static byte[] Decrypt(byte[] cypher, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.Zeros;
        aes.BlockSize = 128;
        aes.Key = key;
        aes.IV = iv;
        using var dc = aes.CreateDecryptor();
        using MemoryStream ms = new(cypher);
        using MemoryStream outMs = new();
        using CryptoStream cs = new(ms, dc, CryptoStreamMode.Read);
        cs.CopyTo(outMs);
        return outMs.ToArray();
    }

    private static string Get(char variable, string input)
    {
        return Regex.Match(input, $"{variable}{"=toNumbers\\(\"([0-9a-f]{32})\"\\)"}").Groups[1].Value;
    }

    protected static void GetCookie(IAttackContext context)
    {
        if (!(context.LastResponse is { } r)) return;
        using var gz = new GZipStream(r.Content.ReadAsStream(), CompressionMode.Decompress);
        using var sr = new StreamReader(gz);
        var content = sr.ReadToEnd();
        var a = ToBytes(Get('a', content));
        var b = ToBytes(Get('b', content));
        var c = ToBytes(Get('c', content));
        context.Headers.Add("Cookie", $"__test={ToHex(Decrypt(c, a, b))}");
    }
}
