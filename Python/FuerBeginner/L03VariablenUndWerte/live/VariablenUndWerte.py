from turtle import *

# --- Vorbereitung ---

# Wir haben keine Typsicherheit. 
# Eine Variable ist ein Objekt und es kann beliebig überschrieben werden.
# kein ; am Ende und keinen Typ am 
name = 15
name = "Mathias"
name = 26.8

nachname = "Cammerlander"

# Funktionen werden wie in java geschrieben. 
print( str(name) + " " + nachname )

print(name, nachname + "\n")

# Arithmetische Operatoren

# int und float
alter = 17
print(alter)

geandertesAlter = alter + 1
alter = alter + 1
alter += 1

print("####")
print(alter)
print(alter / 2)  # 19 dividiert durch 2 ist 9.5. (normale division)
print(alter // 2) # 19 dividiert durch 2 ist 9 und ... (ganz zahldivision)
print(alter % 2)  # 1 Rest. (modulo)
print("####")

# strings
print(str(alter) + " und " + str(geandertesAlter))
print(f"{alter} und {geandertesAlter}")

mein_formatierter_string = str(alter) + "und " + str(geandertesAlter)
mein_formatierter_string = f"{alter} und {geandertesAlter}"

ganz_besonderes_symbol = "🐹" # windows taste + punkt
unicode = "\u0061"
print(unicode)



