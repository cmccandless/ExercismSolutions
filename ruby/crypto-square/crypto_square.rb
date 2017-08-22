class Crypto
  def initialize(text)
    @text = text
    @npt = @text.downcase.chars.select { |c| c =~ /[\da-z]/ }.join
    @size = Math.sqrt(@npt.length).ceil
    @pts = (0..@npt.length / @size)
      .collect { |i| @npt[i*@size..(i+1)*@size - 1] }
      .select { |s| s != "" }
    @cts = (0..@pts[0].length)
      .collect { |i| @pts.collect { |s| s.chars.drop(i).take(1).join }.join }
  end
  def normalize_plaintext
    @npt
  end
  def size
    @size
  end
  def plaintext_segments
    @pts
  end
  def ciphertext
    @cts.join.strip
  end
  def normalize_ciphertext
    @cts.join(" ").strip
  end
end