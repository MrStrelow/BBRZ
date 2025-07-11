# ------------------------------ For Schleife ------------------------------
# for für wenn ich wieß wie oft ich mich wiederhole
# for-each schleife im "zählschleifen style"
print("Version 1")
for i in [0, 1, 2, 3, 4]:
    print(i)

print("Version 2")
wiederholungen = [0, 1, 2, 3, 4]
for i in wiederholungen:
    print(i)

print("Version 3")
for i in range(5):
    print("hallo")

print("Version 4")
for i in range(3,7):
    print(i)

print("Version 5")
for i in [3,4,5,6]:
    print(i)

print("Version 6")
for i in range(3,7):
    if i % 2 == 0: #gerade
        print(i)
    else:
        print("ungerade")


# for-each schleife
print("for-each-Schleife")
print("Variante 1")
teilnehmerlist_03072025 = ["Sandra", "Wandra", "Danndra"]
teilnehmerlist_04072025 = ["Sandra", "Wandra", "Danndra", "Bert"]

teilnehmerlist_zum_drucken = teilnehmerlist_04072025 

for fach in teilnehmerlist_zum_drucken:
    print(fach)

print("Variante 2")
for zaehler, fach in enumerate(teilnehmerlist_zum_drucken):
    if zaehler % 2 == 0:
        print(fach + " - " + str(zaehler))


print("Variante 3")
for zaehler, fach in enumerate(teilnehmerlist_zum_drucken):
    if zaehler % 2 == 0:
        print(fach, " - ", zaehler)

# ------------------------------ While Schleife ------------------------------
# while wenn ich es nicht weiß, wie oft ich mich wiederhole
eingabe = ""

while eingabe != "yössas":
    eingabe = input("Bitte geben Sie das Wort 'yössas' ein: ")

print(eingabe + " wurde eingegeben. Danke.")

# ------------------------------ Rekursion ------------------------------
def wiederhole_mich_5_mal(wiederholungen):
    print(wiederholungen-1)

    if wiederholungen - 1 == 0:
        return
    
    wiederhole_mich_5_mal(wiederholungen-1)


wiederhole_mich_5_mal(5)

print("+++++++++++++++++++++++++")

elemente = [4, 3, 2, 1]
for i in elemente:
    print(i)

print("##########################")

# wähle das erste element der liste
print(elemente[0])

# wähle das letzte element der liste
print(elemente[-1])
print(elemente[len(elemente)-1])

# erstes und letztes element der liste nicht dabei
print(elemente[1:-1])

# erstes element der liste nicht dabei
print(elemente[1:])
