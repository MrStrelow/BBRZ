################## import - externe funktionen laden ################## 
import keyboard
import time
import os
import sys

################## Variablen ################## 
# wir verzichten hier auf den userinput
dimension = 10

# Spieler - logik Objekt
# ist vergleichbar mit einer Map von Spielern in JAVA: Map<PlayerLogic> 
player_positions = {
    "A" : 
        {"x" : 1, "y" : 1}, # 1. Spieler Objekt
    "B" : 
        {"x" : dimension - 2, "y" : dimension - 2} # 2. Spieler Objekt
}

# Spieler - darstellungs Objekt: wie diese umgesetzt wird basiert auf der logik
# Ist nicht Teil der Spieler Logik, denn wir wollen das explizit trennen. 
# Hier in unserem kleinen Beispiel is es jedoch nicht so wichtig.

# Schwarz und Weißes Bauern-Symbol - ♟️ bzw. ♙ ist nicht teil der Monospacefont. Taschen es mit 🟢 und 🔵 aus
players_darstellung = {"A" : "🔵", "B" : "🟢"} 


# vom Spieler-Objekt unabhängige Variablen: 
markers = {"end" : "❌", "line" : "🔸"}
field_properties = {"black" : "⬛", "white" : "⬜"}

################### funktionen ##################
def create_board():
    return [ 
        [
            field_properties["black" if (i + j) % 2 == 0 else "white"] 
            for j in range(dimension)
        ] 
        for i in range(dimension)
    ]


def draw_board(board): #TODO: Klasse fragen warum ohne parameter ein bug entsteht. -> global vs. local scope.
    # os.system('cls' if os.name == 'nt' else 'clear') # flackert - die gesamte console wir gelöscht und neu erzeugt.
    # flacker nicht / weniger: warum? wir setzen die cursor-position auf 0/0 und zeichnen von dort - "bereits verwendeter speicher wird im hintergrund verwendet" - 
    sys.stdout.write("\u001B[H")  # setze cursor auf (0,0)
    sys.stdout.flush() # zwingt sofortige bewegung auf position 0/0 egal ob buffer voll ist.

    for row in board:
        print("".join(row))


def draw_line(start, end):
    if not (start["x"] == end["x"] and start["y"] == end["y"]):
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
    x = player_positions[player]["x"]
    y = player_positions[player]["y"]
    
    while True:
        event = keyboard.read_event()

        if event.event_type == keyboard.KEY_DOWN:
            if event.name == "w" and y > 0:
                y -= 1

            elif event.name == "s" and y < dimension - 1:
                y += 1

            elif event.name == "a" and x > 0:
                x -= 1

            elif event.name == "d" and x < dimension - 1:
                x += 1

            elif event.name == "f":
                break
            
        time.sleep(0.001)

        # leeres brett erzeugen
        global board
        board = create_board()

        # ziel einzeichnen
        board[y][x] = markers["end"]

        # rufe draw line auf und
        draw_line(start = player_positions[player], end = {"x" : x, "y" : y})

        #... zeichne spieler symbole
        for pl, pos in player_positions.items():
            board[pos["y"]][pos["x"]] = players_darstellung[pl]

        draw_board(board)
        
    # Endposition aktualisieren - verändere den zustand des spielers
    # player_positions[player]["x"], player_positions[player]["y"] = x, y
    player_positions[player]["x"] = x
    player_positions[player]["y"] = y
    
    # darstellung aktualisieren - bewege figure auf das ziel
    board[player_positions[player]["y"]][player_positions[player]["x"]] = players_darstellung[player]


################### Main ##################
os.system('cls' if os.name == 'nt' else 'clear') # löschen alles was noch von der alten console übrig ist.
board = create_board()

# Setze die Figuren auf das Spielfeld
for player, pos in player_positions.items():
    board[pos["y"]][pos["x"]] = players_darstellung[player]

draw_board(board)

while True:
    for player in player_positions.keys():
        move_piece(player)

