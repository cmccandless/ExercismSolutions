import java.util.*;
import java.util.stream.*;

public final class BookStore {
    private final int BASE_COST = 8;
    private static final double[] discount = 
        new double[] {1.0, 1.0, 0.95, 0.9, 0.8, 0.75};
    private class Grouping {
        private List<Set<Integer>> groups;
        public Grouping() { this(new ArrayList()); }
        public Grouping(List<Set<Integer>> groups) {
            this.groups = groups;
        }
        public double total() {
            return BASE_COST * groups.stream()
                .map(BookStore::groupCost)
                .reduce(0.0, (a, r) -> a + r);
        }
        public Grouping dup() {
            return new Grouping(groups.stream()
                .map(HashSet::new)
                .collect(Collectors.toList()));
        }
        public Grouping add(int b) { return add(b, 0); }
        public Grouping add(int b, int index) {
            Grouping other = dup();
            Collections.sort(other.groups, BookStore::compareByLength);
            List<Set<Integer>> valid = other.groups.stream()
                .filter(g -> !g.contains(b))
                .collect(Collectors.toList());
            if (valid.isEmpty()) other.groups.add(new HashSet(Arrays.asList(b)));
            else valid.get((valid.size() + index) % valid.size()).add(b);
            return other;
        }
        public Grouping min(Grouping other) {
            return total() < other.total() ? this : other;
        }
    }
    public static <T> int compareByLength(Set<T> o1, Set<T> o2) {
        return Integer.compare(o1.size(), o2.size());
    }
    private static double groupCost(Set<Integer> g) {
        return g.size() * discount[g.size()];
    }
    private static List<Grouping> step(List<Grouping> t, int b) {
        Grouping sm = t.get(0);
        Grouping la = t.get(1);
        return new ArrayList() {{
           add(sm.add(b).min(la.add(b)));
           add(sm.add(b, -1).min(la.add(b, -1)));
        }};
    }
    public double calculateBasketCost(List<Integer> books) {
        if (books.isEmpty()) return 0;
        Grouping start = new Grouping();
        List<Grouping> result = Arrays.asList(start, start.dup());
        for (int b : books) result = step(result, b);
        return result.get(0).min(result.get(1)).total();
    }
}