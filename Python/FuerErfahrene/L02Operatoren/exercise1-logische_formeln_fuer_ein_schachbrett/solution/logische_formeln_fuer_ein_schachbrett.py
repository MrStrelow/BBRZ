# 1)
# x und y jeweils  Variblen - diese sind die Positionen der x und y Achse. Siehe Achsen neben den Schachbrett.
x = 0
y = 0

# 2)
weiß = x % 2 == 0
schwarz = not weiß
# schwarz = x % 2 == 1

# weiß = x % 2 not = 1
# schwarz = x % 2 not = 0

# 3)
weiß = (x % 2 == 0 and y % 2 == 0) or (x % 2 == 1 and y % 2 == 1)
schwarz = not weiß
# schwarz = (x % 2 == 1 and y % 2 == 0) or (x % 2 == 0 and y % 2 == 1)

# 4)
weiß = (x % 2 == 0 and y % 2 == 0 and (x + y) % 3 != 0 ) or (x % 2 == 1 and y % 2 == 1 and (x + y) % 3 != 0)
schwarz = (x % 2 == 1 and y % 2 == 0 and (x + y) % 3 != 0 ) or (x % 2 == 0 and y % 2 == 1 and (x + y) % 3 != 0)
rot = (x + y) % 3 == 0

# 5)
weiß = (x + y) % 2 == 0
schwarz = (x + y) % 2 == 1

# 6)
schwarz = y == 0 or y == 5 or x == 0 or x == 5
weiß = not schwarz

# 7)
schwarzAußen = y == 0 or y == 5 or x == 0 or x == 5
schwarzInnen = ((2 <= y and y <= 3) and (x == 2 or x == 3)) or ((2 <= x and x <= 3) and (y == 2 or y == 3))
schwarz = schwarzAußen or schwarzInnen

weiß = ((1 <= y and y <= 4) and (x == 1 or x == 4)) or ((1 <= x and x <= 4) and (y == 1 or y == 4))

# Tipp: formuliere die weiße Formel und setze schwarz auf not weiß, spart arbeit.
