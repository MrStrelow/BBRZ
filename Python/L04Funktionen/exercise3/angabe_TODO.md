# Welche `Konzepte` der Programmiersprache üben wir hier?
* Funktionen
* Dekoratoren
* Argumente und Rückgabewerte
* Kontrollstrukturen

# Welche `Denkweisen` üben wir hier?
* Wie kann ein `Dekorator` genutzt werden, um wiederverwendbaren Code zu erstellen?
* Wie strukturiert man ein Programm so, dass `Logging` einfach aktiviert und deaktiviert werden kann?
* Wie verhalten sich verschiedene `Log-Level` und wann werden sie verwendet?

# Bei Unklarheiten hier nachlesen:

---

## `Logging` mit einem Dekorator
Schreibe einen `Dekorator @Logging(level)`, der für jede dekorierte Funktion folgende Informationen in die Konsole ausgibt:
* Name der aufgerufenen Funktion
* übergebene Argumente (`args` und `kwargs`)
* Rückgabewert
* Laufzeit der Funktion
* Prozess-ID (`PID`)
* Benutzername (optional aus `os.getenv('USER')`)

Die Konsole soll farbcodiert sein, sodass verschiedene Log-Level unterschiedlich dargestellt werden:
* `DEBUG` - Blau
* `INFO` - Grün
* `WARNING` - Gelb
* `ERROR` - Rot

### Implementierungsdetails
* Der Dekorator soll **nur die Konsole nutzen**, kein Datei-Logging.
* Implementiere eine Klasse `Colors`, die ANSI-Farbcodes definiert.
* Implementiere eine Log-Level-Steuerung: `debug`, `info`, `warning`, `error`. Abhängig vom Level werden unterschiedliche Informationen ausgegeben:
  * `DEBUG` - Alles wird geloggt (Funktionsname, Argumente, Rückgabewert, Laufzeit, User, PID)
  * `INFO` - Nur Funktionsname, Rückgabewert, Laufzeit
  * `WARNING` - Funktionsname und Laufzeit
  * `ERROR` - Nur Fehlerausgaben
* Nutze `functools.wraps`, um den Original-Funktionsnamen zu erhalten.

### Beispielcode
```python
@Logging(level="debug")
def add(a, b):
    return a + b

@Logging(level="warning")
def multiply(a, b):
    return a * b

@Logging(level="error")
def divide(a, b):
    return a / b  # Fehler bei b=0

add(3, 5)
multiply(4, 2)
divide(6, 3)
```

### Erwartete Ausgabe
#### **Debug-Level (`level="debug"`):**
```
[DEBUG] Funktion: add (PID: 12345, User: Max)
  Args: (3, 5)
  Kwargs: {}
[RESULT] Rückgabewert: 8 (Dauer: 0.0001s)
```

#### **Warning-Level (`level="warning"`):**
```
[WARNING] Funktion: multiply (PID: 12345, User: Max)
[RESULT] Rückgabewert: 8 (Dauer: 0.0001s)
```

#### **Error-Level (`level="error"`):**
```
[ERROR] Funktion: divide (PID: 12345, User: Max)
[RESULT] Rückgabewert: 2.0 (Dauer: 0.0001s)
```

