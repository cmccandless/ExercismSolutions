import java.util.*;
import java.util.stream.*;
import java.util.function.Supplier;
public class Alphametics {
    private static Set<String> operators = new HashSet<>();
    static {
        operators.add("+");
        operators.add("==");
    }

    private String equation;
    
    public Alphametics(String equation) {
        this.equation = equation;
    }

    public Map<Character, Integer> solve() throws UnsolvablePuzzleException {
        // Parse equation to get words
        List<String> words = Arrays.stream(equation.split(" "))
            .filter(w -> !operators.contains(w))
            .collect(Collectors.toList());

        // Multitasking:
        // - Get set of all letters in equation
        // - Get set of leading characters for all words
        Set<Character> letterSet = new HashSet<>();
        Set<Character> nonZero = new HashSet<>();
        for (String word : words) {
            nonZero.add(word.charAt(0));
            for (Character ch : word.toCharArray()) {
                letterSet.add(ch);
            }
        }

        // Get letterSet in array form to use for mapping key to solution
        Character[] letters = new Character[letterSet.size()];
        letters = letterSet.toArray(letters);

        // Pop right side of equation from word list
        String right = words.remove(words.size() - 1);

        // Map right characters to reversed array
        char[] rightChars = new char[right.length()];
        for (int i = 0; i < rightChars.length; i++) {
            rightChars[i] = right.charAt(rightChars.length - 1 - i);
        }

        // Map left characters to matrix, reversing each word
        char[][] leftChars = new char[words.size()][];
        for (int w = 0; w < words.size(); w++) {
            String word = words.get(w);
            int n = word.length();
            leftChars[w] = new char[n];
            for (int i = 0; i < n; i++) {
                leftChars[w][i] = word.charAt(n - 1 - i);
            }
        }
        
        // Iterate through permutations of digit string,
        // using only the permutations that are of the same length as the number 
        // of unique letters in the equation
        Supplier<String> perms = new PermutationsSupplier("0123456789", letters.length);
        String solutionKey = perms.get();
        try {
            // Not infinite; will throw EmptyStackException
            // when all valid permutations have been checked
            while (true) {
                Map<Character, Integer> solution = new HashMap<>();
                // Map key to solution
                for (int i = 0; i < solutionKey.length(); i++) {
                    solution.put(letters[i], solutionKey.charAt(i) - '0');
                }

                // Confirm no word starts with 0
                if (nonZero.stream().allMatch(ch -> solution.get(ch) != 0)) {
                    // Starting with right-most digit (keeping track of overflow),
                    // compare decoded values. If sum(left) == right, return solution
                    int carry = 0;
                    boolean viable = true;
                    for (int i = 0; viable && i < rightChars.length; i++) {
                        int digitTotal = carry % 10;
                        carry /= 10;
                        for (int w = 0; w < leftChars.length; w++) {
                            if (leftChars[w].length > i) {
                                digitTotal += solution.get(leftChars[w][i]);
                            }
                        }
                        int digit = digitTotal % 10;
                        carry += digitTotal / 10;
                        if (digit != solution.get(rightChars[i])) {
                            viable = false;
                            break;
                        }
                    }
                    if (viable && carry == 0)
                        return solution;
                }
                solutionKey = perms.get();
            }
        } catch (EmptyStackException ex) {
            throw new UnsolvablePuzzleException();
        }
    }
}
class PermutationsSupplier implements Supplier<String> {
    private Stack<String> prefixStack = new Stack<>();
    private Stack<String> stringStack = new Stack<>();
    private int terminal = 0;
    public PermutationsSupplier(String baseString) {
        prefixStack.push("");
        stringStack.push(baseString);
    }
    public PermutationsSupplier(String baseString, int n) {
        this(baseString);
        terminal = baseString.length() - n;
    }
    
    @Override
    public String get() {
        String prefix = prefixStack.pop();
        String s = stringStack.pop();
        int n = s.length();
        if (n == terminal) return prefix;
        for (int i = n - 1; i >= 0; i--) {
            prefixStack.push(prefix + s.charAt(i));
            stringStack.push(s.substring(0, i) + s.substring(i + 1, n));
        }
        return get();
    }
}
