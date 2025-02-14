## Variablen in Java

Variablen sind Platzhalter für Wertes eines bestimmten Typs.
Mögliche Werte einer Variable vom Typ String (eine Zeichenkette) sind
z.B. "qwer", "greetings", oder "jeder andere Satz der mir einfällt".
Wir kennzeichnen Zeichenketten mit "", damit der Computer es von Symbolen der Programmiersprache unterscheiden kann.
Wir wollen also Zeichenketten verwenden um "Befehle" in der Programmiersprache einzugeben.
Aber auch Werte für Variablen, welche Zeichenketten sind, eingeben. Wir kennzeichnen eben das mit "".

### Variable deklarieren (KEINEN Wert zuweisen)

Wir sagen dem Computer "erstelle mir eine Variable welche mit Zeichenketten umgehen soll".
Wir sagen aber nicht, welchen Wert diese haben soll.
Wir legen also im "Speicher" einen Platz welcher für unsere Variable reserviert wird, "belegen" aber noch nichts.
(Wir kaufen eine Leinwand, aber haben uns noch nicht entschieden, was wir malen wollen.)

Wir schreiben also zuerst den TYP der Variable und danach einen NAMEN mit den wir die Variable in zukunft "ansprechen" wollen.

```java
String firstString;
```

### Variable definieren/initialisieren (EINEN Wert zuweisen)

Wir sagen dem Computer "erstelle mir eine Variable welche mit Zeichenketten umgehen soll UND schreibe den Wert 'Hallo' hinein".
(Wir kaufen eine Leinwand, und malen schon im Geschäft unser Bild.)

Aus allen möglichen Werten, der ein String annehmen kann, ist dieser Variable die Zeichenkette "Hallo" zugewiesen worden.
Wir schreiben also zuerst den TYP der Variable und danach einen NAMEN mit den wir die Variable in zukunft "ansprechen" wollen
und gleichzeitig verwenden wir das "=" (ZUWEISUNGSOPERATOR) um unserer Variable eine Zeichenkette "Hallo" zuzuweisen.
Was block1.Operatoren sind besprechen wir später genauer.
Wir können uns auch einen Pfeil nach links denken "<-", wenn wir das "=" bei einer Zuweisung sehen.
Die Zeichenkette "hallo" wird von der rechten Seite, nach links in die Variable myString "reingeschoben".

```java
String myString = "Hallo";
```

Wir können also mit dem Muster `<Typ> <Name> = <Wert>` eine Variable belegen. Das Muster ist jedoch allgemeiner als hier dargestellt.
Eigentlich müsste es `<Typ> <Name> = <"alles was einen Wert mit gleichem Typ wie <Typ> erzeugt kann hier stehen">` heißen.
Das klingt sehr allgemein, und ist es auch.

```java
String otherString = myString;
```

Der Wert ist abhängig von der Variable myString. Bedeutet, was auch immer in myString steht, steht auch in otherString.
Das funktioniert, da myString den Typ String hat. Dadurch ist hier "etwas erzeugt worden mit Typ String".
Mehr zu "alles was einen Wert mit gleichem Typ wie <Typ> erzeugt kann hier stehen", wenn wir uns über block1.Operatoren unterhalten.

### Typen von Variablen

Wenn wir den `<Typ>`...
- klein schrieben → primitive Datentypen (keine Klassen),
- groß schrieben → (sind Klassen).

Klassen sind die "Grundbausteine" in JAVA und jeder objektorientierten Sprache und erlauben uns
aus Klassen, Objekte zu erzeugen. Das erlaubt uns dann "elegantere" Programme zu schreiben.

Was sind nun die Typen von Variablen?
- Zeichen(ketten):
  - String (oder für mehr funktionalität, StringBuilder)
  - char oder Character (16 Bits - ein Symbol einer Zeichenkette kann nur gespeichert werden. Diese ist im Hintergrund eine ganze Zahl)
- Ganze Zahlen:
  - long oder Long     (ganze Zahl -> [-2^32, +2^32],  keine Kommazahlen)
  - int oder Integer   (ganze Zahl -> [-2^16, +2^16],  keine Kommazahlen)
  - short oder Short   (ganze Zahl -> [-2^8,   +2^8],  keine Kommazahlen)
  - byte oder Byte     (ganze Zahl -> [-2^4,   +2^4],  keine Kommazahlen)
