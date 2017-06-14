module Squares (difference, squareOfSums, sumOfSquares) where

square :: Integral a => a -> a
square n = n * n

upTo :: Integral a => a -> [a]
upTo n = take (fromIntegral n :: Int) [1..]

squareOfSums :: Integral a => a -> a
squareOfSums = square . sum . upTo

sumOfSquares :: Integral a => a -> a
sumOfSquares = sum . map square . upTo

difference :: Integral a => a -> a
difference n = squareOfSums n - sumOfSquares n
