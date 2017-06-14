module DNA (nucleotideCounts) where

import Data.Map (Map, insertWith, fromListWith)

nucs :: String
nucs = "ACGT"

baseMap :: [(Char, Int)]
baseMap = zip nucs [0,0..]

nucleotideCounts :: String -> Either String (Map Char Int)
nucleotideCounts xs 
    | all (`elem` nucs) xs = Right (fromListWith (+) (baseMap ++ zip xs [1,1..]))
    | otherwise = Left "Invalid!"
