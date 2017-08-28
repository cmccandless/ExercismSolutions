class FlattenArray
  VERSION = 1
  
  def self.flatten(array)
    result = []
    array.each { |x|
      if x.kind_of?(Array)
        result.concat(flatten(x))
      else
        result.push(x) if !x.nil?
      end
    }
    result
  end
end