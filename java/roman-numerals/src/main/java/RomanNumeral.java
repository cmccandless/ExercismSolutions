import java.util.*;
import java.util.stream.*;

public final class RomanNumeral {
    private static final Map<Integer, String> table = new LinkedHashMap() {{
       put(1000, "M");
       put(900, "CM");
       put(500, "D");
       put(400, "CD");
       put(100, "C");
       put(90, "XC");
       put(50, "L");
       put(40, "XL");
       put(10, "X");
       put(9, "IX");
       put(5, "V");
       put(4, "IV");
       put(1, "I");
    }};
    private int value;
    public RomanNumeral(int n) {
        value = n;
    }
    public String getRomanNumeral() {
        int n = value;
        StringBuilder s = new StringBuilder();
        for (int k : table.keySet()) {
            if (n == 0) break;
            while (n >= k) {
                n -= k;
                s.append(table.get(k));
            }
        }
        return s.toString();
    }
}