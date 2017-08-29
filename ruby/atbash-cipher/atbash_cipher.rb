class Atbash
  def self.encode(plaintext)
    plaintext.downcase
             .tr("^a-z0-9", "")
             .tr("a-z", (0..25).collect { |x| ("z".ord - x).chr }.join)
             .scan(/.{1,5}/)
             .join(" ")
  end
end