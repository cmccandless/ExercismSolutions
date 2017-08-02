module Sgf (parseSgf) where

import Data.Char (isSpace, isUpper)
import Data.Maybe (fromJust, isNothing)
import qualified Data.Map as M
import qualified Data.Text as Te
import qualified Data.Tree as Tr

type SgfTree = Tr.Tree (M.Map Te.Text [Te.Text])

getToken :: String -> (String, String)
getToken "" = ("", "")
getToken (x:xs) = if x `elem` stops 
                  then let (t,r) = tokenWith [x] xs in (x:t, r)
                  else tokenUntil (x:xs)
    where
        stops = ";([{"
        tokenWith _ "" = ("", "")
        tokenWith "" yss = ("", yss)
        tokenWith sss@(s:ss) (y:ys) 
            | s == ';' && y `elem` stops = ("", y:ys)
            | otherwise = case [s, y] of
                "()"     -> let (t2, r2) = tokenWith ss ys in (y:t2, r2)
                "[]"     -> let (t2, r2) = tokenWith ss ys in (y:t2, r2)
                "{}"     -> let (t2, r2) = tokenWith ss ys in (y:t2, r2)
                [_,'(']  -> let (t2, r2) = tokenWith (y:sss) ys in (y:t2, r2)
                [_,'{']  -> let (t2, r2) = tokenWith (y:sss) ys in (y:t2, r2)
                [_,'[']  -> let (t2, r2) = tokenWith (y:sss) ys in (y:t2, r2)
                [_,'\\'] -> let y2 = head ys
                                (t2, r2) = tokenWith sss (tail ys)
                            in if isSpace y2 then (t2, r2) else (y2:t2, r2)
                _        -> let (t2, r2) = tokenWith sss ys in (y:t2, r2)
        tokenUntil "" = ("", "")
        tokenUntil (y:ys) = if y `elem` stops 
                            then ("", y:ys)
                            else let (t2, r2) = tokenUntil ys in (y:t2, r2)
            
getTokens :: String -> [String]
getTokens "" = []
getTokens xs = let (t, r) = getToken xs in t : getTokens r

sm2tm :: M.Map String [String] -> M.Map Te.Text [Te.Text]
sm2tm = M.fromList . map se2te . M.toList
    where se2te (k, vs) = (Te.pack k, map Te.pack vs)
        
parseSgf :: Te.Text -> Maybe SgfTree
parseSgf sgfText = if badFormat || badRoot || badChildren 
                   then Nothing
                   else Just . treeMaker $ map fromJust children
    where
        ws2s x = if isSpace x then ' ' else x
        sgf = map ws2s $ Te.unpack sgfText
        badFormat = take 2 sgf /= "(;" || last sgf /= ')'
        ((r:root):tokens) = getTokens . init $ tail sgf
        invalidRoot = length root /= 1 || not (isUpper (head root))
        badRoot = not (null root) && invalidRoot
        (values, ctok) = if null tokens
                         then ([], [])
                         else break ((/=) '[' . head) tokens
        singleChild = not (null ctok) && ';' == head (head ctok)
        children = if singleChild
                   then let newSgf = '(':concat ctok ++ ")" 
                        in [parseSgf $ Te.pack newSgf]
                   else map (parseSgf . Te.pack) ctok
        badChildren = any isNothing children
        treeMaker = if null root
                    then Tr.Node M.empty
                    else let vs =  map (init . tail) values
                             m = M.fromList [(root, vs)]
                         in Tr.Node (sm2tm m)