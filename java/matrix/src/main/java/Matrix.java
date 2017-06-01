import java.util.Arrays;
import java.util.List;
import java.util.stream.*;

public final class Matrix
{
    private int[][] mtx;
    public Matrix(String s) {
        mtx = Arrays.stream(s.split("\n"))
            .map(line -> Arrays.stream(line.split(" "))
                .mapToInt(Integer::parseInt)
                .toArray())
            .toArray(int[][]::new);
    }
    public int getRowsCount() {
        return mtx.length;
    }
    public int[] getRow(int r) {
        return mtx[r];
    }
    public int getColumnsCount() {
        return mtx[0].length;
    }
    public int[] getColumn(int c) {
        return IntStream.range(0,mtx.length)
            .map(r -> mtx[r][c])
            .toArray();
    }
}