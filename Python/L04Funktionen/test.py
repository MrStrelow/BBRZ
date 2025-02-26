from functools import reduce

# Liste von Sätzen
texte = [
    "Python ist großartig",
    "Map und Reduce sind kompliziert aber die Denkweise ist nützlich",
    "Ohne Debugger ist das alles schrecklich",
    "Doch besser Comprehensions verwenden",
    "Wir werden aber angenehmere Funktionen kennenlernen",
    "Hässlicher, verworrener Satz mit vielen langen Worten und dem Schimpfwort"
]

# Schimpfwörter Liste (Beispiel, kann beliebig angepasst werden)
schimpfwoerter = ["reduce", "map", "hässlicher"]  # Beispiel für Schimpfwörter

# 1. `filter()` - Alle Sätze filtern, die Schimpfwörter enthalten
texte_ohne_schimpfwörter = filter(lambda satz: not any([schimpfwort in satz.lower() for schimpfwort in schimpfwoerter]), texte)

# 2. `map()` - Jedes Wort in die Anzahl seiner Buchstaben umwandeln, dabei Wörter mit Punkt, Beistrich oder über 20 Zeichen entfernen
def berechne_wortlängen(satz):
    return [len(wort) for wort in satz.split() if len(wort) <= 20 and all(c not in wort for c in ".,")]

# 3. Anwenden von `map()` auf gefilterte Sätze
wortlängen = list(map(berechne_wortlängen, texte_ohne_schimpfwörter))

print("Gefilterte Wortlängen:", wortlängen) 

# 4. `reduce()` - Alle Längen aufsummieren und Anzahl der Wörter berechnen
gesamt_summe, gesamt_anzahl = reduce(
    lambda summe, laengen: (summe[0] + sum(laengen), summe[1] + len(laengen)), 
    wortlängen, 
    (0, 0)  # Startwert als Tuple mit Werten 0 und 0
)

# 5. Durchschnitt berechnen
durchschnitt = gesamt_summe / gesamt_anzahl if gesamt_anzahl > 0 else 0

# Ausgabe
print("Durchschnittliche Wortlänge:", durchschnitt)
