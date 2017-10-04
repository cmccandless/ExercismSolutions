def transform(d):
    return dict([(x.lower(), k) for k, v in d.items() for x in v])
