module IsbnVerifier (isbn) where

import Data.Char (digitToInt, isDigit)
import Data.List (elemIndex)

isbn :: String -> Bool
isbn = verify . filter (/='-')
    where
        isbnDigitToInt 'X' = 10
        isbnDigitToInt x = digitToInt x
        parse _ [] = 0
        parse n (x:xs) = n * isbnDigitToInt x + parse (n - 1) xs
        getCheckDigit = flip mod 11 . parse 10
        doVerify 9 [x] = x `elem` 'X':['0'..'9']
        doVerify count (x:xs) = isDigit x && doVerify (count + 1) xs
        doVerify _ _ = False
        verifyDigits = doVerify 0
        verify xs = verifyDigits xs && getCheckDigit xs == 0
