class Acronym
  def self.abbreviate(phrase)
    phrase.tr(":,","")
          .tr("-", " ")
          .split(" ")
          .collect { |word|
            word[0]
          }
          .join
          .upcase
  end
end
module BookKeeping
  VERSION = 4 # Where the version number matches the one in the test.
end