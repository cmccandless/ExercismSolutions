def flatten(_lst):
    lst = list(_lst)
    result = []
    app = result.append
    while len(lst) > 0:
        x = lst.pop(0)
        if isinstance(x, (list, tuple)):
            lst = list(x) + lst
        elif x is not None:
            app(x)
    return result
