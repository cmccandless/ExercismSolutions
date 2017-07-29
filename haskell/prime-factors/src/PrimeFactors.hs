module PrimeFactors (primeFactors) where
    
minus a@(x:xs) b@(y:ys) = case compare x y of 
    LT -> x : minus xs b
    EQ -> minus xs ys
    GT -> minus a ys
    
primes m
    | m < 2 = []
    | otherwise = 2 : sieve [3,5..m]
    where
        sieve (x:xs) = x : sieve (xs `minus` [x,x+x..m])
        sieve [] = []

primeFactorsT :: Integer -> [Integer] -> [Integer] -> [Integer]
primeFactorsT n factors listPrimes
    | n <= 1 = factors
    | null p = factors
    | otherwise = primeFactorsT (div n h) (factors ++ [h]) p
        where
            p = dropWhile (not . (==) 0 . mod n) listPrimes
            h = head p
    
primeFactors :: Integer -> [Integer]
primeFactors n = primeFactorsT n [] $ primes n
