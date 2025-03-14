# 1.) userinput: 
#   - die größe des spielbretts soll angegeben werden.
#   - welche position soll als start gewählt werden, welche als ziel.

# i.) user informieren was er/sie eingeben soll
dimension = 10
# print(type(dimension))


# 2 Spieler - 

# darstellung
players_darstellung = {"A" : "♟️", "B" : "♙"}

# logik
player_positions = {"A" : {"x" : 1, "y" : 1}, "B" : {"x" : 1, "y" : 1}}

# spielerunabhängige objekte
field_properties = {"black" : "⬛", "white" : "⬜"}
markers = {"end" : "❌", "line" : "🔸"}

# funktionen
def create_board():
    return [[field_properties["black" if (i + j) % 2 == 0 else "white"] for j in range(dimension)] for i in range(dimension)]


def draw_board():
    for row in board:
        print("".join(row))


def draw_line(start, end, markers):
    delta_y = end["y"] - start["y"]
    delta_x = end["x"] - start["x"]

    steps = max(abs(delta_x), abs(delta_y))

    steps_y = delta_y / steps
    steps_x = delta_x / steps

    for i in range(1, steps):
        y = start["y"] + round(steps_y * i)
        x = start["x"] + round(i * steps_x)
        board[y][x] = markers["line"]


def move_piece(player):
    # abfrage der tastatur
    # verändere den zustand des spielers
    # rufe draw line auf
    # wenn der user fertig ist bewege figure auf das ziel
    pass

# aufruf
board = create_board()
draw_board()


while True:
    for player in player_positions.keys:
        move_piece(player)

