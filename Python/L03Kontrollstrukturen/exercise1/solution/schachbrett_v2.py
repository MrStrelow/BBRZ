# Benutzer gibt die Größe des Schachbretts ein
dimension = int(input("Größe des Spielbretts eingeben: "))

# Schachbrett erstellen
# black_square_code = "\u2588"  # ░
# white_square_code = "\u2591"  # █

# oder
# black_square_code = "\u2B1B" # ⬛
# white_square_code = "\u2591" # ⬜

# oder
black_square_code = "⬛"
white_square_code = "⬜"

board = []
for i in range(dimension):
    row = []
    for j in range(dimension):
        if (i + j) % 2 == 0:
            row.append(black_square_code)
        else:
            row.append(white_square_code)
    board.append(row)


# board = [
#     [
#         "⬜" if (i + j) % 2 == 0 else "⬛" 
#             for j in range(dimension)
#     ] 
#     for i in range(dimension)
# ]

# Benutzer gibt die Startkoordinaten ein
start_input = input("Wähle die Figur... [x y]: ").split()
x_start = int(start_input[0])
y_start = int(start_input[1])

# Benutzer gibt die Zielkoordinaten ein
end_input = input("... und wähle das Ziel [x y]: ").split()
x_end = int(end_input[0])
y_end = int(end_input[1])

# Start- und Zielpunkte setzen
board[y_start][x_start] = "🟡"
board[y_end][x_end] = "❌"

# Linie zwischen Start- und Zielpunkt zeichnen
delta_x = x_end - x_start
delta_y = y_end - y_start

steps = max(abs(delta_x), abs(delta_y))
step_x = delta_x / steps
step_y = delta_y / steps

for i in range(1, steps):
    x = x_start + round(i * step_x)
    y = y_start + round(i * step_y)
    board[y][x] = "🔸"

# Schachbrett ausgeben
for row in board:
    for cell in row:
        print(cell, end="")
    print()
