import java.util.*;
import java.util.stream.*;
import java.util.function.Supplier;
public class Alphametics {
    private String expr;
    public Alphametics(String equation) {
        expr = equation;
    }

    private static long sub(String word, Map<Character, Integer> solution) {
        System.out.println(word);
        StringBuilder sb = new StringBuilder();
        for (char ch : word.toCharArray()) {
            sb.append(solution.get(ch));
        }
        return Long.parseLong(sb.toString());
    }

    public Map<Character, Integer> solve() throws UnsolvablePuzzleException {
        Set<String> operators = new HashSet();
        operators.add("+");
        operators.add("==");
        operators.add("=");
        operators.add(" ");
        List<String> words = Arrays.stream(expr.split(" "))
            .filter(w -> !operators.contains(w))
            .collect(Collectors.toList());
        words.stream().forEach(w -> System.out.print(w + ", "));
        System.out.println();
        String right = words.remove(words.size() - 1);
        Set<Character> letterSet = new HashSet();
        for (String word : words) {
            for (Character ch : word.toCharArray()) {
                letterSet.add(ch);
            }
        }
        Character[] letters = new Character[letterSet.size()];
        letters = letterSet.toArray(letters);
        Stream<String> combStream = combinations("0123456789", letters.length);
        for (String combo : (Iterable<String>) combStream::iterator) {
            Stream<String> permStream = permutations(combo);
            for (String solutionKey : (Iterable<String>) permStream::iterator) {
                Map<Character, Integer> solution = new HashMap();
                for (int i = 0; i < solutionKey.length(); i++) {
                    solution.put(letters[i], solutionKey.charAt(i) - '0');
                }
                if (
                    solution.get(right.charAt(0)) != 0 &&
                    words.stream()
                        .allMatch(w -> solution.get(w.charAt(0)) != 0) &&
                    sub(right, solution) == words.stream()
                        .mapToLong(word -> sub(word, solution))
                        .sum()
                )
                    return solution;
            }
        }

        throw new UnsolvablePuzzleException();
    }

    private static long factorial(int n) {
        long result = 1;
        for (long i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    public static Stream<String> permutations(String str) {
        return permutations(str, str.length());
    }

    public static Stream<String> permutations(String str, int n) {
        Supplier<String> permSup = new PermutationsSupplier(str);
        return Stream.generate(permSup)
            .limit(factorial(str.length()))
            .filter(s -> s.length() == n);
    }

    public static Stream<String> combinations(String str) {
        Stream<String> stream = combinations(str, 0);
        for (int i = 1; i < str.length(); i++)
            stream = Stream.concat(stream, combinations(str, i));
        return stream;
    }

    public static Stream<String> combinations(String str, int n) {
        Supplier<String> comSup = new CombinationsSupplier(str);
        int size = str.length();
        long count = factorial(size) / (factorial(size - n) * factorial(n));
        return Stream.generate(comSup)
            .filter(s -> s.length() == n)
            .limit(count);
    }
}
class PermutationsSupplier implements Supplier<String> {
    private Stack<String> prefixStack = new Stack();
    private Stack<String> stringStack = new Stack();
    public PermutationsSupplier(String baseString) {
        prefixStack.push("");
        stringStack.push(baseString);
    }
    
    @Override
    public String get() {
        String prefix = prefixStack.pop();
        String s = stringStack.pop();
        int n = s.length();
        if (n == 0) return prefix;
        for (int i = n - 1; i >= 0; i--) {
            prefixStack.push(prefix + s.charAt(i));
            stringStack.push(s.substring(0, i) + s.substring(i + 1, n));
        }
        return get();
    }
}
class CombinationsSupplier implements Supplier<String> {
    private long index = 0;
    private String baseString;
    public CombinationsSupplier(String baseString) {
        this.baseString = baseString;
    }
    @Override
    public String get() {
        StringBuilder sb = new StringBuilder();
        int n = baseString.length();
        for (int i = n; i >= 0; i--) {
            if (((1 << i) & index) != 0)
                sb.append(baseString.charAt(n - 1 - i));
        }
        index++;
        return sb.toString();
    }
}
