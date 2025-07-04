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

# while wenn ich es nicht weiß, wie oft ich mich wiederhole
