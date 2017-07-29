module Meetup (Weekday(..), Schedule(..), meetupDay) where

import Data.Maybe (fromJust)
import Data.Time.Calendar (addDays, addGregorianMonthsRollOver, Day, fromGregorian)
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
    
toWeekday :: Int -> Weekday
toWeekday n
    | n == 1 = Monday
    | n == 2 = Tuesday
    | n == 3 = Wednesday
    | n == 4 = Thursday
    | n == 5 = Friday
    | n == 6 = Saturday
    | otherwise = Sunday
    
previous :: Schedule -> Schedule
previous s 
    | s == Second = First
    | s == Third = Second
    | s == Fourth = Third
    | otherwise = First

createDate :: Int -> Integer -> Int -> Day
createDate day year month = fromGregorian year month day
    
firstDay :: Integer -> Int -> Day
firstDay = createDate 1

teenthDay :: Integer -> Int -> Day
teenthDay = createDate 13

addMonths :: Integer -> Day -> Day
addMonths = addGregorianMonthsRollOver

firstOfMonth :: Int -> Weekday -> Day -> Day
firstOfMonth month weekday date 
    | weekday == w = date
    | otherwise = firstOfMonth month weekday $ addDays 1 date
    where 
        (_, m, wn) = toWeekDate date
        w = toWeekday wn

meetupDay :: Schedule -> Weekday -> Integer -> Int -> Day
meetupDay Teenth weekday year month = firstOfMonth month weekday $ teenthDay year month
meetupDay First weekday year month = firstOfMonth month weekday $ firstDay year month
meetupDay Last weekday year month = addDays (-7) $ firstOfMonth month weekday $ addMonths 1 $ firstDay year month
meetupDay schedule weekday year month = addDays 7 $ meetupDay (previous schedule) weekday year month
