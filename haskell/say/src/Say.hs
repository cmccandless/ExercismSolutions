module Say (inEnglish) where

import Data.Maybe (fromJust)

digit :: Integer -> String
digit n = case n of
    0  -> ""
    1  -> "one" 
    2  -> "two" 
    3  -> "three"
    4  -> "four"
    5  -> "five"
    6  -> "six"
    7  -> "seven"
    8  -> "eight"
    9  -> "nine"
    10 -> "ten"
    11 -> "eleven"
    12 -> "twelve"
    13 -> "thirteen"
    14 -> "fourteen"
    15 -> "fifteen"
    16 -> "sixteen"
    17 -> "seventeen"
    18 -> "eighteen"
    19 -> "nineteen"
    
ten :: Integer -> String
ten n = case n of
    0 -> ""
    1 -> "ten"
    2 -> "twenty"
    3 -> "thirty"
    4 -> "forty"
    5 -> "fifty"
    6 -> "sixty"
    7 -> "seventy"
    8 -> "eighty"
    9 -> "ninety"
    
labels :: [(Integer, String, String)]
labels = [(1000000000, " ", " billion"),
          (1000000,    " ", " million"),
          (1000,       " ", " thousand"),
          (100,        " ", " hundred"),
          (10,         "-", "")]
          
inEnglish :: Integer -> Maybe String
inEnglish = doSay True
    where
        doSay top n 
            | top && n == 0 = Just "zero"
            | n < 1 = Nothing
            | n < 20 = Just $ digit n
            | otherwise = Just . maybe baseStr (baseSep ++) $ doSay False r
                where (_, ls) = break (\(x,y,z) -> n >= x) labels
                      (val, separator, label) = head ls
                      (q, r) = n `divMod` val
                      baseVal = if val > 10 then fromJust $ doSay False q else ten q
                      baseStr = baseVal ++ label
                      baseSep = baseStr ++ separator
