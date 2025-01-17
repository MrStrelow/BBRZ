# 1.) userinput: 
#   - die größe des spielbretts soll angegeben werden.
#   - TODO: welche position soll als start gewählt werden, welche als ziel.

# i.) user informieren was er/sie eingeben soll
dimension = int(input("Größe des Spielbretts eingeben: "))
# print(type(dimension))
x_start, y_start = input("Startpunkt wählen [x y]: ").split(" ")
x_start, y_start = int(x_start), int(y_start)

x_end, y_end = input("Endpunkt wählen [x y]: ").split(" ")
x_end, y_end = int(x_end), int(y_end)

# 2.) schachbrett generieren
black_square = "⬛" # windows + . (oder "\u2B1B")
white_square = "⬜"

board = []
for y in range(dimension): # erzeugt mir [0,1,2,3,4] wenn user 5 eingibt
    row = []
    
    for x in range(dimension):
        if (x + y) % 2 == 0: # (x % 2 == 0 and y % 2 == 0) or (x % 2 == 1 and y % 2 == 1):
            row.append(white_square)
        else:
            row.append(black_square)


    board.append(row)  

# 3.) linien auf den schachbrett von start zu ende zeichnen (achtung ein wenig mathe)
board[y_start][x_start] = "🟡"
board[y_end][x_end] = "❌"

# 4.) ausgabe des schachbretts
for y in range(dimension):
    for x in range(dimension):
        print(board[y][x], end="")
    
    print() #print(end="\n")