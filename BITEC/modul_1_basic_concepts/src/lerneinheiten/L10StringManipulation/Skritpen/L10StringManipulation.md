# Manipulation von Strings

#### Welche Begriffe werden hier verwendet?
[``Wert``](../../../glossar.md#wert), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ),  [``logische Formel``](../../../glossar.md#logische-formel), [``Kontrollstruktur``](../../../glossar.md#kontrollstruktur), [``Anweisung``](../../../glossar.md#anweisung), [``Ausdruck``](../../../glossar.md#ausdruck), [``Bedingung``](../../../glossar.md#bedingung), [``Verzweigung``](../../../glossar.md#bedingung), [``Block``](../../../glossar.md#bedingung), [``Zweig``](../../../glossar.md#zweig) [``For-Schleife``](../../../glossar.md#while-schleife), [``While-Schleife``](../../../glossar.md#while-schleife), [``Schleife``](../../../glossar.md#schleife), [``Zählvariable``](../../../glossar.md#zählvariable), [``break``](../../../glossar.md#break), [``index``](../../../glossar.md#index), [``Zuständigkeit eines Blocks``](../../../glossar.md#zuständigkeit-eines-blocks), [``Auswertungsreihenfolge``](../../../glossar.md#auswertungsreihenfolge), [``Syntax``](../../../glossar.md#syntax).

Wir lernen hier mehrere Werkzeuge kennen um ``Werte`` des ``Typs`` *String* zu manipulieren. Darunter verstehen wir z.B. 
* nur gewisse Teile einer ``Werte`` des ``Typs`` *String* auslesen, 
* ``Muster`` wie z.B. eine *E-Mail* innerhalb von ``Werte`` des ``Typs`` *String* erkennen,
* *Zahlen* und *Uhrzeit/Datum* in einem gewissen ``Format`` darstellen und
* eine komprimierte (weniger Speicher) Darstellung von Texten finden.

Wir beginnen dazu mit *Standardbefehlen* welche uns ``JAVA`` zur Verfügung stellt. Diese können für einfache Operationen verwenden. Danach lernen wir eine von ``JAVA`` unabhängige und weitverbreitete *Sprache* kennen welche wir in der ``Console``, *Texteditoren* und verschiedensten *Programmiersprachen* verwenden können um ``Muster`` in Texten erkennen bzw. extrahieren zu können.

## Einfache String-Operationen
Die folgenden Operationen werden mithilfe von ``Methoden`` umgesetzt. Wir gehen nicht weiter auf den ``Operator`` *+* ein, welcher eine ``Concatenation`` von *Strings* darstellt. Dieser wurde in [dieser](../../L03Operatoren/skripten/L03Operatoren.md) Lerneinheit besprochen. 

### Sind zwei Strings gleich?
Wir wissen bereits wie wir dieses Problem lösen. Wir verwenden die ``Methode`` *equals*. Diese hat als ``Rückgabe`` einen ``Wert`` des ``Typs`` *boolean*.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";
String vergleich = "Dies ist ein Satz welcher uEberprueft wird.";

boolean sindWirGleich = text.equals(vergleich);

System.out.println("Ist der text: '" + text + "' gleich dem anderen Text '" + vergleich + "'? - Ergebnis: " + sindWirGleich);
```

Wir bekommen hier als Antwort *False* heraus. Jedoch wieso? Wenn wir genauer in die ``Variablen`` schauen bemerken wir, dass die Groß- und Kleinschreibung nicht übereinstimmt. Der Text ist jedoch ansonsten gleich. Was wenn wir die Groß- und Kleinschreibung von den ``Werten`` ignorieren wollen? Wir können dazu die ``Methode`` *equalsIgnoreCase* verwenden. 

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";
String vergleich = "Dies ist ein Satz welcher uEberprueft wird.";

boolean sindWirGleich = text.equalsIgnoreCase(vergleich);

System.out.println("Ist der text: '" + text + "' gleich dem anderen Text '" + vergleich + "'? - Ergebnis: " + sindWirGleich);
```

Ein weiteres Beispiel, ohne zu wissen was die ``Typen`` *CharacterSequence*, *StringBuffer*, *CharBuffer* und *StringBuilder* tun, ist folgendes. Wir akzeptieren jeodch, dass diese unbekannten ``Typen`` im Prinzip eine *Zeichenkette* (wie auch der ``Typ`` *String*) darstellen. Wir sollten **immer** die ``Methode`` *contentEquals* verwenden um einen ``Wert`` des ``Typ`` *String* mit einem ``Wert`` der oben genannten ``Typen`` zu vergleichen.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";
CharacterSequence vergleichMitCharacerSequence = ....
StringBuilder vergleichMitStringBuild =  ....
StringBuffer vergleichMitStringBuffer = ....
CharBuffer vergleichMitCharBuffer = ....

boolean sindWirGleich = text.contentEquals(vergleichMitCharacerSequence);
boolean sindWirGleich = text.contentEquals(vergleichMitStringBuild);
boolean sindWirGleich = text.contentEquals(vergleichMitStringBuffer);
boolean sindWirGleich = text.contentEquals(verglvergleichMitCharBuffereichCB);
```

Wir gehen hier nicht weiter auf Details ein, denn uns fehlen noch die Werkzeuge aus der Objiektorientierung. Es ist jedoch prinzipiell möglich hier die ``Methode`` *equals* zu verwenden. Ob diese dann tut was wir wollen, ist fraglich.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";
CharacterSequence vergleichMitCharacerSequence = ....

boolean sindWirGleich = text.equals(vergleichMitCharacerSequence); // false oder machmal auch true... ? Wir wissen es nicht.
```

Wir merken uns:
> Die *Groß- und Kleinschreibung* ist bei Vergleichen mit der ``Methode`` *equals* wichtig. 
> Wenn die *Groß- und Kleinschreibung* bei Vergleichen nicht berücksichtigt werden soll verwenden wir die ``Methode`` *equalsIgnoreCase*.
> Wenn ``Variablen`` vom ``Typ`` *CharacterSequence*, *StringBuffer*, *CharBuffer* oder *StringBuilder* ist, verwenden wir die ``Methode`` *contentEquals*.

### Kommt ein String in meinem String vor?
Was jedoch wenn wir nicht *exakt* zwei Strings vergleichen wollen. Was wenn wir nur einen überprüfen wollen ob ein ``Wert`` des ``Typs`` *String* mit einem bestimmten *String* **beginnt**, **endet** oder **dazwischen sich befindet**?
Wir verwenden dazu die ``Methoden`` *startsWith*, *endsWith* und *contains*. Die ``Rückgabe`` dieser ``Methoden`` hat den ``Typ`` *boolean* und ist *wahr* wenn der Text in der angegebenen weise vorkommt. Schauen wir uns dazu foldenden Code an:

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";

// BeginntMit
boolean kommtAmAnfangVor = text.startsWith("Dies ist ein Satz");
// EndetMit
boolean kommtAmEndeVor = text.endsWith(" wird.");
// EndetMit
boolean kommtNichtVor = text.endsWith(" wiRd.");
// EndetMit
kommtNichtVor = text.endsWith(" wird..");
// Beinhaltet
boolean kommtIrgendwoVor = text.contains("Satz welcher");
// Beinhaltet
kommtNichtVor = text.contains("kommt nicht vor oder?");

System.out.println("BeginntMit: " + kommtAmAnfangVor + " - EndetMit: " + kommtAmEndeVor + " - Beinhaltet: " + kommtIrgendwoVor + " - kommt nicht vor : " + kommtNichtVor);
```

Wir merken uns:
> Die *Groß- und Kleinschreibung* ist bei Vergleichen mit den ``Methoden`` *startsWith*, *endsWith* und *contains* wichtig. 

### Wie steuere ich die Groß- und Kleinschreibung?
Wichtig ist, dass jeder *Character* des *Strings* **genau so** vorkommt wie angegeben. Die Angabe der Groß- und Kleinschreibung, sowie Satzzeichen (wenn angegeben) ist wichtig. Um Probleme welche die Groß- und Kleinschreibung verursacht erinnern wir uns an den ``Scanner``. Beim Einlesen eines Textes mit z.B. ``.nextLine()``, erlaubt uns ``toLowerCase()`` die Schreibweise des Users vernachlässenigen zu können. Gleiches kann hier angewandt werden.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.".toLowerCase();
boolean oderKommtEsDochVor = text.endsWith(" wIrd.".toLowerCase());

System.out.println("Groß- Kleinschreibung eliminiert? " + oderKommtEsDochVor);
```

Wir verwenden hier bei der ``Variable`` *text* sowie im ``Wert`` mit welchem verglichen wird, die Methode ``toLowerCase``. Das stellt sicher, dass keine Großbuchstaben mehr vorkommen.

Wenn die ``Methode`` *toUpperCase* auf den ``Wert`` angewandt wird, wird jeder Buchstabe als Großbuchstabe dargestellt. Symbole welche nicht in die Groß- und Kleinschreibung fallen, bleiben unverändert.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.".toUpperCase();
boolean oderKommtEsDochVor = text.endsWith(" wIrd.".toUpperCase());

System.out.println("Groß- Kleinschreibung eliminiert? " + oderKommtEsDochVor);
```

Wir merken uns:
> Wenn die ``Methode`` *toLowerCase* oder *toUpperCase* in Vergleichen verwendet wird, sollte diese auf beiden ``Ausdrücken`` angewandt werden. 

### Wie extrahiere ich einen Teil eines Strings?
Die ``Methoden`` *charAt* und *substring* ermöglichen es, spezifische *Character* oder Teile eines *Strings* aus einem *String* zu extrahieren. Die ``Typ`` der ``Rückgabe`` dieser ``Methoden`` ist bei *charAt* ein *Character* und bei *substing* ein *String*.

#### ... unter verwendung von substring
Wir beginnen mit der ``Methode`` *substring* und betrachten folgendes Beispiel:
```java
String text = "Dies ist ein Satz welcher ueberprueft wird.🌊";
String mySubString = text.substring(0, 2); 
System.out.println(mySubString);

mySubString = text.substring(0, text.length()); 
System.out.println(mySubString);

mySubString = text.substring(5, text.length() - 5); 
System.out.println(mySubString);

mySubString = text.substring(500, text.length() - 500); 
System.out.println(mySubString);
```

Wir erzeugen folgenden output, ...
```
Di
Dies ist ein Satz welcher ueberprueft wird.🌊
ist ein Satz welcher ueberprueft wi
Exception in thread "main" java.lang.StringIndexOutOfBoundsException: Range [500, -455) out of bounds for length 45
	at java.base/jdk.internal.util.Preconditions$1.apply(Preconditions.java:55)
	at java.base/jdk.internal.util.Preconditions$1.apply(Preconditions.java:52)
	at java.base/jdk.internal.util.Preconditions$4.apply(Preconditions.java:213)
	at java.base/jdk.internal.util.Preconditions$4.apply(Preconditions.java:210)
	at java.base/jdk.internal.util.Preconditions.outOfBounds(Preconditions.java:98)
	at java.base/jdk.internal.util.Preconditions.outOfBoundsCheckFromToIndex(Preconditions.java:112)
	at java.base/jdk.internal.util.Preconditions.checkFromToIndex(Preconditions.java:349)
	at java.base/java.lang.String.checkBoundsBeginEnd(String.java:4861)
	at java.base/java.lang.String.substring(String.java:2830)
	at lerneinheiten.L10StringManipulation.texst.main(texst.java:17)
```

... und erkennen, dass der ``Index`` für den Beginn des *substrings* bei *0* zu zählen beginnt und das Ende nicht inklusive ist. 

Wir sehen jedoch, zusätzlich falls der Text kürzer als *500* Symbole ist, können wir *text.substring(500, text.length() - 500);* nicht verwenden. Wir sollten hier eine ``Guard`` einbauen welche korrektes Verhalten sicherstellt.
```java
int userinputVon = -25;
int userinputBis = 394;

int mindestensNull = Math.max(0, userinputVon);
int hoechstensLaenge = Math.min(text.length(), userinputBis);
System.out.println(text.substring(mindestensNull, hoechstensLaenge)); 
```

Weiters sehen wir die Nützlichkeit der ``Methode`` *Math.min* um die kleinere von 2 Zahlen und der ``Methode`` *Math.max* um die größere von 2 Zahlen bestimmen zu können. Diese können verwendet werden um berechnungen an einer sinnvollen stelle abzuscheiden. Hier ist es *mindestens* *0* und *höchstens* *text.length*.

Wieso verwenden wir jedoch *Math.max* um die **kleinere** Zahl zu bestimmen und *Math.min* um die **größere** Zahl zu bestimmen? Folgende Abbildung soll dies erklären:
TODO

Wir merken uns:
> Die ``Methode`` *substring* verlangt für den ``Parameter`` *start* mindestens den ``Wert`` *0* und für den ``Parameter`` *end* höchstens die Länge des *Strings* aus welchem ein *Teilstring* entnommen wird.
> Der ``Parameter`` *start* der ``Methode`` *substring* ist inklusive.
> Der ``Parameter`` *end* der ``Methode`` *substring* ist exklusive.

#### ... unter verwendung von charAt
Der Unterschied zu *substirng* ist, dass wir mit der ``Methode`` *charAt* nur **ein** Symbol an einem ``Index`` auslesen können. Wir schauen uns für *charAt* dazu folgendes Beispiel an, welches zudem die Länge eines *Strings* benötigt. Wir bekommen diese mit der ``Methode`` *length*.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.🌊";

for (int i = 0; i < text.length(); i++) {
    System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + text.charAt(i));            
}
```

Dieser Code produziert folgenden Ouput:
```
An Position: [0] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character D
An Position: [1] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character i
An Position: [2] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character e
An Position: [3] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character s
An Position: [4] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character  
...
An Position: [38] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character w
An Position: [39] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character i
An Position: [40] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character r
An Position: [41] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character d
An Position: [42] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character .
An Position: [43] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character ?
An Position: [44] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character ?
```

Uns fällt auf, dass wir hier *45* Characters angezeigt bekommen. Wenn wir diese händisch zählen jedoch nur *44*. Zudem bemerken wir, dass der Character am ``Index`` *43* und *44* beides 🌊 darstellt und mit *?* ausgegeben wird.

Wir erinnern uns, dass Emojis mehr als 16 Bit benötigen können und dadurch 2 Symbole belegen könnten. Wir können deshalb nicht die ``Methode`` *charAt* für 🌊 verwenden. Was können wir dann tun?

Wir müssen hier zwei Methoden aufrufe verwenden um dies umsetzen zu können. 
* Wir extrahieren aus dem String den ``Unicode`` mit *codePointAt*.
* Wir wandeln den CodePoint, welcher potentiell *> 16* bit ist und dadurch mehrere *Characters* benötigt, mit *Character.toString* in einen *String* um.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.🌊";

for (int i = 0; i < text.length(); i++) {
    System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + Character.toString(text.codePointAt(i)));            
}
```

Wir bemerken jedoch, dass die letzten zwei Zeilen der Ausgabe immer noch komisch sind
```
...
An Position: [43] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character 🌊
An Position: [44] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character ?
```

Wir müssen im Falle eines Enojis, welches die Länge der ``Variable`` *text* künstlich aufbläst, korrigieren. Wir verwenden deshalb folgende ``Bedingung``.

```java
for (int i = 0; i < text.length(); i++) {
    int unicode = text.codePointAt(i) // Wir führen hier eine neue Variable ein, da wir den unicode an zwei stellen benötigen. Wir müssten ansonsten unnötigerweise diesen doppelt berechnen.

    System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + Character.toString(unicode));

    if (Character.isEmoji(unicode)) {
        i++;
    }
}
```

Wir erzeugen dadurch folgende Ausgabe:
```
...
An Position: [41] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character d
An Position: [42] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character .
An Position: [43] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character 🌊
```

Um auf einen Blick sehen zu können, dass wirklich mehr als 16 Bit für 🌊 verwendet werden, verwenden wir die ``Methode`` *Integer.toHexString*. Diese nimmt den ``Unicode``, welcher durch die ``Methode`` *codePointAt* im ``Dezimalsystem`` dargestellt wird, und wandeln es in eine *Zahl* im ``Hexadezimalsystem`` um.

```java
System.out.println(Integer.toHexString(text.codePointAt(i)));
```
Folgender Output wird erzeugt:
```
```

Warum ist das nützlich?


Ein etwas
```java
String myString = "🐻‍❄️🟠🤕🌊🏄🏻‍♂️";

