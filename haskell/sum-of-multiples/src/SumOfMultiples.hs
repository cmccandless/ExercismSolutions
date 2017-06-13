module SumOfMultiples (sumOfMultiples) where

import Data.List

sumOfMultiples :: [Integer] -> Integer -> Integer
sumOfMultiples factors limit = sum (nub (concatMap (\a -> takeWhile (<limit) [a, a+a..]) factors))
