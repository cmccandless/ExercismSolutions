class School
  def initialize
    @roster = Hash.new([])
  end
  def students(grade)
    @roster[grade]
  end
  def add(name, grade)
    @roster[grade] = Array.new(@roster[grade]).push(name).sort
  end
  def students_by_grade
    @roster.sort.collect { |g,s| {:grade => g, :students => s } }
  end
end
module BookKeeping
  VERSION = 3 # Where the version number matches the one in the test.
end