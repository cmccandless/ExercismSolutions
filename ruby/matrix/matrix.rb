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
end