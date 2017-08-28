class Say
  @@digit = {
    0 => "zero", 1 => "one", 2 => "two", 3 => "three",
    4 => "four", 5 => "five", 6 => "six", 7 => "seven", 
    8 => "eight", 9 => "nine", 10 => "ten", 11 => "eleven",
    12 => "twelve", 13 => "thirteen", 14 => "fourteen", 
    15 => "fifteen", 16 => "sixteen", 17 => "seventeen",
    18 => "eighteen", 19 => "nineteen"
  }
  @@ten = {
    0 => "", 1 => "ten", 2 => "twenty", 3 => "thirty",
    4 => "forty", 5 => "fifty", 6 => "sixty",
    7 => "seventy", 8 => "eighty", 9 => "ninety"
  }
  @@label = {
    1_000_000_000 => " billion",
    1_000_000 => " million",
    1_000 => " thousand",
    100 => " hundred",
    10 => ""
  }
  def initialize(num)
    @num = num
  end
  def in_english(top=true)
    case
    when @num < 0 || @num >= 1_000_000_000_000
      raise ArgumentError
    when @num == 0
      top ? "zero" : ""
    when @num < 20
      @@digit[@num]
    else
      @@label.each_pair { |value, label|
        if @num >= value
          div = (@num / value).floor
          base = "#{value > 10 ? Say.in_english(div, false) : @@ten[div]}#{label}"
          mod = @num % value
          return mod == 0 ? base
            : "#{base}#{value == 10 ? "-" : " "}#{Say.in_english(mod, false)}"
        end
      }
    end
  end
  def self.in_english(num, top=true)
    Say.new(num).in_english(top)
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end