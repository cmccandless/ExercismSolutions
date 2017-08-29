class Brackets
  @@brackets = {'[' => ']', '{' => '}', '(' => ')'}
  @@closers = [']','}',')']
  def self.paired?(input)
    open = []
    input.chars.each { |ch|
      case
      when @@brackets.include?(ch)
        open.push(ch)
      when @@closers.include?(ch)
        if open.any? && @@brackets[open[-1]] == ch
          open.pop
        else
          return false
        end
      end
    }
    open.empty?
  end
end
module BookKeeping
  VERSION = 4 # Where the version number matches the one in the test.
end