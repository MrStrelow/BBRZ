import math

class Position:
    TOP_RIGHT = 1
    TOP_LEFT = 2
    BOT_RIGHT = 3
    BOT_LEFT = 4

def main():
    field = [["~" for _ in range(5)] for _ in range(5)]
    fill_form = "#"
    fill_background = "~"

    field = fill_canvas(field, fill_background)
    triangle = draw_triangle(field, fill_form)
    
    diamond = draw_diamond(triangle)
    print_canvas(diamond)
    print()

    diamond = draw_pattern(diamond, 3, fill_form, "+")
    print_canvas(diamond)
    print()

    diamond = rotate(draw_pattern(rotate(diamond), 3, fill_form, "+"))
    print_canvas(diamond)
    print()

    sloped_triangle = fill_canvas(field, fill_background)
    sloped_triangle = draw_triangle_with_slope(sloped_triangle, fill_form, 0.25)
    print_canvas(sloped_triangle)
    print()

    sloped_diamond = draw_diamond(sloped_triangle)
    print_canvas(sloped_diamond)

def print_canvas(field):
    for row in field:
        print("".join(row))

def fill_canvas(field, symbol):
    return [[symbol for _ in range(len(field[0]))] for _ in range(len(field))]


# def draw_triangle(field, symbol):
#     return [[symbol if j <= i else cell for j, cell in enumerate(row)] for i, row in enumerate(field)]

def draw_triangle(field, symbol):
    ret = copy(field)
    for i in range(len(ret)):
        for j in range(len(ret[i])):
            if j <= i:
                ret[i][j] = symbol
    return ret

def copy(field):
    return [row[:] for row in field]

def rotate(field):
    return transpose(mirror_x(field))

def transpose(field):
    ret = [[None for _ in range(len(field))] for _ in range(len(field[0]))]
    for i in range(len(field)):
        for j in range(len(field[i])):
            ret[j][i] = field[i][j]
    return ret

def mirror_x(field):
    return field[::-1]

def mirror_y(field):
    return [row[::-1] for row in field]

def combine_form(container, part, position):
    container = copy(container)
    i_offset = len(part)
    j_offset = len(part[0])

    for i in range(len(part)):
        for j in range(len(part[i])):
            if position == Position.TOP_LEFT:
                container[i][j] = part[i][j]
            elif position == Position.BOT_RIGHT:
                container[i + i_offset][j + j_offset] = part[i][j]
            elif position == Position.BOT_LEFT:
                container[i + i_offset][j] = part[i][j]
            elif position == Position.TOP_RIGHT:
                container[i][j + j_offset] = part[i][j]
    return container

def draw_diamond(field):
    top_right = copy(field)
    bot_right = mirror_x(field)
    bot_left = mirror_y(bot_right)
    top_left = mirror_x(bot_left)

    ret = [["" for _ in range(len(field[0]) * 2)] for _ in range(len(field) * 2)]
    ret = combine_form(ret, top_right, Position.TOP_RIGHT)
    ret = combine_form(ret, bot_right, Position.BOT_RIGHT)
    ret = combine_form(ret, bot_left, Position.BOT_LEFT)
    ret = combine_form(ret, top_left, Position.TOP_LEFT)

    return ret

def draw_pattern(field, n, fill_form, new_fill_form):
    field = copy(field)
    for i in range(len(field)):
        if i % n == 0:
            for j in range(len(field[i])):
                if field[i][j] == fill_form:
                    field[i][j] = new_fill_form
    return field

def draw_triangle_with_slope(field, symbol, slope):
    x_max = math.ceil((len(field) - 1) / slope)
    ret = [["~" for _ in range(x_max)] for _ in range(len(field))]

    for x in range(len(ret[0])):
        y = int(round(x * slope)) if x != 0 else 0
        ret[y][x] = symbol

    for y in range(len(ret)):
        for x in range(len(ret[0])):
            if ret[y][x] == symbol:
                break
            else:
                ret[y][x] = symbol
    return ret

if __name__ == "__main__":
    main()
