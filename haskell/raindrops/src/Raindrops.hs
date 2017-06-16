module Raindrops (convert) where

sounds :: [(Int, String)]
sounds = zip [3,5,7] ["Pling","Plang","Plong"]

convert :: Int -> String
convert n = if null translated then show n else translated where
    translated = concatMap snd $ filter ((==) 0 . mod n . fst) sounds
