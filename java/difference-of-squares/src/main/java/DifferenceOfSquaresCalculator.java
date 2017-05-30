import java.util.stream.IntStream;

final class DifferenceOfSquaresCalculator {

    int computeSquareOfSumTo(final int input) {
        return (int)Math.pow(IntStream.rangeClosed(1,input).sum(),2);
    }

    int computeSumOfSquaresTo(final int input) {
        return IntStream.rangeClosed(1,input).map(i -> i * i).sum();
    }

    int computeDifferenceOfSquares(final int input) {
        return computeSquareOfSumTo(input) - computeSumOfSquaresTo(input);
    }

}

