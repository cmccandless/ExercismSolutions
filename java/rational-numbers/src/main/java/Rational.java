import java.math.*;

class Rational {
    private int numerator, denominator;

    Rational(int numerator, int denominator) {
        BigInteger b1 = BigInteger.valueOf(numerator);
        BigInteger b2 = BigInteger.valueOf(denominator);
        BigInteger bgcd = b1.gcd(b2);
        int gcd = bgcd.intValue();
        if (denominator < 0) {
            gcd *= -1;
        }
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;
    }

    int getNumerator() {
        return this.numerator;
    }

    int getDenominator() {
        return this.denominator;
    }

    @Override
    public String toString() {
        return String.format("%d/%d", this.getNumerator(), this.getDenominator());
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null || !this.getClass().isAssignableFrom(obj.getClass())) {
            return false;
        }

        Rational other = (Rational) obj;
        return this.getNumerator() == other.getNumerator()
            && this.getDenominator() == other.getDenominator();
    }

    @Override
    public int hashCode() {
        int prime = 31;
        int result = 1;
        result = prime * result + this.getNumerator();
        result = prime * result + this.getDenominator();

        return result;
    }

    public Rational abs() {
        return new Rational(Math.abs(numerator), denominator);
    }

    public Rational add(Rational other) {
        return new Rational(
            numerator * other.denominator + other.numerator * denominator,
            denominator * other.denominator
        );
    }

    public Rational subtract(Rational other) {
        return add(new Rational(-other.numerator, other.denominator));
    }

    public Rational multiply(Rational other) {
        return new Rational(
            numerator * other.numerator,
            denominator * other.denominator
        );
    }

    public Rational divide(Rational other) {
        return new Rational(
            numerator * other.denominator,
            denominator * other.numerator
        );
    }

    public Rational pow(int exponent) {
        if (exponent == 0) return new Rational(1, 1);
        Rational r = this;
        for (; exponent > 1; exponent--)
            r = r.multiply(this);
        return r;
    }

    public double exp(double x) {
        return Math.pow(Math.pow(x, 1.0 / denominator), numerator);
    }
}
