from functools import reduce

# Liste von Sätzen
texte = [
    "Python ist großartig",
    "Map und Reduce sind kompliziert aber die Denkweise ist nützlich",
    "Ohne Debugger ist das alles schrecklich",
    "Doch besser Comprehensions verwenden",
    "Wir, werden, aber angenehmere, Funktionen§$%§$% kennenlernen",
    "Hässlicher, verworrener Satz mit vielen langen Worten und dem Schimpfwort"
]

schimpfwoerter =  ["reduce", "map", "hässlicher"]

texte_ohne_schimpfwoerte = list(filter(lambda satz: not any([schimpfwort in satz.lower() for schimpfwort in schimpfwoerter]), texte))

wortlaengen = list(map(lambda satz: list(map(len, satz.split())), texte_ohne_schimpfwoerte))

gesamt_summe, gesamt_len = reduce(lambda summe, laenge: (summe[0] + sum(laenge), summe[1] + len(laenge)), wortlaengen, (0, 0))

durchschnitt = gesamt_summe / gesamt_len
print(f"{durchschnitt:.2f}")



