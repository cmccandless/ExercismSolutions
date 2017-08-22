class Bst
  def initialize(data)
    @data = data
    @left = nil
    @right = nil
  end
  def data
    @data
  end
  def insert(x)
    if x > @data
      if @right
        @right.insert(x)
      else
        @right = Bst.new(x)
      end
    else
      if @left
        @left.insert(x)
      else
        @left = Bst.new(x)
      end
    end
  end
  def left
    @left
  end
  def right
    @right
  end
  def each(&block)
    return enum_for(:each) unless block_given?
    @left.each(&block) if @left
    block.call(@data)
    @right.each(&block) if @right
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end