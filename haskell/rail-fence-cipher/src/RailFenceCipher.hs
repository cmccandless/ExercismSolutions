module RailFenceCipher (encode, decode) where

createRails :: Int -> String -> [String]
createRails 1 = flip (:) []
createRails nRails = let rails = replicate nRails []
                     in fillRails rails 0
    where 
        cap :: Int
        cap = 2 * nRails - 2
        append :: [String] -> Int -> Char -> [String]
        append (x:xs) 0 item = (x ++ [item]) : xs
        append (x:xs) index item = x : append xs (index - 1) item
        fillRails :: [String] -> Int -> String -> [String]
        fillRails rails _ [] = rails
        fillRails rails index (x:xs) = 
            let capped = mod index cap
                railIndex = if capped < nRails
                            then capped
                            else 2 * nRails - capped - 2
            in fillRails (append rails railIndex x) (index + 1) xs

encode :: Int -> String -> String
encode n text = concat $ createRails n text

decode :: Int -> String -> String
decode 1 text = text
decode nRails text = unroll [] $ repl (createRails nRails text) text
    where
        rails :: [String]
        rails = createRails nRails text
        repl :: [String] -> String -> [String]
        repl [] _ = []
        repl (b:bogusRails) text =
            let (chunk, rest) = splitAt (length b) text
            in chunk : repl bogusRails rest
        unroll :: [String] -> [String] -> String
        unroll (p:ps) [] = unroll [p] ps
        unroll _ ([]:rails) = ""
        unroll proc ((c:cs):rails) = c : unroll (cs:proc) rails
