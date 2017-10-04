class School:
    def __init__(self, name):
        self.name = name
        self.grades = {}

    def add(self, name, grade):
        try:
            self.grades[grade].append(name)
        except KeyError:
            self.grades[grade] = [name]

    def grade(self, gradeNo):
        try:
            return tuple(sorted(self.grades[gradeNo]))
        except KeyError:
            return tuple()

    def sort(self):
        return [(k, self.grade(k)) for k in self.grades.keys()]
