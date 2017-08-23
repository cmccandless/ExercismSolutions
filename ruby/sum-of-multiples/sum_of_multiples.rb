class SumOfMultiples
  def initialize(*factors)
    @factors = factors
  end
  def to(max)
    @factors.collect {|factor| 
              (1..max / factor).collect { |multiplicand| 
                multiplicand * factor 
              } 
            }
            .flatten
            .uniq
            .select { |multiple| multiple < max }
            .inject(0, :+)
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end
