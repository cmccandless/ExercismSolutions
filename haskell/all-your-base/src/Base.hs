module Base (rebase) where

toBase10 :: Integral a => a -> [a] -> a
toBase10 _ [] = 0
toBase10 inputBase digits = (+) (last digits) $ (*) inputBase $ toBase10 inputBase $ init digits

fromBase10 :: Integral a => a -> a -> [a]
fromBase10 _ 0 = []
fromBase10 outputBase value = let (q,r) = divMod value outputBase in fromBase10 outputBase q ++ [r]

invalidDigit :: Integral a => a -> a -> Bool
invalidDigit base digit = digit < 0 || digit >= base

rebase :: Integral a => a -> a -> [a] -> Maybe [a]
rebase 10 10 inputDigits = Just inputDigits
rebase inputBase outputBase inputDigits 
    | inputBase < 2 || outputBase < 2 = Nothing
    | any (invalidDigit inputBase) inputDigits = Nothing
    | otherwise = Just $ fromBase10 outputBase $ toBase10 inputBase inputDigits
