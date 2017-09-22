class CircularBuffer
  BufferEmptyException = Exception
  BufferFullException = Exception
  def initialize(size)
    @buf = []
    @size = size
  end
  def empty?
    @buf.empty?
  end
  def read
    raise BufferEmptyException if empty?
    @buf.shift
  end
  def full?
    @buf.size == @size
  end
  def write(value)
    raise BufferFullException if full?
    @buf.push(value)
    self
  end
  def write!(value)
    read if full?
    write(value)
  end
  def clear
    @buf.clear
  end
end