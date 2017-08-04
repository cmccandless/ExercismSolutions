module Zipper
 ( BinTree(BT)
 , fromTree
 , left
 , right
 , setLeft
 , setRight
 , setValue
 , toTree
 , up
 , value
 ) where

import qualified Data.Map as M
import Data.Maybe (isNothing, fromJust)
 
data BinTree a = BT { btValue :: a
                    , btLeft  :: Maybe (BinTree a)
                    , btRight :: Maybe (BinTree a)
                    } deriving (Eq, Show)

data Zipper a = Zipper { _index :: Int
                       , _ups :: [Int]
                       , _map :: M.Map Int a
                       } deriving (Eq, Show)

child :: Int -> Zipper a -> Maybe (Zipper a)
child c (Zipper i us m) = 
    let li = i * 2 + c
    in if li `M.member` m
       then Just $ Zipper li (i:us) m
       else Nothing

fromTree :: BinTree a -> Zipper a
fromTree = Zipper 0 [] . treeToMap M.empty 0

left = child 1

purge :: M.Map Int a -> Int -> M.Map Int a
purge m i = let i2 = i * 2 
            in if i `M.notMember` m
               then m
               else flip purge (i2 + 2) . flip purge (i2 + 1) $ M.delete i m

right = child 2
           
setChild :: Int -> Maybe (BinTree a) -> Zipper a -> Zipper a
setChild c tree (Zipper i us m) = 
    let childIndex = i * 2 + c
    in case tree of
        Nothing -> Zipper i us $ purge m childIndex
        _       -> Zipper i us . treeToMap m childIndex $ fromJust tree
        
setLeft = setChild 1

setRight = setChild 2    

setValue :: a -> Zipper a -> Zipper a
setValue v (Zipper i us m) = Zipper i us $ M.insert i v m

toTree :: Zipper a -> BinTree a
toTree (Zipper _ _ m) = fromJust $ mapToTree 0 where
    mapToTree i = if i `M.notMember` m
                  then Nothing
                  else let i2 = 2 * i
                           bl = mapToTree (i2 + 1)
                           br = mapToTree (i2 + 2)
                       in Just $ BT (m M.! i) bl br

treeToMap :: M.Map Int a -> Int -> BinTree a -> M.Map Int a
treeToMap m i tree = let m' = M.insert i (btValue tree) m
                         i2 = 2 * i
                         m'' = maybe m' (treeToMap m' (i2 + 1)) (btLeft tree)
                     in maybe m'' (treeToMap m'' (i2 + 2)) (btRight tree)

                        
up :: Zipper a -> Maybe (Zipper a)
up (Zipper _ [] _)     = Nothing
up (Zipper i (u:us) m) = Just $ Zipper u us m

value :: Zipper a -> a
value (Zipper i _ m) = m M.! i
