using System;

public struct ComplexNumber
{
    private double r {get; set;}
    private double i {get; set;}
    public ComplexNumber(double r, double i)
    {
        this.r = r;
        this.i = i;
    }

    public double Real() => r;

    public double Imaginary() => i;

    public ComplexNumber Mul(ComplexNumber other) => 
        new ComplexNumber(r * other.r - i * other.i, r * other.i + i * other.r);

    public ComplexNumber Add(ComplexNumber other) => new ComplexNumber(r + other.r, i + other.i);

    public ComplexNumber Sub(ComplexNumber other) => new ComplexNumber(r - other.r, i - other.i);

    public ComplexNumber Div(ComplexNumber other) 
    {
        var div = other.r * other.r + other.i * other.i;
        return new ComplexNumber((r * other.r + i * other.i) / div, (i * other.r - r * other.i) / div);
    } 

    public double Abs() => Math.Sqrt(r * r + i * i);

    public ComplexNumber Conjugate() => new ComplexNumber(r, -i);
    
    public ComplexNumber Exp() => new ComplexNumber(Math.Pow(Math.E, r) * Math.Cos(i), Math.Sin(i));
}