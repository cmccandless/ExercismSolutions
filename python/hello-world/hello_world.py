#
# Skeleton file for the Python "Hello World" exercise.
#


def hello(name=''):
    return 'Hello, {}!'.format(name if name != None and name != '' else 'World')
