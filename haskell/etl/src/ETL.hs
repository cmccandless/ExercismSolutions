module ETL (transform) where

import Data.Char (toLower)
import Data.Map (Map, fromList, toList)

transformEntry:: (a, String) -> [(Char,a)]
transformEntry kvp = map (\v->(toLower v, fst kvp)) $ snd kvp

transform :: Map a String -> Map Char a
transform legacyData = fromList . concatMap transformEntry $ toList legacyData
