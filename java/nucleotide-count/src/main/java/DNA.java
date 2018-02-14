import java.util.*;
import java.util.stream.*;

public class DNA {
    private Map<Character, Integer> counts = new HashMap<>();
    public DNA(String s) {
        Stream.of('A','C','T','G').forEach(ch -> counts.put(ch,0));
        s.chars().mapToObj(c -> (char)c)
            .forEach(c -> counts.put(c, counts.get(c) + 1));
    }
    public Map<Character, Integer> nucleotideCounts() {
        return counts;
    }
    public int count(char ch) {
        if (!counts.containsKey(ch)) throw new IllegalArgumentException();
        return counts.getOrDefault(ch, 0);
    }
}
