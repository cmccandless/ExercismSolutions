class Transpose
  def self.transpose(str)
    str.split("\n")
       .collect { |line| 
         line.ljust(str.size)
             .chars 
       }.transpose
       .collect(&:join)
       .join("\n")
       .strip
  end
end
module BookKeeping
  VERSION = 1
end