module Dominoes (chain) where

import Data.List (permutations)
        
breakChain :: [(Int, Int)] -> ([(Int, Int)],[(Int, Int)])
breakChain [] = ([],[])
breakChain [a] = ([a], [])
breakChain (a@(_,ay):b@(bx,_):xs) = if ay /= bx
                                    then ([a],b:xs)
                                    else let (p,q) = breakChain $ b:xs
                                         in (a:p,q)
        
isChain :: [(Int, Int)] -> Bool
isChain [] = True
isChain [(dx,dy)] = dx == dy
isChain dominoes@(d@(dx,dy):_) = let (cs, ds) = breakChain dominoes
                                 --Note: to check for multiple, 
                                 --      disconnected loops in a set, 
                                 --      change "null ds" to "isChain ds"
                                 in dx == snd (last cs) && null ds
        
permuteSwaps :: [(a,a)] -> [[(a,a)]]
permuteSwaps [] = [[]]
permuteSwaps ((x,y):ps) = let pss = permuteSwaps ps
                          in concatMap (\t -> map (t :) pss) [(x,y), (y,x)]
                          
pairPermutations :: [(a,a)] -> [[(a,a)]]
pairPermutations = concatMap permuteSwaps . permutations
                    
chain :: [(Int, Int)] -> Maybe [(Int, Int)]
chain [] = Just []
chain ds = let chains = filter isChain $ pairPermutations ds
           in if null chains
              then Nothing
              else Just $ head chains
