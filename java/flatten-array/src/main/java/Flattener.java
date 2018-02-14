import java.util.*;

final class Flattener {
    private List<?> flat(Object o) {
        return o instanceof List ? 
            flatten((List<?>)o) :
            Arrays.asList(new Object[] {o});
    }
    public List<?> flatten(List<?> list) {
        return list.stream()
            .filter(o -> o != null)
            .map(this::flat)
            .collect(ArrayList::new,
                ArrayList::addAll,
                ArrayList::addAll);
    }
}
