module Change (findFewestCoins) where

type Value = Maybe [Integer]

size :: Value -> Int
size = maybe 0x7ffffffe length

setValAt :: Int -> [Value] -> Integer -> [Value]
setValAt indexT row coin = start ++ (newCurrent : end)
    where (start, current : end) = splitAt indexT row
          pickBest :: Value -> (Int, Value) -> Value
          pickBest prevVal (indexT2, newVal) = 
              let isValid = fromInteger coin == indexT - indexT2
                  isBetter = size prevVal > size newVal in
              if isValid && isBetter 
                  then (coin :) <$> newVal 
                  else prevVal
          bestFromPrev = foldl pickBest current $ zip [0..] start
          newCurrent = if fromInteger coin == indexT 
              then Just [coin] 
              else bestFromPrev
            
setRow :: [Integer] -> [Value] -> Int -> [Value]
setRow coins prevRow indexT = foldl (setValAt indexT) prevRow coins

findFewestCoins :: Integer -> [Integer] -> Value
findFewestCoins target coins = if target < 0 
    then Nothing 
    else let firstRow = Just [] : replicate (fromInteger target) Nothing in
         last $ foldl (setRow coins) firstRow [1..fromInteger target]
