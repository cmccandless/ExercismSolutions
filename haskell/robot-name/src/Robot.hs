module Robot (Robot, mkRobot, resetName, robotName) where

import Data.IORef (IORef, newIORef, readIORef, writeIORef)
import System.Random (newStdGen, randomRs)

type Robot = IORef String

mkRobot :: IO Robot
mkRobot = do
    r <- newIORef ""
    resetName r
    return r

resetName :: Robot -> IO ()
resetName robot = do
    g <- newStdGen
    let name = take 2 (randomRs ('A','Z') g) ++ take 3 (randomRs ('0','9') g)
    writeIORef robot name
    return ()

robotName :: Robot -> IO String
robotName = readIORef