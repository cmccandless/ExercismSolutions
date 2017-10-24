import java.util.*;
import java.util.stream.*;

public class Tournament {
    private static String fmt = "%1$-31s|%2$3s |%3$3s |%4$3s |%5$3s |%6$3s\n";
    private static String header = String.format(fmt, "Team", "MP", "W", "D", "L", "P");
    private static String format(Team team) {
        return String.format(fmt, 
                             team.name,
                             team.matches(),
                             team.wins,
                             team.draws,
                             team.losses,
                             team.points());
    }

    private Map<String, Team> teams = new HashMap<String, Team>();

    public void applyResults(String results) {
        Arrays.stream(results.split("\n"))
              .map(Match::new)
              .forEach(match -> match.applyTo(teams));
    }

    public String printTable() {
        return header + teams.entrySet()
                             .stream()
                             .map(Map.Entry::getValue)
                             .sorted(Team.byPointsThenName)
                             .map(Tournament::format)
                             .collect(Collectors.joining(""));
    }
}
enum Result { 
    loss, draw, win;
    public Result invert() {
        switch(this) {
            case loss:
                return win;
            case win:
                return loss;
            default:
                return this;
        }
    }
}
class Match {
    public String home, away;
    public Result result;
    public Match(String matchStr) {
        String[] parts = matchStr.split(";");
        home = parts[0];
        away = parts[1];
        result = Result.valueOf(parts[2]);
    }
    public void applyTo(Map<String, Team> teams) {
        teams.putIfAbsent(home, new Team(home));
        teams.putIfAbsent(away, new Team(away));
        teams.get(home).apply(result);
        teams.get(away).apply(result.invert());
    }
}
class Team {
    public String name;
    public int wins = 0;
    public int draws = 0;
    public int losses = 0;
    public Team(String name) {
        this.name = name;
    }
    public int matches() {
        return wins + draws + losses;
    }
    public int points() {
        return wins * 3 + draws;
    }
    public void apply(Result result) {
        switch(result) {
            case win:
                this.wins++;
                break;
            case loss:
                this.losses++;
                break;
            case draw:
                this.draws++;
                break;
        }
    }
    public static Comparator<Team> byPointsThenName = (t1, t2) -> 
        Integer.compare(t2.points(), t1.points()) * 10 + t1.name.compareTo(t2.name);
}