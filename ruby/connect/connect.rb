class Board
  @@neighbors = [-1,0,1].product([-1,0,1]).select { |x,y| x != y }
  def initialize(board)
    @board = board.collect { |line| line.tr(" ","") }
  end
  def in_range(x, y)
    x >= 0 && y >= 0 && y < @board.size && x < @board[y].size
  end
  def winner
    visited = {}
    stack = (@board.size.times.collect { |y| [0, y, 'X'] } +
             @board[0].size.times.collect { |x| [x, 0, 'O'] })
    until stack.empty?
      t = stack.pop
      x, y, token = t
      next unless in_range(x, y) && @board[y][x] == token
      next if visited[t.join(",")]
      return token if ((token == 'X' && x == @board[y].size - 1) || 
                       (token == 'O' && y == @board.size - 1))
      visited[t.join(",")] = true
      @@neighbors.each { |m, n| stack.push([x + m, y + n, token]) }
    end
    ''
  end
end
module BookKeeping
  VERSION = 2
end