module Sieve (primesUpTo) where

minus [] _ = []
minus a [] = a
minus a@(x:xs) b@(y:ys) = case compare x y of 
    LT -> x : minus xs b
    EQ -> minus xs ys
    GT -> minus a ys

primesUpTo :: Integer -> [Integer]
primesUpTo m
    | m < 2 = []
    | otherwise = 2 : sieve [3,5..m]
    where
        sieve [] = []
        sieve (x:xs) = x : sieve (xs `minus` [x,x+x..m])