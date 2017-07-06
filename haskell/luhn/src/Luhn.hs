module Luhn (isValid) where

import Data.Char (digitToInt, isDigit)

processDigit :: (Int, Int) -> Int
processDigit (i, n) = let x = if mod i 2 /= 0 then 2 * n else n in
    if x > 9 then x - 9 else x

reverseEnumerate :: [a] -> [(Int, a)]
reverseEnumerate xs = reverse . zip [0..] $ reverse xs

isValid :: String -> Bool
isValid n 
    | numsOnly == "0" || any (not . isDigit) numsOnly = False
    | otherwise = (==) 0 . flip mod 10 . sum . map processDigit . reverseEnumerate $ map digitToInt numsOnly
    where
        numsOnly = filter (/=' ') n
