module POV (fromPOV, tracePathBetween) where

import Data.Tree (Tree (Node), flatten)
import Data.Maybe (isJust)

getBranchWith :: Eq a => a -> [Tree a] -> Maybe (Tree a)
getBranchWith x forest = case filter (elem x . flatten) forest of
    [] -> Nothing
    (t:ts) -> Just t

fromPOV :: Eq a => a -> Tree a -> Maybe (Tree a)
fromPOV x tree@(Node root forest) =
    if x == root 
    then Just tree
    else case getBranchWith x forest of
             Nothing                 -> Nothing
             Just (Node newRoot nfs) -> 
                 let except x = filter (\(Node r _) -> r /= x)
                     nfs' = Node root (except newRoot forest) : nfs
                 in fromPOV x $ Node newRoot nfs'

tracePathBetween :: Eq a => a -> a -> Tree a -> Maybe [a]
tracePathBetween from to tree = case (fromPOV from tree, from == to) of
    (Nothing, _)                  -> Nothing
    (_, True)                     -> Just [to]
    (Just (Node _ fromForest), _) -> 
        case getBranchWith to fromForest of
            Nothing                         -> Nothing
            Just (newTree@(Node newRoot _)) -> 
               (from :) <$> tracePathBetween newRoot to newTree
