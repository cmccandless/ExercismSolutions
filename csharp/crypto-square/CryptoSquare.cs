using System;
using System.Collections.Generic;
using System.Linq;

public class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        return new string(plaintext.ToLower().Where(char.IsLetterOrDigit).ToArray());
    }

    public static string[] PlaintextSegments(string plaintext)
    {
        var q = new List<string>();
        var normalized = NormalizedPlaintext(plaintext);
        var size = (int)Math.Ceiling(Math.Sqrt(normalized.Length));
        foreach (var ch in normalized)
        {
            if (!q.Any() || q.Last().Length >= size) q.Add("");
            q[q.Count - 1] += ch;
        }
        return q.ToArray();
    }

    public static string Ciphertext(string plaintext) 
    {
        var lines = PlaintextSegments(plaintext).Select(line => new Queue<char>(line)).ToArray();
        var result = "";
        bool charsRemaining() => lines.Any(line => line.Any());
        while (charsRemaining())
        {
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                result += line.Any() ? line.Dequeue() : ' ';
            }
            if (charsRemaining()) result += " ";
        }
        return result;
    }

    public static string Encoded(string plaintext) => Ciphertext(plaintext).Replace(" ", "");
}
