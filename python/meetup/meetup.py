import datetime


def getNth(nth):
    if nth == 'teenth':
        return 0
    elif nth == 'last':
        return 10
    return int(nth[0])


def meetup_day(year, month, weekday, nth):
    result = datetime.date(year, month, 1)
    while result.strftime('%A') != weekday:
        result += datetime.timedelta(days=1)
    i = 1
    n = getNth(nth)
    print(n)
    while (i < n and result.month == month) or (n == 0 and result.day < 13):
        result += datetime.timedelta(days=7)
        i += 1
    if result.month != month:
        if nth != 'last':
            raise MeetupDayException('day does not exist!')
        result -= datetime.timedelta(days=7)
    return result


class MeetupDayException(Exception):
    pass