for (int i = 0; i < myString.length(); i++) {
    // System.out.println(myString.charAt(i)); // Error.
    System.out.println(Character.toString(myString.codePointAt(i)));
}
```
Wir merken uns
> length
> 

3. Position eines Textes bestimmenHiermit finden Sie die Startposition (Index) eines bestimmten Teilstrings innerhalb eines Strings.Input: String (gesuchter Text)Output: int (Index des ersten Vorkommens, oder -1 wenn nicht gefunden)Verfügbare Methode:<meinText>.indexOf(<diesemText>);Beispiel:(Verwendet den oben definierten input String)        // Sucht die Position von "Wo". Da "Wo" nicht vorkommt, wird -1 zurückgegeben.
        Integer indexDesErstenBuchstabensW = input.indexOf("Wo");
        // Sucht die Position von "Sa".
        Integer indexDesErstenBuchstabensS = input.indexOf("Sa"); // Ergibt 6

        System.out.println("'Wo' beginnt an Position: " + indexDesErstenBuchstabensW);
        // Der Kommentar "(oh, es kommt nicht vor)" bezog sich ursprünglich auf "Wo", nicht "Sa".
        // "Sa" kommt im String "Dies ist ein Satz welcher ueberprueft wird." an Index 6 vor.
        System.out.println("'Sa' beginnt an Position: " + indexDesErstenBuchstabensS);
4. Teile eines Textes ersetzen / Text einfügenMit String.replace()Diese Methode ersetzt alle Vorkommnisse eines bestimmten Zeichens oder einer Zeichenfolge durch eine andere. Beachten Sie, dass String-Objekte in Java unveränderlich ("immutable") sind; replace() gibt einen neuen String zurück.        // Ersetzt alle 'i' im ursprünglichen 'input'-String durch "XXXX"
        String meinErsetzterText = input.replace("i", "XXXX");
        System.out.println("Der orginale Text: " + input + " wurde mit " + meinErsetzterText + " ersetzt.");
Mit StringBuilderDa Strings unveränderlich sind, kann bei vielen Modifikationen die Verwendung von StringBuilder effizienter sein. StringBuilder erlaubt veränderliche Zeichenfolgen.Beispiel für Modifikationen mit StringBuilder:(Verwendet den oben definierten input String)        


StringBuilder meinEingefügterText = new StringBuilder(input);

        // Fügt "NEU" an Index 10 ein
        meinEingefügterText.insert(10, "NEU");

        // Löscht Zeichen von Index 7 bis (exklusive) Index 9.
        // Dies ist vergleichbar mit replace(""), aber hier werden Indizes statt eines Textmusters angegeben.
        meinEingefügterText.delete(7, 9);

        // Löscht das Zeichen an Index 0
        meinEingefügterText.deleteCharAt(0);

        // Ersetzt Zeichen von Index 15 bis (exklusive) Index 18 durch "BUILD".
        // Die Buchstaben an den Positionen 15, 16 und 17 werden entfernt und danach wird "BUILD" eingefügt.
        meinEingefügterText.replace(15,18,"BUILD");

        // Setzt das Zeichen an Index 1 auf 'ø'
        meinEingefügterText.setCharAt(1, 'ø');

        System.out.println("Der orginale Text: " + input + " wurde manipuliert: " + meinEingefügterText.toString() + "." );
Hintergrund: String vs. StringBuilderUnveränderlichkeit (Immutability): Variablen vom Typ String sind "immutable", d.h., sie können nach ihrer Erstellung nicht geändert werden. Jede Operation, die einen String zu verändern scheint (z.B. replace(), substring(), Konkatenation), erzeugt tatsächlich ein neues String-Objekt im Speicher.Performance: Bei häufigen Änderungen kann das ständige Erzeugen neuer String-Objekte zu Performance-Einbußen führen, da Speicher allokiert und von der Garbage Collection wieder freigegeben werden muss.StringBuilder: Ist ein "Builder Pattern", das intern ein char-Array verwaltet und dessen Größe bei Bedarf dynamisch anpasst. Es erlaubt effiziente Modifikationen des Textes. Am Ende kann der Inhalt des StringBuilder mit der Methode .toString() in einen String umgewandelt werden.Wann was verwenden?:String: Für Texte, die sich nicht oder selten ändern. Besser lesbar für einfache Operationen.StringBuilder (oder StringBuffer für Thread-Sicherheit): Wenn viele Modifikationen an einem String vorgenommen werden müssen, z.B. in Schleifen beim Zusammenbauen eines komplexen Strings.Lesbarkeit vs. Optimierung: Die Lesbarkeit des Codes ist wichtig. Ein StringBuilder kann den Code manchmal schwerer lesbar machen. Vorzeitige Optimierung sollte vermieden werden ("premature optimization is the root of all evil"). Schreiben Sie zuerst sauberen, verständlichen Code und optimieren Sie ihn erst dann, wenn Performance-Probleme tatsächlich auftreten und gemessen wurden.Übungen zur String-ManipulationZusammenfassung wichtiger Methoden:Position/Index eines Sub-Strings finden: indexOf()Überprüfen, ob ein String einen anderen Sub-String enthält, damit beginnt oder endet: contains(), startsWith(), endsWith()Einen Sub-String von Position x bis y extrahieren: substring()Alle Vorkommnisse eines Sub-Strings ersetzen: replace()Das Zeichen an einer bestimmten Position erhalten: charAt()Übung 1: BasicsAufgabe: Lies einen Text als Benutzereingabe ein und führe folgende Schritte aus:a) Wandle den Text in Großbuchstaben um.b) Drehe die Reihenfolge der Buchstaben um (verwende dazu eine Methode der Klasse StringBuilder).c) Drehe die Reihenfolge der Buchstaben um (programmiere dies selbst mithilfe von Schleifen).d) Überprüfe, ob der eingegebene Text ein Palindrom ist (d.h., vorwärts und rückwärts gelesen gleich, Groß-/Kleinschreibung ignorierend).Hinweis zur Eingabe: Benötigt java.util.Scanner. Stellen Sie sicher, dass Sie import java.util.Scanner; am Anfang Ihrer Java-Datei haben.        // Annahme: import java.util.Scanner; ist vorhanden.
        Scanner scanner = new Scanner(System.in);
        System.out.print("Palindrom - Gib einen Text ein: ");

        // Die Variable 'input' wurde bereits weiter oben im globaleren Kontext deklariert.
        // Um Namenskonflikte zu vermeiden und die Lesbarkeit zu erhöhen,
        // verwenden wir hier einen neuen Variablennamen für die Benutzereingabe.
        String palindromInput = scanner.nextLine();
a) In Großbuchstaben umwandeln:        String upperCaseStr = palindromInput.toUpperCase();
        System.out.println("Uppercase: " + upperCaseStr);
b) String umdrehen (mit StringBuilder.reverse()):        String reversedStrBuilder = new StringBuilder(palindromInput).reverse().toString();
        System.out.println("Umgedreht (StringBuilder): " + reversedStrBuilder);
c) String umdrehen (manuell mit Schleife):        // Wir verwenden einen neuen Variablennamen, um Konflikte mit der vorherigen
        // 'reversedStrBuilder'-Variable zu vermeiden und die Klarheit zu wahren.
        String reversedStrManually = "";
        for (int i = palindromInput.length() - 1; i >= 0; i--) {
            reversedStrManually += palindromInput.charAt(i);
        }
        System.out.println("Umgedreht (manuell): " + reversedStrManually);
**d) Palindrom-Überprüfung (als Teil der Übung,



TODO: Passwort programm nehmen und folgendes einbauen
* Regex für hasNext(Pattern pattern); um kürzeren Code zu erhalten wie bei while(!scanner.hasNextInt()).
  * (was ist die idee dahinter? wie verwende ich diesen in einem editor ctrl+f und in JAVA?)
* string builder um strings hinzuzufügen
  * (was ist die idee dahinter? warum gibt es diesen? welche methoden stellt er zur verfügung?)
* ... Methoden aber im übernächsten kapitel erst.


A:missing /u in character encoding and garbage in between(/d{4}) replace/u B: Password validation. mindestens ein großes zeichen. gefolgt von blablabla.


```java
// Konstanten
final String RESET = "\u001B[0m";
final String WHITE = "\u001B[37m";
final String RED = "\u001B[31m";
final String GREEN = "\u001B[32m";
final String BLUE = "\u001B[34m";

