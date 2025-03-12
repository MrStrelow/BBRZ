Wir wollen hier Umwandlungen zwischen verschiedenen Typen (String, Double, Integer, Boolean, Float, Long, ...) kennenlernen.

Wir behandeln die Klassen "Integer/Double/..." usw. und auch primitive Datentypen "int/double/..." usw.
Außerdem ist, wenn unten "Zahl" erwähnt wird "Double/Float/Integer/Long" und deren primitiven Varianten (double/float/int/long) gemeint.

## Definition der Typen

Wir definieren/deklarieren nun alle Varianten von Typen, die wir uns anschauen wollen.

```java
Integer ganzeZahl = 1;
int ganzePrimitiveZahl = 10;
```

### Wiederholung:
Der Basistyp eines ganzzahligen Wertes z.B. `35` ist `int`, und der einer Fließkommazahl z.B. `0.5` ist `double`.
Deshalb muss hier, wie bei `Float`, bei der Zuweisung gesagt werden, dass es sich rechts vom Zuweisungsoperator `=` um einen `Long` handelt.
Wir tun dies mit dem `L` oder `l` am Ende des Wertes.

```java
Long grosseGanzeZahl = 2L;
long grosseGanzePrimitiveZahl = 20L;

Float kleineKommaZahl = 3.0f;
float kleinePrimitiveKommaZahl = 30.0f;

Double grosseKommaZahl = 4.0;
double grossePrimitiveKommaZahl = 4.0d;

Boolean boolscherWert = false;
boolean boolscherPrimitiverWert = true;
```

### Strings zur Speicherung von Zahlen und Wahrheitswerten

```java
String kleineGanzeTextZahl;
String kleineGanzePrimitiveTextZahl;
String grosseGanzeTextZahl;
String grosseGanzePrimitiveTextZahl;
String kleineKommaTextZahl = "75.2";
String kleinePrimitiveKommaTextZahl;
String grosseKommaTextZahl = "101.5";
String grossePrimitiveKommaTextZahl;
String boolscherTextWert;
String boolscherPrimitiverTextWert;
```

## Kategorien von Umwandlungen

Es gibt hier 3 "Kategorien" von Umwandlungen:

1. Von einer Zahl zu einer anderen Zahl (verwende z.B. `<variable>.intValue()`)
2. Von einer Zahl zu einem String (verwende `<variable>.toString()`, siehe Beispiel unten)
3. Von einem String zu einer Zahl (verwende `Integer.parseInt()`)

Alle Typen von z.B. ganzen Zahlen, welche wir verwenden, funktionieren mit allen "ähnlichen" Variablen.
Damit sind `Byte`, `Short`, `Integer` und `Long` gemeint. Wir werden uns aber nur mit `Integer` beschäftigen.

## Methodenaufruf und Objektorientierung

Zuerst müssen wir folgendes besprechen:
In Java sind die Umwandlungen nicht konsistent in der Art, wie diese aufgerufen werden.
Deshalb ein kurzer Einschub aus der Objektorientierung:

Wir haben kennengelernt, dass es Operatoren gibt, welche ein oder mehrere Inputs verwenden, um diese zu einem Output zu verbinden.
Wir können ein solches Verhalten auch mit Methoden erzeugen. Es gibt aber 2 "Orte", wo Methoden leben:

1. Einer ist bei der Variable (Objekt) selbst
2. Der andere ist bei dem Typ (Klasse)

Das gilt aber nicht für primitive Datentypen (`int`, `float`, usw.).
Was das genau bedeutet, sehen wir im folgenden Beispiel:

```java
Double meinDoublerWelcherEinIntegerWar = ganzeZahl.doubleValue();
```

Hier ist der "Ort", in dem die Methode lebt, die Variable `ganzeZahl`.

Ein Beispiel für letzteres ist "parseInt()".  
Diese Methode nimmt den einen String als Input (Argument) und wandelt es in einen Integer um.  
Hier ist der "Ort" in dem die Methode lebt, der Typ "Integer".  
Wir können, wenn wir einen komplexen Datentyp (Klasse) aufrufen, dort Methoden verwenden, sofern diese dort implementiert sind.  

```java
String meinNeunerString = "9";
Integer meinNeuner = Integer.parseInt(meinNeunerString);
```

Wir ignorieren, was bei der Ausgabe hier aufgerufen wird, vorerst.  

