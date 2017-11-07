module PerfectNumbers (classify, Classification(..)) where

data Classification = Deficient | Perfect | Abundant deriving (Eq, Show)

factors :: Int -> [Int]
factors 1 = []
factors n = filter (\x -> mod n x == 0) [1..max (n - 1) 1]

classify :: Int -> Maybe Classification
classify n = if n < 1 
             then Nothing
             else case compare (sum $ factors n) n of
                LT -> Just Deficient
                EQ -> Just Perfect
                GT -> Just Abundant
