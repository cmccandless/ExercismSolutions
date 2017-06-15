import java.util.*;
import java.util.stream.*;

public class Anagram {
    private String baseWord;
    private String baseSorted;
    public Anagram(String baseWord) {
        this.baseWord = baseWord.toLowerCase();
        baseSorted = sorted(baseWord);
    }
    private static String sorted(String word) {
        return word.toLowerCase().codePoints()
            .sorted()
            .collect(StringBuilder::new,
                StringBuilder::append,
                StringBuilder::append)
            .toString();
    }
    public List<String> match(List<String> words) {
        return words.stream()
            .filter(w -> !baseWord.equals(w.toLowerCase()) && baseSorted.equals(sorted(w)))
            .collect(Collectors.toList());
    }
}
