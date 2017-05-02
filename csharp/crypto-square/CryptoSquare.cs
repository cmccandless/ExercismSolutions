using System;
using System.Collections.Generic;
using System.Linq;

public class Crypto
{
    public readonly string NormalizePlaintext;
    public readonly int Size;
    public Crypto(string str)
    {
        NormalizePlaintext = new string(str.ToLower().Where(char.IsLetterOrDigit).ToArray());
        Size = (int)Math.Ceiling(Math.Sqrt(NormalizePlaintext.Length));
    }

    private IEnumerable<char> Column(int col) => Enumerable.Range(0, Size)
        .Select(r => r * Size + col)
        .TakeWhile(i => i < NormalizePlaintext.Length)
        .Select(i => NormalizePlaintext[i]);

    private string ColumnAsRow(int col) => new string(Column(col).ToArray());

    private string Cipher(string delimiter = " ") =>
        string.Join(delimiter, Enumerable.Range(0, Size).Select(ColumnAsRow));

    public string[] PlaintextSegments() => NormalizePlaintext.Segments(Size).ToArray();

    public string Ciphertext() => Cipher("");

    public string NormalizeCiphertext() => Cipher();
}

static class Ext
{
    public static IEnumerable<T> DequeueM<T>(this Queue<T> q, int n, bool exact = false)
    {
        while (q.Any() && n-- > 0) yield return q.Dequeue();
    }

    public static IEnumerable<string> Segments(this IEnumerable<char> col, int size) =>
        new Queue<char>(col).Segments(size);

    public static IEnumerable<string> Segments(this Queue<char> q, int size)
    {
        while (q.Any()) yield return string.Join(string.Empty, q.DequeueM(size));
    }
}
