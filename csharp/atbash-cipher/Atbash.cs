using System;
using System.Linq;

class Atbash
{
	private const byte a = 97;
	private const byte encodeVal = 2 * a + 25; //219
	private const byte len = 5;

	// Example:
	// Before: abcdefghijklmnopqrstuvwxyz0123456789
	// After:  zyxwv utsrq ponml kjihg fedcb a0123 45678 9
	public static string Encode(string value)
	{
		return string.Join(" ",
			// Wrap in array to access encoded length
			from encoded in
				new[]
				{
					string.Join(string.Empty, 
						from char ch in value.ToLower()
						where char.IsLetterOrDigit(ch)
						select char.IsNumber(ch) ? ch : (char)(encodeVal - ch)
					)					
				}
			let numGroups = (int)Math.Ceiling(encoded.Length / (double)len)
			// Split encoded characters into groups of 5
			from i in Enumerable.Range(0, numGroups)
			let groupLen = Math.Min(len, encoded.Length - i * len)
			select encoded.Substring(i * len, groupLen)
		);
	}
}
