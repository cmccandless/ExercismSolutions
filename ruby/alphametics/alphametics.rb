# Run options: --seed 11863

# # Running:

# .........

# Finished in 44.097223s, 0.2041 runs/s, 0.2041 assertions/s.

# 9 runs, 9 assertions, 0 failures, 0 errors, 0 skips

class Alphametics
  def self.evaluate(input)
    return false if input =~ /\b0/
    parts = input.split(' ')
    res = parts.shift.to_i
    (1..parts.length / 2).each { |_|
      op = parts.shift
      operand = parts.shift.to_i
      case op
      when "+"
        res += operand
      when "=="
        return res == operand
      end
    }
    false
  end
  def self.solve(input)
    solution = input.chars
                    .uniq
                    .select { |ch| ch =~ /[A-Z]/ }
                    .join
                    .ljust(10, "_")
                    .chars
                    .permutation
                    .lazy
                    .drop_while { |solution| 
                      !evaluate(input.tr(solution.join, "0-9")) 
                    }.first
    solution.nil? ? {} 
      : solution.zip((0..9).to_a)
                .select { |pair| pair[0] != '_' }
                .to_h
  end
end
module BookKeeping
  VERSION = 4 # Where the version number matches the one in the test.
end