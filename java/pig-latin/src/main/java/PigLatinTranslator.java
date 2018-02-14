import java.util.Arrays;
import java.util.stream.*;

public final class PigLatinTranslator {
    static final String consonents = "s?(?:qu|ch)|[st]hr?|y[^t]|x[^r]|[^aeiou]";
    static final String pattern = "^(" + consonents + ")?((yt|xr|[aeiou])\\w*)$";
    public String translate(String phrase) {
        return Arrays.stream(phrase.split(" "))
            .map(w -> w.replaceAll(pattern, "$2$1ay"))
            .collect(Collectors.joining(" "));
    }
}
