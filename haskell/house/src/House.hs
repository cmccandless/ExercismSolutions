module House (rhyme) where

import Data.List (intercalate)

wordPairs=[("lay in","house that Jack built.\n"),
    ("ate","malt"),
    ("killed","rat"),
    ("worried","cat"),
    ("tossed","dog"),
    ("milked","cow with the crumpled horn"),
    ("kissed","maiden all forlorn"),
    ("married","man all tattered and torn"),
    ("woke","priest all shaven and shorn"),
    ("kept","rooster that crowed in the morn"),
    ("belonged to","farmer sowing his corn"),
    ("","horse and the hound and the horn")]
    
firstPart :: Bool -> String -> String
firstPart start verb = if start then "This is" else "that " ++ verb
    
lastPart :: Int -> String
lastPart 0 = ""
lastPart n = "\n" ++ verse False (n - 1)
    
verse :: Bool -> Int -> String
verse start n = let (verb, noun) = wordPairs !! n in firstPart start verb ++ " the " ++ noun ++ lastPart n

rhyme :: String
rhyme = intercalate "\n" $ map (verse True) [0..length wordPairs - 1]