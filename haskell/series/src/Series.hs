module Series (slices) where

import Data.Char (digitToInt)

slices :: Int -> String -> [[Int]]
slices 0 _ = [[]]
slices _ [] = []
slices n xss@(_:xs)
    | n > length xss = []
    | otherwise = flip (:) (slices n xs) $ map digitToInt $ take n xss