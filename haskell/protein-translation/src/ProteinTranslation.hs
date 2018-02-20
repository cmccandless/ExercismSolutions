module ProteinTranslation(proteins) where

protein :: String -> String
protein codon = case codon of
    "AUG" -> "Methionine"
    "UUU" -> "Phenylalanine"
    "UUC" -> "Phenylalanine"
    "UUA" -> "Leucine"
    "UUG" -> "Leucine"
    "UCU" -> "Serine"
    "UCC" -> "Serine"
    "UCA" -> "Serine"
    "UCG" -> "Serine"
    "UAU" -> "Tyrosine"
    "UAC" -> "Tyrosine"
    "UGU" -> "Cysteine"
    "UGC" -> "Cysteine"
    "UGG" -> "Tryptophan"
    "UAA" -> "STOP"
    "UGA" -> "STOP"
    "UAG" -> "STOP"
    _     -> codon

proteins :: String -> Maybe [String]
proteins (c1:c2:c3:codons) = let p = protein [c1, c2, c3]
                             in case p of 
    "STOP" -> Just []
    _      -> (p :) <$> proteins codons
proteins _ = Just []
