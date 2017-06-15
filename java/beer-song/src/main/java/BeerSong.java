import java.util.stream.*;

public class BeerSong {
    private static String bottles(int v) {
        return v == 0 ? "No more bottles of beer" :
            String.format("%s bottle%s of beer", (v + 100) % 100, v != 1 ? "s" : "");
    }
    public static String verse(int v) {
        return verse(v, bottles(v));
    }
    private static String action(int v) {
        return v == 0 ? "Go to the store and buy some more" :
            String.format("Take %s down and pass it around", v == 1 ? "it" : "one");
    }
    private static String verse(int v, String b) {
        return String.format("%s on the wall, %s.\n%s, %s on the wall.\n\n", 
            b, 
            b.toLowerCase(), 
            action(v), 
            bottles(v - 1).toLowerCase());
    }
    public static String sing(int start, int stop) {
        return IntStream.iterate(start, i -> i - 1)
            .limit(start - stop + 1)
            .mapToObj(BeerSong::verse)
            .collect(Collectors.joining(""));
    }
    public static String singSong() {
        return sing(99,0);
    }
}