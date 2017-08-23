class RailFenceCipher
  VERSION = 1 # Where the version number matches the one in the test.
  
  def self.encode(str, nRails)
    return str if nRails < 2
    rails = Array.new(nRails).fill("")
    cap = 2 * nRails - 2
    chars = str.chars
    (0..str.length - 1).each { |i|
      index = (i % cap)
      rails[index < nRails ? index : 2 * nRails - index - 2] += chars.shift
    }
    rails.join
  end
  
  def self.decode(str, nRails)
    return str if nRails < 2
    rails = Array.new(nRails).fill(0)
    cap = 2 * nRails - 2
    chars = str.chars
    (0..str.length - 1).each { |i|
      index = (i % cap)
      rails[index < nRails ? index : 2 * nRails - index - 2] += 1
    }
    rails = rails.collect { |n| chars.shift(n) }
    decoded = ""
    (0..str.length - 1).each { |i|
      index = (i % cap)
      decoded += rails[index < nRails ? index : 2 * nRails - index - 2].shift
    }
    decoded
  end
end