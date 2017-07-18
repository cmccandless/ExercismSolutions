module Bowling (score, BowlingError(..)) where

data BowlingError = IncompleteGame
                  | InvalidRoll { rollIndex :: Int, rollValue :: Int }
  deriving (Eq, Show)
  
data Status = None | Spare | Strike deriving (Eq, Show)

score :: [Int] -> Either BowlingError Int
score = foldl combine (Right 0) . tally 1 0
        where
            combine a@(Left _) _        = a
            combine _ b@(Left _)        = b
            combine (Right a) (Right b) = Right (a + b)
            classify b1 b2
                | b1 == 10 = Strike
                | b1 + b2 == 10 = Spare
                | otherwise = None
            invalidFrameBall f b = f > 10 || b < 0 || b > 10
            tally f i [] = [Left IncompleteGame | f < 11]
            tally f i [r] 
                | invalidFrameBall f r           = [Left $ InvalidRoll i r]
                | f < 10 || (f == 10 && r == 10) = [Left IncompleteGame]
                | otherwise                      = [Right r]
            tally f i (r:r2:rs) 
                | invalidFrameBall f r   = [Left $ InvalidRoll i r]
                | r2 < 0 || r2 > 10      = [Left $ InvalidRoll (i + 1) r2]
                | r /= 10 && r + r2 > 10 = [Left $ InvalidRoll (i + 1) r2]
                | otherwise = case (classify r r2, rs) of
                    (None, _) -> Right (r + r2) : tally (f + 1) (i + 2) rs
                    (_, []) -> [Left IncompleteGame]
                    (Strike, _) -> let hrs  = head rs
                                       rest = if f == 10 
                                              then drop 1 rs
                                              else r2:rs
                                   in if f == 10 && (hrs > 10 || (r2 /= 10 && r2 + hrs > 10))
                                      then [Left $ InvalidRoll (i + 2) hrs]
                                      else Right (10 + r2 + head rs) : tally (f + 1) (i + 1) rest
                    (Spare, _) -> let rest = if f == 10
                                             then drop 1 rs
                                             else rs
                                  in Right (10 + head rs) : tally (f + 1) (i + 2) rest
