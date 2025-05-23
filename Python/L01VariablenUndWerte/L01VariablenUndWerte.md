# Variablen und Werte in Python

#### Welche Begriffe werden hier verwendet?
[`Programm`](), [`Wert`](), [`Konsole`](), [`Variable`](), [`Typ`](), [`String`](), [`Integer`](), [`Float`](), [`Fließkommazahl`](), [`Boolean`](), [`initialisieren`](), [`Zuweisungsoperator`](), [`Interpreter`](), [`dynamisch typisierte Programmiersprache`](), [`stark typisierte Programmiersprache`](), [`objektorientierte Programmiersprache`](), [`Klasse`](), [`Objekt`](), [`Funktion`](), [`Methode`](), [`Anweisung`](), [`Ausdruck`]()

---

Wir haben 4 grundlegende Werkzeuge erwähnt, welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen
* ❔ Operatoren (bzw. Funktionen aufrufen)
* ❔ Verzweigungen und Bedingte Ausdrücke
* ❔ Schleifen

## Was wollen wir in einem Programm tun?
Ein `Programm` ist für uns die Manipulation von `Werten`, um ein Ergebnis zu erzeugen. In den meisten Computersprachen müssen wir diesen `Werten` immer einen `Typ` geben. Wir tun dies mit einer speziellen Kennzeichnung dieser `Werte`. Diese Kennzeichnung schaut für die folgenden `Typen` folgendermaßen aus:

| Typ | Kennzeichnung | Beispiel |
|--------------|-----------|-----------|
| `str` (String) | ein Text zwischen zwei doppelten Anführungszeichen "" oder einfachen '' | `"🔷 Hellø World, aber es kann auch viel mehr dort stehen wie ﬗ und 🌱"` |
| `int` (Integer) | eine Zahl ohne Punkt (Ganze Zahl) | `-5` und `568` |
| `float` (Float) | eine Zahl mit Punkt (Kommazahlen) | `-9.6584` und `7.`, was abgekürzt für `7.0` ist. |
| `bool` (Boolean) | das Wort `True` und `False` groß geschrieben | |

Wir übergeben nun im folgenden Code der `Konsole` `Werte` von verschiedenen `Typen`. Bedeutet wir geben diese auf der `Konsole` aus.

```python
print("ich bin ein Wert vom Typ String.")
print(3658)       # ich bin ein Wert vom Typ Integer.
print(3658.968)   # ich bin ein Wert vom Typ Float.
print(True)       # ich bin ein Wert vom Typ Boolean.
```

Wir merken uns:
> Ein `Computerprogramm` ist für uns die Manipulation von `Werten`, um ein Ergebnis zu erzeugen.

## Kurzsprechweise von Werten
Da es umständlich ist, immer von `Werten` eines `Typs` zu sprechen, werden wir z.B. anstatt `"Hallo" ist ein Wert vom Typ String` sagen: `"Hallo" ist ein String`. Gleiches gilt für andere `Typen`.

## Warum müssen wir Werte des Typ Strings zwischen "" oder '' schreiben?
Wir kennzeichnen `Strings` (oder auch `Zeichenketten` genannt), mit `""` oder `''`, damit der `Interpreter` sie von Symbolen der Programmiersprache, wie z.B. `print`, unterscheiden kann. Da unsere Sprache textbasiert ist, haben wir eine doppelte Verwendung von Text. Durch eine Kennzeichnung wie eben `""` ist diese Unterscheidung möglich.

## Was erlauben uns Variablen zu tun?
`Variablen` erlauben uns, `Werte` später im Programm wiederzuverwenden, indem wir diese durch einen `Namen` ansprechbar machen. Eine `Variable` wird also zu einem Platzhalter für verschiedene `Werte`. Da Python eine `dynamisch typisierte Programmiersprache` ist, müssen wir den `Typ` **nicht** bei der Erstellung einer `Variable` angeben. Die `Variable` nimmt automatisch den `Typ` des zugewiesenen `Wertes` an.

### Initialisierung
In Python gibt es keine Trennung zwischen Deklaration und Definition, wie sie in einigen anderen Sprachen existiert. Eine Variable wird in dem Moment erstellt und `initialisiert`, in dem ihr zum ersten Mal ein Wert zugewiesen wird. Verwendet man eine Variable, der nie ein Wert zugewiesen wurde, führt dies zu einem Fehler.

