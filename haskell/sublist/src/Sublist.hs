module Sublist (Sublist(..), sublist) where

data Sublist = Equal | Sublist | Superlist | Unequal deriving (Eq, Show)

sublist :: Eq a => [a] -> [a] -> Sublist
sublist [] []   = Equal
sublist _ []    = Superlist
sublist xss yss = case compare (length xss) (length yss) of
    GT -> invert (classify yss xss) 
    EQ -> if and $ zipWith (==) xss yss then Equal else Unequal
    LT -> classify xss yss
    where 
        invert c = if c == Sublist then Superlist else Unequal
        classify [] _  = Sublist
        classify _ []  = Unequal
        classify xss@(x:xs) (y:ys)
            | lx > length ys = Unequal
            | x == y && (and . zipWith (==) xs $ take lx ys) = Sublist
            | otherwise = classify xss ys
                where lx = length xs