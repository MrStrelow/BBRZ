# Operationen auf Strings

#### Welche Begriffe werden hier verwendet?
[``Wert``](../../../glossar.md#wert), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ),  [``logische Formel``](../../../glossar.md#logische-formel), [``Kontrollstruktur``](../../../glossar.md#kontrollstruktur), [``Anweisung``](../../../glossar.md#anweisung), [``Ausdruck``](../../../glossar.md#ausdruck), [``Bedingung``](../../../glossar.md#bedingung), [``Verzweigung``](../../../glossar.md#bedingung), [``Block``](../../../glossar.md#bedingung), [``Zweig``](../../../glossar.md#zweig) [``For-Schleife``](../../../glossar.md#while-schleife), [``While-Schleife``](../../../glossar.md#while-schleife), [``Schleife``](../../../glossar.md#schleife), [``Zählvariable``](../../../glossar.md#zählvariable), [``break``](../../../glossar.md#break), [``index``](../../../glossar.md#index), [``Zuständigkeit eines Blocks``](../../../glossar.md#zuständigkeit-eines-blocks), [``Auswertungsreihenfolge``](../../../glossar.md#auswertungsreihenfolge), [``Syntax``](../../../glossar.md#syntax).

Wir lernen hier mehrere Werkzeuge kennen um ``Werte`` des ``Typs`` *Strings* weiterverarbeiten zu können. Darunter verstehen wir z.B. 
* nur gewisse Teile einer ``Werte`` des ``Typs`` *String* auslesen, 
* ``Muster`` wie z.B. eine *E-Mail* innerhalb von ``Werte`` des ``Typs`` *String* erkennen,
* *Zahlen* und *Uhrzeit/Datum* in einem gewissen ``Format`` darstellen und
* eine komprimierte (weniger Speicher) Darstellung von Texten finden.

Wir beginnen dazu mit *Standardbefehlen* welche uns ``JAVA`` zur Verfügung stellt. Diese können für einfache Operationen verwenden. Dort werden wir kurz den ``Typ`` *StringBulder*  und den Unterschied zum ``Typ`` *String* besprechen. Dazu erwähnen wir das Konzept ``Mutability`` vs. ``Immutability`` und das Acronym ``CRUD``. Danach lernen wir eine von ``JAVA`` unabhängige und weitverbreitete *Sprache* kennen welche wir in der ``Console``, *Texteditoren* und verschiedensten *Programmiersprachen* verwenden können um ``Muster`` in Texten erkennen bzw. extrahieren zu können.

## Einfache String-Operationen
Die folgenden Operationen werden mithilfe von ``Methoden`` umgesetzt. Wir gehen nicht weiter auf den ``Operator`` *+* ein, welcher eine ``Concatenation`` von *Strings* darstellt. Dieser wurde in [dieser](../../L03Operatoren/skripten/L03Operatoren.md) Lerneinheit besprochen. 

### Sind zwei *Strings* gleich?
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

Wir gehen hier nicht weiter auf Details ein, denn uns fehlen noch die Werkzeuge aus der ``Objektorientierung``. Es ist jedoch prinzipiell möglich hier die ``Methode`` *equals* zu verwenden. Ob diese dann tut was wir wollen, ist fraglich.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";
CharacterSequence vergleichMitCharacerSequence = ....

boolean sindWirGleich = text.equals(vergleichMitCharacerSequence); // false oder machmal auch true... ? Wir wissen es nicht.
```

Wir merken uns:
> Die *Groß- und Kleinschreibung* ist bei Vergleichen mit der ``Methode`` *equals* wichtig. 

> Wenn die *Groß- und Kleinschreibung* bei Vergleichen nicht berücksichtigt werden soll verwenden wir die ``Methode`` *equalsIgnoreCase*.

> Wenn ``Variablen`` vom ``Typ`` *CharacterSequence*, *StringBuffer*, *CharBuffer* oder *StringBuilder* ist, verwenden wir die ``Methode`` *contentEquals*.

### Kommt ein *String* in meinem *String* vor?
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

Wenn die ``Methode`` *toUpperCase* auf den ``Wert`` angewandt wird, wird jeder Buchstabe als Großbuchstabe dargestellt. Symbole welche nicht in die Groß- und Kleinschreibung fallen, bleiben unverändert. Bei Anwendung auf beide ``Werte`` bzw. ``Variablen`` ist ebenso sichergestellt, dass die Groß- und Kleinschreibung keine Rolle spielt.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.".toUpperCase();
boolean oderKommtEsDochVor = text.endsWith(" wIrd.".toUpperCase());

System.out.println("Groß- Kleinschreibung eliminiert? " + oderKommtEsDochVor);
```

Wir merken uns:
> Wenn die ``Methode`` *toLowerCase* oder *toUpperCase* in Vergleichen verwendet wird, sollte diese auf beiden ``Ausdrücken`` angewandt werden. 

### Wie extrahiere ich die Länge eines Strings?
Durch Anwendung der ``Methode`` *length*. Diese wird folgerndermaßen aufgerufen.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";
System.out.println(text.length()) // 43
```

Da diese ``Methode`` sehr oft in Verwendung ist, gehen wir nicht weiter auf diese ein und merken uns:
> Die ``Methode`` *length* gibt die Anzahl der Symbole in einem *String* zurück.

### Wie extrahiere ich einen Teil eines Strings?
Die ``Methoden`` *charAt* und *substring* ermöglichen es, spezifische *Character* oder Teile eines *Strings* aus einem *String* zu extrahieren. Die ``Typ`` der ``Rückgabe`` dieser ``Methoden`` ist bei *charAt* ein *Character* und bei *substing* ein *String*.

#### ... unter Verwendung von *substring*
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

Wir sehen jedoch, zusätzlich falls der Text kürzer als *500* Symbole ist, können wir *text.substring(500, text.length() - 500);* nicht verwenden. Wir sollten hier eine ``Verzweigung`` einbauen welche korrektes Verhalten sicherstellt. Auch lassen wir den User zahlen angeben, welche als *start* und *ende* verwendet werden sollen.

```java
// Userinput - start
System.out.print("start angeben: ");
while (!scanner.hasNextInt()) {
    System.out.println("Bitte eine Zahl eingeben, nicht " + scanner.next());
}
int start = scanner.nextInt();

// Userinput - end
System.out.print("ende angeben: ");
while (!scanner.hasNextInt()) {
    System.out.println("Bitte eine Zahl eingeben, nicht " + scanner.next());
}
int ende = scanner.nextInt();

// Bedingungen ob Userinputs korrekt sind
boolean startInnerhalbDesTextes = 0 <= start && start <= text.length();
boolean endeInnerhalbDesTextes = 0 <= ende && ende <= text.length();
String result;

// Verzweigung - wir beheben die fehlerhafte Eingabe falls diese auftritt.
if (startInnerhalbDesTextes && endeInnerhalbDesTextes) {
    result = text.substring(start, ende);
} else {
    result = text
}

System.out.println(result);
```

Da wir hier genau eine ``Zuweisung`` innerhalb der ``If-Bedingung`` (welches eine ``Anweisung`` ist) haben, ist auch die Verwendung von einem ``Ausdruck`` möglich. 

```java
...
// Bedingungen ob Userinputs korrekt sind
boolean startInnerhalbDesTextes = 0 <= start && start <= text.length();
boolean endeInnerhalbDesTextes = 0 <= ende && ende <= text.length();
String result;

// If-Verzweigung als Ausdruck - wir beheben die fehlerhafte Eingabe falls diese auftritt.
result = startInnerhalbDesTextes && endeInnerhalbDesTextes ? 
            text.substring(start, ende) : 
            text;

System.out.println(result);
```

Wir merken uns:
> Die ``Methode`` *substring* verlangt für den ``Parameter`` *beginnIndex* mindestens den ``Wert`` *0* und für den ``Parameter`` *endIndex* höchstens die Länge des *Strings* aus welchem ein *Teilstring* entnommen wird.

> Der ``Parameter`` *beginnIndex* der ``Methode`` *substring* ist inklusive.

> Der ``Parameter`` *endIndex* der ``Methode`` *substring* ist exklusive.

##### Optional: Wie kann ich Math.min und Math.max anstatt der Verzweigung verwenden?
Wir betrachten kurz eine alternative Denkweise um sicherzustellen, dass ein korrekter Input der ``Methode`` *substring* übergeben wird. Wir begrenzen dazu die ``Variable`` *start* und *end* **sinnvoll**. Das bedeutet *start* hat **mindestens** den ``Wert`` *0* und **höchstens** den ``Wert`` *text.length*. Wir setzten diese Begrenzung mit 
* der ``Methode``*Math.min*, welche die *kleinere* von 2 Zahlen berechnet und 
* die ``Methode`` *Math.max*, welche die *größere* von 2 Zahlen berechnet.

Versuche nun den folgenden Code zu verstehen (hier werden die ``Variablen`` *start* und *ende*):
```java
...
int berechneterStartVersuch = Math.max(Math.min(start, text.length()), 0);
int berechnetesEndeVersuch = Math.min(Math.max(ende, 0), text.length());

int berechneterStart = Math.min(berechneterStartVersuch, berechnetesEndeVersuch);
int berechnetesEnde = Math.max(berechneterStartVersuch, berechnetesEndeVersuch);

System.out.println(text.substring(berechneterStart, berechnetesEnde));
```

Wir erkennen jedoch, dass z.B. in **diesem** Fall ein ``If-Ausdruck`` zu bevorzugen ist.

#### ... unter Verwendung von *charAt*
Der Unterschied zu *substirng* ist, dass wir mit der ``Methode`` *charAt* nur **ein** Symbol an einem ``Index`` auslesen können. Wir schauen uns für *charAt* dazu folgendes Beispiel an, welches zudem die Länge eines *Strings* benötigt. Wir bekommen diese mit der ``Methode`` *length*.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.";

for (int i = 0; i < text.length(); i++) {
    System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + text.charAt(i));            
}
```
Dieser Code produziert folgenden Ouput:
```
An Position: [0] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character D
An Position: [1] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character i
An Position: [2] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character e
An Position: [3] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character s
An Position: [4] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character  
...
An Position: [38] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character w
An Position: [39] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character i
An Position: [40] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character r
An Position: [41] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character d
An Position: [42] des Strings 'Dies ist ein Satz welcher ueberprueft wird.' ist der Character .
```

Wir verändern jedoch nun die ``Variable`` *text* folgendermaßen.

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

Wir merken uns:
> Die ``Methode`` *charAt* verlangt für den ``Parameter`` *index* **mindestens** den ``Wert`` *0* und **höchstens** die Länge des *Strings*.

> Der ``Typ`` der ``Rückgabe`` von *charAt* ist *Character* und kann somit alle ``Unicodes`` darstellen welche **höchstens** *16* Bit haben.

#### ... unter Verwendung von *codePointAt* und *Character.toString*

Wir erinnern uns, dass ``Emojis`` mehr als 16 Bit benötigen **können** und dadurch 2 Symbole belegen **könnten**. Wir können deshalb nicht die ``Methode`` *charAt* für 🌊 verwenden. Was können wir nun jedoch tun um 🌊 ausgeben zu können?
Wir rufen dazu zwei ``Methoden`` auf. 
* Wir extrahieren aus dem String den ``Unicode`` mit *codePointAt*.
* Wir wandeln den CodePoint, welcher potentiell *> 16* bit ist und dadurch mehrere *Characters* benötigt, mit *Character.toString* in einen *String* um.

Um auf einen Blick sehen zu können, dass wirklich mehr als 16 Bit für 🌊 verwendet werden, verwenden wir zudem die ``Methode`` *Integer.toHexString*. Diese nimmt den ``Unicode``, welcher durch die ``Methode`` *codePointAt* im ``Dezimalsystem`` dargestellt wird, und wandeln es in eine *Zahl* im ``Hexadezimalsystem`` um.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.🌊";

for (int i = 0; i < text.length(); i++) {
    int unicode = text.codePointAt(i);
    System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + Character.toString(text.codePointAt(i)) + " mit Unicode: " + Integer.toHexString(unicode));            
}
```

Folgender Output wird erzeugt:
```
An Position: [0] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character D mit Unicode: 44
An Position: [1] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character i mit Unicode: 69
An Position: [2] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character e mit Unicode: 65
An Position: [3] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character s mit Unicode: 73
An Position: [4] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character   mit Unicode: 20
...
An Position: [38] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character w mit Unicode: 77
An Position: [39] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character i mit Unicode: 69
An Position: [40] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character r mit Unicode: 72
An Position: [41] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character d mit Unicode: 64
An Position: [42] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character . mit Unicode: 2e
An Position: [43] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character 🌊 mit Unicode: 1f30a
An Position: [44] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character ? mit Unicode: df0a
```

Die `hexadezimale` Darstellung des ``Unicodes`` ist einfacher zu zählen. *2* ``hexadezimale`` ``Ziffern`` stellen *$16^2 = 256 = 2^8$* Symbole dar, was auch *8* ``bits`` tun (ein ``Byte``). Wir stellen also mit *4* ``hexadezimalen`` ``Ziffern``, genau gleich viele Symbole wie mit *16* ``bit`` dar. Wenn wir nun *5* ``hexadezimalen`` ``Ziffern`` sehen, haben wir ein Problem mit dem ``Rückgabetyp`` *Character* von der ``Methode`` *charAt*. Wir benötigen dadurch *codePointAt* und *Character.toString*.

Wir bemerken jedoch zusätzlich, dass die letzten zwei Zeilen der Ausgabe immer noch komisch sind. 
```
...
An Position: [43] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character 🌊
An Position: [44] des Strings 'Dies ist ein Satz welcher ueberprueft wird.🌊' ist der Character ?
```
Wieso brauchen wir nicht **beide** *Character* an der Stelle *43* und *44* um 🌊 darstellen zu können? Wieso müssen wir scheinbar den *Character* an der Stelle *44* entfernen?

Wir merken uns:
> Die ``Methode`` *codePointAt* verlangt für den ``Parameter`` *index* **mindestens** den ``Wert`` *0* und **höchstens** die Länge des *Strings*.

> Der ``Typ`` der ``Rückgabe`` von *codePointAt* ist *Integer* und stellt den ``Unicodes`` des Symbols dar.

> Die ``Methode`` *Character.toString* wird mit dem ``Aufrufeoperator`` *.* über den ``Typ`` *Character* aufgerufen.

> Die ``Methode`` *Character.toString* nimmt einen ``Unicode`` als ``Parameter`` mit ``Typ`` *Integer* entgegen und erzeugt eine ``Rückgabe`` des ``Typs`` *String*.

##### UTF-16 Encoding und Surrogate-Pairs:
*Strings* werden intern mit ``UTF16`` repräsentiert. In ``UTF16`` werden Zeichen durch 16-Bit dargestellt.

**Anmerkung:** Oft schreiben wir in *header* eines ``HTML`` Dokuments oder configurieren die ``Console`` mit ``UTF8``. Können wir nun ``UTF16`` encodete *Character* nicht mehr in ein solches ``HTML`` Dokument oder in die ``Console`` schreiben, da jeder *Character* nun *zwei Symbole* braucht (2*8 Bit = 16 Bit)? Doch, wir können das! Hier legen wir mit "verwende ``UTF8`` fest, dass die **Darstellung** der *Character* im **Output** ``UTF8`` verwendet. Das hat nichts mit dem zu tun, wie wir **innerhalb** einer Programmiersprache wie ``JAVA`` *Characters* codieren. Meistens funktioniert das ``Encoding`` ``UTF16`` jedoch nicht für den **Output**. Wir verwenden dort eben ``UTF8``. 

Um Zeichen außerhalb der 16 Bit darzustellen, verwendet ``UTF16`` ``Surrogate Pairs``. Dies beinhaltet *zwei* 16-Bit *Character* welche z.B. den ``Emoji`` 🌊 *zusammen* darstellen:
* High-``Surrogate`` (aus dem Unicodebereich *D800* bis *DBFF*)
* Low-``Surrogate`` (aus dem Unicodebereich *DC00* bis *DFFF*)

Hier ist *text.charAt(i)* ein High-Surrogate und *text.charAt(i+1)* ein Low-Surrogate. Die ``Methode`` *length* zählt somit die Anazhl der *Character* **inklusive** der ``Surrogates``. Das erklärt den Unterschied zwischen 43 Characters vs. 45 Characters wenn wir nur 🌊 hinzufügen. Wird jedoch *codePointAt(i)* afugerufen, erkennt diese ``Methode`` beim High-``Surrogate*``, dass es sich um ein ``Surrogate``-Paar handelt und gibt den ``Unicode`` des **vollständigen** Symbols zurück (hier *1f30a*). Beim Low-``Surrogate*`` wird jedoch der ``Unicode`` von diesem zurückgegeben (hier *df0a*), welches keine Darstellung besitzt. Es wird *?* ausgegeben.

Was tun wir nun? Wir müssen im Falle eines *Emojis*, welches die Länge der ``Variable`` *text* künstlich aufbläst, korrigieren. Wir verwenden deshalb folgende ``Bedingung``.

```java
String text = "Dies ist ein Satz welcher ueberprueft wird.🌊";

