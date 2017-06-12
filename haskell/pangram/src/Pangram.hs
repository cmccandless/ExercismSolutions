module Pangram (isPangram) where

import Data.Char
import Data.List

isPangram :: String -> Bool
isPangram text 
    | any (not . isLetter) text = isPangram (filter isLetter text)
    | otherwise = length (nub text) == 26
