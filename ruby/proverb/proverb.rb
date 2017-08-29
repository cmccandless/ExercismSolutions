class Proverb
  def initialize(*chain, qualifier: "")
    @to_s = (0..chain.length - 2).collect{ |i|
        "For want of a #{chain[i]} the #{chain[i + 1]}"
      }
      .push("And all for the want of a #{qualifier.empty? ? "" : "#{qualifier} "}#{chain[0]}.")
      .join(" was lost.\n")
  end
  attr_reader :to_s
end