module Deque (Deque, mkDeque, pop, push, shift, unshift) where

import Data.IORef (IORef, newIORef, readIORef, writeIORef)
import Data.Maybe (fromJust, isNothing)

type Deque a = IORef [a]

mkDeque :: IO (Deque a)
mkDeque = newIORef []

pop :: Deque a -> IO (Maybe a)
pop deque = do
    xs <- readIORef deque
    if null xs then 
        return Nothing
    else do
        writeIORef deque $ init xs
        return . Just $ last xs
    
push :: Deque a -> a -> IO ()
push deque x = do
    xs <- readIORef deque 
    writeIORef deque $ xs ++ [x]

unshift :: Deque a -> a -> IO ()
unshift deque x = do
    xs <- readIORef deque
    writeIORef deque $ x : xs

shift :: Deque a -> IO (Maybe a)
shift deque = do
    xs <- readIORef deque 
    if null xs then
        return Nothing
    else do
        writeIORef deque $ tail xs
        return . Just $ head xs
