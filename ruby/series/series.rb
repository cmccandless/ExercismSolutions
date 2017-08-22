class Series
  def initialize(nums)
    @nums = nums.chars
  end
  def slices(n)
    raise ArgumentError if n > @nums.length
    (0..@nums.length - n).collect { |i| @nums[i..n+i-1].join }
  end
end