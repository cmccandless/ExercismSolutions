module Bowling (score, BowlingError(..)) where

data BowlingError = IncompleteGame
                  | InvalidRoll { rollIndex :: Int, rollValue :: Int }
  deriving (Eq, Show)
  
data Status = None | Spare | Strike deriving (Eq, Show)

type FrameResult = Either BowlingError Int

classify :: Int -> Int -> Status
classify b1 b2
    | b1 == 10 = Strike
    | b1 + b2 == 10 = Spare
    | otherwise = None
    
combine :: FrameResult -> FrameResult -> FrameResult
combine (Left IncompleteGame) _ =  Left IncompleteGame
combine _ (Left IncompleteGame) = Left IncompleteGame
combine (Left a@(InvalidRoll _ _)) _ = Left a
combine _ (Left b@(InvalidRoll _ _)) = Left b
combine (Right a) (Right b) = Right (a + b)

score :: [Int] -> FrameResult
score = scoreFrames 1 None
    where
        scoreFrames :: Int -> Status -> [Int] -> FrameResult
        scoreFrames frame status [] = Right 0
        scoreFrames frame status [b1]
            | frame == 11 && status == Spare = Right b1
            | b1 == 10 = Right b1
            | otherwise = Left IncompleteGame
        scoreFrames frame status (b1:b2:rs) = let newStatus = classify b1 b2 in case (frame, status) of 
            (11, Spare) -> Right b1
            (_, Spare) -> combine (Right (2 * b1 + b2)) $ scoreFrames (frame + 1) newStatus rs
            (11, Strike) -> Right (b1 + b2)
            (_, Strike) -> if newStatus == Strike 
                           then combine (Right (2 * b1)) $ scoreFrames (frame + 1) newStatus (b2:rs)
                           else combine (Right (2 * (b1 + b2))) $ scoreFrames (frame + 1) newStatus rs
            (_, None) -> combine (Right (b1 + b2)) $ scoreFrames (frame + 1) newStatus rs