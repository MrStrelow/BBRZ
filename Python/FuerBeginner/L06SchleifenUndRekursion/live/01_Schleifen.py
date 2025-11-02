from random import randint

namen = ["hans", "andrea", "ans", "gans"]

for i, name in enumerate(namen):
    if i % 2 == 0:
        print(name.upper())
    else:
        print(name)

for name in namen:
    print(name)

# wir haben keine for Schleife im Sinne einer Zählschleife. 
# Wir verwenden diesen Trick um eine "Liste" welche die Zahlen 0-4 zu generieren
print(list(range(4))) 
print(list(range(5,10))) # oder von 5 bis 9.
# Achtung! die erste Zahl ist im Ergebnis dabei (inklusive), die 2. nicht (exklusive). 
# ist meistens bei programmiersprachen so.
# Ausnahmen:
print(randint(10,11))

for i in range(len(namen)):
    # print("hallo " + str(i))
    # print("hallo", i)
    print(f"hallo {i}")
    # print(f"hallo {5 if i % 2 == 0 else 7}") #geht nicht? wir brauchen einen index. -> enumerate(namen) verwenden.

print(randint(1,2))
