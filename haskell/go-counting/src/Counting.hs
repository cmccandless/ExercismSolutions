module Counting (
    Color(..),
    territories,
    territoryFor
) where

import Data.List (nub)
import Data.Maybe (mapMaybe)
import qualified Data.Set as S

data Color = Black | White deriving (Eq, Ord, Show)
type Coord = (Int, Int)

territories :: [String] -> [(S.Set Coord, Maybe Color)]
territories board = let points = [(x, y) | y <- [1..length board],
                                           x <- [1..length (head board)]]
                    in nub $ mapMaybe (territoryFor board) points

territoryFor :: [String] -> Coord -> Maybe (S.Set Coord, Maybe Color)
territoryFor board p =
    if validPoint p && ' ' `elem` stones 
    then Just (toSet territory, player)
    else Nothing
    where
        x `within` h = x > 0 && x <= h
        validPoint (x, y) = let validY = y `within` length board
                                validX = x `within` length (head board)
                            in validY && validX
        neighbors p = let addCoords (x1,y1) (x2,y2) = (x1 + x2, y1 + y2)
                          neighborsRelative = [(-1,0),(1,0),(0,-1),(0,1)]
                      in map (addCoords p) neighborsRelative
        validNeighbors = filter validPoint . neighbors
        stoneAt (x, y) = board !! (y - 1) !! (x - 1)
        neighborhood :: S.Set Coord -> [Coord] -> [Coord]
        neighborhood visited [] = []
        neighborhood visited (p:tovisit) = 
            let stoneAtP =  stoneAt p
                extended = tovisit ++ [p2 | p2 <- validNeighbors p,
                                            stoneAtP == ' ',
                                            S.notMember p2 visited]
            in p : neighborhood (S.insert p visited) extended
        fullTerritory = map (\x -> (stoneAt x, x)) $ neighborhood S.empty [p]
        stones = nub $ map fst fullTerritory
        territory = map snd $ filter ((==) ' ' . fst) fullTerritory
        player = if length stones /= 2
                 then Nothing
                 else case head $ filter (/=' ') stones of
                    'W' -> Just White
                    'B' -> Just Black
                    _   -> Nothing
        toSet = S.unions . map S.singleton
