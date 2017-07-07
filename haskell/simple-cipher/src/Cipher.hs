module Cipher (caesarDecode, caesarEncode, caesarEncodeRandom) where

import Data.Char (isLetter, toLower)
import System.Random (newStdGen, randomRs)

increment :: Char -> Int -> Char
increment ch n = toEnum . (+) 97 $ mod (fromEnum ch - 71 + n) 26

encode :: String -> String -> String
encode _ "" = ""
encode (k:ks) (t:ts) = increment t (fromEnum k - 97) : encode (ks ++ [k]) ts

decode :: String -> String -> String
decode _ "" = ""
decode (k:ks) (t:ts) = increment t (97 - fromEnum k) : decode (ks ++ [k]) ts

caesarDecode :: String -> String -> String
caesarDecode = decode

caesarEncode :: String -> String -> String
caesarEncode key = encode key . map toLower . filter isLetter

caesarEncodeRandom :: String -> IO (String, String)
caesarEncodeRandom text = do
    g <- newStdGen
    let key = take 100 $ randomRs ('a', 'z') g
    return (key, caesarEncode key text)
