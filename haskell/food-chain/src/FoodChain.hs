module FoodChain (song) where

animal :: [String]
animal = ["fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse"]

song :: String
song = unlines $ concatMap verse [0..7]
    where
        verse n = concatMap (\f -> f n) [filter (not . null) . start, middle, ending]
            where 
                spider = " wriggled and jiggled and tickled inside her."
                start x = ["I know an old lady who swallowed a " ++ animal !! x ++ ".", extra]
                    where
                        extra = case x of 
                            0 -> ""
                            1 -> "It" ++ spider
                            2 -> "How absurd to swallow a bird!"
                            3 -> "Imagine that, to swallow a cat!"
                            4 -> "What a hog, to swallow a dog!"
                            5 -> "Just opened her throat and swallowed a goat!"
                            6 -> "I don't know how she swallowed a cow!"
                            7 -> "She's dead, of course!"
                middle x = case x of 
                    0 -> ["I don't know why she swallowed the fly. Perhaps she'll die."]
                    7 -> []
                    _ -> (swallowed ++ caught) : middle next
                        where 
                            next = x - 1
                            extra = if next == 1 then " that" ++ spider else "."
                            swallowed = "She swallowed the " ++ animal !! x
                            caught = " to catch the " ++ animal !! next ++ extra
                ending x = ["" | x /= 7]
