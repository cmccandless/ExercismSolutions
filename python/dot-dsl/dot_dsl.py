NODE, EDGE, ATTR = range(3)


class Node(object):
    def __init__(self, name, attrs={}):
        self.name = name
        self.attrs = attrs

    def __eq__(self, other):
        return self.name == other.name and self.attrs == other.attrs


class Edge(object):
    def __init__(self, src, dst, attrs):
        self.src = src
        self.dst = dst
        self.attrs = attrs

    def __eq__(self, other):
        return (self.src == other.src and
                self.dst == other.dst and
                self.attrs == other.attrs)


class Graph(object):
    def __init__(self, data=[]):
        if not isinstance(data, list):
            raise TypeError('data must be an list')
        self.nodes = []
        self.edges = []
        self.attrs = {}
        try:
            if any(len(d) < 2 for d in data):
                raise TypeError(
                    'elements of data must have a length of at least 2'
                )
        except Exception:
            raise TypeError('elements of data must be tuples')
        for data_type, *dat in data:
            if data_type == NODE:
                name, attrs = dat
                self.nodes.append(Node(name, attrs))
            elif data_type == EDGE:
                src_name, dst_name, attrs = dat
                self.edges.append(Edge(src_name, dst_name, attrs))
            elif data_type == ATTR:
                name, value = dat
                self.attrs[name] = value
            else:
                raise ValueError('unknown data type')
