module Beer (song) where

import Data.Char

wall :: String
wall = " on the wall"

strToLower :: String -> String
strToLower = map toLower

bottles :: Integer -> String
bottles n =  count ++ bottles ++ " of beer" where
        count = if n > 0 then show n else "No more"
        bottles = if n == 1 then " bottle" else " bottles"
    
verseSecond :: Integer -> String
verseSecond n | n == 0 = "Go to the store and buy some more, "
    | otherwise = "Take "++one++" down and pass it around, " where
        one = if n == 1 then "it" else "one"
        
dec :: Integer -> Integer
dec n = mod (n + 99) 100

verse :: Integer -> String
verse n = first ++ second where
        bn = bottles n
        first = bn ++ wall ++ ", " ++ strToLower bn ++ ".\n"
        second = verseSecond n ++ strToLower (bottles (dec n)) ++ wall ++ ".\n"
        
join :: String -> [String] -> String
join s [] = ""
join s [x] = x
join s (x:xs) = x ++ s ++ join s xs

song :: String
song = join "\n" $ map verse [99,98..0]
