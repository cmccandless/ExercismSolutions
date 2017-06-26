module Anagram (anagramsFor) where

import Data.Char

anagramsFor :: String -> [String] -> [String]
anagramsFor xs = filter ((==) sxs . sorted . map toLower) 
    where
        sxs = sorted $ map toLower xs

sorted :: Ord a => [a] -> [a]
sorted [] = []
sorted (p:xs) = sorted (filter (< p) xs) ++ [p] ++ sorted (filter (> p) xs)