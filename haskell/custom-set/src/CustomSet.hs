module CustomSet
  ( delete
  , difference
  , empty
  , fromList
  , insert
  , intersection
  , isDisjointFrom
  , isSubsetOf
  , member
  , null
  , size
  , toList
  , union
  ) where

import Prelude hiding (null)
import Data.List (nub)

newtype CustomSet a = CustomSet [a] deriving (Show)
 
instance Eq a => Eq (CustomSet a) where
    setX == setY = setX `isSubsetOf` setY && setY `isSubsetOf` setX

delete :: Eq a => a -> CustomSet a -> CustomSet a
delete x (CustomSet ys) = fromList $ _delete x ys where
        _delete x [] = []
        _delete x (y:ys) = if x == y then ys else y : _delete x ys

difference :: Eq a => CustomSet a -> CustomSet a -> CustomSet a
difference (CustomSet xs) (CustomSet ys) = fromList $ filter (not . flip elem ys) xs

empty :: CustomSet a
empty = CustomSet []

fromList :: Eq a => [a] -> CustomSet a
fromList = CustomSet . nub

insert :: Eq a => a -> CustomSet a -> CustomSet a
insert x (CustomSet ys) = fromList $ x : ys

intersection :: Eq a => CustomSet a -> CustomSet a -> CustomSet a
intersection (CustomSet xs) (CustomSet ys) = fromList $ filter (`elem` xs) ys

isDisjointFrom :: Eq a => CustomSet a -> CustomSet a -> Bool
isDisjointFrom setX setY = null $ intersection setX setY

isSubsetOf :: Eq a => CustomSet a -> CustomSet a -> Bool
isSubsetOf (CustomSet xs) (CustomSet ys) = all (`elem` ys) xs

member :: Eq a => a -> CustomSet a -> Bool
member x (CustomSet ys) = foldr (\y -> (||) (x == y)) False ys

null :: CustomSet a -> Bool
null = (==) 0 . size

size :: CustomSet a -> Int
size (CustomSet xs) = let _size = foldr (\x -> (+) 1) 0 in _size xs

toList :: CustomSet a -> [a]
toList (CustomSet xs) = xs

union :: Eq a => CustomSet a -> CustomSet a -> CustomSet a
union setX setY = foldl (flip insert) setX . toList $ difference setY setX
