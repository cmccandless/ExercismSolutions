import java.util.stream.*;

public final class PascalsTriangleGenerator {
    public static int[][] generateTriangle(int n) {
        if (n < 0) throw new IllegalArgumentException();
        int[][] a = new int[n][];
        for (int i = 0; i < n; i++) {
            int row = i;
            a[i] = IntStream.range(0,i + 1)
                .map(j -> j == 0 || j == row ? 1 : a[row - 1][j] + a[row - 1][j - 1])
                .toArray();
        }
        return a;
    }
}