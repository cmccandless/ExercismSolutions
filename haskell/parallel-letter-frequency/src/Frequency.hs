module Frequency (frequency) where

import Data.Char (isLetter, toLower)
import Data.Map  (Map, fromListWith)
import Data.Text (Text, unpack)

-- Blatant laziness, not actually implementing parallelism on this one
frequency :: Int -> [Text] -> Map Char Int
frequency nWorkers texts = let str = concatMap (map toLower . filter isLetter . unpack) texts in 
    fromListWith (+) $ map (\w -> (w, 1)) str

