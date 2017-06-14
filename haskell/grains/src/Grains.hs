module Grains (square, total) where

import Data.Maybe

square :: Integer -> Maybe Integer
square 1 = Just 1
square n 
    | n > 1 && n < 65 = Just (2 ^ (n - 1))
    | otherwise = Nothing

total :: Integer
total = sum (map (fromJust . square) [1..64])