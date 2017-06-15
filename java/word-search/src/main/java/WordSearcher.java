import java.util.*;
import java.util.stream.*;

public final class WordSearcher {
    private static Pair offset = new Pair(1, 1);
    private static Pair add(Pair p, int x, int y) {
        return new Pair(p.getX() + x, p.getY() + y);
    }
    private static boolean isMatch(String word, int i, char[][] grid, int x, int y) {
        return i < word.length() && 
            0 <= y && y < grid.length &&
            0 <= x && x < grid[y].length &&
            word.charAt(i) == grid[y][x];
    }
    private static WordLocation searchNullable(String word, char[][] grid) {
        for (int y = 0; y < grid.length; y++) {
            for (int x = 0; x < grid[y].length; x++) {
                if (!isMatch(word, 0, grid, x, y)) continue;
                Pair p = add(offset, x, y);
                for (int dy = -1; dy < 2; dy++) {
                    for (int dx = -1; dx < 2; dx++) {
                        if (dy == 0 && dx == 0) continue;
                        int x1 = x, y1 = y, i = 1;
                        for (; isMatch(word, i, grid, x1 += dx, y1 += dy); i++);
                        if (i == word.length()) {
                            Pair p1 = add(offset, x1 - dx, y1 - dy);
                            return new WordLocation(p, p1);
                        }
                    }
                }
            }
        }
        return null;
    }
    public static Optional<WordLocation> search(String word, char[][] grid) {
        return Optional.ofNullable(searchNullable(word, grid));
    }
    public static Map<String, Optional<WordLocation>> search(Set<String> words, char[][] grid) {
        return words.stream().collect(Collectors.toMap(w -> w, w -> search(w, grid)));
    }
}