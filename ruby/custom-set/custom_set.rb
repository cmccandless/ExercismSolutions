class CustomSet
  def initialize(values)
    @head = nil
    unless values.empty?
      @head = BinaryNode.new(values.shift)
      values.each { |value| add(value) }
    end
  end
  attr_reader :size
  def empty?
    @head.nil?
  end
  def member?(value)
    @head && @head.traverse(value, false)
  end
  def add(value)
    @head ? @head.traverse(value, true) : @head = BinaryNode.new(value)
    self
  end
  def to_a
    empty? ? [] : @head.to_a
  end
  def ==(other)
    empty? == other.empty? && to_a.zip(other.to_a).all? { |a, b| a == b }
  end
  def subset?(other)
    to_a.all? { |value| other.member?(value) }
  end
  def disjoint?(other)
    to_a.all? { |value| !other.member?(value) }
  end
  def intersection(other)
    to_a.select { |value| other.member?(value) }
  end
  def difference(other)
    to_a.select { |value| !other.member?(value) }
  end
  def union(other)
    CustomSet.new(to_a + other.to_a)
  end
end
class BinaryNode
  def initialize(value)
    @value = value
    @left = nil
    @right = nil
  end
  def traverse(value, add=false)
    case value <=> @value
    when 0
      !add
    when -1
      @left ? @left.traverse(value, add) : add ? @left = BinaryNode.new(value) : false
    when 1
      @right ? @right.traverse(value, add) : add ? @right = BinaryNode.new(value) : false
    end
  end
  def to_a
    (@left ? @left.to_a : []).push(@value)
                             .concat(@right ? @right.to_a : [])
  end
end
module BookKeeping
  VERSION=1
end