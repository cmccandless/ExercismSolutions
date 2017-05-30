import java.util.List;
import java.util.stream.IntStream;
import java.util.stream.Collectors;

final class HandshakeCalculator {

    List<Signal> calculateHandshake(int number) {
        return IntStream.range(0,Signal.values().length)
            .map(i -> (number & 0x10) > 0 ? Signal.values().length - 1 - i : i)
            .filter(i -> (number & (1 << i)) > 0)
            .mapToObj(i -> Signal.values()[i])
            .collect(Collectors.toList());
    }

}
