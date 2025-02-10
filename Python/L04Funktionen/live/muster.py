dimension = 10

# Funktionen:
def fill_canvas(field, symbol):
    for y in range(dimension):
        for x in range(dimension):
            field[y][x] = symbol
    
    return field


def print_canvas(field):
    for row in field:
        print("".join(row))


def draw_triangle(field, symbol):
    for y in range(len(field)):
        for x in range(len(field)):
            if x <= y:
                field[y][x] = symbol

    return field


def mirror_x(field):
    for y in range(len(field)):
        for x in range(len(field)):
            field[y][x] = field[len(field) - 1 - y][x]

def mirror_y(field):
    return field

# Verwende Funktionen:
field = [["_" for _ in range(dimension)] for _ in range(dimension)]

field = fill_canvas(field, symbol="◽")

top_right = draw_triangle(field, symbol="🔷")
top_left  = mirror_y(top_right)
bot_right = mirror_x(top_right)
bot_left  = mirror_x(top_left)

print_canvas(top_right)
# print_canvas(top_left)
# print_canvas(bot_right)
# print_canvas(bot_left)