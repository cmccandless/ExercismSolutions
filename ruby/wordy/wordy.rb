class WordProblem
  def initialize(input)
    @answer = input.scan(/([A-Za-z ]+)(-?\d+)?\??/)
                   .reduce(0) { |result, part|
                     op, num = part
                     raise ArgumentError if num.nil?
                     case op.strip
                     when "What is", "plus"
                       result + num.to_i
                     when "minus"
                       result - num.to_i
                     when "multiplied by"
                       result * num.to_i
                     when "divided by"
                       result / num.to_i
                     end
                   }
  end
  attr_reader :answer
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end