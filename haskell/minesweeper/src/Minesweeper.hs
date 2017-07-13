module Minesweeper (annotate) where

import Data.Char (intToDigit)

countMines :: Int -> Int -> [String] -> Char
countMines x y board = if result > 0 then intToDigit result else ' '
    where
        xmin = max 0 (x - 1)
        xmax = min (x + 2) (length (board !! y)) - 1
        ymin = max 0 (y - 1)
        ymax = min (y + 2) (length board) - 1
        result = sum [1 | r <- map (board !!) [ymin..ymax],
                          c <- map (r !!) [xmin..xmax],
                          c == '*']
                          
enumerate :: [a] -> [(Int, a)]
enumerate = zip [0..]

annotate :: [String] -> [String]
annotate board = [[if c == ' ' then countMines x y board else c | 
    (x, c) <- enumerate r] | (y, r) <- enumerate board]
