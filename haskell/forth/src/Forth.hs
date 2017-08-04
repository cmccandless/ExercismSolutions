{-# LANGUAGE OverloadedStrings #-}

module Forth
  ( ForthError(..)
  , ForthState
  , evalText
  , toList
  , empty
  ) where

import Data.Char (isAlphaNum, isDigit)
import qualified Data.Map as M
import Data.Text (Text, unpack)

data ForthError
     = DivisionByZero
     | StackUnderflow
     | InvalidWord
     | UnknownWord Text
     deriving (Show, Eq)

type ForthState = [Int]

getWords :: String -> [String]
getWords "" = []
getWords (w:ws) = if isAlphaNum w || w `elem` ['+','-','/','*']
                  then case getWords ws of
                      [] -> [[w]]
                      (p:ps) -> (w:p):ps
                  else "" : getWords ws
                  
isNumber :: String -> Bool
isNumber = all isDigit

empty :: ForthState
empty = []

evalText :: Text -> ForthState -> Either ForthError ForthState
evalText = eval M.empty . getWords . unpack
    where
        eval :: M.Map String [String] -> [String] -> ForthState -> Either ForthError ForthState
        eval defines [] stack = Right stack
        eval defines (w:ws) stack
            | isNumber w = eval defines ws (read w:stack)
            | otherwise = case (w, stack) of
                ("+", x:y:ss) -> eval defines ws (y + x : ss)
                ("+", _)      -> Left StackUnderflow
                ("-", x:y:ss) -> eval defines ws (y - x : ss)
                ("-", _)      -> Left StackUnderflow
                ("*", x:y:ss) -> eval defines ws (y * x : ss)
                ("*", _)      -> Left StackUnderflow
                ("/", 0:y:ss) -> Left DivisionByZero
                ("/", x:y:ss) -> eval defines ws (div y x : ss)
                ("/", _)      -> Left StackUnderflow
                ("DUP", x:ss) -> eval defines ws (x:x:ss)
                ("DUP", _) -> Left StackUnderflow
                ("dup", x:ss) -> eval defines ws (x:x:ss)
                ("dup", _) -> Left StackUnderflow

toList :: ForthState -> [Int]
toList = reverse