- Kommazahlen:
  - float oder Float   (Kommazahl, weniger genau wie Double)
  - Double oder Double (Kommazahl)
- logische Werte:
  - boolean oder Boolean (hat 0 oder 1 als Wert)

Hier definieren wir unsere erste Variable vom Typ Integer (myInteger) sowie die Variable vom primitiven Typ (myPrimitiveInteger).

```java
Integer myInteger = 8;
int myPrimitiveInteger = 8;
```

JAVA erlaubt und unabhängig, ob eine Variable primitive ist oder nicht, diese mit dem Zuweisungsoperator "=" gleich zusetzten.
An sich ist JAVA hier streng. wir können nicht eine Variable vom Typ String und eine vom Typ StringBuilder gleich setzten,
das diese nicht den exakt gleichen Typ haben.

```java
myPrimitiveInteger = myInteger;
myInteger = myPrimitiveInteger;
```

JAVA erlaubt und unabhängig, ob eine Variable primitive ist oder nicht, diese mit dem Zuweisungsoperator "=" gleich zusetzten.

An sich ist JAVA hier streng. Wir können nicht eine Variable vom Typ String und eine vom Typ StringBuilder gleich setzen,
da diese nicht den exakt gleichen Typ haben.

Zudem sehen wir hier auch folgendes:
Wenn eine Variable einmal definiert bzw. deklariert wird, dann muss diese nur mehr mit dem `<Namen>` angesprochen werden.

```java
int myPrimitiveInteger = myInteger; // würde hier nicht funktionieren, da myPrimitiveInteger bereits definiert wurde.
```

Wir werden zuerst einfachheitshalber nur die "Klassen" als Typen verwenden. Also keine primitiven Datentypen.
Der Vorteil von Variablen, welche einen primitiven Typ haben ist, sie sind schlanker und verbrauchen "weniger" Speicher.
Auch ``kann möglicherweise`` der Ort an dem sie sich befinden (Stack) schneller für den Computer verwendbar sein, als der Ort wo mit ``sicherheit`` Objekte liegen (Heap).
Der Nachteil: primitive Datentypen erlauben weniger "Funktionalität".

Das sehen wir hier, wenn wir eine Zahl in einen String umwandeln wollen.
Variablen, welche eine Klasse als Typ haben, besitzen Methoden, primitive Datentypen nicht.

```java
String yetAnotherString = myInteger.toString();
System.out.println(yetAnotherString);
```

Wichtig: Das Ergebnis der Methode ist ein Wert, welcher wie bei Operatoren einen Typ hat.
Hier kommt also eine Zahl in die Methode rein und ein String raus.

Dieses Ergebnis kann wie jeder andere String verwendet werden.
Deshalb ist auch eine Zuweisung zu einer Variable mit dem Zuweisungsoperator `=` möglich!

Wir können nun `yetAnotherString` weiter verwenden, z.B. ausgeben oder weiter manipulieren:

```java
System.out.println(yetAnotherString.toUpperCase());
```

Wir sehen auch, dass wir das Ergebnis der Methode `toUpperCase()` direkt verwenden können und dieses nicht
in einer Variable speichern müssen. Falls wir später im Programm das Ergebnis erneut benötigen, wäre es jedoch verloren.
Daher empfiehlt es sich, es in einer Variable zu speichern, insbesondere wenn die Berechnung aufwendig ist.

Falls eine Methode z. B. 3 Stunden benötigt, um ein Ergebnis zu erzeugen, sollte dieses Ergebnis auf jeden Fall
in einer Variable gespeichert werden.

```java
String upperString = yetAnotherString.toUpperCase();
System.out.println(upperString);
```

Gehen wir nun die verschiedenen Variablentypen durch. Beginnen wir mit Zeichenketten und einzelnen Zeichen.


TODO: hier fehlen texte.....

## Variablen in Java

An sich ist JAVA hier streng. Wir können nicht eine Variable vom Typ String und eine vom Typ StringBuilder gleich setzen,
da diese nicht den exakt gleichen Typ haben.

