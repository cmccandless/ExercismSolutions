module Anagram (anagramsFor) where

import Data.Char

asLower :: String -> String
asLower = map toLower

sorted :: Ord a => [a] -> [a]
sorted [] = []
sorted (p:xs) = sorted (filter (< p) xs) ++ [p] ++ sorted (filter (>= p) xs)

sortedLower :: String -> String
sortedLower = sorted . asLower

filterNotSame :: String -> [String] -> [String]
filterNotSame xs = filter ((/=) (asLower xs) . asLower)

filterNotDuplicates :: [String] -> [String]
filterNotDuplicates (p:xs) = p : filterNotSame p xs

filterSortedEqual :: String -> [String] -> [String]
filterSortedEqual xs = filter ((==) (sortedLower xs) . sortedLower)

anagramsFor :: String -> [String] -> [String]
anagramsFor xs = filterSortedEqual xs . filterNotSame xs . filterNotDuplicates