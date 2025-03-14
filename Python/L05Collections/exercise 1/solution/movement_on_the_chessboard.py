import keyboard
import os
import time

dimension = 10 #int(input("Größe des Spielbretts eingeben: "))

# Farbcodes als Dictionary
square_colors = {"black": "⬛", "white": "⬜"}

# Markierungen als Dictionary
markers = {"end": "❌", "line": "🔸"}

# Spieler und ihre Figuren
players_darstellung = {"A": "♟️", "B": "♙"}  # Schwarz und Weißes Bauer-Symbol

# Initialisiere das Schachbrett
def create_board():
    return [[square_colors["black" if (i + j) % 2 == 0 else "white"] for j in range(dimension)] for i in range(dimension)]

board = create_board()

# Startpositionen der Spieler
player_positions = {"A": {"x": 1, "y": 1}, "B": {"x": dimension - 2, "y": dimension - 2}}

# Setze die Figuren auf das Spielfeld
for player, pos in player_positions.items():
    board[pos["y"]][pos["x"]] = players_darstellung[player]

def draw_board():
    os.system('cls' if os.name == 'nt' else 'clear')
    for row in board:
        print("".join(row))
    print("Pfeiltasten zum Bewegen, Enter zum Bestätigen")

def move_piece(player):
    global board
    x, y = player_positions[player]["x"], player_positions[player]["y"]
    
    draw_board()
    
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
            elif event.name == "enter":
                break


        # Schachbrett aktualisieren
        time.sleep(0.01)  # Kleine Verzögerung, um mehrfaches Drücken zu verhindern

        # Schachbrett aktualisieren
        board = create_board()
        board[y][x] = markers["end"]
        
        draw_line(player_positions[player]["x"], player_positions[player]["y"], x, y)
        
        for pl, pos in player_positions.items():
            board[pos["y"]][pos["x"]] = players_darstellung[pl]

        draw_board()
    
    # Endposition aktualisieren
    board = create_board()
    player_positions[player]["x"], player_positions[player]["y"] = x, y
    for pl, pos in player_positions.items():
        board[pos["y"]][pos["x"]] = players_darstellung[pl]
        
    draw_board()

def draw_line(x_start, y_start, x_end, y_end):
    if x_start != x_end and y_start != x_end:
        delta_x, delta_y = x_end - x_start, y_end - y_start
        steps = max(abs(delta_x), abs(delta_y))
        step_x, step_y = delta_x / steps, delta_y / steps
    
        for i in range(1, steps):
            x = x_start + round(i * step_x)
            y = y_start + round(i * step_y)
            board[y][x] = markers["line"]

# Spielablauf
while True:
    for player in players_darstellung.keys():
        print(f"Spieler {player} ist am Zug!")
        move_piece(player)
