###################  Statements [ich kann KEIN = neben einem Statement (deutsch Anweisung) schreiben] ################## 
# wir sind aus java gewohnt
alter = 17
ausgabe = "" # definiere eine variable... aber das geht in python nicht... wir könne nicht String ausgabe; schreiben

if alter >= 18:
    ausgabe = "ok, du darfst ein auto kaufen."
else:
    ausgabe = "leider nein, du musst gehen."

print(ausgabe)

# daher ist in python der so genannte scope von variablen (block wo variablen leben) anders:
alter = 17

if alter >= 18:
    ausgabe = "ok, du darfst ein auto kaufen." # wir können hier innerhalb des if die ausgabe anlegen und sie ist außerhalb im print(ausgabe) erreichbar.
else:
    ausgabe = "leider nein, du musst gehen." # wir können hier innerhalb des else die ausgabe verwenden und sie ist außerhalb im print(ausgabe) erreichbar.

print(ausgabe)
# -> der scope ist "eins drüber" einlesbar wenn wir keine funktionen verwenden. 
# # "Eins drüber" heißt, innerhalb der blöcke if und else kann eine Ebene darüber, die variable verwendet werden.

# ################## Expression [ich kann EIN = neben einer Expression (deutsch Ausdruck) schreiben] ################## 
ausgabe = "ok, du darfst ein auto kaufen." if alter >= 18 else "leider nein, du musst gehen."