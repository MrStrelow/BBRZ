import time
import random

# 1. Bubble Sort Implementierung (Statements)
def bubble_sort_statement(arr):
    n = len(arr)
    for i in range(n):
        for j in range(0, n - i - 1):
            if arr[j] > arr[j + 1]:
                arr[j], arr[j + 1] = arr[j + 1], arr[j]
    return arr

# 2. Benchmark Setup
LISTEN_GROESSE = 10000
print(f"Generiere Liste mit {LISTEN_GROESSE} zufälligen Elementen...\n")
unsortierte_liste = [random.randint(1, 100000) for _ in range(LISTEN_GROESSE)]

# WICHTIG: Wir müssen die Liste kopieren! 
# Beide Algorithmen müssen mit der exakt gleichen, unsortierten Liste starten.
liste_fuer_builtin = unsortierte_liste.copy()
liste_fuer_bubble = unsortierte_liste.copy()

# 3. Test: Eingebautes sort()
print("Starte eingebautes sort()...")
start_time_builtin = time.perf_counter()

liste_fuer_builtin.sort()

end_time_builtin = time.perf_counter()
zeit_builtin = end_time_builtin - start_time_builtin
print(f"Fertig in: {zeit_builtin:.6f} Sekunden\n")


# 4. Test: Unser Bubble Sort
print("Starte Bubble Sort (Achtung, das dauert jetzt ein paar Sekunden)...")
start_time_bubble = time.perf_counter()

bubble_sort_statement(liste_fuer_bubble)

end_time_bubble = time.perf_counter()
zeit_bubble = end_time_bubble - start_time_bubble
print(f"Fertig in: {zeit_bubble:.6f} Sekunden\n")


# 5. Auswertung
# Wir fangen den Fall ab, falls zeit_builtin extrem nah an 0 ist
faktor = zeit_bubble / zeit_builtin if zeit_builtin > 0 else float('inf')
print("-" * 40)
print(f"ERGEBNIS:")
print(f"Das eingebaute sort() war {faktor:,.0f} mal schneller als Bubble Sort.")