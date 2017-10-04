def hello(name=None):
    if name is None or name.strip() == '':
        name = 'World'
    return 'Hello, {}!'.format(name)
