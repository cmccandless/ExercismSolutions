import java.util.List;
import java.util.HashMap;
import java.util.Map;

public class Etl {
    public Map<String, Integer> transform(Map<Integer, List<String>> old) {
        return old.entrySet().stream()
            .map(e -> e.getValue()
                .stream()
                .collect(HashMap<String, Integer>::new,
                    (m, w) -> m.put(w.toLowerCase(), e.getKey()),
                    Map::putAll))
            .collect(HashMap::new,
                Map::putAll,
                Map::putAll);
    }
}
