from functools import reduce

verdoppeln = lambda x: x * 2
var = 3

verdoppeln(10)

def verdoppeln(x):
    return x * 2

zahlen = [1, 2, 3, 4, 5, 6, 7]

zahlen_quadriert = list(map(lambda x: x * 2, zahlen))

# [x*2 for x in zahlen]

sum_zahlen_quadriert = reduce(lambda x, y: x + y, zahlen_quadriert)

# print(sum(numbers))

print(sum_zahlen_quadriert)  # Ausgabe: 10

print(list(filter(lambda x: 3 <= x and x < 6, zahlen))) # zwischen 3 und 6 exclusive 6 soll true zurückgegeben werden