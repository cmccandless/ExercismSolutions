module Robot
    ( Bearing(East,North,South,West)
    , bearing
    , coordinates
    , mkRobot
    , simulate
    , turnLeft
    , turnRight
    ) where

data Bearing = North
             | East
             | South
             | West
             deriving (Eq, Show)

type Robot = ((Integer, Integer), Bearing)

bearing :: Robot -> Bearing
bearing = snd

coordinates :: Robot -> (Integer, Integer)
coordinates = fst

mkRobot :: Bearing -> (Integer, Integer) -> Robot
mkRobot direction coordinates = (coordinates, direction)

simulate :: Robot -> String -> Robot
simulate robot "" = robot
simulate robot instructions 
    | i == 'A' = simulate (advance robot, b) rest
    | i == 'L' = simulate (p, turnLeft b) rest
    | i == 'R' = simulate (p, turnRight b) rest
    | otherwise = error "Invalid instruction"
    where 
        i = head instructions
        p = fst robot
        b = snd robot
        rest = drop 1 instructions

advance ::  Robot -> (Integer, Integer)
advance robot 
    | b == North = (x, y + 1)
    | b == East = (x + 1, y)
    | b == South = (x, y - 1)
    | b == West = (x - 1, y)
    where
        p = fst robot
        x = fst p
        y = snd p
        b = snd robot
    
turnLeft :: Bearing -> Bearing
turnLeft direction 
    | direction == North = West
    | direction == West = South
    | direction == South = East
    | direction == East = North

turnRight :: Bearing -> Bearing
turnRight direction 
    | direction == North = East
    | direction == West = North
    | direction == South = West
    | direction == East = South