final String kleinbuchstaben = "abcdefghijklmnopqrstuvwxyz";
final String grossbuchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
final String ziffern = "0123456789";
final String sonderzeichen = "!\"§$%&/()=?{[]}\\@#*+~^.,;:-_<>|";


// Variablen
Scanner scanner = new Scanner(System.in);
Random random = new Random();

boolean nochmal;
String zeichenpool;

do {
    // Achtung! Nach jeder Wiederholung zurücksetzen.
    zeichenpool = kleinbuchstaben;

    // ~~~~~~~~~~~~~~~~~~~ START UserInput ~~~~~~~~~~~~~~~~~~~
    // ------------------- Soll das Passwort Großbuchstaben beinhalten [+/-]? -------------------
    System.out.print("Soll das Passwort Großbuchstaben beinhalten [+/-]? ");

    String userInputGrossbuchstaben;

    while ( true ) {
        userInputGrossbuchstaben = scanner.next();

        if (userInputGrossbuchstaben.equals("+") || userInputGrossbuchstaben.equals("-")) {
            break;
        }

        System.out.print("Die Eingabe " + RED + userInputGrossbuchstaben + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
    }

    if (userInputGrossbuchstaben.equals("+")) {
        zeichenpool += grossbuchstaben;
    }

    // ------------------- Soll das Passwort Ziffern beinhalten [+/-]? -------------------
    System.out.print("Soll das Passwort Ziffern beinhalten [+/-]? ");

    String userInputZiffer;

    while ( true ) {
        userInputZiffer = scanner.next();

        if (userInputZiffer.equals("+") || userInputZiffer.equals("-")) {
            break;
        }

        System.out.print("Die Eingabe " + RED + userInputZiffer + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
    }

    if (userInputZiffer.equals("+")) {
        zeichenpool += ziffern;
    }

    // ------------------- Soll das Passwort Sonderzeichen beinhalten [+/-]? -------------------
    System.out.print("Soll das Passwort Sonderzeichen beinhalten [+/-]? ");

    String userInputSonderzeichen;

    while ( true ) {
        userInputSonderzeichen = scanner.next();

        if (userInputSonderzeichen.equals("+") || userInputSonderzeichen.equals("-")) {
            break;
        }

        System.out.print("Die Eingabe " + RED + userInputSonderzeichen + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
    }

    if (userInputSonderzeichen.equals("+")) {
        zeichenpool += sonderzeichen;
    }

    // ------------------- Wie lang soll das Passwort sein [ganze Zahl]? -------------------
    System.out.print("Wie lang soll das Passwort sein [ganze Zahl]? ");

    while (!scanner.hasNextInt()) {
        System.out.print("Eingabe von " + RED + scanner.next() + RESET + " ist nicht zulässig. Bitte eine ganze Zahl eingeben: ");
    }

    int laengePasswort = scanner.nextInt();

    // ------------------- Wie viele Passwörter sollen generiert werden [ganze Zahl]? -------------------
    System.out.print("Wie viele Passwörter sollen generiert werden [ganze Zahl]? ");

    while (!scanner.hasNextInt()) {
        System.out.print("Eingabe von " + RED + scanner.next() + RESET + " ist nicht zulässig. Bitte eine ganze Zahl eingeben: ");
    }

    int anzahlPasswoerter = scanner.nextInt();

    // ~~~~~~~~~~~~~~~~~~~ ENDE UserInput ~~~~~~~~~~~~~~~~~~~

    // Kontrollstrukturen
    System.out.println();
    System.out.println("Es wurden folgende Passwörter...");

    // Zuständigkeit: Erzeuge mehrere Passwörter.
    // Wie viele Passwörter sollen generiert werden? - wiederhole "anzahl der Passwörter" mal
    for (int i = 0; i < anzahlPasswoerter; i++) {
        String password = "";

        // Zuständigkeit: Erzeuge ein Passwort.
        // Wie lange soll das Passwort sein? - wiederhole "Länge des Passwort" mal
        for (int j = 0; j < laengePasswort; j++) {
            int position = random.nextInt(0, zeichenpool.length());
            password += zeichenpool.charAt(position);
        }

        System.out.println(BLUE + password + RESET);
    }

    System.out.println("... generiert.");
    System.out.println();

    System.out.print("Neue Passwörter generieren [+/-]? ");

    // ------------------- UserInput -------------------
    String userInputNeustart;

    while ( true ) {
        userInputNeustart = scanner.next();

        if (userInputNeustart.equals("+") || userInputNeustart.equals("-")) {
            break;
        }

        System.out.print("Die Eingabe " + RED + userInputNeustart + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
    }

    if (userInputNeustart.equals("-")) {
        System.out.println("Programm wurde auf Wunsch des Benutzers beendet.");
        nochmal = false;

    } else {
        nochmal = true;
    }

    System.out.println();

} while (nochmal);
```