for (int i = 0; i < text.length(); i++) {
    int unicode = text.codePointAt(i) 
    System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + Character.toString(unicode) + " mit Unicode: " + Integer.toHexString(unicode));

    // (... wir stehen stehen der Methode in unserer Bedingung sehr suspekt gegenüber ...)
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

Diese scheint zu funktionieren und wir haben das Problem möglicherweise gelöst. Jedoch betrachten wir folgende **Änderung** der ``Variable`` *text*.

```java
String text = "Wi🌊rd⬜🟩🟫.🐹";

for (int i = 0; i < text.length(); i++) {
    int unicode = text.codePointAt(i);
    String korrekteDarstellung = Character.toString(unicode);
    String hexZiffern = Integer.toHexString(unicode);

    System.out.println("An Position: [" + i + "] des Strings '" + text + "' ist der Character " + korrekteDarstellung + " mit Unicode: " + hexZiffern + " ein Emoji: " + Character.isEmoji(unicode));

    if (Character.isEmoji(unicode)) {
        i++;
    }
}
```

Im folgenden Output bemerken wir, dass 🟩 nach ⬜ fehlt. Wieso?

```
...
An Position: [5] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character d mit Unicode: 64 ein Emoji: false
An Position: [6] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character ⬜ mit Unicode: 2b1c ein Emoji: true
An Position: [8] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character ? mit Unicode: dfe9 ein Emoji: false
...
An Position: [12] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character 🐹 mit Unicode: 1f439 ein Emoji: true
```

Wir bemerken, dass ⬜ sonderbar ist. Dieses Symbol ist zwar ein ``Emoji`` laut der ``Methode`` *Character.isEmoji()*, benötigt jedoch nur 16 ``bit``. Wir übersprignen deshlab mit *i++* bei *if(Character.isEmoji(unicode))* die Darstellung von 🟩 und plotten den 2. Character von 🟩 (``surrogate``) welcher als *?* dargestellt wird.

Es stimmt also die ``Bedingung`` *Character.isEmoji()* nicht! Diese identifiziert **nicht** 16 Bit vs. >16 Bit Characters. Die Lösung also nicht eine ``Methode`` welche ``Emojis`` identifiziert zu verwenden, sondern eine *technischere* Bedingung zu verwenden. Wir hatten gesagt wenn wir mehr als *16* ``bits`` benötigen, dann haben wir einen zusätzlichen *Character*. Das können wir mit *hexZiffern.length() > 4* abfragen.

```java
String text = "Wi🌊rd⬜🟩🟫.🐹";

for (int i = 0; i < text.length(); i++) {
    int unicode = text.codePointAt(i);
    String korrekteDarstellung = Character.toString(unicode);
    String hexZiffern = Integer.toHexString(unicode);

    System.out.println("i:" + i + " - " + korrekteDarstellung + " - " + hexZiffern);

//  if (Character.isEmoji(unicode)) {
    if (hexZiffern.length() > 4) {
        i++;
    }
}
```

