class Robot
  @@directions = [:east, :north, :west, :south]
  def initialize(x: 0, y: 0, bearing: :north)
    @bearing = bearing
    @coordinates = [x, y]
  end
  attr_reader :bearing
  attr_reader :coordinates
  def at(x, y)
    @coordinates = [x, y]
  end
  def orient(bearing)
    raise ArgumentError unless @@directions.include?(bearing)
    @bearing = bearing
  end
  def turn_right
    @bearing = @@directions[(@@directions.index(@bearing) + 3) % 4]
  end
  def turn_left
    @bearing = @@directions[(@@directions.index(@bearing) + 1) % 4]
  end
  def advance
    i = @@directions.index(@bearing)
    coordinates[i % 2] += i / 2 == 0 ? 1 : -1
  end
end
class Simulator
  def instructions(instructions_s)
    instructions_s.chars
                  .collect { |i|
                    case i
                    when 'L'
                      :turn_left
                    when 'R'
                      :turn_right
                    when 'A'
                      :advance
                    end
                  }
  end
  def place(robot, x: 0, y: 0, direction: :north)
    robot.at(x, y)
    robot.orient(direction)
  end
  def evaluate(robot, instructions_s)
    instructions(instructions_s).each { |instruction |
      robot.send(instruction)
    }
  end
end