module Prime (nth) where

minus [] _ = []
minus a [] = a
minus a@(x:xs) b@(y:ys) = case compare x y of 
    LT -> x : minus xs b
    EQ -> minus xs ys
    GT -> minus a ys
    
primes m
    | m < 2 = []
    | otherwise = 2 : sieve [3,5..m]
    where
        sieve [] = []
        sieve (x:xs) = x : sieve (xs `minus` [x,x+x..m])

nth :: Int -> Maybe Integer
nth n 
    | n < 1 = Nothing
    | otherwise = Just $ f 512 !! (n - 1)
        where 
            f x
                | length p < n = f $ 2 * x
                | otherwise = p
                    where p = primes x
