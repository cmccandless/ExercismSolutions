module School (School, add, empty, grade, sorted) where

type School = [(Int, [String])]

add :: Int -> String -> School -> School
add gradeNum student [] = [(gradeNum, [student])]
add gradeNum student school@(s:_) 
    | gradeNum == fst s = (gradeNum, sorted $ student : snd s) : drop 1 school
    | otherwise = s : add gradeNum student (drop 1 school)

empty :: School
empty = []

grade :: Int -> School -> [String]
grade gradeNum = concatMap snd . filter ((==) gradeNum . fst)

sorted :: Ord a => [a] -> [a]
sorted [] = []
sorted (p:xs) = sorted (filter (< p) xs) ++ [p] ++ sorted (filter (> p) xs)
