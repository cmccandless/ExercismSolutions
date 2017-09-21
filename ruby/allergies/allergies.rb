class Allergies
  @@allergens = {
    "eggs" => 1,
    "peanuts" => 2,
    "shellfish" => 4,
    "strawberries" => 8,
    "tomatoes" => 16,
    "chocolate" => 32,
    "pollen" => 64,
    "cats" => 128
  }
  def initialize(code)
    @code = code || 0
  end
  def allergic_to?(allergen)
    @code & @@allergens[allergen] > 0
  end
  def list
    @@allergens.select { |k,v|
      allergic_to?(k)
    }
    .collect { |k,v| k }
  end
end