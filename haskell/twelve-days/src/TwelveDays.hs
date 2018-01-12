module TwelveDays (recite) where

import Data.List (intercalate)

gift :: Int -> Int -> String
gift 1 1 = "a Partridge in a Pear Tree."
gift _ n = case n of 
    1 -> "and " ++ gift 1 1
    2 -> "two Turtle Doves"
    3 -> "three French Hens"
    4 -> "four Calling Birds"
    5 -> "five Gold Rings"
    6 -> "six Geese-a-Laying"
    7 -> "seven Swans-a-Swimming"
    8 -> "eight Maids-a-Milking"
    9 -> "nine Ladies Dancing"
    10 -> "ten Lords-a-Leaping"
    11 -> "eleven Pipers Piping"
    12 -> "twelve Drummers Drumming"

nth :: Int -> String
nth n = case n of
    1 -> "first"
    2 -> "second"
    3 -> "third"
    4 -> "fourth"
    5 -> "fifth"
    6 -> "sixth"
    7 -> "seventh"
    8 -> "eighth"
    9 -> "ninth"
    10 -> "tenth"
    11 -> "eleventh"
    12 -> "twelfth"

verseBase :: Int -> String
verseBase n = "On the " ++ nth n ++ " day of Christmas my true love gave to me"

verse :: Int -> [String]
verse 1 = [intercalate ", " [verseBase 1, gift 1 1]]
verse n = [intercalate ", " (verseBase n : map (gift n) [n, n-1..1])]        

recite :: Int -> Int -> [String]
recite start stop = concatMap verse [start..stop]
