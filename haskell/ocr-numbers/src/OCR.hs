module OCR (convert) where

import Data.Bits
import Data.List (intercalate)

convertDigit :: Int -> Char
convertDigit n = case n of
    0xAF -> '0'
    0x09 -> '1'
    0x9E -> '2'
    0x9B -> '3'
    0x39 -> '4'
    0xB3 -> '5'
    0xB7 -> '6'
    0x89 -> '7'
    0xBF -> '8'
    0xBB -> '9'
    _    -> '?'

groupsOf :: Int -> [a] -> [[a]]
groupsOf _ [] = []
groupsOf n xs = let (p,q) = splitAt n xs in p : groupsOf n q
    
getNumbers :: [String] -> [String]
getNumbers xs
    | any null xs = []
    | otherwise = let (ps, qs) = unzip $ map (splitAt 3) xs in concat ps : getNumbers qs

hasSegment :: Char -> Char -> Int
hasSegment a b = if a == b then 1 else 0

accumulate :: Int -> Int -> Int
accumulate r = (.|.) (shift r 1)

convertNumber :: String -> Char
convertNumber = convertDigit . foldl accumulate 0 . zipWith hasSegment "*_*|_||_|"

convert :: String -> String
convert = intercalate "," . map (map convertNumber . getNumbers) . groupsOf 4 . lines
