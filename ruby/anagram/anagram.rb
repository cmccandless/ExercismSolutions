class Anagram
  def initialize(base_word)
    @base_word = base_word
  end
  def match(words)
    sorted = @base_word.downcase.chars.sort
    words.select { |w| w.downcase != @base_word.downcase && w.downcase.chars.sort == sorted }
  end
end
module BookKeeping
  VERSION = 2 # Where the version number matches the one in the test.
end