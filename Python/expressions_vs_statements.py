# in einer liste sind zahlen, diese zahlen sollen 
#   * veroppelt werden wenn diese gerade sind.
#   * halbiert werden wenn diese ungerade sind.
#   * nicht in der Ergebnis liste vorhanden sein, wenn diese durch 9 teilbar sind.
# Das ergebnis soll wieder eine Liste sein. 
# Input: [4, 9, 11, 18, 20, 27]
# Output: [8, 5, 40]


# variante 1: Statements.
input = [4, 9, 11, 18, 20, 27]
output = []

for zahl in input: # Schleife
    if zahl % 9 != 0: # Filter
        if zahl % 2 == 0: # if-Bedingung 
            output.append(zahl * 2)
        else:
            output.append(zahl // 2)

print(output) # [8, 5, 40]


# Variante 2: Expressions.

# [ zahl * 2 wenn gerade ansonsten zahl / 2 for zahl in input ]
output = [ zahl * 2 if zahl % 2 == 0 else zahl // 2 for zahl in input if zahl % 9 != 0 ]
output = [ zahl //2 if zahl % 2 == 1 else zahl *  2 for zahl in input if zahl % 9 != 0 ]

print(output)

