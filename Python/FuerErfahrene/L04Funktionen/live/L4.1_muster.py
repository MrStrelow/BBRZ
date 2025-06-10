dimension = 10

# Enum
class Position:
    TOP_RIGHT = 1
    TOP_LEFT = 2
    BOT_RIGHT = 3
    BOT_LEFT = 4

# Funktionen:
def fill_canvas(field, symbol="⬜"):
    # for y in range(dimension):
    #     for x in range(dimension):
    #         field[y][x] = symbol
    
    return [ [ symbol for _ in range(dimension)] for _ in range(dimension) ]
    
    # return field


def print_canvas(field):
    for row in field:
        print("".join(row))


def draw_triangle(field, symbol):
    for y in range(len(field)):
        for x in range(len(field)):
            if x <= y:
                field[y][x] = symbol

    # return [[symbol if x <= y else field[y][x] for x in range(len(field))] for y in range(len(field))]
    return field


def mirror_x(field):
    copy_of_field = copy(field)

    for y in range(len(field)):
        for x in range(len(field)):
            copy_of_field[y][x] = field[len(field) - 1 - y][x]

    return copy_of_field


def mirror_y(field):
    copy_of_field = copy(field)

    for y in range(len(field)):
        for x in range(len(field)):
            copy_of_field[y][x] = field[y][len(field) - 1 - x]

    return copy_of_field


def copy(field):
    # copy_of_field = []
    # for y in range(dimension):
    #     row = []
    #     for x in range(dimension):
    #         row.append(field[y][x])

    #     copy_of_field.append(row)

    return [[elem for elem in row] for row in field]
    # return [row[:] for row in field]
    # return [row for row in field]


def zammstoepsln(container, triangle, position): #combine_form()
    offset = len(triangle)

    for y in range(len(triangle)):
        for x in range(len(triangle)):
            if position == Position.TOP_LEFT:
                container[y][x] = triangle[y][x]

            elif position == Position.TOP_RIGHT:
                container[y][x + offset] = triangle[y][x]

            elif position == Position.BOT_LEFT:
                container[y + offset][x] = triangle[y][x]   

            elif position == Position.BOT_RIGHT:
                container[y + offset][x + offset] = triangle[y][x]

    return container


def draw_diamant(triangle_top_right):
    triangle_top_left  = mirror_y(triangle_top_right)
    triangle_bot_right = mirror_x(triangle_top_right)
    triangle_bot_left  = mirror_x(triangle_top_left)

    container = [["" for _ in range(dimension * 2)] for _ in range(dimension * 2)]
    diamant = zammstoepsln(container, triangle_top_right, Position.TOP_RIGHT)
    diamant = zammstoepsln(container, triangle_top_left, Position.TOP_LEFT)
    diamant = zammstoepsln(container, triangle_bot_right, Position.BOT_RIGHT)
    diamant = zammstoepsln(container, triangle_bot_left, Position.BOT_LEFT)

    return diamant


# Verwende Funktionen:
# field = []
# for _ in range(dimension):
#     row = []

#     for _ in range(dimension):
#         row.append(None)
    
#     field.append(row)
field = [[None for _ in range(dimension)] for _ in range(dimension)]

field = fill_canvas(
    symbol = "◽", 
    field  = field
)

triangle = draw_triangle(field, symbol="🔷")
print_canvas(triangle)

print_canvas(draw_diamant(triangle))