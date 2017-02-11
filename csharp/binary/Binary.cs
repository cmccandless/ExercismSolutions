using System;
using System.Linq;
using System.Text.RegularExpressions;

class Binary
{
	public static int ToDecimal(string binary)
	{
		if (Regex.IsMatch(binary, "[^10]")) return 0;
		return binary.Select((bit, i) => bit.Equals('1') ? (int)Math.Pow(2, binary.Length - 1 - i) : 0).Sum();
	}
}
