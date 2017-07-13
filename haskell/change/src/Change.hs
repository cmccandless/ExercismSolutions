module Change (findFewestCoins) where

import Data.List (sortBy)
import Data.Maybe (isJust)

findFewestCoins :: Integer -> [Integer] -> Maybe [Integer]
findFewestCoins target = f target . reverse
    where
        byLength x y = compare (length x) (length y)
        f _ []              = Nothing
        f 0 _              = Just []
        f target css@(c:cs) = case compare target c of
            LT -> f target cs
            EQ -> Just [c]
            GT -> if not $ null ms then head ms  else Nothing
                where
                    adj = target - c
                    x = (c :) <$> f adj css
                    y = (c :) <$> f adj cs
                    z = f target cs
                    ms = sortBy byLength $ filter isJust [x,y,z]
