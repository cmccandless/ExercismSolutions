module Matrix
    ( Matrix
    , cols
    , column
    , flatten
    , fromList
    , fromString
    , reshape
    , row
    , rows
    , shape
    , transpose
    ) where

import Data.Char (digitToInt)
import qualified Data.Vector as V

type Vector = V.Vector

type Matrix a = [[a]]

cols :: Matrix a -> Int
cols = length . head

column :: Int -> Matrix a -> Vector a
column x = V.fromList . map (!! x)

flatten :: Matrix a -> Vector a
flatten = V.fromList . concat

fromList :: [[a]] -> Matrix a
fromList = id

fromString :: Read a => String -> Matrix a
fromString = map (map read . words) . lines

reshape :: (Int, Int) -> Matrix a -> Matrix a
reshape (w,h) matrix = map (slice els w) [0..h - 1]
    where 
        els = concat matrix
        slice xs sz n = take sz $ drop (sz * n) xs

row :: Int -> Matrix a -> Vector a
row x = V.fromList . flip (!!) x

rows :: Matrix a -> Int
rows = length

shape :: Matrix a -> (Int, Int)
shape matrix = case matrix of 
    []    -> (0,0)
    (m:_) -> (length matrix, length m)

transpose :: Matrix a -> Matrix a
transpose matrix = case matrix of
    []     -> []
    [m]    -> map (: []) m
    (m:ms) -> zipWith (++) (map (: []) m) $ transpose ms
