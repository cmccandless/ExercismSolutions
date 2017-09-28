class Isogram
  def self.isogram?(word)
    word = word.downcase.chars.select { |ch| ch =~ /[[:alpha:]]/ }
    word.size == word.uniq.size
  end
end
module BookKeeping
  VERSION = 4
end