module BankAccount
    ( BankAccount
    , closeAccount
    , getBalance
    , incrementBalance
    , openAccount
    ) where

import Data.IORef (IORef, newIORef, readIORef, writeIORef)

type BankAccount = IORef (Maybe Integer)

closeAccount :: BankAccount -> IO ()
closeAccount account = writeIORef account Nothing

getBalance :: BankAccount -> IO (Maybe Integer)
getBalance = readIORef

incrementBalance :: BankAccount -> Integer -> IO (Maybe Integer)
incrementBalance account amount = do
    readIORef account >>= writeIORef account . fmap (+ amount)
    readIORef account

openAccount :: IO BankAccount
openAccount = newIORef $ Just 0
    
