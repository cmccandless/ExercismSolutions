import java.util.HashMap;

class RaindropConverter {
    private static HashMap<Integer, String> words = new HashMap<Integer, String>()
    {{
       put(3, "Pling");
       put(5, "Plang");
       put(7, "Plong");
    }};
    String convert(int number) {
        String result = words.entrySet()
            .stream()
            .filter(e -> (number % e.getKey()) == 0)
            .map(e -> e.getValue())
            .collect(StringBuilder::new,
                StringBuilder::append,
                StringBuilder::append)
            .toString();
        return result.isEmpty() ? Integer.toString(number) : result;
    }
}
