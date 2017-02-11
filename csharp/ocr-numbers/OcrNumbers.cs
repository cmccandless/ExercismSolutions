using System.Collections.Generic;

static class OcrNumbers
{
	private static Dictionary<int, string> Ocr = new Dictionary<int, string>()
	{
		  {0x77,"0"},
		  {0x60,"1"},
		  {0x3E,"2"},
		  {0x7C,"3"},
		  {0x69,"4"},
		  {0x5D,"5"},
		  {0x5F,"6"},
		  {0x64,"7"},
		  {0x7F,"8"},
		  {0x7D,"9"},
	};
	public static string Convert(string input)
	{
		var result = string.Empty;
		var rows = input.Split('\n');
		var value = 0;
		for (int i=0; i < rows[0].Length; i++)
		{
			switch(i%3)
			{
				case 0:
					value = 0;
					if (rows[1][i].Equals('|')) value |= 1;
					if (rows[2][i].Equals('|')) value |= 1 << 1;
					break;
				case 1:
					if (rows[0][i].Equals('_')) value |= 1 << 2;
					if (rows[1][i].Equals('_')) value |= 1 << 3;
					if (rows[2][i].Equals('_')) value |= 1 << 4;
					break;
				case 2:
					if (rows[1][i].Equals('|')) value |= 1 << 5;
					if (rows[2][i].Equals('|')) value |= 1 << 6;
					result += Ocr.ContainsKey(value) ? Ocr[value] : "?";
					break;
			}
		}
		return result;
	}
}
