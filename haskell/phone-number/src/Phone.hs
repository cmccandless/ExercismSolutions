module Phone (number) where

import Data.Char

isValid :: String -> Bool
isValid [] = False
isValid xs@(x:_) | len == 11 = x == '1' && isValid (drop 1 xs)
    | len == 10 = x `notElem` "01" && xs !! 3 `notElem` "01"
    | otherwise = False where
        len = length xs

justify :: String -> Maybe String
justify xs | isValid xs = Just . reverse . take 10 $ reverse xs
    | otherwise = Nothing
        
number :: String -> Maybe String
number = justify . filter isDigit
