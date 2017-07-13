module WordProblem (answer) where

import Data.Char (isDigit)

isInteger :: String -> Bool
isInteger "" = False
isInteger ('-':x:xs) = x /= '-' && isInteger (x:xs)
isInteger xs = all isDigit xs

removeQ :: String -> String
removeQ xs = if last xs == '?' then init xs else xs

answer :: String -> Maybe Integer
answer = parse 0 . words
    where
        parse x [] = Just x
        parse _ ("What":"is":y:ys) = parse (atoi y) ys
        parse x (op:"by":y:ys) = parse x (op:y:ys)
        parse x (op:y:ys) 
            | not . isInteger $ removeQ y = Nothing
            | otherwise = let n = read $ removeQ y in case op of
                "plus"       -> parse (x + n) ys
                "minus"      -> parse (x - n) ys
                "multiplied" -> parse (x * n) ys
                "divided"    -> parse (x `div` n) ys
                _            -> Nothing
        parse n _ = Nothing
    
