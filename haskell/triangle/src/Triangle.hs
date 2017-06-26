module Triangle (TriangleType(..), triangleType) where

import Data.List (permutations)

data TriangleType = Equilateral
                  | Isosceles
                  | Scalene
                  | Illegal
                  deriving (Eq, Show)
                  
invalid :: Real a => a -> a -> a -> Bool
invalid a b c = a >= b + c || b >= a + c || c >= a + b
                  
triangleType :: Real a => a -> a -> a -> TriangleType
triangleType a b c 
    | invalid a b c = Illegal
    | score == 3 = Equilateral
    | score == 1 = Isosceles
    | otherwise = Scalene
    where
        score = length $ filter id [a==b,b==c,a==c]
        