```java
System.out.println(ganzeZahl                       + " <Typ>: " + meinNeuner.getClass().getSimpleName());
System.out.println(meinDoublerWelcherEinIntegerWar + " <Typ>: " + meinDoublerWelcherEinIntegerWar.getClass().getSimpleName());
```

Um den Typ einer Variable in eine textuelle Form zu bringen (einen String, den ich ausgeben kann), stellt uns der Typ (Klasse) Integer, Double, usw. eine Methode `getClass` und danach `getSimpleName` zur Verfügung.  

```java
System.out.println(meinNeunerString + " <Typ>: " + meinNeunerString.getClass().getSimpleName());
System.out.println(meinNeuner       + " <Typ>: " + meinNeuner.getClass().getSimpleName());
```

Nun wieder zu den 3 "Kategorien" der Umwandlungen, die wir besprechen.  

### 1. Zahl zu Zahl:

```java
grosseKommaZahl = grosseGanzeZahl.doubleValue();
ganzeZahl = grosseKommaZahl.intValue();
grosseGanzeZahl = ganzeZahl.longValue();
grosseGanzeZahl = kleineKommaZahl.longValue();
kleineKommaZahl = grosseKommaZahl.floatValue();
```

Streng genommen gibt uns hier z.B. `grosseKommaZahl.intValue();` einen `int` zurück, nicht einen `Integer`!  
Wenn wir wirklich einen `Integer` wollen, dann müssen wir noch `Integer.valueOf(grosseKommaZahl.intValue());` dranhängen.  
Da wir hier aber nur eine "=" Zuweisung vollziehen, macht dies Java automatisch für uns.  

**Achtung!** Dieses Verhalten ist nur bei den vordefinierten Zahlen (`Integer` vs. `int`) so. Wir müssen in Zukunft (Block 2) genauestens auf die Typen achten! Denn streng genommen ist ein `Integer` nicht das gleiche wie ein `int`.  
Notwendig ist der Aufruf von `valueOf`, wenn wir Methoden von `Integer` verwenden wollen.  
Das wäre z.B., wenn wir wissen wollen, ob die Zahl den Wert "infinity" hat. Dafür können wir die Methode `isInfinite()` verwenden.  

```java
boolscherPrimitiverWert = Double.valueOf(grosseGanzeZahl.doubleValue()).isInfinite();
```

Das ist aber nicht möglich ohne den Aufruf `valueOf`. Denn eine Variable vom Typ `double` hat keine Methoden. `Double` jedoch schon!  

```java
// boolscherPrimitiverWert = grosseGanzeZahl.doubleValue().isInfinite(); // Fehler!
```

```java
System.out.println("Was ist es? - " + kleineKommaZahl.getClass().getSimpleName());
System.out.println("Was ist es? - " + grosseKommaZahl.getClass().getSimpleName());
```

Was tun wir jedoch, wenn wir primitive Typen haben? Diese sind `int`, `double`, `long`, usw.  
Dort können wir keine Methoden von der Variable aufrufen.  
Hier gibt es ein Konzept, welches Typecasting genannt wird.  
Wir schreiben dazu zwei geschwungene Klammern und in diesen den gewünschten Typ.  
z.B. `(int)`.  

```java
ganzePrimitiveZahl = (int) grossePrimitiveKommaZahl;
```

In diesem Fall wird sogar automatisch `(int)` aufgerufen. Da wir nichts falsch machen, wenn wir eine ganze Zahl
z.B. `25` zu einer Kommazahl `25.0` umschreiben.
Im umgekehrten Fall verlieren wir die Kommastellen.
z.B. `25.4` wird zu `25`. Deshalb ist im vorherigen Beispiel der Aufruf von `(int)` notwendig,
der von `(double)` hier jedoch nicht.

```java
grossePrimitiveKommaZahl = (double) ganzePrimitiveZahl;
```

Achtung! Mit den komplexen Datentypen der Zahlen funktioniert dies leider nicht immer.

```java
// ganzeZahl = (Integer) grosseKommaZahl; // Fehler!
// ganzeZahl = (int) grosseKommaZahl; // Fehler!
```

Verwende hier die vorher genannten Methoden:

```java
ganzeZahl = grosseKommaZahl.intValue();
```

Achtung! Hier ist jedoch die Reihenfolge der Aufrufe zu beachten.
Folgendes Beispiel soll dies verdeutlichen.
Die Umwandlung zwischen `int` und `Integer` ist jedoch nicht sehr nützlich,
jedoch soll es die Wichtigkeit der korrekten Reihenfolge der Auswertung verdeutlichen.

