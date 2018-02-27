class TreeNode(object):
    def __init__(self, data, left=None, right=None):
        self.data = data
        self.left = left
        self.right = right

    def __eq__(self, other):
        if not isinstance(other, TreeNode):
            return False

        return (
            self.data == other.data and
            self.left == other.left and
            self.right == other.right
        )

    def __insert__(self, data):
        if data <= self.data:
            if self.left is None:
                self.left = TreeNode(data)
            else:
                self.left.__insert__(data)
        else:
            if self.right is None:
                self.right = TreeNode(data)
            else:
                self.right.__insert__(data)

    def __iter__(self):
        if self.left is not None:
            yield from self.left
        yield self.data
        if self.right is not None:
            yield from self.right

    def __repr__(self):
        return '{{ data: {}, left: {}, right: {} }}'.format(
            self.data,
            self.left,
            self.right
        )


class BinarySearchTree(object):
    def __init__(self, datum):
        self.root = None
        [self.add(d) for d in datum]

    def add(self, data):
        new_node = TreeNode(data)
        if self.root is None:
            self.root = new_node
        else:
            self.root.__insert__(data)

    def data(self):
        return self.root

    def sorted_data(self):
        if self.root is None:
            return []
        return list(self.root)

    def __repr__(self):
        return repr(self.root)
