public class ComplexNumber {
    private double real, imag;
    public ComplexNumber(double real, double imag) {
        this.real = real;
        this.imag = imag;
    }
    public double getReal() { return real; }
    public double getImag() { return imag; }
    public double abs() { return Math.sqrt(real * real + imag * imag); }
    public ComplexNumber add(ComplexNumber other) {
        return new ComplexNumber(real + other.real, imag + other.imag);
    }
    public ComplexNumber minus(ComplexNumber other) {
        return new ComplexNumber(real - other.real, imag - other.imag);
    }
    public ComplexNumber times(ComplexNumber other) {
        return new ComplexNumber(real * other.real - imag * other.imag,
                                 real * other.imag + imag * other.real);
    }
    public ComplexNumber div(ComplexNumber other) {
        double divisor = (other.real * other.real + other.imag * other.imag);
        double newReal = real * other.real + imag * other.imag;
        double newImag = imag * other.real - real * other.imag;
        return new ComplexNumber(newReal / divisor, newImag / divisor);
    }
    public ComplexNumber conjugate() { return new ComplexNumber(real, -imag); }
    public ComplexNumber exponentialOf() {
        return new ComplexNumber(Math.pow(Math.E, real) * Math.cos(imag), 
                                 Math.sin(imag));
    }
}