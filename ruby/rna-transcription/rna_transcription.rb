class Complement
  def self.of_dna(codons)
    codons =~ /[^CGTA]/ ? "" : codons.tr("CGTA", "GCAU")
  end
end

module BookKeeping
  VERSION = 4 # Where the version number matches the one in the test.
end