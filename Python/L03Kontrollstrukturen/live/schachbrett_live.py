# 1.) userinput: 
#   - die größe des spielbretts soll angegeben werden.
#   - TODO: welche position soll als start gewählt werden, welche als ziel.

# i.) user informieren was er/sie eingeben soll
dimension = int(input("Größe des Spielbretts eingeben: "))
# print(type(dimension))

# 2.) schachbrett generieren
black_square = "⬛" # windows + . (oder "\u2B1B")
white_square = "⬜"

board = []
for y in range(dimension): # erzeugt mir [0,1,2,3,4] wenn user 5 eingibt
    row = []
    
    for x in range(dimension): 
        row.append(black_square)
        #board.append(white_square)

    board.append(row)  

print(board)

# 3.) linien auf den schachbrett von start zu ende zeichnen (achtung ein wenig mathe)