module RotationalCipher (rotate) where

import Data.Char (chr, ord)

rotateChar :: Int -> Char -> Char
rotateChar n ch
    | ch `elem` ['a'..'z'] = rotate n (ord 'a') ch
    | ch `elem` ['A'..'Z'] = rotate n (ord 'A') ch
    | otherwise = ch
    where
        rotate n base ch = chr ((ord ch - base + n) `mod` 26 + base)

rotate :: Int -> String -> String
rotate n = map (rotateChar n)
