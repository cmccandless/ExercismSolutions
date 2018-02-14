import java.util.*;

public final class RomanNumeral {
    private static final Map<Integer, String> table = new LinkedHashMap<>();
    static {
       table.put(1000, "M");
       table.put(900, "CM");
       table.put(500, "D");
       table.put(400, "CD");
       table.put(100, "C");
       table.put(90, "XC");
       table.put(50, "L");
       table.put(40, "XL");
       table.put(10, "X");
       table.put(9, "IX");
       table.put(5, "V");
       table.put(4, "IV");
       table.put(1, "I");
    }
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