Damit finden wir unser verlorenes 🟩 wieder.

```
An Position: [0] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character W mit Unicode: 57 ein Emoji: false
An Position: [1] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character i mit Unicode: 69 ein Emoji: false
An Position: [2] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character 🌊 mit Unicode: 1f30a ein Emoji: true
An Position: [4] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character r mit Unicode: 72 ein Emoji: false
An Position: [5] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character d mit Unicode: 64 ein Emoji: false
An Position: [6] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character ⬜ mit Unicode: 2b1c ein Emoji: true
An Position: [7] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character 🟩 mit Unicode: 1f7e9 ein Emoji: true
An Position: [9] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character 🟫 mit Unicode: 1f7eb ein Emoji: true
An Position: [11] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character . mit Unicode: 2e ein Emoji: false
An Position: [12] des Strings 'Wi🌊rd⬜🟩🟫.🐹' ist der Character 🐹 mit Unicode: 1f439 ein Emoji: true
```

Wir merken uns:
> Die ``Methode`` *length* gibt die Anzahl der *Character* inklusive der ``Surrogate-Pairs`` zurück.

> Falls ein ``Surrogate-Pair`` vorkommt, extrahiert die ``Methode`` *codePointAt* für den **high**-``Surrogate`` den ``Unicode`` des gesamten *Synmbols* und nicht des **high**-``Surrogates``.

> Falls ein ``Surrogate``-Pair vorkommt, extrahiert die ``Methode`` *codePointAt* für den **low**-``Surrogate`` den ``Unicode`` des **low**-``Surrogate``, welche wir verwerfen können.

### Wie finde ich die Position eines *Characters* im *String*?
Wir verwenden dazu die ``Methode`` *indexOf*. Diese findet das **erste** Vorkommen eines *Characters* in einem *String*. Wir wenden diese ``Methode`` folgendermaßen an.

```java
String text = "Wi🌊🐹rd⬜🟩🟫.🐹";
System.out.println(text.indexOf("🐹")); // 3
```

Wie finden wir jedoch *alle* vorkommen eines *Characters* in einem *String*? Bauen wir uns dazu unsere eigene ``Kontrollstruktur``. Wir verwenden dazu die ``Methode`` *indexOf* und überschreiben dazu das 1. Vorkommen eines *Characters* im *String* wenn wir diesen gefunden haben. Dadurch finden wir wenn *indexOf* ein 2. mal aufgerufen wird, das nächste Vorkommen des *Characters*. 

```java
int position = 0;
String text = "Wi🌊🐹rd⬜🟩🟫.🐹hallo";
Character zuSuchenderCharacter = 'l';
// String zuSuchenderString = "l" // geht auch

while (true) {
    position = text.indexOf(zuSuchenderCharacter);

    if (position <= -1) {
        break;
    }

    text.//ersetze? replace? mainpuliere den String... Wir haben jedoch keine Methode zum Manipulieren eines Strings.
    System.out.println(position);
}
```

Was nun? Anscheinend vermeiden die *Methoden* welche für einen *String* zu Verfügung stehen eine *teilweises überschreiben* des *Strings*. Wieso jedoch? Wir schauen uns dazu kurz den ``StringBuilder`` an.

#### Mutability vs. Immutability
Der ``Typ`` *String* ist intern in ``JAVA`` ``immutable``. Das bedeutet wenn wir eine ``Variable`` des ``Typs`` *String* anlegen, können die Daten im Speicher **nicht** überschrieben werden. Wenn wir also *"ich bin" + " " + "ein String"* schreiben, wird aus den *drei* Teilstrings, ein neuer *String* gebaut. Es liegen also nun *4* Strings im Speicher. Es wird **nicht** der Ort im ``Speicher`` von *"ich bin"* verwendet und *"ich bin ein String"* daraus gemacht. Der *String* mit ``Wert`` *"ich bin"* Wenn das der Fall wäre, **wäre** *String* ``mutable``. Was es aber nicht ist.

Wir lernen nun einen Grund kennen warum in JAVA *Strings* ``immutable`` sind. Die Verwendung eines ``internal String Pools``. Zusätzliche Gründe, welche wir nicht besprechen sind, ... 
* bedenken bezüglich der Sicherheit. *Strings* beinhalten oft sicherheitskritische Daten (Pfade, Namen, Passwörter bevor wir diese ``hashen``) welche schwer "hackbar" sein sollten. 
* Auch bezüglich des Software Designs ist ``immutability`` angenehm bei der ``parallelen`` Programmierung und beugt hier **schwerwiegendsten** Fehlern auf einfachste weise vor.

##### Strings im Speicher - der internal String Pool und die baseline Heap allocation
Wir gehen hier nicht genau darauf ein was der Speicher ist. Es reicht für uns folgendes zu wissen. *Strings* werden "grob" folgendermaßen angelegt. Wir haben dort *zwei* Möglichkeiten:
1) *Strings* werden im Speicher neu angelegt und wir merken uns diesen **für immer** in dem so genannten ``internal String Pool`` für eine schnelle Wiederverwendung.
2) *Strings* werden **immer** neu im Speicher angelegt und wir vergessen diesen wenn wir die ``Variable`` nicht mehr verwenden. Wir nenen diese ``baseline Heap allocation``.

Wir schreiben also folgendes:
```java
String ersteVariable = "ich bin"; // internal String pool: "ich bin" liegt nun im Speicher und wir merken es uns für immer. 

String zweiteVariable = new String("ich bin"); // baseline heap allocation: "ich bin" liegt nun doppelt im Speicher und wir vergessen es wieder wenn zweiteVariable nicht mehr benötigt wird.

zweiteVariable = null; // Wir haben "ich bin" wieder vergessen. Es liegt aber durch ersteVariable "ich bin" noch einmal im Speicher.

zweiteVariable = ersteVariable.substring(0, ersteVariable.length()); // baseline heap allocation: "ich bin" liegt nun wieder doppelt im Speicher und wir vergessen es wieder wenn zweiteVariable nicht mehr benötigt wird.

zweiteVariable = "ich bin"; // Wir überschreiben mit = zweiteVariable und vergessen den Inhalt. Danach schreiben wir es in den internal string pool. "ich bin" liegt bereits im Speicher, wir legen es nicht doppelt an.
```

Der Computer merkt sich **alle** *Strings* im Speicher, wenn wir diese mit ``Werten`` im anlegen z.B. *... = "ich bin ein Wert";*. Das ist die erwähne *Variante 2* mit ``internal String Pool``. Falls dieser ``Wert`` in einer anderen ``Variable`` wiederverwendet wird, legen wir nicht *doppelt* diese Variable an, sondern verwenden den bereits angelegten ``Wert``. Wenn eine andere Art der Zuweisung außer *.. = "ich bin ein Wert";* verwendet wird, z.B. *... = new String("ich bin");* oder *... = ersteVariable.substring(0, ersteVariable.length());*, verwenden wir *Variante 1* die ``baseline Heap allocation``. Damit merken wir uns die ``Werte`` potentiell doppelt, aber vergessen diese auch wieder wenn wir diese nicht mehr verwenden. 

Hier zum ein paar Zuweisungen welche **alle** den ``internal String Pool`` verwenden.

```java
String ersteVariable = "ich bin"; // "ich bin" liegt nun im Speicher
String zweiteVariable = "ich bin"; //  "ich bin" liegt bereits im Speicher, wir legen es nicht doppelt an.
```

Was passiert wenn wir folgendes schreiben:
```java
String ersteVariable = "ich bin"; // "ich bin" liegt nun im Speicher
String zweiteVariable = "ich bin"; //  "ich bin" liegt bereits im Speicher, wir legen es nicht doppelt an.

zweiteVariable = "doch was anderes"; // "doch was anderes" wird im Speicher hinzugefügt. Wir merken uns dort "ich bin" und "doch was anderes".
// zweiteVariable verwendet nun "doch was anderes" und nicht mehr "ich bin".

zweiteVariable = "ganz anders"; // "ganz anderes" wird im Speicher hinzugefügt. Wir merken uns dort "ich bin", "doch was anderes" und "ganz anders" 
// zweiteVariable verwendet nun "ganz anders" und nicht mehr "doch was anderes".

ersteVariable = "doch was anderes"; // "doch was anderes" gibt es bereits im Speicher. Wir verwenden es wieder und legen es nicht nochtmal an.
```

Diese Logik des ``internal String Pools`` funktioniert nur, wenn sichergestellt wird, dass *Strings* **nicht im Speicher** *manipuliert* werden kann. Wenn wir nun eine ``concatenation`` durch *+* dem bereits verwendeten Code-Snippet hinzufügen, wird ein neuer ``Wert`` mit ``Typ`` *String* im Speicher angelegt. Das passiert immer, egal ob ``internal String Pool`` oder ``baseline Heap allocation``. Die Verwendete Logik ist bei der ``concatenation`` jedoch die ``baseline Heap allocation``. Wir zwingen ``JAVA`` den ``Wert`` in den ``internal String Pool`` aufzunehmen,  wenn wir *zweiteVariable.intern()* schreiben. Das merken klingt irgendwie sinnvoll, wenn wir öfter einen *String* mit gleichem Inhalt verwenden.

```java
... // Code von oben

zweiteVariable = zweiteVariable + ersteVariable; // baseline heap allocation: "ich bindoch was anderes" wird im Speicher hinzugefügt.
zweiteVariable.intern(); //internal string pool: wenn es dort noch nicht bekann ist, wird es dort für immer gespeichert.
System.out.println(zweiteVariable);
```

Noch ein paar Änderungen. Schreiben wir dies kürzer mit dem *gemischten* ``Operator`` *+=* und innerhalb einer ``Schleife``. Zudem schreiben wir **fälschlicherweise** *zweiteVariable.intern()* und zwingen ``JAVA`` zur Aufnahme in dem ``internal String Pool``.

