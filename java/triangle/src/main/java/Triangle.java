import java.util.Arrays;

class Triangle {
    double[] sides;
    Triangle(double side1, double side2, double side3) throws TriangleException {
        sides = new double[] {side1, side2, side3};
        Arrays.sort(sides);
        if (sides[0] < 0 || (sides[2] >= sides[0] + sides[1])) 
            throw new TriangleException();
    }

    TriangleKind getKind() {
        int r = sides[0] == sides[1] ? 1 : 0 + sides[1] == sides[2] ? 1 : 0;
        return TriangleKind.values()[2-r];
    }

}
