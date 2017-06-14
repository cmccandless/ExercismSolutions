module Acronym (abbreviate) where

import Data.Char
        
splitOn :: String -> String -> [String]
splitOn delims str
    | null str = []
    | otherwise = fst t : splitOn delims (drop 1 (snd t)) where 
        t = break (`elem` delims) str

getWords :: String -> [String]
getWords = filter (not . null) . splitOn "-+ "

useChar :: Bool -> (Int, Char) -> Bool
useChar notAc t = fst t == 0 || (notAc && isUpper (snd t))

getChars :: String -> String
getChars w = map snd (filter (useChar (w /= map toUpper w)) (zip [0..] w))

abbreviate :: String -> String
abbreviate = map toUpper . concatMap getChars . getWords
