{-# LANGUAGE TemplateHaskell #-}
module Person
  ( Address (..)
  , Born    (..)
  , Name    (..)
  , Person  (..)
  , bornStreet
  , renameStreets
  , setBirthMonth
  , setCurrentStreet
  ) where

import Control.Lens
import Data.Time.Calendar (Day, fromGregorian, toGregorian)

data Address = Address { _street      :: String
                       , _houseNumber :: Int
                       , _place       :: String
                       , _country     :: String
                       }

data Born = Born { _bornAt :: Address
                 , _bornOn :: Day
                 }

data Name = Name { _foreNames :: String
                 , _surName   :: String
                 }

data Person = Person { _name    :: Name
                     , _born    :: Born
                     , _address :: Address
                     }
                     
$(makeLenses ''Address)
$(makeLenses ''Born)
$(makeLenses ''Name)
$(makeLenses ''Person)

bornStreet :: Born -> String
bornStreet = view street . view bornAt

setCurrentStreet :: String -> Person -> Person
setCurrentStreet = over address . set street

setMonth :: Int -> Day -> Day
setMonth month date = let (year, _, day) = toGregorian date 
                      in fromGregorian year month day

setBirthMonth :: Int -> Person -> Person
setBirthMonth = over born . over bornOn . setMonth

renameStreets :: (String -> String) -> Person -> Person
renameStreets f = over (born . bornAt . street) f . over (address . street) f
