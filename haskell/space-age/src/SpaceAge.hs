module SpaceAge (Planet(..), ageOn) where

data Planet = Mercury
            | Venus
            | Earth
            | Mars
            | Jupiter
            | Saturn
            | Uranus
            | Neptune deriving (Eq)

ageOn :: Planet -> Float -> Float
ageOn planet seconds 
    | planet == Earth = seconds / 31557600 
    | planet == Mercury = seconds / 31557600 / 0.2408467
    | planet == Venus = seconds / 31557600 / 0.61519726
    | planet == Mars = seconds / 31557600 / 1.8808158
    | planet == Jupiter = seconds / 31557600 / 11.862615
    | planet == Saturn = seconds / 31557600 / 29.447498
    | planet == Uranus = seconds / 31557600 / 84.016846
    | otherwise = seconds / 31557600 / 164.79132
        