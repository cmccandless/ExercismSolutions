class Array
  def partition
    k = []
    d = []
    self.each { |x| (yield(x) ? k : d).push(x) }
    [k, d]
  end
  def keep(&block)
    partition(&block)[0]
  end
  def discard(&block)
    partition(&block)[1]
  end
end