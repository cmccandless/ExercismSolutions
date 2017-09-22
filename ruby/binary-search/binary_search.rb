class BinarySearch
  def initialize(list)
    @list = list
    raise ArgumentError if list != list.sort
  end
  attr_accessor :list
  def middle
    list.size / 2
  end
  def search_for(data)
    p, r, q = [0, middle, list.size]
    while p < r
      case list[r] <=> data
      when 1
        q = r
      when 0
        return r
      when -1
        p = r
      end
      r = (q - p) / 2 + p
    end
    raise RuntimeError
  end
end