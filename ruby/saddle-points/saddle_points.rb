class Matrix
  def initialize(input)
    @grid = input.split("\n").collect { |line|
      line.split(" ")
          .collect { |number| 
            number.to_i 
          }
    }
  end
  def rows
    @grid.to_a
  end
  def columns
    @grid.transpose
  end
  def saddle_points
    (0..@grid.length - 1).collect { |y|
      (0..@grid[y].length - 1).select { |x|
        @grid[y][x] == @grid[y].max && 
          @grid[y][x] == columns[x].min
      }
      .collect { |x|
        [y,x]
      }
    }
    .flatten(1)
  end
end