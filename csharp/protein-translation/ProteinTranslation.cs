using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    private static Dictionary<string, string> proteins = new Dictionary<string, string>()
    {
        ["AUG"] = "Methionine", ["UUU"] = "Phenylalanine", ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine", ["UUG"] = "Leucine", ["UCU"] = "Serine",
        ["UCC"] = "Serine", ["UCA"] = "Serine", ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine", ["UAC"] = "Tyrosine", ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine", ["UGG"] = "Tryptophan", ["UAA"] = "STOP",
        ["UAG"] = "STOP", ["UGA"] = "STOP",
    };

    public static string[] Translate(string codon) =>
        new Queue<char>(codon).DequeueAllCodons().Select(TranslateSingle)
        .TakeWhile(p => !p.Equals("STOP")).ToArray();

    public static string TranslateSingle(string codon)
    {
        try { return proteins[codon]; }
        catch (KeyNotFoundException) { throw new Exception(); }
    }

    public static IEnumerable<string> DequeueAllCodons(this Queue<char> q)
    {
        while (q.Count > 2) yield return string.Join("", q.DequeueM(3));
    }

    public static IEnumerable<T> DequeueM<T>(this Queue<T> q, int n)
    {
        while (q.Any() && n-- > 0) yield return q.Dequeue();
    }
}
