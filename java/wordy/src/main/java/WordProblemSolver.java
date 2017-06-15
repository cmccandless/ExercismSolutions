import java.util.*;

final class WordProblemSolver {
    private static Set<String> validWords = new HashSet() {{
       add("What");
       add("is");
       add("by");
       add("plus");
       add("minus");
       add("multiplied");
       add("divided");
    }};
    public int solve(String eq) {
        int result = 0;
        String op = "plus";
        for (String word : eq.split("[\\s?]+")) {
            try {
                int x = Integer.parseInt(word);
                switch(op) {
                    case "is":
                    case "plus": result += x; break;
                    case "minus": result -= x; break;
                    case "times": 
                    case "multiplied": result *= x; break;
                    case "divided": result /= x; break;
                }
            }
            catch (NumberFormatException ex) {
                if (!validWords.contains(word)) 
                    throw new IllegalArgumentException("I'm sorry, I don't understand the question!");
                if (!word.equals("by")) op = word;
            }
        }
        return result;
    }
}
