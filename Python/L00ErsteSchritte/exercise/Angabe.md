## Erste Schritte mit Python

### Hinweise
Als Voraussetzung für diese Übungen sollte eine Python-Entwicklungsumgebung (z.B. VS Code mit Python-Erweiterung, PyCharm, Spyder) oder zumindest ein Texteditor und ein installierter Python-Interpreter vorhanden sein. Python-Skripte werden üblicherweise in Dateien mit der Endung `.py` gespeichert.

### Formatierung des Dokuments:
- Python-Code
- Beispiel-Konsolenausgaben

### Farbcodes für die Konsole (ANSI Escape Codes):
Diese Codes funktionieren in den meisten modernen Terminals.

```python
ANSI_RESET = "\u001B[0m"
ANSI_BLACK = "\u001B[30m"
ANSI_RED = "\u001B[31m"
ANSI_GREEN = "\u001B[32m"
ANSI_YELLOW = "\u001B[33m"
ANSI_BLUE = "\u001B[34m"
ANSI_PURPLE = "\u001B[35m"
ANSI_CYAN = "\u001B[36m"
ANSI_WHITE = "\u001B[37m"
```

### Beispiel für farbige Ausgabe:
```python
# Erfordert die oben definierten ANSI-Konstanten
print("Hello " + ANSI_RED + "World" + ANSI_RESET + "!")
```

## Erste Konsolenausgaben

1.  Erstellen Sie eine Python-Datei (z.B. `hallo_welt.py`), die "Hello World" auf die Konsole ausgibt.

2.  Adaptieren Sie das Programm durch folgende Schritte:
    * Geben Sie als erste Zeile Ihren Vornamen mittels `print()` aus.
    * Geben Sie in der zweiten Zeile Ihren Nachnamen mit `print()` aus.
    * Geben Sie in einer separaten Zeile folgenden Text aus: *Heute ist Mittwoch, der 04. Oktober 2023.*
        * Jedes Wort soll hierbei separat mit `print()` und der `end`-Option ausgegeben werden, um in einer Zeile zu bleiben, z.B.: `print("Heute", end=" ")`.
    * Geben Sie denselben Satz jetzt mit Tabulatoren als Abstände aus. **Tipp:** `\t` erzeugt einen Tabulator innerhalb eines Strings.
    * Geben Sie die einzelnen Strings `"3"`, `"+"`, `"7"`, `"="`, `"10"` in einer Zeile auf die Konsole aus.
        * In Python können Strings mit `+` verkettet werden.

    Beispiel für String-Verkettung:
    ```python
    print("Hello" + " " + "World")
    ```

3.  Geben Sie die Zahl `3` auf die Konsole aus.

4.  Geben Sie die Zahlen `1` bis `5` mit Tabulatoren getrennt auf die Konsole aus. Jede Zahl soll durch eine andere Farbe dargestellt werden (verwenden Sie die oben definierten ANSI-Farbcodes).

5.  Geben Sie das Ergebnis der Berechnung `3+7` auf die Konsole aus.
    **Wichtig:** Geben Sie nicht einfach den String `"10"` aus, sondern lassen Sie Python die Berechnung durchführen.
    ```python
    # print("10") # wäre hier nicht die gesuchte Lösung für die Berechnung
    ```

## Arbeiten mit Programm-Argumenten

Programm-Argumente sind Werte, die einem Skript beim Aufruf über die Kommandozeile mitgegeben werden. In Python greift man darauf über das Modul `sys` und die Liste `sys.argv` zu.

1.  Machen Sie sich damit vertraut, wie Sie einem Python-Skript Argumente übergeben.
    * **In der Kommandozeile:** `python ihr_skript.py Wien BBRZ`
        Hier wären `"Wien"` das erste Argument (`sys.argv[1]`) und `"BBRZ"` das zweite (`sys.argv[2]`). `sys.argv[0]` ist immer der Name des Skripts selbst.
    * **In IDEs (z.B. VS Code, PyCharm):** Suchen Sie in den Ausführungskonfigurationen ("Run/Debug Configurations", "launch.json" etc.) nach einer Option, um Programm-Argumente festzulegen.

    *(Hinweis: Die genaue Einstellungsmethode für Programm-Argumente in einer IDE variiert. Konsultieren Sie die Dokumentation Ihrer IDE.)*

2.  Importieren Sie das `sys`-Modul am Anfang Ihrer Python-Datei (`import sys`).
    Geben Sie in Ihrer `hallo_welt.py` (oder einer neuen Datei) 3 Leerzeilen und folgende Titelzeile aus:
    ```
    === Arbeiten mit Argumenten ===
    ```
    **Tipp für Leerzeilen:** `print("\n\n\n...")` oder mehrere `print()`-Aufrufe.

3.  Geben Sie darunter das erste übergebene Argument aus. **Tipp:** Dieses ist über `sys.argv[1]` zugreifbar. Stellen Sie sicher, dass mindestens ein Argument übergeben wurde, um einen `IndexError` zu vermeiden (z.B. mit einer `if`-Abfrage auf `len(sys.argv)`).

4.  Geben Sie folgendes auf die Konsole aus, wobei die Werte für die Stadt und die Organisation aus den Programm-Argumenten stammen sollen:
    ```
    Das erste Argument ist Wien und das zweite Argument ist BBRZ.
    ```
    Verwenden Sie `sys.argv[1]` und `sys.argv[2]`. Achten Sie auch hier auf eine ausreichende Anzahl an Argumenten.

In Python können Strings mit `+` verkettet werden, oder Sie verwenden f-Strings für eine modernere Formatierung:
```python
name = "Welt"
# Mit +
print("Hallo" + " " + name)
# Mit f-String (oft bevorzugt)
print(f"Hallo {name}")
```
Für diese Übung können Sie bei der `+`-Verkettung bleiben, um näher am Java-Beispiel zu sein.
