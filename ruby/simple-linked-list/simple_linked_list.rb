class Element
  def initialize(datum)
    @datum = datum
    @next = nil
  end
  attr_reader :datum
  attr_accessor :next
  def ==(other)
    nil? || other.nil? ? nil? && other.nil? : @datum == other.datum 
  end
end
class SimpleLinkedList
  def initialize(datums=nil)
    @tail = nil
    push(*datums.collect { |datum| Element.new(datum) }) if !datums.nil?
  end
  def push(*elements)
    elements.each { |element|
      element.next = @tail if !@tail.nil?
      @tail = element
    }
    self
  end
  def pop
    element = @tail
    if !@tail.nil?
      @tail = @tail.next 
      element.next = nil
    end
    element
  end
  def to_a
    a = []
    node = @tail
    while !node.nil?
      a.push(node.datum)
      node = node.next
    end
    a
  end
  def reverse!
    a = to_a.collect { |datum| Element.new(datum) }
    @tail = nil
    push(*a)
    self
  end
end
module BookKeeping
  VERSION = 1 # Where the version number matches the one in the test.
end