class BinarySearchTree(object):
    def __init__(self):
        self.value = None
        self.left = None
        self.right = None

    def add(self, value):
        if self.value is None:
            self.value = value
        elif self.value < value:
            if self.right is None:
                self.right = BinarySearchTree()
            self.right.add(value)
        else:
            if self.left is None:
                self.left = BinarySearchTree()
            self.left.add(value)

    def list(self):
        result = []
        if self.value is not None:
            if self.left is not None:
                result = self.left.list()
            result.append(self.value)
            if self.right is not None:
                result.extend(self.right.list())
        return result

    def search(self, value):
        if self.value == value:
            return self
        elif self.value < value and self.right is not None:
            return self.right.search(value)
        elif self.value >= value and self.left is not None:
            return self.left.search(value)
