module Clock (clockHour, clockMin, fromHourMin, toString) where

newtype Clock = Clock Int deriving (Eq, Show) 

maxMinutes = 60
maxTime = 24 * maxMinutes

instance Num Clock where
    fromInteger             = Clock . fromInteger
    negate (Clock t)        = Clock $ maxTime - t
    (Clock t1) + (Clock t2) = fromHourMin 0 (t1 + t2)
    (*) _ _                 = error "Not supported"
    abs _                   = error "Not supported"
    signum _                = error "Not supported"

clockHour :: Clock -> Int
clockHour (Clock t) = t `div` maxMinutes

clockMin :: Clock -> Int
clockMin (Clock t) = t `mod` maxMinutes

fromHourMin :: Int -> Int -> Clock
fromHourMin hour minute = case (hour, compare minute 0) of
    (0,    LT) -> fromHourMin 0 (minute + maxTime)
    (0,    _)  -> Clock $ minute `mod` maxTime
    (hour, _)  -> fromHourMin 0 (hour * maxMinutes + minute)

pad :: Int -> String
pad s = let ss = show s in case compare s 10 of
    LT -> '0' : ss
    _  -> ss

toString :: Clock -> String
toString clock = pad (clockHour clock) ++ ":" ++ pad (clockMin clock)