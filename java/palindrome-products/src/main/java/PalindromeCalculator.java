import java.util.*;
import java.util.stream.*;

public final class PalindromeCalculator {
    private static boolean isPalindrome(long n) {
        char[] s = Long.toString(n).toCharArray();
        return IntStream.range(0,s.length / 2)
            .allMatch(i -> s[i] == s[s.length - i - 1]);
    }
    private List<List<Integer>> newList(int i, int j) {
        return new ArrayList<>(Arrays.asList(Arrays.asList(i, j)));
    }
    public SortedMap<Long, List<List<Integer>>> 
        getPalindromeProductsWithFactors(int start, int stop) {
        SortedMap<Long, List<List<Integer>>> result = new TreeMap<>();
        for (int i = start; i <= stop; i++) {
            for (int j = i; j <= stop; j++) {
                long prod = i * (long)j;
                if (result.containsKey(prod)) 
                    result.get(prod).add(Arrays.asList(i, j));
                else if (isPalindrome(prod)) 
                    result.put(prod, newList(i, j));
            }
        }
        return result;
    }
}