```java
... // Code von oben

for (int i = 0; i < 1_000_000_000; i++) {
    zweiteVariable += ersteVariable; // zweiteVariable besitzt immer einen neuen Wert.
    zweiteVariable.intern(); // Durch intern merken wir und jeden Zwischenschritt im internal string pool und fügen den neuen Wert im Speicher hinzu, auch wenn wir diesen nie wieder verwenden. Eine Milliarde mal. 
    // Das geht nicht gut aus...
}

System.out.println(zweiteVariable);
```

Wir erkennen, das scheint nicht sinnvoll in zwei Punkten zu sein. ``Werte`` wiederzuverwenden ist eine gute Idee wenn wir öfters im Programm die selben Texte verwenden, jedoch nicht in diesem Fall:
* wenn wir immer neue *Strings* erzeugen, kopieren wir den alten ``Wert`` an einem neuen Ort im Speicher und ergänzen dort das Neuhinzugefügte. **Es dauert länger**. 
* Auch merken wir uns in **jedem** Zwischenschritt dieser ``Schleife``, das Ergebnis im Speicher, auch wenn wir es nicht mehr verwenden. *Es verwendet viel Speicher*.

Eine einfache Lösung für den 2. Punkt ist das entfernen von *zweiteVariable.intern()*. Wir haben jedoch das Problem des 1. Punkts immer noch. Wir wünschen uns in diesem Fall eine Möglichkeit direkt den *String* im Speicher manipulieren zu können, ohne einen neuen anzulegen. Wir wünschen uns eine ``mutalbe`` Variante des *Strings*. Das ist der ``StringBuilder``. Dieser bietet uns nun Werkzeuge zur direkten manipulation eines Strings an. Wir gehen nicht genau auf diese ein. Diese sind jedoch ``Methoden`` mit Namen *insert*, *replace* und *delete*. 

Wir erinnern uns was wir eigentlich tun wollten. Die Position aller *Characters* in einem *String* finden. Die Idee war, wenn wir ein Vorkommen von *'l'* finden, an dieser Position das *'l'* mit z.B. *'_'* austauschen. Dadruch findet die ``Methode`` *indexOf* das nächste vorkommen von *'l'*, bis es keines mehr gibt. Wir verwenden dazu einen ``StringBuilder`` da wir was direkt manipulieren wollen. 

```java
String text = "Wi🌊🐹rd⬜🟩🟫.🐹hallo";
int position = 0;
StringBuilder textBuilder = new StringBuilder(text);
Character zuSuchenderCharacter = 'l';

while (true) {
    position = textBuilder.indexOf(Character.toString(zuSuchenderCharacter)); // StringBuilder hat auch eine Methode indexOf wie String.
    // Nur brauchen wir hier für indexOf bei einer Variable des Typs StrinBuilder einen String als Parameter und keinen Character.

    if (position <= -1) { // wenn kein 'l' mehr in textBuilder gefunden wird.
        break;
    }

    textBuilder.replace(position, position+1, "_"); // String wird direkt im Speicher manipuliert und nicht neu angelegt und der alte vergessen!
    System.out.println(position);
}
```

Es wird folgendes Ausgegeben:
```
18
19
```

Wir dürfen wieder die ``surrogate Pairs`` der ``Emojis`` nicht vergessen (⬜ braucht keines), um eine sinnvolle Interpretation von 18 und 19 als Index zu finden. 

Wir beenden diese lange und detailierte Sektion mit folgdendem **wichtigen** Hinweis... haben wir unser Problem, *finde alle Positionen eines Characters in einem String* kompliziert oder einfach gelöstes? 

Jedoch davor merken wir uns:
> Der ``internal String Pool`` wird bei der *Zuweisung* eines *Strings* durch Angabe eines *Wertes* verwendet. 

> Der ``internal String Pool`` speichert noch nicht dort vorkommende *Strings* dort ab und merkt sich diese für die Laufzeit des Programms.

> Der ``internal String Pool`` verhindert eine *doppelte* Speicherung des *gleichen* *Strings*.

> Die ``baseline Heap allocation`` wird bei der *Zuweisung* eines *Strings* durch Angabe eines ``Ausdrucks``, mit Ausnahme des ``Wertes`` verwendet.

> Die ``baseline Heap allocation`` legt den *String* *immer* neu im Speicher an, unabhängig ob dieser schon existiert.

> Die ``baseline Heap allocation`` vergisst ``Variablen`` welche nicht mehr verwenden werden.

> Der ``Typ`` *String* ist ``immutable``.

> Der ``Typ`` *StringBuilder* ist ``mutable``.

> ``Immutability`` wird ist im allgemeinen der ``Mutability`` bevorzugt.

> ``Mutability`` wird der ``Immutability`` bevorzugt, wenn wir *schnelle* und *speichereffiziente* Programme brauchen.

> Die ``Methode`` *indexOf* ist die Umkehrung der ``Methode`` *charAt*.

> Wir verwenden ``StringBuilder`` und dessen ``Methode`` *concat* anstatt häufig neue *Strings* mit *+=* zu erzeugen. 

> Wir verwenden ``StringBuilder`` wenn wir ``Update`` oder ``Delete`` Operationen bei einem *String* anwenden wollen. 

##### Kompliziert oder einfach gelöstes Problem
Wir sind prinzipiell froh, dass wir das Problem *finde alle Positionen eines Characters in einem String* gelöst haben. Wir haben um dies zu Verstehen zu können komplizierte Konzepte konzepte wie ``immutability`` und ``mutability`` angeschnitten. Was war jedoch hier der ausschlaggebende Grund? Es war folgender Gedanke:
* Wie schaffe ich es *indexOf* von dem Verhalten *finde **das erste** Vorkommen eines Characters* auf *finde **alle** Vorkommen eines Characters* abzuändern. Wir hätten hier uns **sofort** fragen sollen, ist diese **Änderung** mit dem Werkzeug *indexOf* sinnvoll? Die Antwort hier ist - Nein. 

Anmerkung: Es gibt die Möglichkeit die Verwendung des *StringBuilder* zu umgehen indem wir *index = text.indexOf(character, index + 1)* verwenden. Dort suchen wir nach dem ersten Vorkommen des gefunden *Character*, durch *index + 1* erst nach dem angegeben Ort weiter. Das ändert jedoch nichts am Problem, dass der Code dennoch sich sehr *technisch* und *unüberischtlich* anfühlt.

Wenn wir die **Anforderungen** des Problems uns anschauen bemerken wir, dass die natürlich zu scheindende *Erweiterung* von *ein Vorkommen* auf *alle Vorkommen* nicht einfach umsetzbar ist. Wieso versuchen wir nicht es auf eine andere weise zu lösen und zwar ohne *indexOf*.

Wir kommen zu folgendem Schluss:
```java
String text = "Wi🌊🐹rd⬜🟩🟫.🐹hallo";
Character zuSuchenderCharacter = 'l';

for (int i = 0; i < text.length(); i++) {
    if (text.charAt(i) == zuSuchenderCharacter) { // == da wir Character vergleichen
        System.out.println(i);
    }
}
```
mit Output:
```
18
19
```

und falls wir einen ``Emoji`` suchen, mit dem Umweg durch *codePointAt*.

```java
String text = "Wi🌊🐹rd⬜🟩🟫.🐹hallo";
String zuSuchenderString = "🐹";

for (int i = 0; i < text.length(); i++) {
    if (text.codePointAt(i) == zuSuchenderString.codePointAt(0)) { // == da wir Integer vergleichen
        System.out.println(i);
    }
}
```
mit Output:
```
4
14
```

Dieser Code ist einfacher zu verstehen. Wir vernachlässigen hier die Diskussion der ``Performacne``, welche fast nie ein Grund für schwerer lesbaren Code sein sollte. Wir nehmen auch dieses Beispiel nicht zu ernst, denn die Variante mit *indexOf* ist nicht um Welten schlimmer. Es ist ein Beispiel um auf "kleine Änderungen, mit potentiell großen Wirkungen" aufmerksam zu machen.

Wir merken uns:
> Es ist nicht absehbar ob eine *kleine Änderung* der ``Anforderung``, nicht zur Verwendung *gänzlich anderer Werkzeuge* führt.

> Wir versuchen zu Beginn **immer** in der *Breite* zu Denken bevor wir in die *Teife* gehen und stürzen und nicht **sofort** in die *Tiefe* bei der Lösung eines Problems. 

### Wie gebe ich eine formatiere Zahl als String aus?
Wir haben kurz den ``Typ`` *DecimalFormatter* in [dieser](../../L05VariablenUmwandeln/skripten/L05VariablenUmwandeln.md) Einheit kennen gelernt. Manches was wir mit diesem ``Typ`` umsetzen können, wollen jedoch nur kompakter umsetzten. Ein Beispiel dafür ist einer Zahl schnell ein einfaches Format zu geben. Da diese Zahl als *String* dargestellt wird, wenn diese z.B. nur *drei* Nachkommastellen, oder *drei* Vorkommastellen hat, können wir folgendes verwenden. Die ``Methode`` *printf*. Danach soll ein Integer ausgegeben werden welcher die Breite fünf hat, linksbündig ist und immer das Vorzeichen ausgibt.

```java
// formatierte ausgabe mit system.out.printf - Zahlenformat
System.out.printf("Das erstes Argument ist %07.3f und danach kommt ⬜%+-5d⬜ linksbündig.", 13.06796, 20);
```

Output:
```
Das erstes Argument ist 013.068 und danach kommt ⬜+20  ⬜ linksbündig.
```

Wir verwenden hier das Symbol *%* als Beginn der einzufügenden Variable, welche als 2. ``Parameter`` der ``Methode`` *printf* übergeben wird. Jedes weitere *%* bezieht sich auf folgende ``Parameter``. Wenn also *zwei mal* ein *%* in einem *String* vorkommt, werden *zwei* ``Parameter`` erwartet. Nach dem *%* folgt eine kryptische ``Syntax`` um:
* den ``Typ`` indem der ``Parameter`` umgewandelt wird und die
* anzuwendende formatierung anzugeben.