```java
ganzeZahl = ((Integer) ganzePrimitiveZahl).intValue();
```

Ohne der Klammerung wäre es ein Fehler.

```java
// ganzeZahl = (Integer) ganzePrimitiveZahl.intValue(); // Fehler!
```

Wir haben somit eine Reihenfolge der Auswertung, wobei `.` stärker bindet als `(Integer)`.
Zuerst wird die `ganzePrimitiveZahl` mit dem `.` verbunden.
Das führt zu einem Fehler, denn dieser primitive Typ hat keine Methoden.
Wenn wir klammern, dann führen wir zuerst die Umwandlung zu `(Integer)` durch. Danach ist der Aufruf der Methoden möglich.

Was passiert jedoch, wenn wir noch einen anderen Operator hinzufügen? Wie sieht hier die Reihenfolge aus?
Wir verwenden hier dazu das `+`.

Wir klammern nun korrekt, jedoch ist hier wieder ein Fehler. Wir sehen dadurch, dass `(Integer)` stärker als `+` bindet.
Bedeutet, wir wandeln zuerst die `ganzePrimitiveZahl` in einen `Integer` um.
Danach zählen wir diese mit dem `Integer` `ganzeZahl` zusammen.
Das Ergebnis des `+` Operators ist jedoch ein Wert, welcher einen primitiven Typ `int` hat!
Danach ist der Aufruf der Methode `intValue()` nicht möglich, da der primitive Typ `int` vorliegt.

```java
// ganzeZahl = ((Integer) ganzePrimitiveZahl + ganzeZahl).intValue(); // Fehler!
```

Wir müssen also zuerst die Addition klammern, da sie schwächer bindet, danach `(Integer)`, denn `(Integer)` bindet
schwächer als `.`. Danach kommt ein Wert raus, welcher den Typ `Integer` besitzt, und der Aufruf von `intValue()` ist möglich.

```java
ganzeZahl = ((Integer) (ganzePrimitiveZahl + ganzeZahl)).intValue();
```

### 2. Zahl zu String

Hier haben wir zwei Möglichkeiten, wenn ein komplexer Datentyp (Objekt) vorliegt.

Die erste ist folgende: Jedes von diesen hat die Methode `.toString()`, (auch selbst erstellte Klassen haben diese Methode!).

```java
kleineGanzeTextZahl = ganzeZahl.toString();
boolscherTextWert = boolscherWert.toString();
```

Die zweite Möglichkeit ist mittels der Methode `toString`, welche aber am Typ `Integer` und nicht an der Variable wie zuvor hängt.
Wir können damit Variablen vom Typ `Integer` und `int` behandeln.

```java
kleineGanzePrimitiveTextZahl = Integer.toString(ganzePrimitiveZahl);
kleineGanzeTextZahl = Integer.toString(ganzeZahl);
```

```java
System.out.println("Was ist es? - " + ganzeZahl.getClass().getSimpleName());
System.out.println("Was ist es? - " + kleineGanzeTextZahl.getClass().getSimpleName());
```

Wir können jedoch mit einer anderen Methode Kommazahlen besser formatieren als mit `toString`.
Diese ist die `format`-Methode.

```java
Double anotherDouble = 3.1488582546225456464;
```

Die Zahl zwischen `"%.<Zahl>f"` gibt die Anzahl der Kommastellen an.

```java
String roundedDouble = String.format("%.2f", anotherDouble);
System.out.println("Die Zahl auf zwei Kommastellen gerundet lautet - " + roundedDouble);
```

### Kommastellen eines `Double` abschneiden

Wir legen dazu eine Variable des Typs `DecimalFormat` an.
Achtung! Hier `.` auf `,` ausbessern für deutsche Computer.

```java
DecimalFormat df = new DecimalFormat("#.##");
```

`RoundingMode.FLOOR` bedeutet, wir schneiden die Kommazahlen ab.
`RoundingMode.CEILING` bedeutet, wir runden immer auf die höheren Kommazahlen auf.
Auch hier `.` auf `,` ausbessern für deutsche Computer.

```java
df.applyLocalizedPattern("#.##");
df.setRoundingMode(RoundingMode.FLOOR);
```

Hier rufen wir die vorbereitete `format`-Methode auf.

```java
String StringButItsADouble = df.format(anotherDouble);
System.out.println(StringButItsADouble);
```

Wenn hier die deutsche Variante von `1.000.000,00` und nicht die englische Variante `1,000,000.00` verwendet wird (Systemsprache Deutsch vs. Englisch).

