import java.util.HashMap;

final class Scrabble {
    private int score;
    private static HashMap<String, Integer> scores = new HashMap<String, Integer>();
    static {
        scores.put("aeioulnrst", 1);
        scores.put("dg", 2);
        scores.put("bcmp", 3);
        scores.put("fhvwy", 4);
        scores.put("k", 5);
        scores.put("jx", 8);
        scores.put("qz", 10);
    }
    
    Scrabble(String word) {
        score = (word == null || word.trim().isEmpty()) ? 0 :
            word
                .toLowerCase()
                .chars()
                .mapToObj(c -> scores
                    .entrySet()
                    .stream()
                    .filter(e -> e.getKey().indexOf((char)c) >= 0)
                    .findFirst()
                    .get().getValue())
                .mapToInt(Integer::intValue)
                .sum();
    }

    int getScore() {
        return score;
    }
}
