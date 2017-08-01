module Sgf (parseSgf) where

import Data.Char (isUpper)
import Data.Maybe (fromJust, isNothing)
import qualified Data.Map as M
import qualified Data.Text as Te
import qualified Data.Tree as Tr

type StrSgfTree = Tr.Tree (M.Map String [String])
type SgfTree = Tr.Tree (M.Map Te.Text [Te.Text])

parseValue :: String -> (String, String)
parseValue "" = ("", "")
parseValue (x:xs) = case x of
    '[' -> parseValue xs
    ']' -> ("", xs)
    _   -> let (v, vs) = parseValue xs
           in (x:v, vs)

parseValues :: String -> ([String], String)
parseValues "" = ([], "")
parseValues xss@(x:xs) = case x of
    '[' -> let (v, vs) = parseValue xss
               (v2, vs2) = parseValues vs
           in (v:v2, vs2)
    _   -> ([], xss)
    
parseEntries :: String -> ([(String, [String])], String)
parseEntries "" = ([], "")
parseEntries xss@(x:xs) = case x of
    ')' -> ([], xss)
    ';' -> ([], xss)
    '(' -> ([], xss)
    _   -> let (v, vs) = parseValues xs
               (v2, vs2) = parseEntries vs
           in (([x], v) : v2, vs2)
          
selector :: String -> String -> (String, String)
selector s@(e:es) xss@(x:xs) = case [e, x] of 
    "()"     -> smartBreak es xs
    [_, '('] -> smartBreak ('(':s) xs 
    "[]"     -> smartBreak es xs 
    [_, '['] -> smartBreak ('[':s) xs 
    ";;"     -> ("", xss)
    _        -> smartBreak s xs 
          
smartBreak :: String -> String -> (String, String)
smartBreak s xss = case (s, xss) of
    ("", _) -> ("", xss)
    (e:es, []) -> if e /= ';' || not (null es)
                  then error ("bad chunk " ++ s)
                  else ("", "")
    (e:es, x:xs) -> let (xs1, xs2) = selector s xss
                    in (x:xs1, xs2)

parseTrees :: String -> Maybe [StrSgfTree]
parseTrees "" = Just []
parseTrees xss@[x] = error ("bad chunks: " ++ xss)
parseTrees (x:xs) = let (xs1, xs2) = smartBreak [x] xs
                        (tree, rem) = if x == ';'
                                      then (parseTree (x : ';' : init xs1 ++ ")"), ';':xs2)
                                      else (parseTree (x : xs1), xs2)
                    in if isNothing tree
                       then Nothing
                       else if null rem
                            then Just [fromJust tree]
                            else (fromJust tree :) <$> parseTrees rem
-- parseTrees (';':xs) = let (xs1, xs2) = break (==';') xs
                          -- tree = parseTree ("(;" ++ xs1 ++ ")")
                      -- in if isNothing tree
                         -- then Nothing
                         -- else (fromJust tree :) <$> parseTrees xs2

parseTree :: String -> Maybe StrSgfTree
parseTree ('(':';':ts) = if null ts 
                        then Nothing 
                        else let sgf = init ts
                                 closer = last ts
                             in case (sgf, closer) of
                                ("", ')')     -> Just $ Tr.Node M.empty []
                                (_, ')')      -> let (m, xs2) = parseEntries sgf
                                                     root = M.fromList m
                                                     forest = parseTrees xs2
                                                 in if any (\(k:_, _) -> not $ isUpper k) m || isNothing forest
                                                    then Nothing 
                                                    else Just . Tr.Node root $ fromJust forest
                                _             -> Nothing
parseTree _ = Nothing

stringEntryToTextEntry :: (String, [String]) -> (Te.Text, [Te.Text])
stringEntryToTextEntry (k, vs) = (Te.pack k, map Te.pack vs)

stringMapToTextMap :: M.Map String [String] -> M.Map Te.Text [Te.Text]
stringMapToTextMap = M.fromList . map stringEntryToTextEntry . M.toList

stringTreeToTextTree :: StrSgfTree -> SgfTree
stringTreeToTextTree (Tr.Node root forest) = Tr.Node (stringMapToTextMap root) (map stringTreeToTextTree forest)

parseSgf :: Te.Text -> Maybe SgfTree
parseSgf = fmap stringTreeToTextTree . parseTree . Te.unpack