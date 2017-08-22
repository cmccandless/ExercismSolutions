class PhoneNumber
  def self.clean(number)
    number = number.chars.select { |ch| ch =~ /\d/ }.join
    number = number[1..-1] if number.length == 11 && number[0] == '1'
    number.length == 10 && number[0] != '1' && number[3] =~ /[^01]/ ? number : nil
  end
end
module BookKeeping
  VERSION = 2 # Where the version number matches the one in the test.
end