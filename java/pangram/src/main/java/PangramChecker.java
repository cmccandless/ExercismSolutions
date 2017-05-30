import java.text.Normalizer;
import java.util.*;

public class PangramChecker {
    public static void AddSet(HashSet<Character> a, HashSet<Character> b) {
        for (Character x : b) a.add(x);
    }
    public boolean isPangram(String input) {
        return Normalizer.normalize(input.toLowerCase(), Normalizer.Form.NFD)
            .chars()
            .filter(Character::isLetter)
            .collect(HashSet<Character>::new,
                (r, c) -> r.add((char)c),
                PangramChecker::AddSet)
            .size() == 26;
    }   
}
