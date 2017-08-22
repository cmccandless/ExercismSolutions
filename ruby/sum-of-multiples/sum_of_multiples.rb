class SumOfMultiples
  def initialize(*factors)
    @factors = factors
  end
  def to(max)
    @factors.collect {|x| (1..max/x).collect { |n| n*x } }
            .flatten
            .uniq
            .select { |n| n < max }
            .push(0) # In case of no valid factors
            .inject(:+)
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end