Zudem sehen wir hier auch folgendes:
Wenn eine Variable einmal definiert bzw. deklariert wird, dann muss diese nur mehr mit dem `<Namen>` angesprochen werden.

```java
int myPrimitiveInteger = myInteger; // würde hier nicht funktionieren, da myPrimitiveInteger bereits definiert wurde.
```

Wir werden zuerst einfachheitshalber nur die "Klassen" als Typen verwenden. Also keine primitiven Datentypen.
Der Vorteil von Variablen, welche einen primitiven Typ haben ist, sie sind schlanker und verbrauchen "weniger" Speicher.
Auch ist der Ort an dem sie sich befinden (Stack) schneller für den Computer verwendbar, als der Ort wo Objekte liegen (Heap).
Der Nachteil: primitive Datentypen erlauben weniger "Funktionalität".

Das sehen wir hier, wenn wir eine Zahl in einen String umwandeln wollen.
Wir werden umwandlungen von Variablen in einem eigenen JAVA file behandeln.

&#x20;       // Wichtig für uns jetzt ist, Variablen, welche eine Klasse als Typ haben, haben Methoden

&#x20;       // und Variablen welche einen primitiven Datentyp haben, nicht.

&#x20;       // Methoden sind wie block1.Operatoren, welche Werte/Variablen entgegennehmen, diese umwandeln, und einen neuen Wert zurückgeben.

&#x20;       // Das sehen wir hier, wenn wir aus unserem Integer myInteger mit der Methode toString() eine Zahl nehmen und diese in einen String umwandeln.

&#x20;       // Methoden werden von Variablen (auch Objekten genannt, wenn der Typ eine Klasse ist) mit dem "." Operator aufgerufen.

```java
String yetAnotherString = myInteger.toString();
System.out.println(yetAnotherString);
```

Wichtig: Das Ergebnis der Methode ist ein Wert, welcher wie bei Operatoren einen Typ hat.
Hier kommt also eine Zahl in die Methode rein und ein String raus.

Dieses Ergebnis kann wie jeder andere String verwendet werden.
Deshalb ist auch eine Zuweisung zu einer Variable mit dem Zuweisungsoperator `=` möglich!

Wir können nun `yetAnotherString` weiter verwenden, z.B. ausgeben oder weiter manipulieren:

```java
System.out.println(yetAnotherString.toUpperCase());
```

Wir sehen auch, dass wir das Ergebnis der Methode `toUpperCase()` direkt verwenden können und dieses nicht
in einer Variable speichern müssen. Falls wir später im Programm das Ergebnis erneut benötigen, wäre es jedoch verloren.
Daher empfiehlt es sich, es in einer Variable zu speichern, insbesondere wenn die Berechnung aufwendig ist.

Falls eine Methode z. B. 3 Stunden benötigt, um ein Ergebnis zu erzeugen, sollte dieses Ergebnis auf jeden Fall
in einer Variable gespeichert werden.

```java
String upperString = yetAnotherString.toUpperCase();
System.out.println(upperString);
```

Gehen wir nun die verschiedenen Variablentypen durch. Beginnen wir mit Zeichenketten und einzelnen Zeichen.

### Zeichenketten (`String`) und einzelne Zeichen (`char`)

#### `Character` Datentyp

```java
Character userInputDecimalNumber = 97;  // ASCII-Code für 'a'
Character userInputHexNumber = 0x018E;  // Unicode-Zeichen
Character userInputChar = 'a';
```

```java
System.out.println("'" + userInputChar + "' ist das gleiche wie '" + userInputDecimalNumber + "'");
```

Da der Computer meist nur mit Zahlen umgehen kann, gibt es ein "Mapping" von Zahlen zu Symbolen.
Ein Beispiel: Der Wert `97` entspricht dem Symbol `'a'`. Diese Codes heißen ASCII- oder Unicode-Codes.

Beispiel für Unicode-Zeichen:

```java
Character million = '҉';
System.out.println(million);
```

**Smileys und Unicode-Zeichen:**

```java
String tannenbaum = "🌲";
System.out.println(tannenbaum);
```

Wir können auch Zeichen anhand ihrer ASCII- oder Unicode-Werte manipulieren:

```java
Character aPlusB = 97 + 98;
System.out.println(aPlusB);
```


