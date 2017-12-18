class Node(object):
    def __init__(self, value):
        self.__value__ = value
        self.__next__ = next

    def value(self):
        return self.__value__

    def next(self):
        return self.__next__


class LinkedListIterator(object):
    def __init__(self, linked_list):
        self.current = linked_list.root

    def __next__(self):
        if self.current is None:
            raise StopIteration
        value = self.current.value()
        self.current = self.current.next()
        return value


class LinkedList(object):
    def __init__(self, values=[]):
        self.root = None
        self.len = 0
        for value in values:
            self.push(value)

    def __len__(self):
        return self.len

    def __iter__(self):
        return LinkedListIterator(self)

    def head(self):
        if self.root is None:
            raise EmptyListException()
        return self.root

    def push(self, value):
        self.len += 1
        newNode = Node(value)
        newNode.__next__ = self.root
        self.root = newNode

    def pop(self):
        if self.root is None:
            raise EmptyListException()
        value = self.root.value()
        self.root = self.root.next()
        self.len -= 1
        return value

    def reversed(self):
        return LinkedList(self)


class EmptyListException(Exception):
    def __init__(self):
        Exception.__init__(self, 'list is empty')
