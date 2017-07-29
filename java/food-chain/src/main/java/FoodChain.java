import java.util.*;
import java.util.stream.*;

public class FoodChain {
	private static String[][] words = new String[][] {
        new String[]{"fly","",""},
        new String[]{"spider","It wriggled and jiggled and tickled inside her.",
            " that wriggled and jiggled and tickled inside her"},
        new String[]{"bird","How absurd to swallow a bird!",""},
        new String[]{"cat","Imagine that, to swallow a cat!",""},
        new String[]{"dog","What a hog, to swallow a dog!",""},
        new String[]{"goat","Just opened her throat and swallowed a goat!",""},
        new String[]{"cow","I don't know how she swallowed a cow!",""},
        new String[]{"horse","She's dead, of course!",""},
    };
	private static String phrase(int i) {
		return String.format("She swallowed the %s to catch the %s%s.", 
							 words[i][0], 
							 words[i - 1][0], 
							 words[i - 1][2]);
	}
	private static String getVerse(int n) {
		List<String> list = new ArrayList();
		list.add(String.format("I know an old lady who swallowed a %s.", words[n - 1][0]));
		if (n > 1) list.add(words[n - 1][1]);
		if (n < 8) {
			list.addAll(IntStream.range(1,n)
				.map(i -> n - i)
				.mapToObj(FoodChain::phrase)
				.collect(Collectors.toList()));
			list.add("I don't know why she swallowed the fly. Perhaps she'll die.");
		}
		return list.stream()
			.collect(Collectors.joining("\n"));
	}
	public String verse(int n) {
		return verses(n, n);
	}
	public String verses(int start, int stop) {
		return IntStream.range(start, stop + 1)
			.mapToObj(FoodChain::getVerse)
			.collect(Collectors.joining("\n\n"));
	}
}