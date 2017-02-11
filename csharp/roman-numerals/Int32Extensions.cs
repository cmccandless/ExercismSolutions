using System.Collections.Generic;
using System.Linq;

public static class Int32Extensions
{
	private static Dictionary<int, string> roman = new Dictionary<int, string>()
		{
			{ 1, "I" },
			{ 4, "IV" },
			{ 5, "V" },
			{ 9, "IX" },
			{ 10, "X" },
			{ 40, "XL" },
			{ 50, "L" },
			{ 90, "XC" },
			{ 100, "C" },
			{ 400, "CD" },
			{ 500, "D" },
			{ 900, "CM" },
			{ 1000, "M" },
		};

	public static string ToRoman(this int value)
	{
		var result = string.Empty;
		var keys = roman.Keys.ToArray();
		for (int i = keys.Length - 1; value > 0; i--)
		{
			var key = keys[i];
			while (value >= key)
			{
				result += roman[key];
				value -= key;
			}
		}
		return result;
	}
}
