module Pangram (isPangram) where

import Data.Char
import Data.List

isPangram :: String -> Bool
isPangram = (==) 26 . length . nub . filter isLetter