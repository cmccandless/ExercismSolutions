module SumOfMultiples (sumOfMultiples) where

import Data.List

sumOfMultiples :: [Integer] -> Integer -> Integer
sumOfMultiples factors limit = sum (nub (concatMap (\a -> [a, a+a..(limit - 1)]) factors))
