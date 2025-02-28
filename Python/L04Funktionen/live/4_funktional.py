verdoppeln = lambda x: x * 2
var = 3

verdoppeln(10)

def verdoppeln(x):
    return x * 2


zahlen = [1, 2, 3, 4]

print(list(map(lambda x: x * 2, zahlen)))

[x*2 for x in zahlen]

from functools import reduce

numbers = [1, 2, 3, 4]

sum_result = reduce(lambda x, y: x + y, numbers)

print(sum(numbers))

print(sum_result)  # Ausgabe: 10