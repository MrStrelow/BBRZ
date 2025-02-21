dimension = 3

field = []
for _ in range(dimension):
    row = []

    for _ in range(dimension):
        row.append(None)
    
    field.append(row)

### schreibe um zu list comprehention

field = [[None for _ in range(dimension)] for _ in range(dimension) ]