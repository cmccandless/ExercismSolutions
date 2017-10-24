module ComplexNumbers
(Complex,
 conjugate,
 abs,
 real,
 imaginary,
 mul,
 add,
 sub,
 div,
 complex) where

import Prelude hiding (div, abs)

-- Data definition -------------------------------------------------------------
type Complex a = (a, a)

complex :: (a, a) -> Complex a
complex = id

-- unary operators -------------------------------------------------------------
conjugate :: Num a => Complex a -> Complex a
conjugate (r, i) = (r, -i)

abs :: Floating a => Complex a -> a
abs (r, i) = sqrt (r * r + i * i)

real :: Num a => Complex a -> a
real = fst

imaginary :: Num a => Complex a -> a
imaginary = snd

-- binary operators ------------------------------------------------------------
mul :: Num a => Complex a -> Complex a -> Complex a
mul (a, b) (c, d) = (a * c - b * d, a * d + b * c)

add :: Num a => Complex a -> Complex a -> Complex a
add (a, b) (c, d) = (a + c, b + d)

sub :: Num a => Complex a -> Complex a -> Complex a
sub (a, b) (c, d) = (a - c, b - d)

div :: Fractional a => Complex a -> Complex a -> Complex a
div (a, b) (c, d) = let divider = c * c + d * d
                    in ((a * c + b * d) / divider, (b * c - a * d) / divider)
