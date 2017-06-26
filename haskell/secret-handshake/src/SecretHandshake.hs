module SecretHandshake (handshake) where

import Data.Bits

action :: Int -> String
action n 
    | n == 0 = "wink"
    | n == 1 = "double blink"
    | n == 2 = "close your eyes"
    | n == 3 = "jump"
    | otherwise = ""

handshake :: Int -> [String]
handshake n 
    | testBit n 4 = reverse . handshake $ n .&. 0xF
    | otherwise = map action $ filter (testBit n) [0..3]
