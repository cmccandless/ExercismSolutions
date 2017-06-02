import java.util.*;

final class Flattener {
    private static List<Object> flat(Object o) {
        return o instanceof List ? flatten((List)o) : new ArrayList() {{add(o);}};
    }
    public static List<Object> flatten(List<Object> list) {
        return list.stream()
            .filter(o -> o != null)
            .map(Flattener::flat)
            .collect(ArrayList::new,
                ArrayList::addAll,
                ArrayList::addAll);
    }
}
