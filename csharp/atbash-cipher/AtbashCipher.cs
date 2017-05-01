using System;
using System.Collections.Generic;
using System.Linq;

public static class AtbashCipher
{
    private const byte LEN = 5;

    private static IEnumerable<char> Clean(this string value) => value.ToLower().Where(char.IsLetterOrDigit);

    public static IEnumerable<T2> Map<T1, T2>(this IEnumerable<T1> col, Func<Queue<T1>, T2> f)
    {
        var q = new Queue<T1>(col);
        while (q.Count > 0) yield return f(q);
    }

    public static IEnumerable<T> DequeueM<T>(this Queue<T> q, int n)
    {
        while (n-- > 0 && q.Count > 0) yield return q.Dequeue();
    }

    private static string Chunk(Queue<char> q) => new string(q.DequeueM(LEN).ToArray());

    private static char Encode(char ch) => char.IsNumber(ch) ? ch : (char)(219 - ch);

    public static string Encode(this string value) => string.Join(" ", value.Clean().Select(Encode).Map(Chunk));

    private static string Strip(this string value) => value.Replace(" ", "");

    public static string Decode(this string value) => value.Encode().Strip();
}