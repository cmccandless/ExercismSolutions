using System;
using System.Linq;

static class Hexadecimal
	{
		public static int ToDecimal(string hex)
		{
			hex = hex.ToUpper();
			if (hex.Any(ch => !(char.IsDigit(ch) || (ch <= 'F' && ch >= 'A')))) return 0;
			return hex.ToCharArray()
				.Select((ch, i) => (int)Math.Pow(16, hex.Length - i - 1) * 
					(ch <= '9' ? 
					(int)ch - '0' :
					(int)ch - 'A' + 10))
				.Sum();
		}
	}
