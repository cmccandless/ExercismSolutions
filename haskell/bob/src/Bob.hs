module Bob (responseFor) where

import Data.Char

isWhitespace :: Char -> Bool
isWhitespace c = c `elem` " \t\r\n"

strip :: String -> String
strip xs = reverse (dropWhile isWhitespace (reverse (dropWhile isWhitespace xs)))

responseFor :: String -> String
responseFor xs 
    | null xs = "Fine. Be that way!"
    | isWhitespace (last xs) = responseFor (strip xs)
    | any isLetter xs && map toUpper xs == xs = "Whoa, chill out!"
    | last xs == '?' = "Sure."
    | otherwise = "Whatever."
