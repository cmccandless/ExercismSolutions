import java.util.*;
import java.util.stream.*;

public final class MinesweeperBoard {
    public char[][] board;
    public MinesweeperBoard(List<String> board) {
        if (board == null)
            throw new IllegalArgumentException("Input board may not be null.");
        if (!board.stream().allMatch(line -> line.length() == board.get(0).length()))
            throw new IllegalArgumentException("Input board rows must all have the same number of columns.");
        if (!board.stream().allMatch(MinesweeperBoard::validateLine))
            throw new IllegalArgumentException("Input board can only contain the characters ' ' and '*'.");
        this.board = board.stream()
            .map(s -> s.toCharArray())
            .toArray(char[][]::new);
    }
    private static boolean validateLine(String line) {
        return line.codePoints().allMatch(ch -> ch == ' ' || ch == '*');
    }
    private int countMines(int x, int y) {
        return IntStream.range(y - 1, y + 2)
            .filter(j -> j >= 0 && j < board.length)
            .mapToObj(j -> IntStream.range(x - 1, x + 2)
                .filter(i -> i >= 0 && i < board[j].length &&
                    (i != x || j != y) &&
                    board[j][i] == '*')
                .reduce(0, (a, b) -> a + 1))
            .reduce(0, (a, b) -> a + b);
    }
    private char getChar(int x, int y) {
        if (board[y][x] != ' ') return board[y][x];
        int count = countMines(x, y);
        return count == 0 ? ' ' : (char)(count + '0');
    }
    public List<String> getAnnotatedRepresentation() {
        return IntStream.range(0, board.length)
            .mapToObj(y -> IntStream.range(0, board[y].length)
                .mapToObj(x -> getChar(x, y))
                .collect(StringBuilder::new,
                    StringBuilder::append,
                    StringBuilder::append)
                .toString())
            .collect(Collectors.toList());
    }
}
