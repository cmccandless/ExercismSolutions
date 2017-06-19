import java.util.*;
import java.util.stream.*;

public class PythagoreanTriplet {
    private int a, b, c;
    public PythagoreanTriplet(int a, int b, int c) {
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public boolean isPythagorean() {
        return (a * a + b * b) == (c * c);
    }
    public int calculateSum() {
        return a + b + c;
    }
    public long calculateProduct() {
        return a * b * c;
    }
    public static TripletGenerator makeTripletsList() {
        return new TripletGenerator();
    }
}