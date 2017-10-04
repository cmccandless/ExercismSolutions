import datetime

ONE_GIGASECOND = 1000000000


def add_gigasecond(d):
    return d + datetime.timedelta(0, ONE_GIGASECOND)
