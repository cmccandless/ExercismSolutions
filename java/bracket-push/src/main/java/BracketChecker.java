import java.util.*;

final class BracketChecker {
    private static HashMap<Character, Character> match = new HashMap<>();
    private String s;
    private static Character match(Character open) {
        switch(open) {
            case '{': return '}';
            case '(': return ')';
            case '[': return ']';
        }
        return 0;
    }
    public BracketChecker(String s) {
        this.s = s;
    }
    public boolean areBracketsMatchedAndNestedCorrectly() {
        Stack<Character> close = new Stack<>();
        for (char ch : s.toCharArray()) {
            if (match.containsKey(ch)) close.push(match(ch));
            else if (match.values().contains(ch) && 
                (close.isEmpty() || close.pop() != ch)) return false;
        }
        return close.isEmpty();
    }
}
