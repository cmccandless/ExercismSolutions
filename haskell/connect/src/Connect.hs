module Connect (Mark(..), winner) where

data Mark = Cross | Nought deriving (Eq, Show)

inrange :: Int -> Int -> Int -> Bool
inrange min max n = min <= n && n < max

neighbors :: (Int, Int) -> [[a]] -> [(Int, Int)]
neighbors (x, y) ms = let bs = [-1,-1,0,1,1,0]
                          xs = map (x +) bs
                          ys = map (y +) $ reverse bs
                      in filter f $ zip xs ys
    where f (x2, y2) = inrange 0 (length ms) y2 && 
                       inrange 0 (length (head ms)) x2
    
doesPlayerWin :: Mark -> [(Int, Int)] -> [(Int, Int)] -> [String] -> Bool
doesPlayerWin _ _ [] _ = False
doesPlayerWin player visited (p@(x,y):ps) board = 
    let ns = filter (`notElem` visited) $ neighbors p board
    in case (player, board !! y !! x) of
    (Cross, 'X')  -> x == length (head board) - 1 ||
                     doesPlayerWin player (p:visited) (ps ++ ns) board
    (Nought, 'O') -> y == length board - 1 || 
                     doesPlayerWin player (p:visited) (ps ++ ns) board
    _             -> doesPlayerWin player (p:visited) ps board
            

winner :: [String] -> Maybe Mark
winner [] = Nothing
winner board 
    | let initial = zip [0,0..] [0..length board - 1]
      in doesPlayerWin Cross [] initial board = Just Cross
    | let initial = zip [0..length (head board) - 1] [0,0..]
      in doesPlayerWin Nought [] initial board = Just Nought
    | otherwise = Nothing