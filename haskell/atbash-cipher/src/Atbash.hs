module Atbash (decode, encode) where

import Data.Char (isAlphaNum, isLetter, toLower)

transcode :: Char -> Char
transcode ch 
    | isLetter ch = toEnum (219 - fromEnum (toLower ch)) :: Char
    | otherwise = ch

segments :: Int -> String -> [String]
segments _ "" = []
segments n xs = take n xs : segments n (drop n xs)

decode :: String -> String
decode = concat . words . map transcode

encode :: String -> String
encode = unwords . segments 5 . map transcode . filter isAlphaNum
