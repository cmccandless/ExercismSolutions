class Deque
  def initialize
    @head = nil
    @tail = nil
  end
  def push(value)
    if @tail.nil?
      @tail = @head = Node.new(value)
    else
      @tail.next = Node.new(value, @tail)
      @tail = @tail.next
    end
  end
  def pop
    return nil if @tail.nil?
    value = @tail.value
    @tail = @tail.prev
    if @tail.nil?
      @head = nil
    else
      @tail.next = nil 
    end
    value
  end
  def unshift(value)
    if @head.nil?
      @head = @tail = Node.new(value)
    else
      @head.prev = Node.new(value, nil, @head)
      @head = @head.prev
    end
  end
  def shift
    return nil if @head.nil?
    value = @head.value
    @head = @head.next
    if @head.nil?
      @tail = nil
    else
      @head.prev = nil 
    end
    value
  end
end
class Node
  def initialize(value, prev=nil, _next=nil)
    @value = value
    @prev = prev
    @next = _next
  end
  attr_accessor :value
  attr_accessor :prev
  attr_accessor :next
end