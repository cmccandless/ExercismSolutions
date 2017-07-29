module Series (largestProduct) where

import Data.Char (digitToInt, isDigit)
    
largestProduct :: Int -> String -> Maybe Integer
largestProduct 0 _ = Just 1
largestProduct _ "" = Nothing
largestProduct size digits@(_:ds) 
    | any (not . isDigit) digits = Nothing
    | otherwise = case compare (length digits) size of
        LT -> Nothing
        EQ -> Just . toInteger . product $ map digitToInt digits
        GT -> max <$> largestProduct size (take size digits) <*> largestProduct size ds