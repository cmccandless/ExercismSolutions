using System;
using System.Collections.Generic;
using System.Linq;

public static class Base
{
    private static int ToBase10Int(this int[] digits, int inputBase = 10) =>
        digits.Aggregate(0, (r, x) => r * inputBase + x);
    private static int[] ToBase10(this int[] digits, int inputBase) =>
        digits.ToBase10Int(inputBase).ToString().Select(c => c - '0').ToArray();
    private static int[] FromBase10(this int[] digits, int outputBase)
    {
        if (outputBase == 10) return digits;
        var a = new List<int>();
        var s = digits.ToBase10Int();
        var i = 1;
        while (s > i) i *= outputBase;
        while (i > 1)
        {
            i /= outputBase;
            a.Add(s / i);
            s %= i;
        }
        return a.ToArray();
    }
    private static bool ValidBases(params int[] bases) => bases.All(b => b >= 2);
    private static bool ValidDigits(this int[] digits, int _base) =>
        digits.Any(x => x > 0) && digits.First() != 0 && digits.All(x => x >= 0 && x < _base);
    public static int[] Rebase(int inputBase, int[] digits, int outputBase)
    {
        if (!ValidBases(inputBase, outputBase) || !digits.ValidDigits(inputBase))
            throw new ArgumentException();
        return digits.ToBase10(inputBase).FromBase10(outputBase);
    }
}
