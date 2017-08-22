class Array
  def accumulate
    self.collect {|x| yield x}
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end