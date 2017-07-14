module Bowling (score, BowlingError(..)) where

data BowlingError = IncompleteGame
                  | InvalidRoll { rollIndex :: Int, rollValue :: Int }
  deriving (Eq, Show)
  
data BowlingResult = Either BowlingError Int
  
data Status = None | Spare | Strike deriving (Eq, Show)

classify :: Int -> Int -> Status
classify b1 b2
    | b1 == 10 = Strike
    | b1 + b2 == 10 = Spare
    | otherwise = None

score :: [Int] -> BowlingResult
score = f 1 None
    where
        f :: Int -> Status -> [Int] -> BowlingResult
        f frame status [] = 0
        f frame status (b1:b2:rs) = let next = f (frame + 1) (classify b1 b2) rs in
            combine fscore next
            where
                fscore = BowlingResult
                fscore = case (frame, status) of
                    (_, None)   -> b1 + b2
                    (_, Spare)  -> 2 * b1 + b2
                    (_, Strike) -> 2 * (b1 + b2)
                    _           -> 0
                combine :: BowlingResult -> BowlingResult -> BowlingResult
                combine IncompleteGame _ =  IncompleteGame
                combine _ IncompleteGame = IncompleteGame
                combine a@(InvalidRoll _ _) _ = a
                combine _ b@(InvalidRoll _ _) = b
                combine a b = a + b

