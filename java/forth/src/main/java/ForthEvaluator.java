import java.util.*;

public class ForthEvaluator {
    private static final String ERR_UNDERFLOW = 
        "%s requires that the stack contain at least %d value%s";
    private static final String ERR_DIV_BY_0 = 
        "Division by 0 is not allowed";
    private static final String ERR_BAD_REDEFINE = 
        "Cannot redefine numbers";
    private static final String ERR_UNKNOWN =
        "No definition available for operator \"%s\"";
    private static boolean isNumber(String s) {
        if (s.charAt(0) == '-') s = s.substring(1);
        if (s.trim().isEmpty()) return false;
        return s.codePoints().allMatch(c -> Character.isDigit((char)c));
    }
    private static void stackUnderflow(String label, int needed) {
        String plural = needed == 1 ? "" : "s";
        String msg = String.format(ERR_UNDERFLOW, label, needed, plural);
        throw new IllegalArgumentException(msg);
    }
    public List<Integer> evaluateProgram(List<String> input) {
        LinkedList<String> inputStack = new LinkedList<>();
        for (String line : input) {
            for (String word : line.split(" "))
                inputStack.offer(word);
        }
        Map<String, List<String>> defines = new HashMap<>();
        LinkedList<Integer> s = new LinkedList<>();
        while (!inputStack.isEmpty()) {
            String x = inputStack.pop();
            System.out.println(x);
            if (isNumber(x)) {
                s.push(Integer.parseInt(x));
                continue;
            }
            if (defines.containsKey(x.toUpperCase())) {
                for (String w : defines.get(x.toUpperCase())) 
                    inputStack.push(w);
                continue;
            }
            switch(x.toUpperCase()) {
                case "+": 
                    if (s.size() < 2)
                        stackUnderflow("Addition", 2);
                    s.push(s.pop() + s.pop()); 
                    break;
                case "-": 
                    if (s.size() < 2)
                        stackUnderflow("Subtraction", 2);
                    s.push(-s.pop() + s.pop()); 
                    break;
                case "*": 
                    if (s.size() < 2)
                        stackUnderflow("Multiplication", 2);
                    s.push(s.pop() * s.pop()); 
                    break;
                case "/": 
                    if (s.size() < 2)
                        stackUnderflow("Division", 2);
                    if (s.peek() == 0) 
                        throw new IllegalArgumentException(ERR_DIV_BY_0);
                    s.push((int)((1 / (double)s.pop()) * s.pop()));
                    break;
                case "DUP": 
                    if (s.isEmpty())
                        stackUnderflow("Duplicating", 1);
                    s.push(s.peek()); break;
                case "DROP": 
                    if (s.isEmpty())
                        stackUnderflow("Dropping", 1);
                    s.pop(); break;
                case "SWAP": 
                    if (s.size() < 2)
                        stackUnderflow("Swapping", 2);
                    for (int t : Arrays.asList(s.pop(), s.pop()))
                        s.push(t);
                    break;
                case "OVER":
                    if (s.size() < 2)
                        stackUnderflow("Overing", 2);
                    for (int t : Arrays.asList(s.pop(), s.peek()))
                        s.push(t);
                    break;
                case ":":
                    String key = inputStack.pop();
                    if (isNumber(key)) 
                        throw new IllegalArgumentException(ERR_BAD_REDEFINE);
                    LinkedList<String> values = new LinkedList<>();
                    x = inputStack.pop();
                    while (!x.equals(";")) {
                        values.push(x);
                        x = inputStack.pop();
                    }
                    defines.put(key.toUpperCase(), values);
                    break;
                default:
                    String msg = String.format(ERR_UNKNOWN, x);
                    throw new IllegalArgumentException(msg);
            }
        }
        Collections.reverse(s);
        return s;
    }
}