Bei der `Initialisierung` wird einer `Variable` mit einem `Wert` zugewiesen.

```python
# Das ist eine Initialisierung. Die Variable 'mein_string' wird erstellt und
# ihr wird der Wert "Hallo" zugewiesen. Ihr Typ ist nun 'str'.
mein_string = "Hallo"

# Man kann einer Variable den speziellen Wert 'None' zuweisen,
# um zu signalisieren, dass sie absichtlich leer ist.
platzhalter = None
print(platzhalter)

# Später kann man ihr einen neuen Wert und damit auch einen neuen Typ zuweisen.
platzhalter = 5
print(platzhalter) # Der Typ von 'platzhalter' ist jetzt 'int'.
```

Wir merken uns:
> In Python wird eine Variable durch die erste Zuweisung eines Wertes `initialisiert`.

## Was kann ich einer Variable zuweisen?
Wir können mit dem Muster *<Name> <Zuweisungsoperator> <Wert>* eine Variable `initialisieren`. Das Muster ist jedoch allgemeiner als hier dargestellt.
Eigentlich müsste es heißen: *<Name> <Zuweisungsoperator> <Ausdruck, der einen Wert erzeugt>*.

Der `Zuweisungsoperator` ist mit dem Symbol `=` abgebildet. Wir können uns auch einen Pfeil nach links denken **<-**, wenn wir das `=` bei einer Zuweisung sehen. Wir nehmen also den `Ausdruck`, welcher *rechts* vom `Zuweisungsoperator` steht und "schreiben" den erzeugten `Wert` in die `Variable` welche links steht. Die Variable nimmt dabei den Typ des Wertes an.

```python
mein_string = "das ist ein String"              # Der Wert rechts vom = hat den Typ str.
anderer_string = mein_string                    # Die Variable rechts vom = hat den Typ str.
benutzereingabe = input("Gib etwas ein: ")       # Die Funktion rechts vom = erzeugt einen Wert vom Typ str.
alter = 42
formatiert = f"Wert: {alter}"                   # Der Ausdruck rechts vom = erzeugt einen Wert vom Typ str.
```

Die *komplette Zeile* nennen wir eine `Anweisung`.

Wir merken uns:
> Die `Variable` links vom `Zuweisungsoperator` `=` nimmt den `Wert` und den `Typ` des `Ausdrucks` rechts davon an.

> Ein `Ausdruck` ist `Programmcode`, welcher einen `Wert` erzeugt.
> Eine *Zeile* eines `Programmcodes` ist eine `Anweisung`. Diese erzeugt *nicht zwangsläufig* einen `Wert`.

## Verschiedene Arten von Typen
In Python gibt es eine Reihe von eingebauten, fundamentalen Datentypen. Die wichtigsten für den Anfang sind:
- **Zeichenketten**:
  - `str` (Eine Kette von Unicode-Zeichen)
- **Zahlen**:
  - `int` (Ganze Zahlen beliebiger Größe)
  - `float` (Kommazahlen, auch Fließkommazahlen genannt)
- **logische Werte**:
  - `bool` (Kann nur die Werte `True` oder `False` annehmen)

Wir merken uns:
> `Typen` wie `str`, `int`, `float` und `bool` sind die Grundbausteine unserer Daten. `Variablen` werden kleingeschrieben, wodurch wir sie gut von `Typen` unterscheiden können (obwohl Typen in Python auch kleingeschrieben sind, werden sie oft in einem anderen Kontext verwendet).

## In Python ist alles ein Objekt
Im Gegensatz zu Sprachen wie Java gibt es in Python keine Unterscheidung zwischen "primitiven Typen" und "Klassen" (oder Wrapper-Klassen). In Python ist **alles** ein `Objekt`. Eine Zahl ist ein Objekt, ein String ist ein Objekt, sogar eine Funktion ist ein Objekt.

Ein `Objekt` ist eine Bündelung von Daten (Werten) und Funktionen, die auf diesen Daten arbeiten. Diese Funktionen, die zu einem Objekt "gehören", nennt man `Methoden`. Wir können diese `Methoden` mit dem `Aufrufeoperator` (einem Punkt `.`) aufrufen.

Da in Python alles ein Objekt ist, hat auch jeder Wert und jede Variable potenziell `Methoden`, die wir nutzen können.

