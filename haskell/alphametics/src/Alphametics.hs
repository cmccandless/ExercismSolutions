module Alphametics (solve) where

import Data.Char (isLetter)
import Data.List (nub, permutations)

doLookup :: [(Char, Int)] -> Char -> Int
doLookup d k = let (_, (_,v):_) = break ((==) k . fst) d in v

parseWord :: [(Char, Int)] -> String -> Int
parseWord = f 0
    where
        f n _ "" = n
        f n d (x:xs) = f (10 * n + doLookup d x) d xs

solves :: [(Char, Int)] -> [String] -> Bool
solves _ [] = True
solves d (x:xs) = f d (parseWord d x) xs
    where 
        f d n [] = n == 0
        f d n (x:y:xs) = case x of
            "==" -> f d (n - parseWord d y) xs
            "+"  -> f d (n + parseWord d y) xs
            "*"  -> f d (n * parseWord d y) xs
            _    -> error ("Unsupported operator " ++ x)
            
createCandidates puzzle = 
    let puzzleWords = words puzzle
        letters = filter isLetter $ nub puzzle
        notZero = filter isLetter . nub $ map head puzzleWords
        validCandidate c = head c `notElem` notZero
        candidates = filter validCandidate . permutations . take 10 $ letters ++ repeat ' ' in
    (puzzleWords, candidates)
            
mkSolution :: String -> [(Char, Int)]
mkSolution = filter ((/=) ' ' . fst) . flip zip [0..]

solve :: String -> Maybe [(Char, Int)]
solve puzzle = doSolve candidates
    where 
        (puzzleWords, candidates) = createCandidates puzzle
        doSolve [] = Nothing
        doSolve (c:cs) = let sol = mkSolution c in
            if sol `solves` puzzleWords
            then Just sol
            else doSolve cs
