# UML Klassendiagramm

Die Überlegungen aus dem UML-Klassendiagramm werden wir nun in Klassen übersetzen. Wir haben uns dort Folgendes überlegt:
| Konzept | Beschreibung | Art der Wörter welche wir verwenden |
-------- | -------- | --------
|**Klasse** | beschreibt die "Dinge" in unserer "Welt" bzw. "Domäne" | (HAUPTWORT/NOMEN) |
|**Felder** | beschreiben den Zustand einer Klasse | (HAUPTWORT/NOMEN) |
|**Methoden** | beschreiben, was ein Ding tun kann  | (ZEITWORT/VERB) |
|**Beziehungen** | beschreiben Interaktionen zwischen Klassen | (ZEITWORT/VERB) |

Wir haben folgende Klassen, Felder, Methoden und Beziehungen definiert:

### Modellierte Klassen

#### Hund
- **Felder:** `chipped`, `health`, `age`, `geschlecht`
- **Beziehungen:**
  - `<hat>`: einen Hundebesitzer
  - `<ist>`:
- **Methoden:** `fressen()`, `bellen()`, `spielen()`, `weglaufen()`

#### Pudel
- **Felder:** `fluff`
- **Beziehungen:**
  - `<hat>`: einen Hundebesitzer
  - `<ist>`: ein Hund
- **Methoden:** `winseln()`

#### Schäferhund
- **Felder:** `capacity`
- **Beziehungen:**
  - `<hat>`: einen Hundebesitzer, welcher einen Hundefüherschein hat
  - `<ist>`: ein Hund
- **Methoden:** `hueten()`

#### Hundebesitzer
- **Felder:** `hatHundeFuehrerschein`
- **Beziehungen:**
  - `<hat>`: einen oder mehrere Hunde
  - `<ist>`: ein Mensch
- **Methoden:** `gassiGehen()`, `hundeFuettern()`, `hundeVernachlaessigen()`

#### Mensch
- **Felder:** `age`, `health`, `happiness`
- **Beziehungen:**
  - `<hat>`:
  - `<ist>`:
- **Methoden:** `hundKaufen()`
