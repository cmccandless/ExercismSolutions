module DNA (toRNA) where

get :: Char -> Char
get c 
    | c == 'G' = 'C'
    | c == 'C' = 'G'
    | c == 'T' = 'A'
    | c == 'A' = 'U'

toRNA :: String -> Maybe String
toRNA xs 
    | null [x | x <- xs, x `notElem` "GCTA"] = Just (map get xs)
    | otherwise = Nothing