Der ``Typ`` wird mit dem Symbol *f* für *floating point number* angegeben. Davor wird die Anzahl der Nachkommastellen mit *.3* angegeben. Wenn wir "Vorkommastellen" haben wollen, müssen wir die gesamte Länge inklusive des Trennsymbols *.* angeben. Hier ist das 3 Vorkommastellen, das Trennsymbol und 3 Nachkommastellen. Wir geben nun *7* mit einer beginnenden Null an, diese darft fehlen. Insgesamt ergeben diese Teile den String *%07.3f*.

Für den 2. Parameter wird der ``Typ`` *d* für digit angegeben. Wir meinen damit einen *Integer*. Mit *+* wir immer die Ausgabe eines Vorzeichens angegeben, *-* bedeutet linksbündig und *5*, die Breite der Ausgabe.


Wir verzichten hier eine ausführliche Auflistung der speziellen Formatierungsprache und verweisen auf das Internet und dem folgenden Beispiel zum ausprobieren:
```java
int num = 42;
System.out.printf("Dezimal: |%d|\n", num);        // |42|
System.out.printf("Breite 5: |%5d|\n", num);      // |   42| (rechtsbündig)
System.out.printf("Linksbündig: |%-5d|\n", num);   // |42   |
System.out.printf("Mit Nullen: |%05d|\n", num);   // |00042|
System.out.printf("Mit Vorzeichen: |%+d|\n", num); // |+42|
System.out.printf("Hexadezimal: |%x|\n", num);    // |2a|
System.out.printf("Hex (groß): |%X|\n", num);   // |2A|
System.out.printf("Oktal: |%o|\n", num);        // |52|

int negNum = -42;
System.out.printf("Negative Zahl: |%d|\n", negNum);          // |-42|
System.out.printf("Negative Zahl (Klammern): |%(d|\n", negNum); // |(42)|
System.out.printf("Negative Zahl (+ Flag): |%+d|\n", negNum);    // |-42|

long bigNum = 1234567890L;
System.out.printf("Mit Tausendertrennzeichen: |%,d|\n", bigNum); // |1,234,567,890| (abhängig von Locale)

double pi = Math.PI; // ca. 3.1415926535...
System.out.printf("Standard float: %f\n", pi);       // 3.141593 (Standardpräzision ist 6)
System.out.printf("Präzision 2: %.2f\n", pi);        // 3.14
System.out.printf("Präzision 8: %.8f\n", pi);        // 3.14159265
System.out.printf("Breite 10, Präz. 2: |%10.2f|\n", pi); // |      3.14|
System.out.printf("Linksb., Breite 10, P. 2: |%-10.2f|\n", pi); // |3.14      |
System.out.printf("Mit Nullen, B. 10, P. 2: |%010.2f|\n", pi); // |0000003.14| (Nullen vor der Zahl)

System.out.printf("Wiss. Notation: %e\n", pi);             // 3.141593e+00
System.out.printf("Wiss. Notation (groß): %E\n", pi);     // 3.141593E+00
System.out.printf("Wiss. Notation, Präz. 3: %.3e\n", pi); // 3.142e+00

double largeNum = 1234567.89;
double smallNum = 0.00000123;
System.out.printf("g-Format (groß): %g\n", largeNum); // 1.23457e+06 (kann variieren)
System.out.printf("g-Format (klein): %g\n", smallNum); // 1.23000e-06 (kann variieren)
System.out.printf("g-Format (Pi): %g\n", pi);       // 3.14159
```

### Wie gebe ich eine formatieres Datum als String aus?
Das bereits besprochene gilt auch hier. Jedoch mit anderen Buchstaben und Bedeutungen. Wir starten mit dem ``Typ`` *LocalDateTime* welche ein Datum für uns darstellt. Im allgemeinen wird ein *Datum* als vergangene *Sekunden* ab dem Datum *01.01.1970:00:00.000* darsgestellt. Dieser ``Time-Stamp`` wird dann in verschiedene *Darstellungen* umgewandelt. Unser Typ *LocalDateTime* ist also nur eine "gestylte" Zahl. In ``JAVA`` bekommen wir einen ``Time-Stamp`` mit *System.currentTimeMillis();* (hier in Milliskunden mit ``Typ`` *Long* - der große *Integer*). 

```java
// Uhrzeitformat
LocalDateTime now = LocalDateTime.now();
System.out.println(now);
System.out.printf("hallo %tY🟩%td🟫%tm und danach %d", now, now, now, 20);
System.out.printf("hallo %tY🟩%td🟫%tB und danach %d", now, now, now, 20);
```

Output:
```
hallo 2025🟩19🟫05 und danach 20hallo 2025🟩19🟫May und danach 20
```

Wir benötigen hier durch Verwendung mehrerer *%* auch mehrere ``Parameter``. Ansonsten müssen wir es in einem *%* ausdrücken, falls wir nur einmal die ``Variable`` *now* übergeben wollen.

Auch hier Verweisen wir auf das Internet und auf folgendes Beispiel.
Wir bemerken zudem auch, dass es mehrere ``Typen`` gibt welche ein Datum halten. Ähnlich wie bei *String* geht es hier z.B: auch um ``immutability`` (LocalDateTime) und ``mutabiltiy`` (Date).

```java
Date now = new Date();
System.out.printf("Aktuelles Jahr: %tY\n", now); // z.B. 2025
System.out.printf("Komplettes Datum (US): %tc\n", now); // z.B. Mon May 19 14:13:04 CEST 2025 (locale-abhängig)
System.out.printf("ISO 8601 Datum: %tF\n", now); // z.B. 2025-05-19
System.out.printf("Uhrzeit (24h): %tT\n", now);   // z.B. 14:13:04
```

