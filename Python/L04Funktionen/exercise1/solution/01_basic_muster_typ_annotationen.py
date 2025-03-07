from typing import List

dimension: int = 10

# Enum
class Position:
    TOP_RIGHT = 1
    TOP_LEFT = 2
    BOT_RIGHT = 3
    BOT_LEFT = 4

# Funktionen:
def fill_canvas(field: List[List[str]], symbol: str = "⬜") -> List[List[str]]:
    return [[symbol for _ in range(dimension)] for _ in range(dimension)]

def print_canvas(field: List[List[str]]) -> None:
    for row in field:
        print("".join(row))

def draw_triangle(field: List[List[str]], symbol: str) -> List[List[str]]:
    for y in range(len(field)):
        for x in range(len(field)):
            if x <= y:
                field[y][x] = symbol
    return field

def mirror_x(field: List[List[str]]) -> List[List[str]]:
    copy_of_field = copy(field)
    for y in range(len(field)):
        for x in range(len(field)):
            copy_of_field[y][x] = field[len(field) - 1 - y][x]
    return copy_of_field

def mirror_y(field: List[List[str]]) -> List[List[str]]:
    copy_of_field = copy(field)
    for y in range(len(field)):
        for x in range(len(field)):
            copy_of_field[y][x] = field[y][len(field) - 1 - x]
    return copy_of_field

def copy(field: List[List[str]]) -> List[List[str]]:
    return [[elem for elem in row] for row in field]

def zammstoepsln(container: List[List[str]], triangle: List[List[str]], position: int) -> List[List[str]]:
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

def draw_diamant(triangle_top_right: List[List[str]]) -> List[List[str]]:
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
field: List[List[str]] = [[None for _ in range(dimension)] for _ in range(dimension)]

field = fill_canvas(field, symbol="◽")

triangle = draw_triangle(field, symbol="🔷")

diamant = draw_diamant(triangle)

print_canvas(diamant)
