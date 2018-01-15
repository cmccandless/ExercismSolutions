import java.util.stream.*;
class Proverb {
    private String[] words;

    Proverb(String[] words) {
        this.words = words;
    }

    private String line(int num) {
        return num == words.length ?
            String.format("And all for the want of a %s.", words[0]) :
            String.format("For want of a %s the %s was lost.", words[num - 1], words[num]);
    }

    String recite() {
        return IntStream.range(1, words.length + 1)
            .mapToObj(this::line)
            .collect(Collectors.joining("\n"));
    }

}
