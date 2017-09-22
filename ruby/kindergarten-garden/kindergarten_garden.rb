class Garden
  def initialize(plants, students=["Alice", "Bob", "Charlie", "David", 
                                   "Eve", "Fred", "Ginny", "Harriet", 
                                   "Ileana", "Joseph", "Kincaid", "Larry"])
    plants.split("\n")
          .collect { |ln| ln.chars.each_slice(2).to_a }
          .transpose
          .zip(students.sort)
          .each { |slice, student|
            define_singleton_method :"#{student.downcase}" {
              slice.flatten
                   .collect { |plant|
                     case plant
                     when "C"
                       :clover
                     when "G"
                       :grass
                     when "R"
                       :radishes
                     when "V"
                       :violets
                     end
                   }
            }
          }
  end
end