class Scrabble
  @@scores = { 
    "aeioulnrst" => 1, 
    "dg" => 2, 
    "bcmp" => 3, 
    "fhvwy" => 4, 
    "k" => 5, 
    "jx" => 8, 
    "qz" => 10 
  }
  def initialize(word)
    word = word.nil? ? "" : word.downcase.tr("^a-z","")
    @score = @@scores.collect { |letters, score|
                       word.count(letters) * score
                     }
                     .sum
  end
  attr_reader :score
  def self.score(word)
    Scrabble.new(word).score
  end
end