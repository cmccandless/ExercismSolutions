module Allergies (Allergen(..), allergies, isAllergicTo) where

import qualified Data.Bits

data Allergen = Eggs
              | Peanuts
              | Shellfish
              | Strawberries
              | Tomatoes
              | Chocolate
              | Pollen
              | Cats
              deriving (Enum, Eq)

allergies :: Int -> [Allergen]
allergies = map toEnum . flip filter [0..7] . Data.Bits.testBit

isAllergicTo :: Allergen -> Int -> Bool
isAllergicTo = flip Data.Bits.testBit . fromEnum
