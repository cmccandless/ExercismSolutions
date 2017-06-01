import java.util.*;
import java.util.stream.*;

final class DiamondPrinter {
    private static <T> Stream<T> mirror(Stream<T> s) {
        List<T> a = s.collect(Collectors.toList());
        return Stream.concat(a.stream(), 
            IntStream.range(1,a.size())
                .mapToObj(i -> a.get(a.size() - 1 - i)));
    }
    private static String pad(int ch, char max) {
        String left = new String(new char[max - ch]);
        String right = new String(new char[ch - 'A']);
        return (left + (char)ch + right).replace("\0", " ");
    }
    private static String makeLine(int ch, char max) {
        return mirror(pad(ch,max).chars()
            .mapToObj(c -> Character.toString((char)c)))
            .collect(Collectors.joining(""))
            .toString();
    }
    public static List<String> printToList(char character) {
        return mirror(IntStream.rangeClosed('A', character)
            .mapToObj(c -> makeLine(c, character)))
            .collect(Collectors.toList());
    }
}
