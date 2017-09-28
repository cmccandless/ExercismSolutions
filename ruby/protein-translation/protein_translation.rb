InvalidCodonError = Exception
class Translation
  def self.of_codon(codon)
    case codon
    when "AUG"
      "Methionine"
    when /UU[CU]/
      "Phenylalanine"
    when /UU[AG]/
      "Leucine"
    when /UC[ACGU]/
      "Serine"
    when /UA[CU]/
      "Tyrosine"
    when /UG[CU]/
      "Cysteine"
    when "UGG"
      "Tryptophan"
    when /U(A[AG]|GA)/
      "STOP"
    else
      raise InvalidCodonError
    end
  end
  def self.of_rna(rna)
    rna.chars
       .each_slice(3)
       .collect { |codon| of_codon(codon.join) }
       .take_while { |codon| codon != "STOP" }
  end
end