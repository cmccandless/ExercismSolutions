import java.util.*;
import java.util.stream.*;

public final class Allergies {
    private int allergen;
    public Allergies(int a) {
        allergen = a;
    }
    public boolean isAllergicTo(Allergen a) {
        return (a.getScore() & allergen) > 0;
    }
    public List<Allergen> getList() {
        return Arrays.stream(Allergen.values())
            .filter(a -> isAllergicTo(a))
            .collect(Collectors.toList());
    }
}