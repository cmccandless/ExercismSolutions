module Strain (keep, discard) where

discard :: (a -> Bool) -> [a] -> [a]
discard _ [] = []
discard p xs = fst t ++ discard p (drop 1 $ snd t) where t = break p xs

keep :: (a -> Bool) -> [a] -> [a]
keep p = discard (not . p)
