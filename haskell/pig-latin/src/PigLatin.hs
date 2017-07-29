module PigLatin (translate) where

prefixIgnore :: [String]
prefixIgnore = ["xr", "yt"]

prefixMove :: [String]
prefixMove = ["sch","squ","thr","qu","th","sc","sh","ch",
              "st","b","c","d","f","g","h","j","k","l","m",
              "n","p","q","r","s","t","v","w","x","y","z"]

startsWith :: String -> String -> Bool
startsWith str prefix = take (length prefix) str == prefix

startsWithAny :: String -> [String] -> [(String,String)]
startsWithAny str = map (\p -> (p, drop (length p) str)) . filter (startsWith str)

translateWord :: String -> String
translateWord word
    | not (null ignore) = word ++ "ay"
    | not (null move) = let (p,r) = head move in r ++ p ++ "ay"
    | otherwise = word ++ "ay"
        where ignore = startsWithAny word prefixIgnore
              move = startsWithAny word prefixMove

translate :: String -> String
translate = unwords . map translateWord . words
