import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class House {
	private String[] verb = new String[] {
		"",
		"lay in",
		"ate",
		"killed",
		"worried",
		"tossed",
		"milked",
		"kissed",
		"married",
		"woke",
		"kept",
		"belonged to",
		""
	};
	private String[] noun = new String[] {
		"",
		"house that Jack built.",
		"malt",
		"rat",
		"cat",
		"dog",
		"cow with the crumpled horn",
		"maiden all forlorn",
		"man all tattered and torn",
		"priest all shaven and shorn",
		"rooster that crowed in the morn",
		"farmer sowing his corn",
		"horse and the hound and the horn"
	};
	public String verse(int n) {
		return IntStream.range(0, n)
			.map(i -> n - i)
			.mapToObj(i -> String.format("%s the %s",
				i == n ? "This is" : String.format("that %s", verb[i]),
				noun[i]))
			.collect(Collectors.joining("\n"));
	}
	public String verses(int startVerse, int endVerse) {
		return IntStream.rangeClosed(startVerse,endVerse)
			.mapToObj(this::verse)
			.collect(Collectors.joining("\n\n"));
	}
	public String sing() {
		return verses(1, verb.length - 1);
	}
}