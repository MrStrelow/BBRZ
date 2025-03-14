import keyboard
import time

dimension = 10

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


def draw_line(start, end):
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
    event = keyboard.read_event()

    # was ist der startwert von dem wir ausgehen?
    x =...
    y =...

    if event.event_type == keyboard.KEY_DOWN:
        if event.name == "w" and darf ich den move machen:
            x = .. oder y = ...
        elif event.name == "s" and :
            
        elif event.name == "a" and:

        elif event.name == "d" and:

        elif event.name == "f":
            pass

    time.sleep(0.01)
    # leers brett erzeugen
    board = create_board()

    # rufe draw line auf und
    draw_line(start = player_positions[player], end = {"x" : x, "y" : y})

    #... zeichne spieler symbole
    for pl, pos in player_positions.items():
        board[pos["y"]][pos["x"]] = players_darstellung[pl]

    draw_board()


    # verändere den zustand des spielers
    # wenn der user fertig ist bewege figure auf das ziel

# aufruf
board = create_board()
draw_board()


while True:
    for player in player_positions.keys():
        move_piece(player)

