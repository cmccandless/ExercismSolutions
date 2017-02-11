using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Tournament
{
	public static void Tally(Stream inStream, Stream outStream)
	{
		var dict = new Dictionary<string, TeamStats>();
		using (var reader = new StreamReader(inStream))
		{
			while (!reader.EndOfStream)
			{
				var parts = reader.ReadLine().Split(';');
				if (parts.Length != 3) continue;
				if (!dict.ContainsKey(parts[0])) dict[parts[0]] = new TeamStats();
				if (!dict.ContainsKey(parts[1])) dict[parts[1]] = new TeamStats();
				switch (parts[2])
				{
					case "win":
						dict[parts[0]].Wins++;
						dict[parts[1]].Losses++;
						break;
					case "loss":
						dict[parts[0]].Losses++;
						dict[parts[1]].Wins++;
						break;
					case "draw":
						dict[parts[0]].Draws++;
						dict[parts[1]].Draws++;
						break;
				}
			}
		}
		using (var writer = new StreamWriter(outStream))
		{
			writer.WriteLine(string.Join(" | ", new[] 
			{
				"Team".PadRight(30,' '),
				"MP",
				" W",
				" D",
				" L",
				" P"
			}));
			var stats = from kvp in dict
						let teamName = kvp.Key
						let _stats = kvp.Value
						where _stats.MatchesPlayed > 0
						orderby _stats.Points descending, teamName
						let ar = new[] { teamName.PadRight(30, ' ') }
							.Concat(_stats.Stats.Select(n => n.ToString().PadLeft(3, ' ')))
						select string.Join(" |", ar);
			foreach (var line in stats)
			{
				writer.WriteLine(line);
			}
		}
	}
	private class TeamStats
	{
		public int MatchesPlayed { get { return Wins + Draws + Losses; } }
		public int Wins { get; set; }
		public int Draws { get; set; }
		public int Losses { get; set; }
		public int Points { get { return Wins * 3 + Draws; } }
		public int[] Stats
		{
			get
			{
				return new[] 
				{
					MatchesPlayed,
					Wins,
					Draws,
					Losses,
					Points,
				};
			}
		}
	}
}
