import java.util.*;
import java.util.concurrent.*;

public class ParallelLetterFrequency {
    private String text;

    public ParallelLetterFrequency(String text) {
        this.text = text;
    }

    public Map<Integer, Integer> letterCounts() {
        return text.toLowerCase().codePoints()
            .parallel()
            .filter(Character::isLetter)
            .mapToObj(i -> (Integer)i)
            .collect(
                ConcurrentHashMap::new,
                (m, ch) -> {
                    if (m.containsKey(ch)) {
                        m.compute(ch, (k, v) -> v + 1);
                    } else {
                        m.put(ch, 1);
                    }
                },
                (a, b) -> b.forEach((k, v) -> {
                    if (a.containsKey(k)) {
                        a.compute(k, (k2, v2) -> v + v2);
                    } else {
                        a.put(k, v);
                    }
                })
            );
    }
}
