class Record():
    def __init__(self, record_id, parent_id):
        self.parent_id = parent_id
        self.node_id = record_id
        self.record_id = record_id
        self.children = []

    def __repr__(self):
        return '{}=>{}'.format(self.record_id, self.parent_id)

    def __lt__(self, other):
        return self.record_id < other.record_id

    def add(self, other):
        if other.node_id == 0:
            if self.node_id != 0:
                raise ValueError('Root parent must be 0')
        elif other.node_id == self.node_id:
            raise ValueError('Non-root is parent of self')
        elif other.node_id < self.node_id:
            raise ValueError('Parent younger than child')
        else:
            self.children = list(sorted(self.children + [other]))


def BuildTree(records):
    nodes = {r.record_id: r for r in sorted(records)}
    for k, v in nodes.items():
        try:
            nodes[v.parent_id].add(v)
        except KeyError:
            raise ValueError('Parent does not exist')
    if not nodes:
        return None
    if not all(i == k for i, k in enumerate(nodes.keys())):
        raise ValueError('Non-continuous nodes')
    try:
        return nodes[0]
    except KeyError:
        raise ValueError('No root node')
