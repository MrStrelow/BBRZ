# Importiert das sys-Modul, um auf Programm-Argumente zugreifen zu können
import sys

# Farbcodes für die Konsole (ANSI Escape Codes)
ANSI_RESET = "\u001B[0m"
ANSI_BLACK = "\u001B[30m"
ANSI_RED = "\u001B[31m"
ANSI_GREEN = "\u001B[32m"
ANSI_YELLOW = "\u001B[33m"
ANSI_BLUE = "\u001B[34m"
ANSI_PURPLE = "\u001B[35m"
ANSI_CYAN = "\u001B[36m"
ANSI_WHITE = "\u001B[37m"

# === Erste Konsolenausgaben ===
print("=== Erste Konsolenausgaben ===")

# 1. "Hello World" ausgeben
print("Hello World")
print("-" * 30) # Trennlinie

# 2. Adaptieren des Programms
#    - Vorname ausgeben
vorname = "Max" # Bitte durch eigenen Vornamen ersetzen
print(vorname)

#    - Nachname ausgeben
nachname = "Mustermann" # Bitte durch eigenen Nachnamen ersetzen
print(nachname)
print("-" * 30) # Trennlinie

#    - Datumssatz Wort für Wort ausgeben
print("Heute", end=" ")
print("ist", end=" ")
print("Mittwoch,", end=" ") # Beispielhaft, da das Datum dynamisch sein sollte
print("der", end=" ")
print("16.", end=" ") # Aktuelles Datum anpassen
print("Mai", end=" ")
print("2025.", end="\n") # Zeilenumbruch am Ende
# Alternativ und kürzer für den gesamten Satz:
# import datetime
# heute = datetime.date.today()
# wochentag = ["Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag"]
# monat_name = ["Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"]
# print(f"Heute ist {wochentag[heute.weekday()]}, der {heute.day:02d}. {monat_name[heute.month-1]} {heute.year}.")


#    - Denselben Satz mit Tabulatoren
print("Heute\tist\tMittwoch,\tder\t16.\tMai\t2025.") # Tabulatoren einfügen
print("-" * 30) # Trennlinie

#    - Strings "3", "+", "7", "=", "10" in einer Zeile ausgeben
print("3" + " + " + "7" + " = " + "10")
# Alternative mit print und mehreren Argumenten (fügt automatisch Leerzeichen ein):
print("3", "+", "7", "=", "10")
print("-" * 30) # Trennlinie

# 3. Zahl 3 ausgeben
print(3)
print("-" * 30) # Trennlinie

# 4. Zahlen 1 bis 5 mit Tabulatoren und Farben
print(ANSI_RED + "1" + ANSI_RESET + "\t" +
      ANSI_GREEN + "2" + ANSI_RESET + "\t" +
      ANSI_BLUE + "3" + ANSI_RESET + "\t" +
      ANSI_YELLOW + "4" + ANSI_RESET + "\t" +
      ANSI_PURPLE + "5" + ANSI_RESET)
print("-" * 30) # Trennlinie

# 5. Ergebnis der Berechnung 3+7 ausgeben
print(3 + 7)
print("-" * 30) # Trennlinie


# === Arbeiten mit Programm-Argumenten ===
# WICHTIG: Die folgenden Zeilen werden einen IndexError verursachen,
# wenn das Skript nicht mit mindestens zwei Kommandozeilenargumenten
# aufgerufen wird (zusätzlich zum Skriptnamen selbst).

# 2. 3 Leerzeilen und Titelzeile ausgeben
print("\n\n") # Drei Leerzeilen
print("=== Arbeiten mit Argumenten ===")

# sys.argv[0] ist immer der Skriptname
# sys.argv[1] ist das erste Argument, sys.argv[2] das zweite, usw.

# 3. Erstes Argument ausgeben (ohne Fehlerbehandlung)
#    Wenn sys.argv[1] nicht existiert, bricht das Programm hier mit einem IndexError ab.
print("Das erste übergebene Argument ist:", sys.argv[0])
print("-" * 30) # Trennlinie

# 4. Satz mit beiden Argumenten ausgeben (ohne Fehlerbehandlung)
#    Wenn sys.argv[1] oder sys.argv[2] nicht existiert,
#    bricht das Programm hier (oder in der Zeile darüber) mit einem IndexError ab.
arg1 = sys.argv[0]
arg2 = sys.argv[0]
print(f"Das erste Argument ist {arg1} und das zweite Argument ist {arg2}.")
# Alternative mit + Operator:
# print("Das erste Argument ist " + arg1 + " und das zweite Argument ist " + arg2 + ".")

print("-" * 30) # Trennlinie
print("Ende des Skripts.")

