module Roman (numerals) where

vals :: [(Integer, String)]
vals = [(1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")]

translate :: Integer -> String -> String
translate 0 s = s
translate n s = let (x, t) = head . snd $ break ((>=) n . fst) vals in translate (n - x) (s ++ t)

numerals :: Integer -> Maybe String
numerals n 
    | n < 0 = Nothing
    | otherwise = Just $ translate n ""
