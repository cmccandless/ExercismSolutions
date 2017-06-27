module ListOps
  ( length
  , reverse
  , map
  , filter
  , foldr
  , foldl'
  , (++)
  , concat
  ) where
  
import Prelude hiding
  ( length, reverse, map, filter, foldr, (++), concat )
  
foldl' :: (b -> a -> b) -> b -> [a] -> b
foldl' _ z [] = z
foldl' f z (x:xs) = z' `seq` foldl' f z' xs where z' = f z x

foldr :: (a -> b -> b) -> b -> [a] -> b
foldr _ z [] = z
foldr f z [x] = f x z
foldr f z (x:xs) = foldr f (foldr f z xs) [x]

length :: [a] -> Int
length = foldl' (\x y -> x + 1) 0

reverse :: [a] -> [a]
reverse = foldl' (flip (:)) []

map :: (a -> b) -> [a] -> [b]
map _ [] = []
map f (x:xs) = f x : map f xs

filter :: (a -> Bool) -> [a] -> [a]
filter _ [] = []
filter p (x:xs) = [x | p x] ++ filter p xs

(++) :: [a] -> [a] -> [a]
[] ++ [] = []
xs ++ [] = xs
[] ++ ys = ys
(x:xs) ++ ys = x : xs ++ ys

concat :: [[a]] -> [a]
concat = foldr (++) []
