module Accumulate (accumulate) where

accumulate :: (a -> b) -> [a] -> [b]
-- I really, really wanted to use this...
-- accumulate = map
accumulate f [] = []
accumulate f xs@(x:_) = f x : accumulate f (drop 1 xs)