```python
# 'benutzer_input' ist ein Objekt vom Typ 'str'.
# Wir können die Methode 'upper()' darauf aufrufen, um eine großgeschriebene Version zu erhalten.
benutzer_input = "Hallo Welt"
gross_geschrieben = benutzer_input.upper() # .upper() ist eine Methode des String-Objekts

print(gross_geschrieben) # Gibt "HALLO WELT" aus

# 'meine_zahl' ist ein Objekt vom Typ 'int'.
meine_zahl = 5
# int-Objekte haben auch Methoden. 'bit_length()' gibt die Anzahl der Bits zurück,
# die zur Darstellung der Zahl benötigt werden.
print(meine_zahl.bit_length()) # Gibt 3 aus (da 5 binär 101 ist)
```

Wir merken uns:
> `Funktionen`, die zu einem `Objekt` gehören, nennen wir `Methoden`. Wir rufen sie mit dem Punkt-Operator `.` auf.

> Da in Python alles ein Objekt ist, können wir auf fast alle unsere Variablen Methoden anwenden, um mit ihnen zu arbeiten.

## Ergebnisse von Funktionen
Das Ergebnis einer Funktion (oder Methode) ist ein `Wert`, der ebenfalls einen Typ hat. Wir können dieses Ergebnis direkt verwenden oder in einer Variable speichern.

```python
mein_text = "   einige leerzeichen am anfang und ende   "
# Die Methode .strip() entfernt Leerzeichen am Anfang und Ende eines Strings.
# Das Ergebnis ist ein neuer String, den wir in 'gesaeubert' speichern.
gesaeubert = mein_text.strip()

print(f"Original: '{mein_text}'")
print(f"Gesäubert: '{gesaeubert}'")

# Wir können das Ergebnis auch weiterverarbeiten, ohne es zwischenzuspeichern.
# Hier verketten wir Methodenaufrufe:
# 1. strip() -> "einige leerzeichen am anfang und ende"
# 2. upper() -> "EINIGE LEERZEICHEN AM ANFANG UND ENDE"
sofort_gross = mein_text.strip().upper()
print(sofort_gross)
```

Wenn wir das Ergebnis einer aufwendigen Berechnung erneut benötigen, ist es sinnvoll, es in einer `Variable` zu speichern. Dauert eine Funktion z.B. drei Minuten, um ein Ergebnis zu erzeugen, sollten wir dieses Ergebnis auf jeden Fall in einer `Variable` speichern, anstatt die Funktion mehrmals aufzurufen.

---

## Zeichenketten (Strings)
Ein `String` in Python ist eine unveränderliche Sequenz von Unicode-Zeichen. Das bedeutet, wir können alle möglichen Symbole, Buchstaben und Emojis aus der ganzen Welt in einem String speichern.

`Werte` vom `Typ` `str` werden mit einfachen `'` oder doppelten `"` Anführungszeichen gekennzeichnet.

```python
# Beide Schreibweisen sind gültig
string_eins = "Hallo Welt 🌲"
string_zwei = 'Hallo Welt 🔷'

# Man kann die jeweils andere Art von Anführungszeichen im String verwenden:
zitat = "Er sagte: 'Python ist super!'"
print(zitat)
```

Da Strings eine Sequenz von Zeichen sind, können wir sie mit dem `+` Operator aneinanderhängen (konkatenieren).

```python
teil_eins = "Hallo"
teil_zwei = "du"
teil_drei = "Welt"

ganzer_satz = teil_eins + " " + teil_zwei + " " + teil_drei + "!"
print(ganzer_satz) # Gibt "Hallo du Welt!" aus
```

### Unicode und Sonderzeichen
Da Python-Strings Unicode nativ unterstützen, können wir Sonderzeichen direkt einfügen. Man kann sie auch über ihre Unicode-Codepunkte darstellen, indem man `\u` für 4-stellige Hex-Codes oder `\U` für 8-stellige Hex-Codes verwendet.

```python
# Direkte Eingabe von Symbolen
symbol_direkt = "Das kyrillische Millionensymbol ist ҉"
print(symbol_direkt)

# Eingabe über Unicode-Code
# U+0489 ist der Hex-Code für das Symbol ҉
symbol_via_code = "Das ist es auch: \u0489"
print(symbol_via_code)

# Emojis sind auch nur Unicode-Zeichen
emoji = "Ein Baum ist \U0001F332"
print(emoji)
```

