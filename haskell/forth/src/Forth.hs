{-# LANGUAGE OverloadedStrings #-}

module Forth
  ( ForthError(..)
  , ForthState
  , evalText
  , toList
  , empty
  ) where

import Data.Char (isAlphaNum, isDigit, toUpper)
import qualified Data.Map as M
import Data.Text (Text, pack, unpack)

data ForthError
     = DivisionByZero
     | StackUnderflow
     | InvalidWord
     | UnknownWord Text
     deriving (Show, Eq)

data ForthState = ForthState { stack :: [Int]
                             , defines :: M.Map String [String]
                             } deriving (Show, Eq)
                  
empty :: ForthState
empty = ForthState [] M.empty

evalText :: Text -> ForthState -> Either ForthError ForthState
evalText = eval . getWords . unpack
    where
        getWords "" = []
        getWords (w:ws) = if isAlphaNum w || w `elem` ("+-/*:;" :: String)
                          then case getWords ws of
                              [] -> [[w]]
                              (p:ps) -> (w:p):ps
                          else "" : getWords ws
        isNumber = all isDigit
        eval :: [String] -> ForthState -> Either ForthError ForthState
        eval [] state = Right state
        eval (w:ws) state@(ForthState stack defines)
            | isNumber w = eval ws $ ForthState ((read w :: Int) : stack) defines
            | otherwise = 
                let uw = map toUpper w
                in if M.member uw defines
                   then eval ((defines M.! uw) ++ ws) $ ForthState stack defines
                   else case (uw, stack) of
                       ("+", x:y:ss)     -> eval ws $ ForthState (y + x : ss) defines
                       ("+", _)          -> Left StackUnderflow
                       ("-", x:y:ss)     -> eval ws $ ForthState (y - x : ss) defines
                       ("-", _)          -> Left StackUnderflow
                       ("*", x:y:ss)     -> eval ws $ ForthState (y * x : ss) defines
                       ("*", _)          -> Left StackUnderflow
                       ("/", 0:y:ss)     -> Left DivisionByZero
                       ("/", x:y:ss)     -> eval ws $ ForthState (div y x : ss) defines
                       ("/", _)          -> Left StackUnderflow
                       ("DUP", x:ss)     -> eval ws $ ForthState (x:x:ss) defines
                       ("DUP", _)        -> Left StackUnderflow
                       ("DROP", x:ss)    -> eval ws (ForthState ss defines)
                       ("DROP", _)       -> Left StackUnderflow
                       ("SWAP", x:x':ss) -> eval ws $ ForthState (x':x:ss) defines
                       ("SWAP", _)       -> Left StackUnderflow
                       ("OVER", x:x':ss) -> eval ws $ ForthState (x':x:x':ss) defines
                       ("OVER", _)       -> Left StackUnderflow
                       (":", _)          -> 
                           let (k:v, _:remWs) = break (==";") ws
                               newDefines = M.insert (map toUpper k) v defines
                               newState = ForthState stack newDefines
                           in if isNumber k
                              then Left InvalidWord
                              else eval remWs newState
                       _                 -> Left (UnknownWord $ pack w)

toList :: ForthState -> [Int]
toList = reverse . stack
