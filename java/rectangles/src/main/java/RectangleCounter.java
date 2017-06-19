import java.util.*;
import java.util.stream.*;

final class RectangleCounter {
    private static boolean hline(char[][]inputGrid, int[] a, int[] b) {
        return IntStream.range(a[0] + 1, b[0])
            .mapToObj(i -> inputGrid[a[1]][i])
            .allMatch(ch -> ch == '+' || ch == '-');
    }
    private static boolean vline(char[][]inputGrid, int[] a, int[] b) {
        return IntStream.range(a[1] + 1, b[1])
            .mapToObj(i -> inputGrid[i][a[0]])
            .allMatch(ch -> ch == '+' || ch == '|');
    }
    private static boolean validPartial(char[][] inputGrid, int[] a, int[] b) {
        return a[1] == b[1] && a[0] < b[0] && hline(inputGrid, a, b);
    }
    private static boolean validRectangle(char[][] inputGrid, int[] a, int[] b, int[] c) {
        return a[0] == c[0] && a[1] < c[1] &&
            inputGrid[c[1]][b[0]] == '+' &&
            vline(inputGrid, a, c) &&
            hline(inputGrid, c, b) &&
            vline(inputGrid, b, c);
    }
    public int countRectangles(String[] inputGrid) {
        return countRectangles(Arrays.stream(inputGrid)
            .map(s -> s.toCharArray())
            .toArray(char[][]::new));
    }
    public int countRectangles(char[][] inputGrid) {
        List<int[]> corners = IntStream.range(0,inputGrid.length)
            .mapToObj(y -> IntStream.range(0,inputGrid[y].length)
                .filter(x -> inputGrid[y][x] == '+')
                .mapToObj(x -> new int[] {x,y})
                .collect(Collectors.toList()))
            .flatMap(List::stream)
            .collect(Collectors.toList());
        return corners.stream()
            .mapToInt(a -> corners.stream()
                .filter(b -> validPartial(inputGrid, a, b))
                .mapToInt(b -> (int)corners.stream()
                    .filter(c -> validRectangle(inputGrid, a, b, c))
                    .count())
                .sum())
            .sum();
    }
}
