class Cipher
  def initialize(key=nil)
    raise ArgumentError if !key.nil? && (key.empty? || key =~ /[^a-z]/)
    @key = key || (0..100).collect { |_| 'a' }.join
  end
  attr_reader :key
  def transcode(input, &block)
    input.chars
         .zip(key.chars.cycle.take(input.length))
         .collect(&block)
         .join
  end
  def decode(input)
    n, a = [26, "a".ord]
    transcode(input) { |ch, shift|
      (((ch.ord - a % n) + n + a - shift.ord) % n + a).chr
    }
  end
  def encode(input)
    n, a = [26, "a".ord]
    transcode(input) { |ch, shift|
      (((ch.ord - 2 * a + shift.ord) % n) + a).chr
    }
  end
end