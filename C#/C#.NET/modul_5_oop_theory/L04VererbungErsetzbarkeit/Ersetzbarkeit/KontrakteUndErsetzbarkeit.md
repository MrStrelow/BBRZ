## Vererbung der Spezifikation
### Typbeziehungen (Unterklassen und Oberklassen)
Eine Klasse `SpezielleKlasse` ist dann eine `Unterklasse` der Klasse `AllgemeineKlasse`, wenn `SpezielleKlasse` die `Spezifikation` von `AllgemeineKlasse` erfüllt, umgekehrt aber `AllgemeineKlasse` nicht die `Spezifikation` von `SpezielleKlasse`. 
Die Klasse `AllgemeineKlasse` ist dann eine `Oberklasse` von `SpezielleKlasse`.

Die Beziehung zwischen `AllgemeineKlasse` und `SpezielleKlasse` wird `Spezialisierung` genannt. Die umgekehrte Beziehung zwischen `SpezielleKlasse` und `AllgemeineKlasse` heißt `Generalisierung`.

### Ersetzbarkeitsprinzip
Wenn die Klasse `B` eine `Unterklasse` der Klasse `A` ist, dann können in einem Programm alle Exemplare der Klasse 
`A` durch Exemplare der Klasse `B ersetzt` worden sein, `und es gelten` trotzdem weiterhin alle zugesicherten Eigenschaften (`Kontrakte`) der Klasse `A`.

#### Kontrakte bei Ersetzbarkeit
Konsequenzen des Prinzips der Ersetzbarkeit für dessen Unterklassen.

- **Vorbedingung**: 
Eine Unterklasse kann die Vorbedingungen für eine Operation, die durch die Oberklasse definiert wird, `einhalten oder abschwächen`. Sie darf die Vorbedingungen aber `nicht verschärfen`.

- **Nachbedingung**: 
Eine Unterklasse kann die Nachbedingungen für eine Operation, die durch eine Oberklasse definiert werden, `einhalten oder erweitern`. Sie darf die Nachbedingungen aber `nicht einschränken`.

- **Invariante**: 
Eine Unterklasse muss dafür sorgen, dass die für die Oberklasse definierten Invarianten `immer gelten`. Es können jedoch neue Invarianten hinzugefügt werden, welche aber nicht im Wiederspruch mit jenen aus der Oberklasse stehen drüfen.

### Verletzugn der Ersetzbarkeit - Reicht eine IST-Beziehung?
