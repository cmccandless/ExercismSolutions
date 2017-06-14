module RunLength (decode, encode) where

import Data.Char
import Data.List

str :: String -> String
str g = c ++ take 1 g where
    c = if length g > 1 then show (length g) else ""
    
expand :: Int -> Char -> Int
expand n c = n * 10 + digitToInt c

popped :: [a] -> [a]
popped = drop 1

rep :: Int -> Char -> String
rep n = replicate (max n 1)

encode :: String -> String
encode = encodeEx ""

encodeEx :: String -> String-> String
encodeEx partial text
    | null text = partial
    | otherwise = encodeEx (partial ++ str (fst g)) (snd g) where
        h = head text
        g = break (/=t) text

decode :: String -> String
decode = decodeEx "" 0

decodeEx :: String -> Int -> String -> String
decodeEx partial count text
    | null text = partial
    | isDigit h = decodeEx partial (expand count h) p
    | otherwise = decodeEx (partial ++ rep count h) 0 p where 
        h = head text
        p = popped text