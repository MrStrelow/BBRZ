from math import pi
from dataclasses import dataclass
from types import SimpleNamespace

## standard class
class CircleStandard: # statement!
    # eigenschaften -> siehe konstruktor
    # methoden
    def area(self):
        return self.radius ** 2 * pi


    # konstruktor
    def __init__(self, radius, color = "red"):
        self.radius = radius
        self.color = color


## data class
@dataclass
class CircleData: # statement!
    # eigenschaften
    radius: float
    color: str = "red"

    # methoden
    def area(self):
        return self.radius ** 2 * pi
    # konstruktor
    #... brauche wir nicht!
    
############# main #############
circle = CircleStandard(radius=10, color="blue")
print(f"Mein Circle (Standard) ist {circle.area():.2f}")

circle = CircleData(radius=10, color="blue")
print(f"Mein Circle (Data) ist {circle.area():.2f}")

## Objekte ohne Klassen! -> Variante: dict
circle = {
    # eigenschaften
    "radius" : 10, # Achtung! Doppelpunkt sagt aus, dass jetzt ein value nach dem key kommt. Hat nichts mit dem Typ zu tun wie bei Dataclass.
    "color" : "blue",
    # methoden
    "area" : lambda: pi * circle["radius"] ** 2
}

print(f"Mein Circle (Dict ohne Klasse!) ist {circle['area']():.2f}")

circle_2 = {
    # eigenschaften
    "radius" : 10, # Achtung! Doppelpunkt sagt aus, dass jetzt ein value nach dem key kommt. Hat nichts mit dem Typ zu tun wie bei Dataclass.
    "color" : "blue",
    # methoden
    "area" : lambda: pi * circle_2["radius"] ** 2,
    "umfang" : lambda: 2* pi * circle_2["radius"]
}

print(f"Mein Circle (Dict ohne Klasse!) ist {circle_2['umfang']():.2f}")

# ja nettere schreibweise mit simple namespace

circle_simple = SimpleNamespace(
    # eigenschaften
    radius = 10, # Achtung! Doppelpunkt sagt aus, dass jetzt ein value nach dem key kommt. Hat nichts mit dem Typ zu tun wie bei Dataclass.
    color = "blue",
    # methoden
    area = lambda: pi * circle_simple.radius ** 2,
    umfang = lambda: 2* pi * circle_simple.radius
)

print(f"Mein Circle (SimpleNamespace ohne Klasse!) ist {circle_simple.umfang():.2f}")





