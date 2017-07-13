module ZebraPuzzle (Resident(..), Solution(..), solve) where

import Data.List (permutations)
import Data.Maybe (isNothing, fromJust)

data Resident = Englishman | Spaniard | Ukrainian | Norwegian | Japanese
  deriving (Eq, Show, Enum)

data Solution = Solution { waterDrinker :: Resident
                         , zebraOwner :: Resident
                         } deriving (Eq, Show)
                         
perms :: [[Int]]
perms = permutations [0..4]

nextTo :: Int -> Int -> Bool
nextTo a b = abs (a - b) == 1

solve :: Solution
solve = solveResidents perms
    where
        solveResidents (p@[nor,eng,span,jap,ukr]:ps)
            | nor /= 0 ||  -- Constraint 10
              isNothing s = solveResidents ps
            | otherwise = fromJust s
            where
                s = solveColors perms
                solveColors [] = Nothing
                solveColors ([green,red,blue,ivory,yellow]:ps)
                    | eng /= red ||         -- Constraint 2
                      green /= ivory + 1 || -- Constraint 6
                      blue /= 2 ||          -- Constraint 10+15
                      isNothing s = solveColors ps
                    | otherwise = s
                    where
                        s = solveSmokes perms
                        solveSmokes [] = Nothing
                        solveSmokes ([old,parl,kools,lucky,ches]:ps)
                            | yellow /= kools || -- Constraint 8
                              jap /= parl ||     -- Constraint 14
                              isNothing s = solveSmokes ps
                            | otherwise = s
                            where
                                s = solveDrinks perms
                                solveDrinks [] = Nothing
                                solveDrinks ([water,oj,tea,milk,coffee]:ps)
                                    | coffee /= green || -- Constraint 4
                                      tea /= ukr ||      -- Constraint 5
                                      milk /= 2 ||       -- Constraint 9
                                      oj /= lucky ||     -- Constraint 13
                                      isNothing s = solveDrinks ps
                                    | otherwise = s
                                    where
                                        s = solvePets perms
                                        solvePets [] = Nothing
                                        solvePets ([fox,dog,zebra,horse,snails]:ps)
                                            | span /= dog ||                        -- Constraint 3
                                              snails /= old ||                      -- Constraint 7
                                              not (ches  `nextTo` fox) ||                 -- Constraint 11
                                              not (kools `nextTo` horse) = solvePets ps  -- Constraint 12
                                            | otherwise = Just $ Solution (matchPerson water) (matchPerson zebra)
                                                where 
                                                    persons = [(eng,Englishman)
                                                              ,(span,Spaniard)
                                                              ,(ukr,Ukrainian)
                                                              ,(nor,Norwegian)
                                                              ,(jap,Japanese)
                                                              ]
                                                    matchPerson n = head [snd x | x <- persons, fst x == n]
