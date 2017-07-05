module Brackets (arePaired) where

isOpen :: Char -> Bool
isOpen = flip elem "{(["

isClose :: Char -> Bool
isClose = flip elem "})]"

isMatch :: Char -> Char -> Bool
isMatch a b = case a of
    '{' -> b == '}'
    '(' -> b == ')'
    '[' -> b == ']'
    _   -> False

arePairedT :: String -> String -> Bool
arePairedT [] [] = True
arePairedT _ [] = False
arePairedT [] (x:xs)
    | isOpen x = arePairedT [x] xs
    | isClose x = False
    | otherwise = arePairedT [] xs
arePairedT bss@(b:bs) (x:xs) 
    | isOpen x = arePairedT (x:bss) xs
    | isClose x = isMatch b x && arePairedT bs xs
    | otherwise = arePairedT bss xs

arePaired :: String -> Bool
arePaired = arePairedT []
