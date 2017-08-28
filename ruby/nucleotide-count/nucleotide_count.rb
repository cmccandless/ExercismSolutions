class String
  def histogram
    "ATCG".chars
          .collect { |ch|
            [ch, self.count(ch)]
          }
          .to_h
  end
end
class Nucleotide
  def self.from_dna(input)
    raise ArgumentError if input =~ /[^ATCG]/
    input
  end
end