class OcrNumbers
  def self.convertDigit(n)
    digits = [0xAF,0x09, 0x9E, 0x9B, 0x39, 0xB3, 0xB7, 0x89, 0xBF, 0xBB]
    digits.include?(n) ? digits.index(n).to_s : "?"
  end
  def self.convertNumber(s)
    convertDigit(s.chars
                  .zip("*_*|_||_|".chars)
                  .collect { |ch,seg| ch == seg ? 1 : 0 }
                  .join
                  .to_i(2))
  end
  def self.getNumbers(lines)
    ps, qs = lines.collect { |line| 
      return [] if line.empty?
      [line[0..2], line[3..-1]]
    }
    .transpose
    getNumbers(qs).unshift(ps[0,3].join)
  end
  def self.convert(input)
    numbers = []
    lines = input.split("\n")
    raise ArgumentError if (input.count("\n") + 1) % 4 != 0
    lines.each_slice(4) { |lines| 
           raise ArgumentError if lines.any? { |line| line.length % 3 != 0 }
           numbers.push(getNumbers(lines).collect { |number| 
                                           convertNumber(number) 
                                         }
                                         .join)
         }
    numbers.join(",")
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end