### Effizientes Zusammenfügen von Strings
Obwohl die Verkettung mit `+` einfach ist, kann sie bei sehr vielen Teilen ineffizient sein. Der empfohlene Weg, viele kleine Strings zu einem großen zusammenzufügen (z.B. in einer Schleife), ist, sie zuerst in einer Liste zu sammeln und dann die `join()`-Methode zu verwenden.

```python
# Ineffizient in einer Schleife mit sehr vielen Wiederholungen
resultat = ""
for i in range(10):
  resultat = resultat + str(i) + " "
print(resultat)

# Effizienter Weg
teile_liste = []
for i in range(10):
  teile_liste.append(str(i))

# Die join-Methode wird auf dem Trennzeichen-String aufgerufen.
resultat_effizient = " ".join(teile_liste)
print(resultat_effizient)
```

Wir merken uns:
> Eine Aneinanderreihung von Zeichen wird *Zeichenkette* oder *String* genannt.

> Die `Operation` `Konkatenation` beschreibt das Aneinanderhängen von Strings.

> Um viele Strings effizient zusammenzufügen, sammelt man sie in einer Liste und verwendet die `join()`-Methode.

## Positive und Negative Zahlen ohne Komma - Ganze Zahlen (`int`)
Ganze Zahlen (keine Kommazahlen, die aber negativ und positiv sein können) werden in Python durch den Typ `int` repräsentiert. Ein großer Vorteil von Python ist, dass `int`-Variablen eine beliebige Größe haben können, begrenzt nur durch den verfügbaren Arbeitsspeicher deines Computers. Es gibt keine Unterscheidung zwischen `byte`, `short`, `int` und `long` wie in Java.

```python
# Eine normale ganze Zahl
meine_zahl = 42

# Eine sehr große Zahl, die in Java ein 'long' wäre
grosse_zahl = 92233720368547758071234567890

# Berechnungen funktionieren wie erwartet
produkt = meine_zahl * grosse_zahl
print(produkt)
```

## Zahlen mit Kommastellen (`float`)
Kommazahlen werden in Python durch den Typ `float` dargestellt. Intern verwenden sie eine Darstellung mit doppelter Genauigkeit (64-Bit), was dem `Double` in Java entspricht. Wir nennen sie `Fließkommazahlen`, weil das Komma "fließen" kann, um eine breite Spanne von Werten (sehr kleine und sehr große Zahlen) darzustellen.

Diese Flexibilität hat jedoch einen Preis: Rundungsfehler. Nicht jede Dezimalzahl kann exakt als binäre Fließkommazahl dargestellt werden.

```python
mein_float = 0.25  # Dieser Wert ist exakt darstellbar

# 0.1 ist im Binärsystem ein periodischer Bruch und kann nicht exakt dargestellt werden
ein_zehntel = 0.1
print(f"Ein Zehntel ist: {ein_zehntel:.25f}") # Zeigt die Ungenauigkeit

summe = 0.1 + 0.1 + 0.1
print(f"Die Summe ist: {summe:.25f}")
print(f"Ist die Summe gleich 0.3? {summe == 0.3}") # False! Wegen der Rundungsfehler
```

Wir merken uns:
> `float`-Zahlen sind nützlich, aber haben Rundungsfehler.

> Vergleiche **niemals** zwei `float`-Werte direkt mit dem `Vergleichsoperator` `==`. Überprüfe stattdessen, ob ihr Unterschied kleiner als eine sehr kleine Toleranz ist.

## Boolesche Werte (`bool`)
Boolesche Werte können nur einen von zwei Zuständen annehmen: "Wahr" oder "Falsch". In Python werden diese durch die Schlüsselwörter `True` und `False` (beide großgeschrieben) dargestellt.

Boolesche Werte sind das Fundament der Logik in Programmen. Wir verwenden sie, um den Ablauf eines Programms zu steuern, z.B. in Verzweigungen und Schleifen.

```python
ist_student = True
hat_bezahlt = False

print(f"Ist Student? {ist_student}")

# Das Ergebnis von Vergleichen ist immer ein boolescher Wert
alter = 20
ist_volljaehrig = (alter >= 18)
print(f"Ist volljährig? {ist_volljaehrig}")
```