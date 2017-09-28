class ListOps
  def self.arrays(arr)
    arr.size
  end
  def self.reverser(arr)
    a = []
    arr.each { |x| a.unshift(x) }
    a
  end
  def self.concatter(a, b)
    c = []
    a.each { |x| c.push(x) }
    b.each { |x| c.push(x) }
    c
  end
  def self.mapper(arr, &block)
    return arr unless block_given?
    a = []
    arr.each { |x| a.push(block.call(x)) }
    a
  end
  def self.filterer(arr, &block)
    return arr unless block_given?
    a = []
    arr.each { |x| a.push(x) if block.call(x) }
    a
  end
  def self.sum_reducer(arr, &block)
    s = 0
    arrays(arr).times.each { |i| s += arr[i] }
    s
  end
  def self.factorial_reducer(arr, &block)
    p = 1
    arrays(arr).times.each { |i| p *= arr[i] }
    p
  end
end
module BookKeeping
  VERSION = 2
end