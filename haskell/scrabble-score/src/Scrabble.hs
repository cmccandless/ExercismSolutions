module Scrabble (scoreLetter, scoreWord) where

import Data.Char (toLower)

scoreLetter :: Char -> Integer
scoreLetter letter 
    | ch `elem` "aeioulnrst" = 1
    | ch `elem` "fhvwy" = 4
    | ch `elem` "bcmp" = 3
    | ch `elem` "dg" = 2
    | ch `elem` "jx" = 8
    | ch `elem` "qz" = 10
    | ch == 'k' = 5
    | otherwise = 0
    where
        ch = toLower letter

scoreWord :: String -> Integer
scoreWord = sum . map scoreLetter
