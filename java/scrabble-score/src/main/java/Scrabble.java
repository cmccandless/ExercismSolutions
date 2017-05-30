import java.util.HashMap;

final class Scrabble {
    private String word;
    private int score;
    private static HashMap<String, Integer> scores = new HashMap<String, Integer>()
    {{
        put("aeioulnrst", 1);
        put("dg", 2);
        put("bcmp", 3);
        put("fhvwy", 4);
        put("k", 5);
        put("jx", 8);
        put("qz", 10);
    }};
    
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
