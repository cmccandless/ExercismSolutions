class Node(object):
    def __init__(self, value, next=None, prev=None):
        self.value = value
        self.next = next
        self.prev = prev


class LinkedList(object):
    def __init__(self):
        self.head = None
        self.tail = None

    def push(self, x):
        n = Node(x)
        if self.tail is None:
            self.head = n
        else:
            self.tail.next = n
            n.prev = self.tail
        self.tail = n

    def pop(self):
        n = self.tail
        if n.prev is None:
            self.head = None
        else:
            n.prev.next = None
        self.tail = n.prev
        return n.value

    def unshift(self, x):
        n = Node(x)
        if self.head is None:
            self.tail = n
        else:
            self.head.prev = n
            n.next = self.head
        self.head = n

    def shift(self):
        n = self.head
        if n.next is None:
            self.tail = None
        else:
            n.next.prev = None
        self.head = n.next
        return n.value
