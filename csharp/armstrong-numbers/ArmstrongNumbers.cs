using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        IEnumerable<int> powNdigits(Char[] digits) => digits.Select(d => (int)Math.Pow(d - '0',  digits.Length));
        return powNdigits(number.ToString().ToCharArray()).Sum() == number;
    }
}
