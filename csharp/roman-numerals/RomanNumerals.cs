using System;
using System.Collections.Generic;
using System.Linq;
using Pair = System.Tuple<string, int>;

public static class RomanNumeralExtension
{
    private static Dictionary<int, string> roman = new Dictionary<int, string>()
    {
        [1000] = "M",
        [900] = "CM",
        [500] = "D",
        [400] = "CD",
        [100] = "C",
        [90] = "XC",
        [50] = "L",
        [40] = "XL",
        [10] = "X",
        [9] = "IX",
        [5] = "V",
        [4] = "IV",
        [1] = "I",
    };

    private static string Chunk(int k, int value) => string.Join("", Enumerable.Repeat(roman[k], value / k));

    private static Pair Next(Pair r, int k) => Tuple.Create(r.Item1 + Chunk(k, r.Item2), r.Item2 % k);

    public static string ToRoman(this int value) => roman.Keys.Aggregate(Tuple.Create("", value), Next).Item1;
}