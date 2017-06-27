module Meetup (Weekday(..), Schedule(..), meetupDay) where

import Data.Maybe (fromJust)
import Data.Time.Calendar (addDays, Day, fromGregorianValid)
import Data.Time.Calendar.WeekDate (toWeekDate)

data Weekday = Monday
             | Tuesday
             | Wednesday
             | Thursday
             | Friday
             | Saturday
             | Sunday deriving (Eq)

data Schedule = First
              | Second
              | Third
              | Fourth
              | Last
              | Teenth deriving (Eq)
              
fromWeekday :: Weekday -> Int
fromWeekday w 
    | w == Monday = 1
    | w == Tuesday = 2
    | w == Wednesday = 3
    | w == Thursday = 4
    | w == Friday = 5
    | w == Saturday = 6
    | w == Sunday = 7
    | otherwise = 0
    
extractWeekday :: (Integer, Int, Int) -> Int
extractWeekday (year, month, weekday) = weekday
              
firstOfMonth :: Integer -> Int -> Int -> Weekday -> Day
firstOfMonth year month day weekday 
    | fromWeekday weekday == w = d
    | otherwise = firstOfMonth year month (day + 1) weekday
    where 
        d = fromJust $ fromGregorianValid year month 1
        w = extractWeekday $ toWeekDate d

meetupDay :: Schedule -> Weekday -> Integer -> Int -> Day
meetupDay Teenth weekday year month = firstOfMonth year month 13 weekday
meetupDay schedule weekday year month = firstOfMonth year month 1 weekday
