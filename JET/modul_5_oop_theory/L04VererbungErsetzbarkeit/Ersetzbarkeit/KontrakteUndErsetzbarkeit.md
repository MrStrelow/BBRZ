## Vererbung der Spezifikation
### Typbeziehungen (Unterklassen und Oberklassen)
Eine Klasse `SpezielleKlasse` ist dann eine `Unterklasse` der Klasse `AllgemeineKlasse`, wenn `SpezielleKlasse` die `Spezifikation` von `AllgemeineKlasse` erf�llt, umgekehrt aber `AllgemeineKlasse` nicht die `Spezifikation` von `SpezielleKlasse`. 
Die Klasse `AllgemeineKlasse` ist dann eine `Oberklasse` von `SpezielleKlasse`.

Die Beziehung zwischen `AllgemeineKlasse` und `SpezielleKlasse` wird `Spezialisierung` genannt. Die umgekehrte Beziehung zwischen `SpezielleKlasse` und `AllgemeineKlasse` hei�t `Generalisierung`.

### Ersetzbarkeitsprinzip
Wenn die Klasse `B` eine `Unterklasse` der Klasse `A` ist, dann k�nnen in einem Programm alle Exemplare der Klasse 
`A` durch Exemplare der Klasse `B ersetzt` worden sein, `und es gelten` trotzdem weiterhin alle zugesicherten Eigenschaften (`Kontrakte`) der Klasse `A`.

#### Kontrakte bei Ersetzbarkeit
Konsequenzen des Prinzips der Ersetzbarkeit f�r dessen Unterklassen.

- **Vorbedingung**: 
Eine Unterklasse kann die Vorbedingungen f�r eine Operation, die durch die Oberklasse definiert wird, `einhalten oder abschw�chen`. Sie darf die Vorbedingungen aber `nicht versch�rfen`.

- **Nachbedingung**: 
Eine Unterklasse kann die Nachbedingungen f�r eine Operation, die durch eine Oberklasse definiert werden, `einhalten oder erweitern`. Sie darf die Nachbedingungen aber `nicht einschr�nken`.

- **Invariante**: 
Eine Unterklasse muss daf�r sorgen, dass die f�r die Oberklasse definierten Invarianten `immer gelten`. Es k�nnen jedoch neue Invarianten hinzugef�gt werden, welche aber nicht im Wiederspruch mit jenen aus der Oberklasse stehen dr�fen.

### Verletzugn der Ersetzbarkeit - Reicht eine IST-Beziehung?
