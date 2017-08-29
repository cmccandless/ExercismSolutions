class SecretHandshake
  @@cmds = ["wink", "double blink", "close your eyes", "jump"]
  def initialize(code)
    @commands = []
    if code.kind_of?(Integer)
      add = @commands.method((code & (1 << @@cmds.length) > 0) ? :unshift : :push)
      (0..@@cmds.length - 1).each { |i| 
          add.call(@@cmds[i]) if code & (1 << i) > 0
      }
    end
  end
  attr_reader :commands
end