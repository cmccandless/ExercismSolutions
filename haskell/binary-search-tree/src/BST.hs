module BST
    ( BST
    , bstLeft
    , bstRight
    , bstValue
    , empty
    , fromList
    , insert
    , singleton
    , toList
    ) where
    
import Data.Maybe (fromJust, isNothing)

data BST a = BST (Maybe a) (Maybe (BST a)) (Maybe (BST a)) deriving (Eq, Show)

bstLeft :: BST a -> Maybe (BST a)
bstLeft (BST _ left _) = left

bstRight :: BST a -> Maybe (BST a)
bstRight (BST _ _ right) = right

bstValue :: BST a -> Maybe a
bstValue (BST value _ _) = value

empty :: BST a
empty = BST Nothing Nothing Nothing

fromList :: Ord a => [a] -> BST a
fromList = foldl (flip insert) empty

maybeInsert :: Ord a => a -> Maybe (BST a) -> Maybe (BST a)
maybeInsert x = Just . maybe (singleton x) (insert x)

insert :: Ord a => a -> BST a -> BST a
insert x (BST value left right) = case fmap (compare x) value of
    Nothing -> singleton x
    Just GT -> BST value left $ maybeInsert x right
    _       -> BST value (maybeInsert x left) right

singleton :: a -> BST a
singleton x = BST (Just x) Nothing Nothing

maybeToList :: Maybe (BST a) -> [a]
maybeToList = maybe [] toList

toList :: BST a -> [a]
toList (BST Nothing _ _) = []
toList (BST value left right) = maybeToList left ++ [fromJust value] ++ maybeToList right
