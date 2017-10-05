module Diamond (diamond) where

import Data.Char (ord, chr)

diamond :: Char -> [String]
diamond c = let a = ord 'A'
                d = ord c
                space = flip replicate ' '
                line i = space (d - i) ++ chr i : space (i - a)
                mirror xs = xs ++ drop 1 (reverse xs)
            in mirror $ map (mirror . line) [a..d]