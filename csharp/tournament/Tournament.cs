using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{
    private static string HeaderStr = $"{"Team",-30} | MP |  W |  D |  L |  P";

    private static TeamStats GetOrAdd(this Dictionary<string, TeamStats> dict, string team) =>
        dict.ContainsKey(team) ? dict[team] : dict[team] = new TeamStats(team);

    private static Dictionary<string, TeamStats> CollectStats(Stream inStream)
    {
        var dict = new Dictionary<string, TeamStats>();
        using (var reader = new StreamReader(inStream))
        {
            while (!reader.EndOfStream)
            {
                var parts = reader.ReadLine().Split(';');
                if (parts.Length >= 3) dict.GetOrAdd(parts[0]).AddGame(dict.GetOrAdd(parts[1]), parts[2][0]);
            }
        }
        return dict;
    }

    private static IEnumerable<string> FormatEntries(this Dictionary<string, TeamStats> dict) =>
        from stats in dict.Values
        where stats.MatchesPlayed > 0
        orderby stats.Points descending, stats.Name
        select stats.ToString();

    private static void WriteResults(this Dictionary<string, TeamStats> dict, Stream outStream)
    {
        using (var writer = new StreamWriter(outStream))
        {
            writer.WriteLine(HeaderStr);
            foreach (var line in dict.FormatEntries()) writer.WriteLine(line);
        }
    }

    public static void Tally(Stream inStream, Stream outStream) =>
        CollectStats(inStream).WriteResults(outStream);

    private class TeamStats
    {
        public readonly string Name;

        public int Wins, Draws, Losses;

        public int MatchesPlayed => Wins + Draws + Losses;

        public int Points => Wins * 3 + Draws;

        public int[] Stats => new[] { MatchesPlayed, Wins, Draws, Losses, Points, };

        public string StatString => string.Join(" | ", Stats.Select(n => $"{n,2}"));

        public TeamStats(string name) { Name = name; }

        public override string ToString() => $"{Name,-30} | {StatString}";

        public void AddGame(TeamStats away, char result)
        {
            switch (result)
            {
                case 'w':
                    Wins++;
                    away.Losses++;
                    break;
                case 'l':
                    Losses++;
                    away.Wins++;
                    break;
                case 'd':
                    Draws++;
                    away.Draws++;
                    break;
            }
        }
    }
}
