module Triangle (rows) where

nextRow :: [Integer] -> [Integer]
nextRow [x] = [x]
nextRow (x:y:xs) = (x + y) : nextRow (y : xs)

rows :: Int -> [[Integer]]
rows x = case compare x 1 of
    LT -> []
    EQ -> [[1]]
    GT -> let pre = rows (x - 1) in 
        pre ++ [nextRow . (:) 0 $ last pre]
