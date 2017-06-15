import java.util.*;
import java.util.stream.*;

final class Matrix {
    private List<List<Integer>> rows;
    public Matrix(List<List<Integer>> m) {
        this.rows = m;
    }
    private List<Integer> col(int c) {
        return IntStream.range(0, rows.size()).boxed()
            .map(i -> rows.get(i).get(c))
            .collect(Collectors.toList());
    }
    private List<List<Integer>> cols() {
        return IntStream.range(0, rows.isEmpty() ? 0 : rows.get(0).size())
            .mapToObj(i -> col(i))
            .collect(Collectors.toList());
    }
    public Set<MatrixCoordinate> getSaddlePoints() {
        List<Integer> rowMax, colMin;
        rowMax = rows.stream()
            .map(r -> r.stream().max(Integer::compare).get())
            .collect(Collectors.toList());
        colMin = cols().stream()
            .map(c -> c.stream().min(Integer::compare).get())
            .collect(Collectors.toList());
        return IntStream.range(0, rows.size())
            .mapToObj(r -> IntStream.range(0, rows.get(r).size())
                .mapToObj(c -> new int[] {r, c})
                .filter(p -> rowMax.get(p[0]) == colMin.get(p[1]))
                .map(p -> new MatrixCoordinate(p[0], p[1]))
                .collect(Collectors.toSet()))
            .collect(HashSet::new,
                Set::addAll,
                Set::addAll);
    }
}
