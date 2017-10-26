class ComplexNumber
    attr_reader :real, :imaginary
    def initialize(real, imaginary)
        @real = real
        @imaginary = imaginary
    end
    def ==(other)
        real == other.real && imaginary == other.imaginary
    end
    def +(other)
        ComplexNumber.new(real + other.real, imaginary + other.imaginary)
    end
    def -(other)
        ComplexNumber.new(real - other.real, imaginary - other.imaginary)
    end
    def *(other)
        ComplexNumber.new(real * other.real - imaginary * other.imaginary,
                          real * other.imaginary + imaginary * other.real)
    end
    def /(other)
        div = (other.real * other.real + other.imaginary * other.imaginary).to_f
        ComplexNumber.new((real * other.real + imaginary * other.imaginary) / div,
                          (imaginary * other.real - real * other.imaginary) / div)
    end
    def abs
        Math.sqrt(real * real + imaginary * imaginary)
    end
    def conjugate
        ComplexNumber.new(real, -imaginary)
    end
    def exp
        ComplexNumber.new(Math.exp(real) * Math.cos(imaginary), Math.sin(imaginary).round)
    end
end
module BookKeeping
    VERSION = 1
end