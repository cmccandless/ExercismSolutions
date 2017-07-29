module Spiral (spiral) where

spiral :: Int -> [[Int]]
spiral = roll []
    where
        roll _ 0 = []
        roll [] size = roll [[size * size]] size
        roll ms size
            | n == size = ms
            | otherwise = roll m size
            where
                n = length ms
                m = if mod n 2 == mod size 2 then 
                        let s = head (head ms) - 1;
                            left = [s, s - 1..];
                            bottom = [reverse $ take (n + 1) [s - (2 * n)..]] in
                        zipWith (:) left ms ++ bottom
                    else 
                        let s = last (last ms) - 1;
                            top = take (n + 1) [s - (2 * n)..];
                            right = map (:[]) [s - n + 1..] in
                        top : zipWith (++) ms right