### 3. String zu Zahl:

Hier verwenden wir die Methode "<Typ>.parse<Typ>". Damit ist z.B. `Integer.parseInt` gemeint. Aber auch `Double.parseDouble`
und `Boolean.parseBoolean`. Wenn ich einen Integer will, muss ich also mit `Integer` starten und danach `parse`,
wenn Double, dann mit `Double` starten und danach `parse`, usw.

```java
    ganzeZahl = Integer.parseInt(kleineGanzeTextZahl);
    grosseGanzeZahl = Long.parseLong(kleineGanzeTextZahl);
    boolscherWert = Boolean.parseBoolean(boolscherTextWert);

    grosseKommaZahl = Double.parseDouble(kleineKommaTextZahl);
    kleineKommaZahl = Float.parseFloat(grosseKommaTextZahl);
```

Eine Anmerkung hier ist, dass der String kein `f/F` bzw. `d/D` benötigt. Wenn diese vorhanden sind, passiert jedoch kein Fehler.
Es kann sogar ein String, welcher `"15.2f"` enthält, in der `Double.parseDouble()` Methode verwendet werden, und umgekehrt.

```java
    grosseKommaZahl = Double.parseDouble(kleineKommaTextZahl + "f");
    grosseKommaZahl = Double.parseDouble(kleineKommaTextZahl + "F");
    kleineKommaZahl = Float.parseFloat(grosseKommaTextZahl + "d");
    kleineKommaZahl = Float.parseFloat(grosseKommaTextZahl + "D");
```

#### 3.1) Boolescher Wert zu Zahl:

Wenn `boolescher Wert` gleich `true` ist, dann gibt `compareTo(false)` `1` zurück.
Wenn `boolescher Wert` gleich `false` ist, dann gibt `compareTo(false)` `0` zurück.
Achtung! Beides keine tolle Lösung. Besser mit einer Verzweigung.
Dies ist z.B. `if-else`, `switch` oder der ternäre Operator.

```java
    boolscherWert = false;
    ganzeZahl = boolscherWert.compareTo(false);

    System.out.println("Geht das wirklich?... " + ganzeZahl + " und ist vom Typ: " + ganzeZahl.getClass().getSimpleName());

    boolscherWert = true;
    ganzeZahl = boolscherWert.compareTo(false);

    System.out.println("Geht das wirklich?... " + ganzeZahl + " und ist vom Typ: " + ganzeZahl.getClass().getSimpleName());
```

Wir schauen uns kurz hier die Logik einer "wenn-dann-ansonsten" Verzweigung mittels des "ternären" Operators an.
Da wir nur einen ternären (3-ternär, 2-binär, 1-unär) Operator haben, hat er keinen spezielleren Namen.
In anderen Sprachen (z.B. Python) wird dieser "conditional expressions" genannt.

Wir können damit folgendes modellieren:

Umgangssprachlich:
> "<wenn> es regnet <dann> gehe ich schwimmen <ansonsten> bleibe ich zu Hause."

In Python verschieben wir die Reihenfolge der Aussage. Es würde dann so geschrieben werden (ohne `<>`):
> `gehe schwimmen if es regnet else bleibe zu Hause`

In Java schreiben wir dies kryptischer, aber wieder in der ursprünglichen Reihenfolge wie in der umgangssprachlichen Version:

```java
    esRegnet ? geheSchwimmen : bleibeZuHause;
```

Was tut dieser Ausdruck nun?

Schauen wir uns das vorherige Beispiel mit "wandle einen Boolean in eine Zahl um" an:

Wenn der `boolscherWert` wahr ist, dann wird `1` zurückgegeben, wenn falsch, dann `0`.

```java
    ganzeZahl = boolscherWert ? 1 : 0;
```

Mit `double` ist es nicht ganz so einfach.

```java
    double myDoubleWhoIsNotAnObject = 5.0;
    // Ist leider kompliziert... und casten "(int)" kennen wir noch nicht.
    Integer warEinmalEinDoubleUndIstJetztEinInteger2 = Long.valueOf(Math.round(myDoubleWhoIsNotAnObject)).intValue();
    Integer warEinmalEinDoubleUndIstJetztEinInteger3 = (int) Math.round(myDoubleWhoIsNotAnObject);
    Integer warEinmalEinDoubleUndIstJetztEinInteger4 = Double.valueOf(myDoubleWhoIsNotAnObject).intValue();
```