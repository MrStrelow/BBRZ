# 1.) userinput: 
#   - die größe des spielbretts soll angegeben werden.
#   - welche position soll als start gewählt werden, welche als ziel.

# i.) user informieren was er/sie eingeben soll
dimension = 10
# print(type(dimension))

x_start, y_start = input("Startpunkt wählen [x y]: ").split(" ")
x_start, y_start = int(x_start), int(y_start)

x_end, y_end = input("Endpunkt wählen [x y]: ").split(" ")
x_end, y_end = int(x_end), int(y_end)

# 2.) schachbrett generieren
# ii.) definiere variablen mit schwarzem und weißem symbol
black_square = "⬛" # windows + . (oder "\u2B1B")
white_square = "⬜"

# iii.) definiere eine Liste welche unser schachbrett darfstellen soll.
board = []
for y in range(dimension): # erzeugt mir [0,1,2,3,4] wenn user 5 eingibt
    row = []
    
    for x in range(dimension):
        if (x + y) % 2 == 0: # (x % 2 == 0 and y % 2 == 0) or (x % 2 == 1 and y % 2 == 1):
            # iii.) füge 
            row.append(white_square)
        else:
            row.append(black_square)


    board.append(row)  

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


# 5.) ausgabe des schachbretts
for y in range(dimension):
    for x in range(dimension):
        print(board[y][x], end="")
    
    print() #print(end="\n")