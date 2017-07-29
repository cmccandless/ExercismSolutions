module Matrix (saddlePoints) where

import qualified Data.Array as Ar

getPoints :: Ar.Array (Int, Int) e -> [(Int, Int)] -> [e]
getPoints m = map ((Ar.!) m)

cols :: Ar.Array (Int, Int) e -> [Int]
cols m = let c = snd . snd $ Ar.bounds m in [0..c]

column :: Ar.Array (Int, Int) e -> Int -> [e]
column matrix = getPoints matrix . zip (cols matrix) . repeat 

columnMin :: Ord e => Ar.Array (Int, Int) e -> Int -> e
columnMin matrix = minimum . column matrix

isColMin :: Ord e => Ar.Array (Int, Int) e -> (Int, Int) -> Bool
isColMin matrix p@(x,y) = (matrix Ar.! p) == columnMin matrix y

rows :: Ar.Array (Int, Int) e -> [Int]
rows m = let r = fst . snd $ Ar.bounds m in [0..r]

row :: Ar.Array (Int, Int) e -> Int -> [e]
row matrix = getPoints matrix . flip zip (rows matrix) . repeat

rowMax :: Ord e => Ar.Array (Int, Int) e -> Int -> e
rowMax matrix = maximum . row matrix

isRowMax :: Ord e => Ar.Array (Int, Int) e -> (Int, Int) -> Bool
isRowMax matrix p@(x,y) = (matrix Ar.! p) == rowMax matrix x

saddlePoints :: Ord e => Ar.Array (Int, Int) e -> [(Int, Int)]
saddlePoints matrix = filter (\p -> isRowMax matrix p && isColMin matrix p) points
    where
        points = [(x,y) | x <- rows matrix, y <- cols matrix]