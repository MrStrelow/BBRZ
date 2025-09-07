from functools import reduce

#   0         1       2          3
# [Name, Kategorie, Preis, Lagerbestand]
tabelle = [
    ["Laptop",         "Elektronik", 1200, 15],
    ["Kaffeemaschine", "Haushalt",   80,   30],
    ["Smartphone",     "Elektronik", 800,  0],  # Nicht verfügbar!
    ["Kopfhörer",      "Elektronik", -150,  50],
    ["Teemaschine",      "Elektronik", 350,  40],
    ["Wassermachine",      "Elektronik", 150,  50],
    ["Leintuch",       "Bücher",     25,   100], # Falsche Kategorie!
]

gefilterte_tabelle = list(
    filter(
        # funktion nach der die Filterlogik abläuft
        # nur elektornik kategorie und menge größer als 0 ist und der preis größer gleich 0 ist. 
        lambda zeile: 
            zeile[1] == "Elektronik" and zeile[3] > 0 and zeile[2] >= 0, 
        
        # die daten welche gefiltert werden sollen
        tabelle
    )
)

print(gefilterte_tabelle)

# wert pro Name: multipliziere menge mit preis pro zeile. verwende map.
kosten_pro_name = list(
    map(
        lambda zeile: 
           zeile[2] * zeile[3],
        gefilterte_tabelle
    )
)

print(kosten_pro_name)

# versicherungssumme: zähle den wert pro Name zusammen um eine finale zahl zu erhalten. verwende reduce.
versicherungssumme = reduce(
    lambda produkt_erster_artikel, produkt_zweiter_artikel: 
        produkt_erster_artikel + produkt_zweiter_artikel,
    kosten_pro_name
)


print(versicherungssumme)

####### List Comprehension
print(sum([ zeile[2] * zeile[3] for zeile in tabelle if zeile[1] == "Elektronik" and zeile[3] > 0 and zeile[2] >= 0]))

#######
res = []
for zeile in tabelle:
    if zeile[1] == "Elektronik" and zeile[3] > 0 and zeile[2] >= 0:
        res.append(zeile)


# print(gefilterte_tabelle)

list(filter(lambda zeile: zeile[1] == "Elektronik" and zeile[3] > 0 and zeile[2] >= 0, tabelle))