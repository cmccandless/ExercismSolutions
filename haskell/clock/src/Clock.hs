module Clock (clockHour, clockMin, fromHourMin, toString) where

type Clock = Int

maxHours = 24
maxMinutes = 60
maxTime = maxHours * maxMinutes

clockHour :: Clock -> Int
clockHour = flip div 60

clockMin :: Clock -> Int
clockMin = flip mod 60

fromMin :: Int -> Clock
fromMin minute
    | minute < 0 = fromMin (minute + maxTime)
    | otherwise = mod minute maxTime

fromHourMin :: Int -> Int -> Clock
fromHourMin hour minute = fromMin $ (60 * hour) + minute

pad :: Int -> String
pad s = let ss = show s in if s < 10 then '0' : ss else ss

toString :: Clock -> String
toString clock = pad (clockHour clock) ++ ":" ++ pad (clockMin clock)
