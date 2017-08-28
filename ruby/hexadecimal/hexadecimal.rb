class Hexadecimal
  @@digits = {
    "0" => 0, "1" => 1, "2" => 2, "3" => 3,
    "4" => 4, "5" => 5, "6" => 6, "7" => 7,
    "8" => 8, "9" => 9, "a" => 10, "b" => 11,
    "c" => 12, "d" => 13, "e" => 14, "f" => 15
  }
  def initialize(hex)
    @to_decimal = hex =~ /[^\da-f]/ ? 0 
      : hex.length == 1 ? @@digits[hex] 
        : @@digits[hex[-1]] + 16 * Hexadecimal.new(hex[0..-2]).to_decimal
  end
  attr_reader :to_decimal
end