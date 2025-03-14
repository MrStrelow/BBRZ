# 1.) userinput: 
#   - die größe des spielbretts soll angegeben werden.
#   - welche position soll als start gewählt werden, welche als ziel.

# i.) user informieren was er/sie eingeben soll
dimension = 10
# print(type(dimension))


# 2 Spieler - 

players_darstellung = {"A" : "♟️", "B" : "♙"}
field_properties = {"black" : "⬛", "white" : "⬜"}
markers = {"end" : "❌", "line" : "🔸"}

def create_board():
    return [[field_properties["black" if (i + j) % 2 == 0 else "white"] for j in range(dimension)] for i in range(dimension)]


def draw_board():
    for row in board:
        print("".join(row))


board = create_board()
draw_board()

player_positions = {"A" : {"x" : 1, "y" : 1}, "B" : {"x" : 1, "y" : 1}}



# TODO
x_start, y_start = input("Startpunkt wählen [x y]: ").split(" ")
x_start, y_start = int(x_start), int(y_start)

x_end, y_end = input("Endpunkt wählen [x y]: ").split(" ")
x_end, y_end = int(x_end), int(y_end)

 

# 3.) linien auf den schachbrett von start zu ende zeichnen (achtung ein wenig mathe)
board[y_start][x_start] = "♟️"
board[y_end][x_end] = "❌"


# 4.) zeichne linie zwischen ♟️ und ❌ ein.
delta_y = y_end - y_start
delta_x = x_end - x_start

steps = max(abs(delta_x), abs(delta_y))

steps_y = delta_y / steps
steps_x = delta_x / steps

for i in range(1, steps):
    y = y_start + round(steps_y * i)
    x = x_start + round(i * steps_x)
    board[y][x] = "🔸"

