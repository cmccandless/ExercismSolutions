using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ETL
{
	public static Dictionary<string, int> Transform(Dictionary<int, IList<string>> old)
	{
		return (from kvp in old
				let score = kvp.Key
				from letter in kvp.Value
				select new { letter=letter.ToLower(), score })
				.ToDictionary(x => x.letter, x => x.score);
	}
}
