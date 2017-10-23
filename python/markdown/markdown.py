import re


def wrap(text, tag):
    return '<{0}>{1}</{0}>'.format(tag, text)


def parse(markdown, delimiter, tag):
    return re.sub('{0}(.+){0}'.format(delimiter), wrap(r'\1', tag), markdown)


def parse_strong(markdown):
    return parse(markdown, '__', 'strong')


def parse_em(markdown):
    return parse(markdown, '_', 'em')


def parse_text(markdown, is_list):
    parsedText = parse_em(parse_strong(markdown))
    return parsedText if is_list else wrap(parsedText, 'p')


def parse_header(markdown, is_list):
    count = 0
    while markdown[count] == '#':
        count += 1
    if count == 0:
        return (None, is_list)
    header_tag = 'h{}'.format(count)
    header_html = wrap(markdown[count + 1:], header_tag)
    return ('</ul>{}'.format(header_html) if is_list else header_html, False)


def parse_line_item(markdown, is_list):
    if markdown.startswith('*'):
        inner_html = wrap(parse_text(markdown[2:], True), 'li')
        return (inner_html if is_list else '<ul>{}'.format(inner_html), True)
    return (None, is_list)


def parse_paragraph(markdown, is_list):
    result = parse_text(markdown, is_list)
    return ('{}</ul>'.format(result) if is_list else result, False)


def parse_line(markdown, is_list):
    result, is_list_after = parse_header(markdown, is_list)
    if result is None:
        result, is_list_after = parse_line_item(markdown, is_list)
    if result is None:
        result, is_list_after = parse_paragraph(markdown, is_list)
    if result is None:
        raise ValueError('invalid markdown')
    return (result, is_list_after)


def parse_markdown(markdown):
    is_list = False
    result = []
    for line in markdown.split('\n'):
        line, is_list = parse_line(line, is_list)
        result.append(line)
    result = ''.join(result)
    return '{}</ul>'.format(result) if is_list else result
