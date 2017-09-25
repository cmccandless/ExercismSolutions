ValueError = Exception
class Board
  def self.transform(board)
    raise ValueError unless board.all? { |line| 
      line.size == board[0].size && line =~ /^[|+\-* ]+$/
    }
    neighbors = [[-1,-1],[-1,0],[-1,1],[0,-1],[0,1],[1,-1],[1,0],[1,1]]
    (0..board.size - 1).collect { |y|
      (0..board[y].size - 1).collect { |x|
        unless board[y][x] == " "
          board[y][x]
        else
          neighbors.count { |m,n|
            y + n >= 0 && y + n < board.size &&
            x + m >= 0 && x + m < board[y].size && 
            board[y+m][x+n] == "*"
          }.to_s
        end
      }.join
      .tr("0"," ")
    }
  end
end