class RotationalCipher
  def self.rotate(plaintext, n)
    plaintext.chars.collect { |char|  
      base = (char =~ /[A-Z]/ ? 'A' : 'a').ord
      char =~ /[A-Za-z]/ ? ((char.ord - base + n + 26) % 26 + base).chr : char
    }.join
  end
end
module BookKeeping
  VERSION = 1
end