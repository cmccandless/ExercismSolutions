module Spiral (spiral) where

import Control.Arrow

groupsOf :: Int -> [a] -> [[a]]
groupsOf _ [] = []
groupsOf n xs = let (p, q) = splitAt n xs in p : groupsOf n q

create :: Int -> [[Int]]
create size = groupsOf size [1..size*size]

topRight :: [[Int]] -> ([[Int]], [Int])
topRight (m:ms) = (ps, m ++ qs)
    where 
        (ps, qs) = unzip $ map (init &&& last) ms
        
bottomLeft :: [[Int]] -> ([[Int]], [Int])
bottomLeft ms = (qs, reverse (ps ++ q))
    where
        (p, q) = (init &&& last) ms
        (ps, qs) = unzip $ map (head &&& tail) p

peel :: [[Int]] -> [Int]
peel = peelT
    where
        peelT [] = []
        peelT ms = let (m, xs) = topRight ms in xs ++ peelB m
        peelB [] = []
        peelB ms = let (m, xs) = bottomLeft ms in xs ++ peelT m

rollB [] size = rollT [[size * size]] size
rollB ms size 
    | n == size && all ((==) size . length) ms = ms
    | otherwise = rollT m size
    where
        n = length ms
        s = (head $ head ms) - 1
        m = zipWith (:) [s, s - 1..] ms ++ [reverse $ take (n + 1) [s - (2 * n)..]]
rollT [] size = rollB [[size * size]] size
rollT ms size 
    | n == size && all ((==) size . length) ms = ms
    | otherwise = rollB m size
    where
        n = length ms
        s = (last $ last ms) - 1
        m = take (n + 1) [s - (2 * n)..] : zipWith (++) ms (map (:[]) [s..])
        
roll :: Int -> [[Int]]
roll = rollB []
        
spiral :: Int -> [[Int]]
spiral 0 = []
spiral 1 = [[1]]
-- spiral 2 = [[1,2],[4,3]]
-- spiral 3 = [[1,2,3],
            -- [8,9,4],
            -- [7,6,5]]
-- spiral 4 = [[1,2,3,4],
            -- [12,13,14,5],
            -- [11,16,15,6],
            -- [10,9,8,7]]
-- spiral 5 = [[1,2,3,4,5],
            -- [16,17,18,19,6],
            -- [15,24,25,20,7],
            -- [14,23,22,21,8],
            -- [13,12,11,10,9]]
-- spiral size = map (\x -> replicate size 0) [0..size - 1]
spiral size = [1..size] : [take size [3 * size - 2,3*size - 3..]]
