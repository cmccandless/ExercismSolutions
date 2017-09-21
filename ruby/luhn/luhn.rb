class Luhn
  def self.valid?(n)
    return false if n =~ /[^\d ]/
    digits = n.tr("^0-9", "")
              .chars
              .collect { |ch| ch.to_i }
    doDouble = true
    sum = digits.reverse.collect { |digit|
      (doDouble = !doDouble) ? (2 * (digit > 4 ? digit - 4.5 : digit)) : digit
    }
    .sum
    digits.size > 1 && sum % 10 == 0
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end