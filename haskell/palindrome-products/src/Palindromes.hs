module Palindromes (largestPalindrome, smallestPalindrome) where

import Data.Map (fromListWith, toList)

isPalindrome :: Integer -> Bool
isPalindrome n = let s = show n in s == reverse s
        
largestPalindrome :: Integer -> Integer -> (Integer, [(Integer, Integer)])
largestPalindrome minF maxF = f (minF,[]) $ take 1000 [maxF, maxF - 1..minF]
    where f best []         = best
          f best mss@(m:ms) = f (g best mss) ms
              where g best []     = best
                    g best (n:ns) = let p = m * n in 
                        case (isPalindrome p, compare p $ fst best) of
                        (False, _) -> g best ns
                        (_, GT)    -> (p, [(m, n)])
                        (_, EQ)    -> let (b, bf) = best in (b, (m,n) : bf)
                        (_, LT)    -> best

smallestPalindrome :: Integer -> Integer -> (Integer, [(Integer, Integer)])
smallestPalindrome minF maxF = f (maxF * maxF + 1, []) $ take 1000 [minF..maxF]
    where f best []         = best
          f best mss@(m:ms) = f (g best mss) ms
              where g best []     = best
                    g best (n:ns) = let p = m * n in 
                        case (isPalindrome p, compare p $ fst best) of
                        (False, _) -> g best ns
                        (_, LT)    -> (p, [(m, n)])
                        (_, EQ)    -> let (b, bf) = best in (b, (m,n) : bf)
                        (_, GT)    -> best
