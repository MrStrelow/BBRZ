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