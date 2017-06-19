module Triangle (TriangleType(..), triangleType) where

import Data.List (permutations)

data TriangleType = Equilateral
                  | Isosceles
                  | Scalene
                  | Illegal
                  deriving (Eq, Show)
                  
invalid :: Real a => a -> a -> a -> Bool
invalid a b c = a == 0 || any (\p -> head p >= sum (drop 1 p)) (permutations [a,b,c])
                  
triangleType :: Real a => a -> a -> a -> TriangleType
triangleType a b c 
    | invalid a b c = Illegal
    | score == 6 = Equilateral
    | score == 2 = Isosceles
    | otherwise = Scalene
    where
        score = length $ filter (\p -> head p == (p !! 1)) (permutations [a,b,c])
        