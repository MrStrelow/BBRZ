# Person
# Dictionary

person = { 
    # Schlüssel : Wert,
    # Key       : Value,
    "vorname"   : "Lana",
    "nachname"  : "Banana",
    "alter"     : 30,
    "ist_aktiv" : True,
    "kombinierter_name" : lambda: person["vorname"] + " " + person["nachname"]
}

person_anders = { 
    # Schlüssel : Wert,
    # Key       : Value,
    "vorname"  : "Lana",
    "nachname"  : "Banana",
    "ist_aktiv" : True,
    "kombinierter_name" : lambda: person_anders["vorname"] + " " + person_anders["nachname"] + " " + str(person_anders["ist_aktiv"])
}

print(person["vorname"])
print(person["kombinierter_name"]())
print(person_anders["kombinierter_name"]())

print(person == person_anders)

# Named Tuple
from collections import namedtuple

Person = namedtuple("Person", ["vorname", "nachname", "alter", "ist_aktiv", "kombinierter_name"])

pers = Person(
    vorname = "Lana", 
    nachname = "Banana",
    alter = 30, 
    ist_aktiv = False, 
    kombinierter_name = lambda: person_anders["vorname"] + " " + person_anders["nachname"] + " " + str(person_anders["ist_aktiv"])
)

print(pers.vorname)
print(pers.kombinierter_name())


# a = ["hallo", 30]
# print(type(a[0]))
# print(type(a[1]))