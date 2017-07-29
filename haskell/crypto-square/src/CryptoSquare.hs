module CryptoSquare (encode) where

import Data.Char (isAlphaNum, isSpace, toLower)

segments :: Int -> String -> [String]
segments _ "" = []
segments n xs = take n xs : segments n (drop n xs)

isqrt :: Int -> Int
isqrt n = f n
    where
        f x
            | x > 2 && x * x > n = f (x - 1)
            | x * x == n = x
            | otherwise = x + 1
            
transpose :: [[a]] -> [[a]]
transpose [] = []
transpose [m] = map (: []) m
transpose (m:ms) = zipWith (++) (map (: []) m) (transpose ms)

filterStr :: String -> String
filterStr xs = map toLower $ filter isAlphaNum xs

size :: String -> Int
size xs = isqrt $ length xs

stripTail :: String -> String
stripTail "" = ""
stripTail xs = if isSpace (last xs) then stripTail (init xs) else xs

fill :: Int -> String -> String
fill n xs = if mod (length xs) n /= 0 then fill n (xs ++ " ") else xs

encode :: String -> String
encode xs = unwords . map stripTail . transpose . segments s $ fill s flat
    where
        flat = filterStr xs
        s = size flat