## Kompliziertere String-Operationen
Wir betrachten in diesem Kapitel so genannte ``Regular Expressions`` welche kurz ``RegEx`` heißen.
Wir können diese eigene Sprache im ``Terminal``, in fast allen Texteditoren (VS-Code, Intellij, ...) und auch Programmiersprachen (JAVA, C#, Python, JavaScript, Rust, Go, ...) verwenden. Es reicht also **einmal** ``RegEx`` zu begreifen um es überall verwenden zu können.

Wir betrachten hier nur kurz was die wichtigsten Bausteine von ``RegEx`` sind anhand der Erkennung einer E-mail in einem Text.

## Kompliziertere String-Operationen
Wir betrachten in diesem Kapitel so genannte ``Regular Expressions`` welche kurz ``RegEx`` heißen.
Wir können diese eigene Sprache im ``Terminal``, in fast allen Texteditoren (VS-Code, Intellij, ...) und auch Programmiersprachen (JAVA, C#, Python, JavaScript, Rust, Go, ...) verwenden. Es reicht also **einmal** ``RegEx`` zu begreifen um es überall verwenden zu können.

### Was ist ein RegEx?
Eine ``Regular Expression``, kurz ``RegEx``, ist eine eigene "Mini"-Programmiersprache welche ein *Muster* innerhalb eines *Strings* beschreibt. Wir benötigen dazu *zwei* *Strings*:
* Ein *String* welcher das zu suchende *Muster* in der Sprache ``RegEx`` angibt (das ist der ``RegEx``) und
* ein *String* in welchen wir das *Muster* suchen (das ist der *Input*).

Wir können damit:
* prüfen ob der *Input* diesem *Muster* entspricht (*Match*: True/False), 
* die Position welches dem *Musters* entspricht im *Input* finden (*Find*: Auf Index 0 bis 26 ist unser Muster im *String*), oder
* den Text welches dem *Muster* entspricht im *Input* extrahieren oder ersetzen (*Extract/Replace*: "mathias.cammerlander@gmail.com" ist das Ergebnis unseres ``RegEx``, oder ersetze jedes Vorkommen einer Mailadresse mit ⬛).

Wir bemerken hier, dass unsere ``JAVA`` spezifischen *Werkzeuge* welche wir in []() kennengelernt haben, auch mit ``RegEx`` umgesetzt werden können. Wir betrachten hier nur kurz was die wichtigsten Bausteine von ``RegEx`` sind anhand der Erkennung einer E-mail in einem Text.

| Regex                                                                                             | ✅  | ❌|
| :------------------------------------------------------------------------------------------------ | :---------------- | :--------------------- |
| `^\w+@\w+\.\w+$`  | `simple@mail.com` | `user@example.co.uk`   |
| `^\w+@(\w+\.)+\w+$` | `simple@mail.com` | `kontakt@meine-firma.de`         |
| `` ^[a-zA-Z0-9_!#$%&'*+/=?{}~^.-]+@[a-zA-Z0-9_!#$%&'*+/=?{}~^.-]+(\.\w+)*\.\w+$``         | `simple@mail.com` | `simple@mail`          |


**Anmerkung:** 
* Wir fügen später die ``Syntax`` des ``RegEx`` in ``JAVA`` ein. Hier betrachten wir zuerst die Sprache selbst, ohne auf ``JAVA`` oder eine andere Programmiersprache zu verweisen.
* Wenn wir wirklich einen ``RegEx`` wollen, welcher nahezu alle Speziallefälle korrekt umsetzt, kann [hier](https://emailregex.com/) einige Beispiele sehen. Meist ist jedoch ein solches Level an Komplexität nicht notwendig.
* **Für interaktives lernen** sind [Kreuzworkrätsel](https://regexcrossword.com/) mit ``RegEx`` zu empfehlen.
* Um ``RegEx`` testen zu können ob dieser tut was er soll, kann folgende [Website](https://regex101.com/) verwendet werden. Hover mit der Maus über den ``RegEx`` um diesen `dort erklärt zu bekommen.

### Was sind die Bausteine eines RegEx? 
Wir haben bereits bemerkt, dass wir hier einen wesentlichen *Nachteil* im Vergleich zu ``JAVA`` haben. Wir vermischen in einem ``RegEx`` zwei Bedeutungen (``Semantik``) von Text.
* Text welcher Teil der Programmiersprache sind (*while*)
* Text welcher Teil eines ``Wertes`` in der Programmiersprache sind (*"while"*)

In ``JAVA`` unterscheidet hier das Symbol *""* zwischen Texte welche als ``Wert`` gesehn werden und jenen der Programmiersprache, wie das ``Keyword`` *for* oder ein ``Operator`` wie der *Aufrufeoperator* **.** bei *meineVariable **.** toString();*. Bei ``RegEx`` ist es jedoch nicht auf dem ersten Blick ersichtlich um was eigentlich geht (Falls dabei noch Zweifel bestehen, bitte nochmal auf den 3. ``RegEx`` der Mail im obigen Beispiel schauen 🤕). Ist ``.`` nun ein *Punkt*, wie in der ``Wert`` *"."* oder ist es Teil der Programmiersprache was *hier kann jedes Symbol stehen* bedeutet? Da ``RegEx`` kompakt geschrieben werden, damit sie "in eine Zeile passen", haben wir nicht den Luxus lange ``Keywords`` zu verwenden sondern eher *Keycharacter*, also nur ein *Symbol*. Ein Vorgriff um nun aufzulösen was der *Punkt* nun ist. Dieser ist *Teil der Sprache* und bedeutet *hier kann jedes Symbol stehen*.

#### Einfachste Muster
Der einfachste ``RegEx`` ist, genau der *String* was wir suchen. Damit ist im *einfachsten Fall* folgendes gemeint:
```re
M
```
Dieser ``RegEx`` sucht das *Muster* *M*. Es wird also das *M* im Text gesucht. Eine ganz normale Suche wie in einem Texteditor. Wenn wir nun mehrere *Characters* aneinanderreihen entsteht folgendes *Muster*. Ebenfalls eine ganz normale Suche.
```re
Mathias
```

Was jedoch wenn wir jeden Text finden wollen, welcher die Länge *7* hat? (*Mathias* oder *Martina*). Wir müssen nun einen allgemeinen Begriff als den ``RegEx`` *Mathias* angeben. Dieser *matcht* nur beim *Input* *Mathias*. 

#### Welche Symbole sind in einem RegEx erlaubt?
``Zeichenklassen`` erlauben es, eine Gruppe von Zeichen zu definieren, welche im Text vorkommen müssen. Die Logik ist einer **Whitelist** (erlaubte Zeichen) oder, bei *Negation*, wie eine **Blacklist** (verbotene Zeichen) gleich. Eine *Analogie* wäre zudem ``Werte`` in ``JAVA``.

Ein Beispiel den Text der Länge *7* ist:
```re
[abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ][abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ]
```

*Anmerkung:* Keine Sorge wir lernen noch Werkzeuge kennen um dies folgendermaßen darzustellen *[a-zA-Z]{7}* zu können.

Hier nun eine Auflistung von den Möglichkeiten welche wir haben um unsere ``Zeichenklassen`` darstellen zu können. Diese muss nicht auswendig gelernt werden, sondern dient zum Nachschlagen und Ausprobieren.
* **Benutzerdefinierte Zeichenklassen:** Werden in eckigen Klammern *[]* definiert.
    * *[abc]* : Trifft auf 'a', 'b' oder 'c' zu.
    * *[a-z]* : Trifft auf jeden Kleinbuchstaben von 'a' bis 'z' zu (Bereichsangabe).
    * *[A-Z]* : Trifft auf jeden Großbuchstaben von 'A' bis 'Z' zu.
    * *[0-9]* : Trifft auf jede Ziffer von '0' bis '9' zu.
    * *[a-zA-Z0-9]* : Trifft auf jeden alphanumerischen Charakter zu.
    * Man kann auch spezifische Zeichen und Bereiche kombinieren: *[a-cx-z_0-9]* trifft auf 'a', 'b', 'c', 'x', 'y', 'z', '_' oder eine beliebige Ziffer 0-9 zu.
* **Negierte Zeichenklassen:** Beginnen mit *^* innerhalb der eckigen Klammern.
    * *[^abc]* : Trifft auf jedes Zeichen zu, das *nicht* 'a', 'b' oder 'c' ist.
    * *[^0-9]* : Trifft auf jedes Zeichen zu, das keine Ziffer ist.
* **Vordefinierte Zeichenklassen (Abkürzungen):** Für häufig verwendete Zeichengruppen gibt es praktische Abkürzungen:
    * *\d* : Trifft auf eine beliebige Ziffer zu. Gleichbedeutend wie *[0-9]*.
    * *\D* : Trifft auf jedes Zeichen zu, das *keine* Ziffer ist (das Gegenteil von *\d*). Gleichbedeutend wie *[^0-9]*.
    * *\w* : Trifft auf ein "Wortzeichen" zu. Dies umfasst *Buchstaben* und *Zahlen* sowie den *Unterstrich* *_*. Gleichbedeutend wie *[a-zA-Z0-9_]*.
    * *\W* : Trifft auf jedes Zeichen zu, das *kein* Wortzeichen ist (das Gegenteil von *\w*). Gleichbedeutend wie *[^a-zA-Z0-9_]*.
    * *\s* : Trifft auf ein "Whitespace"-Zeichen zu. Dies umfasst Leerzeichen, Tabulatoren (*\t*), Zeilenumbrüche (*\n*, *\r*), Seitenvorschübe (*\f*) und andere Leerraumzeichen.
    * *\S* : Trifft auf jedes Zeichen zu, das *kein* Whitespace-Zeichen ist (das Gegenteil von \s*).
    * *.* (Punkt): Der Punkt ist ein spezielles Zeichen, welches auf (fast) jedes beliebige Zeichen zutrifft, *außer* in der Regel auf Zeilenumbruchzeichen *\n* und Dergleichen.

Wir können also das Muster jenes Textes der Länge *7*, einfacher schreiben. Wir erlauben damit jeodch zusätzlich zu Groß- und Kleinbuchstaben, auch *Zahlen* und den *Unterstrich* als ``Wert``.
```re
[\w][\w][\w][\w][\w][\w][\w]
```

##### Was gibt es für Operatoren innerhalb einer Zeichenklasse? 
Wir haben bereits einen ``Operator`` kennen gelernt, ohne darüber zu sprechen. Der *Character* *-* bedeutet nicht, bindestrich, sondern **innerhalb** einer ``Zeichenklasse`` *von bis*. Es ist also möglich Bereiche eleganter anzugeben. Weiters erinnern wir uns an *^* (Zirkumflex) welches **innerhalb** einer ``Zeichenklasse`` eine *Negation* bedeutet. Eine *Analogie* wäre zudem ``Operatoren`` in ``JAVA``. Diese verknüpfen ``Werte`` in ``JAVA`` und auch in einem ``RegEx``. Wir belassen es vorerst bei diesen *drei* ``Operatoren`` und schauen uns unser Beispiel der Texte der Länge *7* an. Wir verwenden hier eine eigens erstellte ``Zeichenklasse`` und nicht wie zuvor die vorgefertigte *\w*.

```re
[a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z][a-zA-Z]
```

**Anmerkung:** Leider funktioniert *[a-Z]* nicht und muss als *[a-zA-Z]* geschrieben werden.

##### Wie inkludiere ich alle Symbole inklusive einem Zeilenumbruch wenn dieser im . nicht enthalten ist?:
Da der Punkt *.* standardmäßig keine Zeilenumbrüche matcht, kann man Konstrukte wie *[\w\W]* oder *[\s\S]* (oder auch *[\d\D]*) verwenden. Da *\w* alle Wortzeichen und *\W* alle Nicht-Wortzeichen matcht, deckt die Kombination *[\w\W]* jedes erdenkliche Zeichen ab, einschließlich Zeilenumbrüchen *\n*, Tabulatoren *\t*, Carriage-Returns *\r*, etc.
Das Gleiche gilt für *[\s\S]*. Der Trick besteht in *nimm X ODER nicht X*, was alles darstellt und mit *[\s\S]*, *[\w\W]* und *[\d\D]* ausgedürckt wird.

##### Wie verwende ich - oder . wenn ich dieses Symbol matchen will?
Wir müssen Symbole der Sprache ``escapen`` um es in einem ``Wert`` umzuwandeln. Wir tun dies mit dem *Backslash*.
```re
[abc\.\-]
``` 
Dieser ``RegEx`` erlaubt das Symbol a, b, c, . oder -. Falls wir folgendes schreiben, erlauben wir beliebige Symbole und nicht nur die gerade angegebenen.
```re
[abc.\-]
```
Wir müssen also jedes Zeichen genauestens betrachten.

#### Wie wiederhole ich eine Zeichenklasse ohne sie öfters zu schreiben?
Wir gehen nun zu den *Quantifizieren*. eine *Analogie* zu diesen ist die ``For-Schleife``. Diese geben an, wie oft das vorangehende *Zeichen*, oder die vorangehende ``Zeichenklasse`` im Text vorkommen muss.
* *(Stern): Das vorangehende Element darf **null oder beliebig oft** vorkommen. Beispiel: _a*_ trifft auf "", "a", "aa", "aaa", usw. zu. Man verwendet _*_, wenn ein Muster optional ist und beliebig oft wiederholt werden kann.
* _+_ (Plus): Das vorangehende Element muss **mindestens einmal** vorkommen (also einmal oder beliebig oft). Beispiel: _a+_ trifft auf "a", "aa", "aaa", usw. zu, aber **nicht** auf "".
* _?_ (Fragezeichen): Das vorangehende Element ist **optional**, d.h., es darf **null oder genau einmal** vorkommen. Beispiel: _colou?r_ trifft auf "color" und "colour" zu. Man verwendet _?_, wenn ein Teil eines Musters optional ist.
* _{n}_ : Das vorangehende Element muss **genau n-mal** vorkommen. Beispiel: _\d{3}_ trifft auf genau drei Ziffern zu, z.B. "123".
* _{n,}_ : Das vorangehende Element muss **mindestens n-mal** vorkommen. Beispiel: _\d{2,}_ trifft auf zwei oder mehr Ziffern zu, z.B. "12", "123", "1234".
* _{n,m}_ : Das vorangehende Element muss **mindestens n-mal, aber höchstens m-mal** vorkommen. Beispiel: _\w{3,5}_ trifft auf drei, vier oder fünf Wortzeichen zu.

Wir haben also bereits 3 *Grundkonzepte* aus ``JAVA`` wiedergefunden. ``Werte`` als Zeichen und ``Zeichenklassen``, ``Operatoren`` als ``Operatoren`` und ``Schleifen`` als ``Quantifizierer``.

Wir verbessern nun unseren ``RegEx`` eines Textes der Länge 7.
```re
[a-zA-Z]{7}
```

##### Greedy vs. Lazy Evaluation
Standardmäßig sind ``Quantifizierer`` wie _*_, _+_ und _{n,}_ **greedy** (gierig). Das bedeutet, sie versuchen, so viele Zeichen wie möglich zu *matchen*. Wenn wir ein *Muster* öfter im *Input* haben, was ist dann as gefundene *Muster*?

* **Greedy _*_**: Im *String* ``<h1>Überschrift</h1>`` würde der Regex _<.*>_ auf den gesamten *String* von ``<h1>`` bis ``</h1>`` matchen, weil _.*_ so viele Zeichen wie möglich (hier ``<h1>Überschrift</h1>``) *frisst*. Von der ersten Spitzen Klammer bis zur letzten. Er gibt sich nicht mit ``<h1>`` zufrieden, sondern sucht das Längste zutrefende *Muster*, was hier ``<h1>Überschrift</h1>`` ist.
* **Lazy (Non-Greedy) _*?_**: Um das *greedy* Verhalten zu ändern, kann man ein Fragezeichen an den ``Quantifizierer`` anhängen, um ihn "non-greedy" oder "lazy" zu machen. Ein non-greedy ``Quantifizierer`` versucht, so *wenige* Zeichen wie möglich zu matchen.
* Im *String* ``<h1>Überschrift</h1>`` würde _<.*?>_ nur auf ``<h1>`` matchen (und bei einer globalen Suche dann separat auf ``</h1>``). Der _.*?_ matcht so wenig wie möglich, bis das nächste Zeichen des Patterns (_>_) gefunden wird.

Die gleiche Idee gilt für _+?_ und _{n,}?_. 

Achtung! Hier ist *+?* zusammen **ein** ``Operator`` (1 oder n mal, aber lazy) und hat nichts mit *?* (0 oder 1 mal) zu tun.

Versuchen wir nun einen ``RegEx`` zu schreiben, welcher eine *E-Mail* Adresse matched. Wir erweitern dazu unser Beispiel mit den Text der Länge *7*.
```re
`[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+`
```
Wir verwenden hier folgende *Werkzeuge*:
* ``Zeichenklasse`` um einen ``Wert`` festzulegen was erlaubt ist.
* ``Operatoren`` innerhalb der ``Zeichenklassen`` um Bereiche anzugeben.
* ``Escapesequenz`` welche den Punkt als ``Wert`` darstellt und nicht als ``Operator``.
* ``Quantifizierer`` welcher mindestens eine wiederholung der ``Zeichenklasse`` fordert, jedoch beliebig viele erlaubt. Wie machen also aus *Zeichen* damit *Wörter*.
* Wir haben zudem 2 fixe Symbole welche außerhalb der ``Zeichenklasse`` sich befinden. Hier ist es da @ und . Symbol. Wir wollen hier keine Auswahl an Symbolen erlauben, sondern exakt ein *@* und exakt einen *.* haben. 

Mit diesen *Werkzeugen* sind wir schon gut unterwegs und können bereits Probleme lösen. Denken wir jedoch nochmals an unsere grundlegenden *Werkzeuge* in  ``JAVA``. Diese waren:
* 1.1) ``Werte``: *Zeichen* und ``Zeichenklassen`` bei ``RegEx`` genannt
* 1.2) ``Variablen``: ?
* 2.0) ``Operatoren``: ``Operatoren`` innerhalb einer ``Zeichenklasse`` bei ``RegEx`` genannt
* 3.0) ``Verzweigungen``: ? 
* 4.0) ``Schleifen``: ``Quantifizierer`` bei ``RegEx`` genannt

Wir betrachten als letzten Punkt die ``Variablen``, welche wir als ``Backreferences`` in ``Gruppen`` bei einem ``RegEx`` bezeichnen. 

Warum als letzten Punkt wenn wir noch keine ``Verzweigungen`` haben? Dise sind kompliziert bei einem ``RegEx`` wenn diese in voller Mächstigkeit verwendet werden sollen. Wir machen es uns hier jedoch einfach und verlangen die *Logik* in ``JAVA`` oder jede andere Programmiersprache aus. Dort verstehen wir folgendes leicher.

```java
String input = ...
if (Pattern.matches("mathias@[a-zA-Z0-9]+\.com+", input)) {
    ✅
} else if (Pattern.matches("[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+", input)) {
    ✅
} else {
    ❌
}

// oder...
if (Pattern.matches("mathias@[a-zA-Z0-9]+\.com+", input)) {
    ✅
} else {
    ❌
}
```

#### Wie fasse ich ein Muster zusamen um es später wiederzuverwenden?
Wir sind nun bei der Analogie der ``Variablen`` angekommen. Wir nennen dies ``Backreference`` innerhalb einer ``Gruppe``. Dazu verwenden wir die runden Klammern _()_ in einem ``RegEx``.

##### Gruppierung
Diese fasst Teile eines Musters zusammen und macht dadurch ``Quantifizierer`` und andere ``Operatoren`` auf die gesamte ``Gruppe`` anwendbar. 
```re
(ab)+ 
```

Dieser ``RegEx`` trifft auf den *Input* "ab", "abab", "ababab", usw. zu. Wichtig ist der Unterschied zur ``Zeichenklasse``.
```re
[ab]+ 
```

Dieser ``RegEx`` trifft auf den *Input* "a", "b", "aa", "ab", "ba", "bb", "aaa", usw. zu. Die ``Zeichenklasse`` lässt also *a* **oder** *b*, und dieses *Muster* öfter zu. Im Gegensatz dazu lässt die ``Gruppe`` *a* **und** als nächstes Symbol *b* zu, und dieses *Muster* öfter zu.

Wir können innerhalb einer ``Gruppe`` jedoch ``Zeichenklassen`` verwenden. Anders herum nicht.
```re
([a-z]+[0-9]+){2}
```
Dieser ``RegEx`` drückt aus, wir wollen *a* **oder** *b* **oder** ... **oder** *y* **oder** *z* beliebig oft akzeptieren. Es muss jedoch *0* **oder** *1* **oder** ... **oder** *8* **oder** *9* beliebig oft folgen. Dieses gesamte *Muster* muss nun **genau** *zwei* mal vorkommen. Es wird also *lazorswag1337420* nicht akzeptiert. Es müsste *lazorswag1337420haxor101* sein. Wir sehen nun die Verbindung zur ``Variable`` in ``JAVA``. Wir speichern dort ``Werte`` und in der Welt der ``RegEx`` speichern wir *Muster*. Wir könnne jedoch auch bei einem ``RegEx`` die Idee aus ``JAVA`` verwenden. Die Wiederverwendung eines ``Wertes`` zu einem späteren Zeitpunkt. Da wir nun zwei verschiedene Verwendungen haben, gibt es auch hier zwei verschiedene Namen.
* Die ``Variable`` merkt sich das *Muster*" $\rightarrow$ ``Gruppe``
* Die ``Variable`` merkt sich einen ``Wert`` welche das *Muster* zulässt." $\rightarrow$ ``Backreference`` 


##### Backreference
Alles was eine ``Gruppierung`` erfasst, kann nun mithilfe einer ``Backreference`` angesprochen werden und zu einem späteren Zeitpunkt verwendet werden. Wir tun dies mithilfe des *Backslashes* und einer Nummerierung. Diese Nummerierung _\1_ bezieht sich auf den Inhalt der *ersten* ``Gruppierung``. Wenn es nur eine ``Gruppierung`` gibt, dann ist diese mit *\1* anzusprechen.
```re
([a-z]+[0-9]+)\1
```
Dieser ``RegEx`` schein ähnlich zu dem Vorherigen *([a-z]+[0-9]+){2}*. Jedoch erlaubt der Vorherige *lazorswag1337420haxor101* und der neue nicht. Dieser zwingt das *Muster* **exakt** sich ein zweites mal zu wiederhlen. Es muss deshalb *lazorswag1337lazorswag1337* sein. Wenn wir es mit ``Variablen`` aus ``JAVA`` vergleichen ist es möglichweise nachvollziehbarer.
```java
String musterWelchesGruppiertWird = "lazorswag1337"; // Gruppierung welches das Muster ([a-z]+[0-9]+) erlaubt - es erlaubt den Wert lazorswag1337
String backslashEins = musterWelchesGruppiertWird; // Speichere Wert: Aufruf der Backreference \1 mit Wert lazorswag1337
System.out.println(musterWelchesGruppiertWird + backslashEins); // Erlaubtes Muster folgt sich selbst nocheinmal
```

Wenn wir mehrere ``Gruppierungen`` haben kann mit _\2_ auf die zweite, _\3_ auf die dritte, usw. zugegriffen werden.
```re
([a-z]+[0-9]+)\1(hallo)\2
```
Dieser ``RegEx`` erlaubt *lazorswag1337lazorswag1337hallohallo* als *Input*.

```re
([a-z]+[0-9]+)\1(hallo)\2\1
```
Dieser ``RegEx`` erlaubt *lazorswag1337lazorswag1337hallohallolazorswag1337* oder *mathias1992mathias1992hallomathias1992* als *Input*.

Ein praxisrelevanteres Beispiel dazu wäre ein ``Pfad`` in einem ``Dateisystem``. Dazu ändern wir den ``RegEx`` leicht.
```re
C:\/([\w\/]+)(interacto\/)\2\1
```

Hier werden nur ``Pfade`` erlaubt welche sich wiederholende Ordner haben *C:/Users/Mathias/GitHub/interacto/interacto/Users/Mathias/GitHub/*. Die Praxisrelevanz ist hier bezogen auf die Erstellung eines ``RegEx`` für ``Pfade``. Warum wir eine solche sich wiederholende Struktur abfragen ist nicht nachvollziehbar. Es gibt jedoch in der Praxis oft *Muster* welche wir nicht direkt verstehen. Wir müssen nur damit umgehen können und flexible Lösungen von Problemen liefern.

Ein weiteres Beispiel sind ``HTML``-Tags. Da sie möglicherweise schon wissen, dass ``HTML`` Dokumente aus *Text*besteht und ein Spezialfall von ``XML`` Dokumente sind, und diese durch sogenannte ``Schema`` auf ein gewissen *Muster* überprüft werden können, sollte nun nicht überraschend sein, dass wir soetwas auch mit ``RegEx`` umsetzen könnten. Ein sehr grundlegender check eines ``HTML`` files könnte sein, dass jeder sich öffnende ``Tag`` ``<a>`` auch wieder mit exakt dem gleichen Text geschlossen wird ``</a>``. _(<([A-Z][A-Z0-9]*)\b[^>]*>).*?</\2>_ könnte verwendet werden, um HTML-Tags zu finden, bei denen der öffnende und schließende Tag-Name übereinstimmen. _\2_ stellt hier sicher, dass der Name im schließenden Tag derselbe ist wie der in der zweiten Gruppe (dem öffnenden Tag-Namen) erfasste.

##### RegEx Gruppierungen mit Backreferences in Editoren
Backreferences sind besonders mächtig in der "Suchen und Ersetzen"-Funktionalität vieler Texteditoren. Man kann nach einem Muster suchen, das Teile erfasst, und diese erfassten Teile dann in der Ersetzung anders anordnen oder formatieren. Z.B. Suchen nach _(\w+)\s+(\w+)_ (zwei Wörter) und Ersetzen mit _$2, $1_ (oder _\2, \1_, je nach Editor) würde "Vorname Nachname" zu "Nachname, Vorname" umwandeln.


#### Weitere Operatoren außerhalb der Zeichenklassen
* Weiters erinnern wir uns an den *Punkt* **.**, welcher (fast) *jedes beliebige* Symbol matched.
* _|_ (Oder-Operator / Alternation): Erlaubt die Angabe von Alternativen. _Katze|Hund_ trifft entweder auf "Katze" oder auf "Hund" zu.
* _^_ (Anker - Zeilenanfang): Wenn _^_ am Anfang eines ``RegEx``s steht (und nicht innerhalb einer Zeichenklasse _[]_), bedeutet es, dass das Muster am Anfang einer Zeile (oder des Strings, je nach Modus) beginnen muss.
* _$_ (Anker - Zeilenende): Wenn _$_ am Ende eines ``RegEx``s steht, bedeutet es, dass das Muster am Ende einer Zeile (oder des Strings) enden muss.

**Anmerkung:** Wir bemerken hier dass es auch bei ``RegEx`` ``überladene Operatoren`` gibt. *^* hat *innerhalb* einer ``Zeichenklasse`` die Bedeutung einer *Negation*, jedoch *außerhalb* der *der Text muss mit dem angegebenen Muster beginnen*.
```re
^[^a-z]+
```
Hier wird der *Input* *123 ich bin ein anderer Text* akzeptiert, aber *ich bin nur ein anderer Text 123* nicht. Ohne dem *^* *außerhalb* der ``Zeichenklasse`` würde bei *ich bin nur ein anderer Text 123* die *123* gefunden werden. Wir zwingen jedoch den *Input* mit dem Muster *123* zu beginnen. 

Umgekehrt ist es mit dem ``Operator`` *$* welches das *Ende* absichert. Folgender ``RegEx`` erlaubt also nur *Zahlen*.

```re
^[^a-z]+$
```

### RegEx in Java
#### Der Pattern Typ und die match Methode
Hier ist ein Beispiel, wie man die _Pattern.matches()_ Methode in Java verwenden kann, um zu überprüfen, ob ein String einem bestimmten E-Mail-*Muster* entspricht.

```java
import java.util.regex.Pattern;

public class EmailValidator {
    public static void main(String[] args) {
        String mail = "mathias.cammerlander@gmail.com";
        // probiere foldende Mailadressen.
        // String mail = "test@yahoo.co.uk";
        // String mail = "invalid-mail";
        // String mail = "another.user@subdomain.gmail.com"; // Dieses Beispiel passt nicht zum spezifischen Regex unten

        // probiere folgende RegEx.
        String regex = "^([a-zA-Z]+)\\.([a-zA-Z]+)@(yahoo|gmail)\\.[a-z]{2,63}$";
        // String regex = "^\w+@\w+\.\w+$";
        // String regex = "^\w+@(\w+\.)+\w+$";
        // String regex = "^[a-zA-Z0-9_!#$%&'*+/=?{}~^.-]+@[a-zA-Z0-9_!#$%&'*+/=?{}~^.-]+(\.\w+)*\.\w+$";
        // String regex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
        
        String musterPasst = "Der Input: \"" + email + "\" passt zum Muster \"" + regex + "\".";
        String musterPasstNicht = "Der Input: \"" + email + "\" passt NICHT zum Muster \"" + regex + "\".";

        System.out.println("Prüfe: " + mail);
        boolean hasMatched = Pattern.matches(regex, email);

        if (hasMatched) {
            System.out.println(musterPasst);
        } else {
            System.out.println(musterPasstNicht);
        }
    }
}
```

#### Variablen des Typs String haben die Methode replaceAll
In ``Java`` kann man die _String_-Methode _replaceAll(String regex, String replacement)_ verwenden, um alle Vorkommen, die einem ``RegEx`` entsprechen, durch einen anderen *String* zu ersetzen. In diesem kann mit _$1_, _$2_ usw. sich auf die ``Gruppierungen`` beziehen.

Wie haben hier einen Fehler welcher sich über ein *1000* Seiten großes Dokument durchzieht. Es stehen falsche, unterschiedliche Währungen welche als *¥* gekennzeichnet gehören. Die neue Generierung dieses Dokuments und die Ausführung aller benötigten Berechnungen auf denen die Zahlen basieren dauern 7h (z.B Prüfbericht des interen Audits über Kreditbewertugnen, Jahresabschluss einer Bank, etc.). Es gibt keine Zwischenergebnisse der Berechnungen. Die händische Korrektur dauert ebenso 7h. Wir benötigen dieses Dokument in 1h bei der Eigentümerversammlung. Ein ``RegEx`` benötigt jedoch nur *95.3009* ms (Das Einlesen, die Decodierung danach die Änderung des Textes, die neue Codierung und das neue speichern des PDFs dauer ein paar Minuten) und schaffen durch eine solche *open heart* Operation an dem PDF Dokument, dass dieses ohne (...mit wenigeren) Fehler präsentiert wird.

```java
// Simulieren eines sehr langen Textes (vereinfacht)
StringBuilder sb = new StringBuilder();
// Erzeugen wir ca. 2MB Text (1000 Seiten * ~2000 Zeichen/Seite)
// mit einigen Vorkommen von USD/EUR
for (int i = 0; i < (int)((2000*1000)/50); i++) { 
    sb.append("Das Ergebnis beträgt 100 USD und nicht 120 EUR. ");
    if (i % 1000 == 0) {
            sb.append("Weitere Zahlen 500 USD. ");
    }
}
String text = sb.toString();
System.out.println("Textlänge: " + text.length() + " Zeichen");

String regex = "(\\d+)\\s+(EUR|USD)";
String replacement = "$1¥"; // Ersetzt durch die erfasste Zahl und Yen

long startTime = System.nanoTime();
String neuerText = text.replaceAll(regex, replacement);
long endTime = System.nanoTime();

long durationNanos = endTime - startTime;
double durationMillis = durationNanos / 1_000_000.0;

System.out.println("Ersetzung dauerte: " + durationMillis + " ms");
```

### Eine bessere Schleife mit *scanner.hasNext* und RegEx
Wir starten mit der bekannten User-Input-Validierung, welche so lange nachfragt, bis eine korrekte Eingabe statt gefunden hat.

```java
 // Konstanten
final String RESET = "\u001B[0m";
final String RED = "\u001B[31m";

final String kleinbuchstaben = "abcdefghijklmnopqrstuvwxyz";
final String grossbuchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

// Variablen
Scanner scanner = new Scanner(System.in);

// Achtung! Nach jeder Wiederholung zurücksetzen.
String zeichenpool = kleinbuchstaben;

// ~~~~~~~~~~~~~~~~~~~ START UserInput ~~~~~~~~~~~~~~~~~~~
// ------------------- Soll das Passwort Großbuchstaben beinhalten [+/-]? -------------------
System.out.print("Soll das Passwort Großbuchstaben beinhalten [+/-]? ");

// lange
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

scanner.close();
```

Wir ersetzen hier die ``Schleife`` *while* durch folgende *while*. Diese Prüft mithilfe eines ``RegEx`` welcher ein ``Parameter`` der ``Methode`` *hasNext* ist, ob der User ein *+* oder *-* eingibt. Falls es etwas anderes ist, wiederholen wir die ``Schleife`` und fordern den User erneut auf ein *+* oder *-* einzugeben. Wir verwenden den ``RegEx`` als erkennung eines Musters im *String* welchen der User eingibt. Hier reicht die Angabe einer ``Zeichenklasse`` *[+-]*. Jeder andere *String* welcher diesem ``RegEx`` folgt, wird als nicht akzeptiert angenommen und *hasNext* ergibt *false*. Deshalb muss *hasNext* noch mit *!* negiert werden.

```java
...

// kurz mit regex
while (!scanner.hasNext("[+-]")) {
    System.out.print("Die Eingabe " + RED + scanner.nextLine() + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
}

if(scanner.next().equals("+")) {
    zeichenpool += grossbuchstaben;
}

System.out.println(zeichenpool);

scanner.close();
```