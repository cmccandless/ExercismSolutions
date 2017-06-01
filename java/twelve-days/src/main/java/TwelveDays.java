import java.util.stream.Collectors;
import java.util.stream.IntStream;

public final class TwelveDays {
    private static String[] ord = {
        "first", "second", "third", "fourth",
        "fifth", "sixth", "seventh", "eighth",
        "ninth", "tenth", "eleventh", "twelfth"
    };
    private static String[] gift = {
        "a Partridge in a Pear Tree.",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming"
    };
    public static String verse(int n) {
        return String.format("On the %s day of Christmas my true love gave to me, %s\n",
            ord[n - 1], IntStream.range(0,n)
                .map(i -> n - 1 - i)
                .mapToObj(i -> (n > 1 && i == 0 ? "and " : "") + gift[i])
                .collect(Collectors.joining(", ")));
    }
    public static String verses(int start, int stop) {
        return IntStream.rangeClosed(start, stop)
            .mapToObj(TwelveDays::verse)
            .collect(Collectors.joining("\n"));
    }
    public static String sing() {
        return verses(1,12);
    }
}