using System;
using System.Collections.Generic;
using System.Linq;

public static class RnaTranscription
{
    private static Dictionary<char, char> complement = new Dictionary<char, char>()
    {
        { 'G', 'C'},
        { 'C', 'G'},
        { 'T', 'A'},
        { 'A', 'U'},
    };
    public static string ToRna(string dna)
    {
        try { return string.Join(string.Empty, dna.Select(ch => complement[ch])); }
        catch (KeyNotFoundException) { throw new ArgumentException(); }
    }
}