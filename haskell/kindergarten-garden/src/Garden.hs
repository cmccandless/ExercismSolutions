module Garden
    ( Plant (..)
    , defaultGarden
    , garden
    , lookupPlants
    ) where

import Data.Map (Map)
import qualified Data.Map as Map

data Plant = Clover
           | Grass
           | Radishes
           | Violets
           deriving (Eq, Show)

defaultStudents :: [String]
defaultStudents = ["Alice", "Bob", "Charlie", "David",
    "Eve", "Fred", "Ginny", "Harriet",
    "Ileana", "Joseph", "Kincaid", "Larry"]
           
parsePlant :: Char -> Plant
parsePlant plant
    | plant == 'C' = Clover
    | plant == 'G' = Grass
    | plant == 'R' = Radishes
    | otherwise = Violets
           
parseRow :: String -> [[Plant]]
parseRow "" = []
parseRow row = map parsePlant (take 2 row) : parseRow (drop 2 row)
           
parsePlants :: String -> [[Plant]]
parsePlants plants = zipWith (++) (head rows) (rows !! 1) where
        rows = map parseRow $ lines plants
           
defaultGarden :: String -> Map String [Plant]
defaultGarden = garden defaultStudents

garden :: [String] -> String -> Map String [Plant]
garden students plants = Map.fromList $ zip (sorted students) (parsePlants plants)

lookupPlants :: String -> Map String [Plant] -> [Plant]
lookupPlants = Map.findWithDefault []

sorted :: Ord a => [a] -> [a]
sorted [] = []
sorted (p:xs) = sorted (filter (< p) xs) ++ [p] ++ sorted (filter (> p) xs)
