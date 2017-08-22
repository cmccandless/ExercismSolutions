class Hamming
  def self.compute(a, b)
    raise(ArgumentError) if a.length != b.length
    a.length == 0 ? 0 : a.chars.zip(b.chars).collect{ |x| (x[0]<=>x[1]).abs }.inject(:+)
  end
end

module BookKeeping
  VERSION = 3 # Where the version number matches the one in the test.
end