import java.util.*;
import java.util.stream.*;

public class WordCount {
    public Map<String, Integer> phrase(String s) {
        return Arrays.stream(s.toLowerCase().split("[^\\w]"))
            .filter(w -> !w.isEmpty())
            .collect(Collectors.groupingBy(w -> w, Collectors.summingInt(e -> 1)));
    }
}
