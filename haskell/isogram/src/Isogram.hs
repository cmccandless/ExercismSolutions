module Isogram (isIsogram) where

import Data.Char (isAlpha, toLower)
import Data.List (nub)

isIsogram :: String -> Bool
isIsogram = let f xs = (length . nub $ map toLower xs) == length xs
            in f . filter isAlpha
