module WordCount (wordCount) where

import Data.Char (toLower)

noQuotes :: String -> String
noQuotes "" = ""
noQuotes ('\'':xs) = noQuotes xs
noQuotes w = if last w == '\'' then noQuotes $ init w else w

toWords :: String -> [String]
toWords xs = case break (`elem` " ,\n\"!:@.$%^&") xs of
    ("", "") -> []
    ("", s)  -> toWords (tail s)
    (f, "")  -> [noQuotes f]
    (f, s)   -> noQuotes f : toWords (tail s)

wordCount :: String -> [(String, Int)]
wordCount = f [] . toWords . map toLower
    where
        f ws [] = ws
        f ws (x:xs)
            | elem x $ map fst ws = f (map (\(w,c) -> if w == x then (w,c + 1) else (w,c)) ws) xs
            | otherwise = f ((x,1) : ws) xs
