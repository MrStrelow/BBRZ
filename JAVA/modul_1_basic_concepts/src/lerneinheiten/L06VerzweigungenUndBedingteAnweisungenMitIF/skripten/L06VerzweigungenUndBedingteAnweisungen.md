# Verzweigungen und Bedingte Anweisungen mit If

#### Welche Begriffe werden hier verwendet?
[``Wert``](../../../glossar.md#wert), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ),  [``logische Formel``](../../../glossar.md#logische-formel), [``Kontrollstruktur``](../../../glossar.md#kontrollstruktur), [``Anweisung``](../../../glossar.md#anweisung), [``If-Anweisung``](../../../glossar.md#if-anweisung), [``Ausdruck``](../../../glossar.md#ausdruck), [``If-Ausdruck``](../../../glossar.md#if-ausdruck), [``Bedingung``](../../../glossar.md#bedingung), 
[``Bedingte Anweisung``](../../../glossar.md#bedingte-anweisung), [``Verzweigung``](../../../glossar.md#bedingung), [``Verzweigung``](../../../glossar.md#verzweigung), [``Mehrfachverzweigung``](../../../glossar.md#mehrfachverzweigung), [``Block``](../../../glossar.md#bedingung), [``Scope``](../../../glossar.md#bedingung), [``Zweig``](../../../glossar.md#zweig)

Wir haben 4 Grundlegende Werkzeuge erwähnt welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen 
* ✅ Operatoren (bzw. Methoden aufrufen) 
* ➡️ Verzweigungen und Bedingte Ausdrücke
* ❔ Schleifen

Wir behandeln nun ``Verzweigungen`` und ``Bedingten Anweisungen``. Wir verwenden dazu vorerst die Varianten mittels dem ``If`` und ``else`` Keywords.

## Was ist unser Ziel mit diesem Werkzeug?
Stellen wir uns folgendes Problem vor. Wir haben eine Kontrolle einer Person bei einem Onlinevertragsabschluss und fragen ab, ob diese *alt genug* ist und einen *Führerschein* hat. Diese will ein Auto kaufen. Falls alt genug ist und einen Führerschein hat, befinden wir uns in einem Zustand welcher uns erlaubt den Kunden positiv abzuspeichern. Um dies umzusetzen brauchen wir ``Verzweigungen`` bzw. ``Bedingten Anweisungen``. Diese steuern welcher Programmcode ausgeführt wird. Solche Konstrukte werden ``Konstrollstrukturen`` genannt. Die Grundlage für eine solche Steuerung sind ``logische Formeln`` welche wir bereits kennen gelernt haben. Diese ``logischen Formeln`` bestehen aus ``booleschen Variablen`` welche mit ``logischen Operatoren`` bzw. ``Vergleichsoperatoren`` verknüpft werden. 

Wir merken uns:
> Eine ``Kontrollstruktur`` steuert den Ablauf eines Programms.

> Eine ``Bedingung`` ist eine ``logische Formel`` welche in einer ``Kontrollstruktur`` verwendet wird.

## Was ist eine Bedingte Anweisung (Conditional)?
Schreiben wir folgenden Code welcher die Kontrolle einer Person darstellt:

```java
System.out.print("Wie alt sind Sie? ");
Integer alter = ... // eine Zahl aus der Datenbank, oder aus der Usereingabe mittels Scanner.

if (alter >= 18) {
    System.out.println("Verstehe. Sie sind alt genug.");
}
```

Wir sehen hier, die Ausgabe *Verstehe. Sie sind alt genug.* wird nur ausgegeben wenn das *alter* größer oder gleich *18* ist. Diese Ausgabe ist also ``bedingt`` auf die ``logische Formel`` *alter >= 18*, welche wir ``Bedingung`` nennen. Die Ausgabe *Wie alt sind sie?* hat keine ``Bedingung`` und ist dadurch bedingungslos. Bedeutet diese wird *immer* ausgeführt. 

wir merken uns :
> Eine ``Bedingte Anweisung`` ist eine ``Kontrollstruktur`` welche uns erlaubt ``Code`` auszuführen, wenn eine ``Bedingung`` erfüllt ist.

### Wann verwenden wir eine Bedingte Anweisung?
Wir merken uns:
> Wir modellieren mit einer ``Bedingte Anweisung`` *Wenn-dann Aussagen*. 

Wir dürfen diese also nur verwenden, wenn kein *alternatives* Verhalten angegeben wird. 

Ein Beispiel:
```java
// WENN ich alt genug bin, 
if (alter >= 18) {
    // DANN darf ich weiter.
    System.out.println("Verstehe. Sie sind alt genug.");
}
// ANSOSNTEN... ?
```

Wir wissen nicht was ansonsten passiert. Wir gehen in die ``Bedingte Anweisung``, wenn dessen Bedingung erfüllt ist und springen drüber wenn nicht, denn wir haben keine Vorgabe was passieren soll wenn wir **nicht** *alt genug* sind.

### Warum erkennen wir nicht alle Variablen?
Da wir mit den geschwungenen Klammern ``{}`` einen so genannten neuen ``Scope`` oder auch ``Block`` genannt einführen müssen wir auf folgendes aufpassen, wenn wir mehrere dieser ``Bedingte Anweisungen`` untereinanderschreiben.

Hier passiert ein Fehler... jedoch welcher?
```java
public static void main(String[] args) {    // geschwungenen Klammern!
    Integer alter = ... // diese Variable gibt es innerhalb der geschwungenen Klammern, bedeutet in der main methode

    if (alter >= 18) {                          // geschwungenen Klammern!
        Integer meinAlter = 21;                     // diese Variable gibt es in der Bedingte Anweisung
        System.out.println("Verstehe. Sie sind alt genug. Ich selbst bin " + meinAlter);
    }                                           // geschwungenen Klammern!

    if (alter >= 95) {                          // geschwungenen Klammern!
        System.out.println("Verstehe. Sie sind alt genug. Jedoch wollen Sie noch Autofahren? Ich selbst bin " + meinAlter);
    }                                           // geschwungenen Klammern!
}                                           // geschwungenen Klammern!
```

Wir sehen, die ``Variable`` *meinAlter* existiert nur innerhalb der runden Klammern. Wir können es nur innerhalb von ``if (alter >= 18) { ... }`` verwenden. Wir versuchen es aber innerhalb von ``if (alter >= 95) { ... }`` zu verwenden. Dort erkennt JAVA diese ``Variable`` nicht und verhindert die Ausführung des Programms. 

Wir erkennen zusätzlich, die ``Variable`` *alter* kann innerhalb von ``if (alter >= 18) { ... }`` sowie ``if (alter >= 95) { ... }`` verwendet werden. Es ist also möglich Variablen *außerhalb* eines ``Blockes`` zu ``definieren`` und diese *innerhalb* zu verwenden. Umgekehrt ist es jedoch nicht möglich. 

Allgemein wird dies ``Scoping`` oder der ``Scope`` einer ``Variable`` genannt. Dieser klärt wo welche Variable erkannt wird. Das ist z.B. innerhalb des ``Blocks`` von Zeile 10 ``{`` bis Zeile 25 ``}`` und dieser Bereich ist der ``Scope``. Wenn der Zugriff einer Variable *außerhalb* dieses ``Scopes`` ist, wird dies ``Variable is out of Scope`` genannt.

> Der ``Scope`` ist in JAVA jener ``Block`` welcher durch geschwungene Klammern ``{`` auf und zu ``}`` gekennzeichnet wird. Variablen können nur innerhalb dieses ``Scopes`` verwendet werden.

**Anmerkung:** Der Lösungsvorschlag in Intellij "Bring Variable ... into Scope" meint die Variable in jenen ``Scope`` zu geben in dem wir gerade befinden. Dadurch können wir diese ``Variable`` verwenden. 

**Anmerkung:** Der Scope welcher durch ``{...}`` angegeben wird ist unabhängig von ``Bedingte Anweisungen``. Dieses Konzept wird **immer** durch ``{...}`` angegeben, egal ob und welches ``Keyword`` (z.B. *if*, *while*, *for*, etc.) daneben steht.

## Was ist eine Verzweigung (Branches)?
Eine ``Verzweigung`` liegt vor, wenn wir zu einer ``Bedingte Anweisung`` zusätzlich das *Gegenteil* der ``Bedingung`` hinzufügen.

```java
System.out.print("Wie alt sind Sie? ");
Integer alter = ... // eine Zahl aus der Datenbank, oder aus der Usereingabe mittels Scanner.

if (alter >= 18) {
    System.out.println("Verstehe. Sie sind alt genug.");

} else { // Was ist das Gegenteil von alter >= 18 ?
    System.out.println("Verstehe. Sie sind NICHT alt genug.");
}
```

Wir sehen hier, die Ausgabe *Verstehe. Sie sind alt genug.* wir nur ausgegeben wenn das *alter* größer oder gleich *18* ist. Das ist die gleiche Logik wie bei der ``Bedingte Anweisung``. Wir erzeugen jedoch eine *Verzweigung* durch Anwendung des ``else``. Wir stellen uns nun 2 Türen vor, welche und wir können nur in eine der betreten. Ich gehe in die *linke* wenn *alter* größer oder gleich *18* ist und in die *rechte* wenn das *alter* **nicht** größer oder gleich *18* ist. Wir können diese Aussage umformen auf, wenn das *alter* kleiner *18* ist. Wir nennen dies eine ``Verzweigung``, denn wir erschaffen zwei ``Zweige`` welche ich nicht gleichzeitig betreten kann.

Wir merken uns:
> Wir nennen eine ``Kontrollstruktur``, welche eine ``Anweisung`` ist eine ``If-Anweisung``. Diese gibt keine ``Werte`` zurück.

> Wir nennen eine ``If-Anweisung`` eine **``Bedingte Anweisung``**, wenn diese *kein* ``else`` hat.

> Wir nennen eine ``If-Anweisung`` eine **``Verzweigung``**, wenn diese *ein* ``else`` hat.

Wir können nun folgendes tun. Der ``Block`` unter dem *if*- oder *else*-``Zweig`` erlaubt uns bereits bekannten Code dort zu schreiben. Das bedeutet auch, dass wir dort eine neue ``Verzweigung`` schreiben können. 

```java
if (alter >= 18) {
    System.out.println("Verstehe. Sie sind alt genug.");
    
    if (hatFuehrerschein) {
        System.out.println("Verstehe. Sie haben einen Führerschein.");

    } else {
        System.out.println("Verstehe. Sie haben KEINEN Führerschein.");
    }
    
} else { 
    System.out.println("Verstehe. Sie sind NICHT alt genug.");
}
```

Wir merken uns:
> Eine ``Verzweigung`` ist ``geschachtelt``, wenn eine *weitere* ``Verzweigung`` in der *ersten* ``Verzweigung`` steht.

**Anmerkung:** Wir können auch ``Bedingte Anweisungen`` in ``Verzweigungen`` und umgekehrt schachteln.

Solche *Schachtelungen* können im *else*-``Zweig`` bzw. *if*-``Zweig`` vorkommen. Auch in beiden gleichzeitig ist möglich.

### Wann verwenden wir eine Verzweigung?
Wir modellieren mit einer ``Verzweigung`` so genannte *Wenn-dann-ansosnten Aussagen*. Das *Ansonsten* modellieren wir mit dem Keyword ``else``. Wir dürfen die ``Verzweigung`` also nur verwenden, wenn wir ein *gegenteiliges* Verhalten zur ``Bedingte Anweisung`` angeben.

```java
// WENN ich alt genug bin, - die Bedingung, für diese Zweig ist alter >= 18
if (alter >= 18) {
    // DANN darf ich weiter.
    System.out.println("Verstehe. Sie sind alt genug.");
    
} else { // ANSOSNTEN - die Bedingung, für diesen Zweig ist !(alter >= 18) -> alter < 18
    System.out.println("Verstehe. Sie sind NICHT alt genug.");
}
```

Wir merken uns:
> Der ``Block`` nach dem ``Keyword`` *if* oder *else* wird ``Zweig`` genannt.

> Der *else*-``Zweig`` hat die *negierte* ``Bedingung`` des *if*-``Zweigs``.

### Wann verwenden wir eine verschachtelte Verzweigung?
Wir modellieren mit einer geschachtelten ``Verzweigung`` ähnliches wie bei einer nicht geschachtelten. Wir versuchen hier jedoch *kompliziertere* Aussagen zu ertsellen. Eine solceh wäre, "WENN ich älter bin als *18* und ich einen Führerschein habe, DANN darf ich ein Auto kaufen. ANSOSNTEN, WENN ich keinen jünger als 18 bin oder keinen Führerschein habe, DANN darf ich kein Auto kaufen.

```java
// WENN ich alt genug bin, - die Bedingung, für diese Zweig ist alter >= 18
if (alter >= 18) {
    // DANN muss ich einen Führerschein haben.
    System.out.println("Verstehe. Sie sind alt genug.");
    
    // WENN ich einen Führerschein habe, - die Bedingung, für diese Zweig ist alter >= 18 && hatFuehrerschein
    if (hatFuehrerschein) {
        // DANN darf ich weiter
        System.out.println("Verstehe. Sie haben einen Führerschein.");

    } else {// ANSOSNTEN - die Bedingung, für diesen Zweig ist alter >= 18 && !hatFuehrerschein
        System.out.println("Verstehe. Sie haben KEINEN Führerschein (sind jedoch alt genug).");
    }
    
} else { // ANSOSNTEN - die Bedingung, für diesen Zweig ist !(alter >= 18) -> alter < 18
    System.out.println("Verstehe. Sie sind NICHT alt genug.");
}
```

Wir erkennen, dass eine Schachtelung eine gewisse Logik darstellt. Z.B. fällt uns auf, dass beide ``Bedingungen`` *alter größer als 18 *und *hatFuehrerschein* ein ``logisches UND`` *alter >= 18 && hatFuehrerschein* darstellt. 

Wir merken uns, wenn wir *beide* *if*-``Zweige`` entlang gehen:
> Eine geschachtelte ``Verzweigung`` ist vergleichbar mit einem ``logisches UND`` *&&*. Das *&&* verbindet beide ``Bedingungen`` der *If*-``Zweige``.

#### Wie entsteht eine Verschachtelung?
Meistens entsteht eine ``Verschachtelung`` **nicht** in der Reihenfolge wie wir diese lesen. Wir lesen von der äußersten bis zur innersten. Es ist meistens genau anders herum. Wir beginnnen z.B. mit folgendem Code, welcher eine Abfrage der ``Variable`` *userInput* ist. Wir prüfen ob diese ein *Vokal* oder ein *Konsonant* ist. 

```csharp
if (
    userinput.equals("a") || userinput.equals("e") || userinput.equals("i") ||
    userinput.equals("o") || userinput.equals("u")
) {
    System.out.println("Usereingabe ist ein Vokal.");

} else {
    System.out.println("Usereingabe ist ein Konsonant.");
}
```

Der Code ist korrekt. Jedoch haben wir 2 Fehler eingebaut. Wir haben nämlich nicht eingeschränkt was der User alles eingeben kann. Diese "ungewünschten" Zustände sind oft schwer zu erkennen. 
* Der User gibt *a1* ein. Ausgabe ist **Konsonant**.
* Der User gibt *9* ein, Ausgabe ist **Konsonant**.
* Der User gibt *A* ein, Ausgabe ist **Konsonant**.

Es muss also *zuerst* abgefragt werden ob der Input des Users nur Länge 1 hat, sowie nur Buchstaben von **a-z** bzw. **A-Z** verwendet werden. 

```csharp
// if (97 <= userCharInput && userCharInput <= (97 + 26) && userinput.length() == 1) { // oder...
if (Character.isLetter(userCharInput) && userinput.length() == 1) {
    // hier ist der gewünschte Zustand eingetreten

} else {
    // hier ist der ungewünschte Zustand eingetreten
}
```
Wir geben nun den bereits geschreibenen Code in den *gewünschten* Zustand. Dadurch entsteht eine Schachtelung.

```java
// if (97 <= userCharInput && userCharInput <= (97 + 26) && userinput.length() == 1) { // oder...
if (Character.isLetter(userCharInput) && userinput.length() == 1) {
    if (
        userinput.equals("a") || userinput.equals("e") || userinput.equals("i") ||
        userinput.equals("o") || userinput.equals("u")
    ) {
        System.out.println("Usereingabe ist ein Vokal.");

    } else {
        System.out.println("Usereingabe ist ein Konsonant.");
    }

} else {
    // hier ist der ungewünschte Zustand eingetreten
}
```

### Wann verwenden wir eine Mehrfachverzweigung?
Wir erinnern uns an die ``Verzweigung``. Wir haben dort *zwei* ``Zweige`` und können nur einen davon ausführen. Einer ist der Code innerhalb des *if-*``Zweigs`` und die alternative dazu ist der Code innerhalb des *else-*``Zweigs``. Wir können nur einen dieser ``Zweige`` ausführen, da sich die ``Bedingungen`` der ``Zweige`` gegenseitig ausschließen (Die ``Bedingung`` für den *else*-``Zweig`` ist das *Gegenteil* von der Bedingung im *if-*``Zweig``).

Dieses Konzept wollen wir nicht nur auf zwei Optionen beschränken. Wir stellen uns Türen vor, durch welche wir durchgehen wollen. Wenn wir mehr als 2 Türen beschreiben wollen, brauchen wir eine sogenannte ``Mehrfachverzweigung``. Diese ist durch folgendes *else-if* Konstrukt beschrieben.

```java
if (A) { // Bedingung ist: WENN "A wahr ist" DANN...
    System.out.println("1. Zweig");

} else if(B) { // ANSONSTEN, WENN "!A && B wahr ist" 
    System.out.println("2. Zweig");

} else { // ANSONSTEN ... hier ist jedoch diese Bedingung versteckt: !A && !B
    System.out.println("3. Zweig");
}
```

Ein Beispiel wäre, eine Software für eine Verwaltung von Kursen und Noten zu schreiben (Moodle). Dort wollen wir Ergebnisse in % zu Noten transformieren. Hier haben wir 6 "Buckets" (oder Türen) und wir können ein Ergebnis einen "Bucket" zuweisen (nur durch eine der 6 Türen gehen). 6, weil wir die Noten 1-5 haben und einen Fehlerzustand. 

```java
// Mehrfachverzweigung (if else-if else-if ... else)
Integer bewertungInProzent = 62;

if (0 <= bewertungInProzent && bewertungInProzent < 50) {
    System.out.println("Nicht Genügend");

} else if (50 <= bewertungInProzent && bewertungInProzent < 62) {
    System.out.println("Genügend");

} else if (62 <= bewertungInProzent && bewertungInProzent < 75) {
    System.out.println("Befriedigend");

} else if (75 <= bewertungInProzent && bewertungInProzent < 87) {
    System.out.println("Gut");

} else if (87 <= bewertungInProzent && bewertungInProzent <= 100) {
    System.out.println("Sehr Gut");

} else {
    System.out.println("außerhalb der grenzen 0 und 100, beides inklusive");
}
```

Wir merken uns:
> ``Mehrfachverzweigungen`` können verwendet werden um nur **einen** von mehreren ``Zweigen`` zu wählen und dessen Code ausführen.

### Können wir If-Anwesungen in andere umschreiben?
Wir können alle Arten von ``If-Anweisungen`` (Verschachtelungen, Mehrfachverzweigung, Bedingungen, Verzweigungen) in eine andere Art umschreiben. Wann eine Variante besser als eine andere ist, ist ohne konkretes Beispiel schwer zu sagen. Wir haben jedoch oben ein paar Daumenregeln kennengelernt. Ein Beispiel dazu:

```java
// Mehrfachverzweigung
if (
    userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
    userinput.equals("o") || userinput.equals("u")
) {
    System.out.println("Usereingabe ist ein Vokal.");

} else if(
    userinput.equals("b") || userinput.equals("c") || userinput.equals("d") ||
    userinput.equals("f") || userinput.equals("g") || userinput.equals("h") ||
    userinput.equals("j") || userinput.equals("k") || userinput.equals("l") ||
    userinput.equals("m") || userinput.equals("n") || userinput.equals("p") ||
    userinput.equals("q") || userinput.equals("r") || userinput.equals("s") ||
    userinput.equals("t") || userinput.equals("v") || userinput.equals("w") ||
    userinput.equals("x") || userinput.equals("y") || userinput.equals("z")
) {
    System.out.println("Usereingabe ist ein Konsonant.");

} else {
    System.out.println("Usereingabe ist ein Konsonant.");
}
```

vs.

```java
// verschachtelte Verzweigung
if (Character.isLetter(userCharInput) && userinput.length() == 1) {
    if (
        userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
        userinput.equals("o") || userinput.equals("u")
    ) {
        System.out.println("Usereingabe ist ein Vokal.");
    } else {
        System.out.println("Usereingabe ist ein Konsonant.");
    }
} else {
    System.out.println("Fehlerhafte Eingabe.");
}
```

vs. 

```java
// Bedingungen
// Guards: beschütze gegen ungewünschte Logik
if (!Character.isLetter(userCharInput)) { 
    System.out.println("Fehlerhafte Eingabe.");
    return;
}

if (userinput.length() != 1) {
    System.out.println("Fehlerhafte Eingabe.");
    return;
}

// Business Logic: gewünschte Logik
if (
    userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
    userinput.equals("o") || userinput.equals("u")
) {
    System.out.println("Usereingabe ist ein Vokal.");
} else {
    System.out.println("Usereingabe ist ein Konsonant.");
}
```

All diese Programme haben das gleiche Verhalten.

## Was ist eine If-Anweisung (If-Statement) und was ein If-Ausdruck (If-Expression)?
**Wir verzichten auf folgendes.** Wir **könnten** jede Art von Programmzeile einen Namen geben. Diese sind ``Direktiven``, ``Anweisungen``, ``Deklarationen``, ``Definitionen``, ``Ausdrücke``, etc. Das ist jedoch sehr trocken und begrenzt nützlich.

Wir picken jedoch ``Ausdrücke`` und ``Anweisungen`` raus und beziehen diese auf unsere ``Verzweigung`` sowie ``Bedingte Anweisung``. Wir nennen das einen ``If-Ausdruck`` bzw. eine ``If-Anweisung``. 

Zu ``If-Anweisung`` muss kein Beispiel gegeben werden. Es sind die uns bekannten ``Bedingte Anweisungen`` oder ``Verzweigung``.

Merken wir uns:
> Eine **``If``**``-Anweisung`` ist in JAVA der Aufruf von ``Bedingte Anweisungen`` oder ``Verzweigung``. Diese produzieren **keinen** ``Wert`` und sind deshalb ``Anweisungen``.

Wir können also folgendes **nicht** schreiben. 
```java
String antwort = if (alter >= 18) {
    yield "Verstehe. Sie sind alt genug.";
} else {
    yield "Wir können einen solch komplexen Vertrag nicht abschließen."
}
```

In manchen Situationen wäre jedoch eine solches Sprachkonstrukt nützlich. Genau solche Konstrukte werden ``Ausdrücke`` (Expressions) genannt. 

Wir merken uns:
> Ein **``If``**``-Ausdruck`` ist in JAVA der Aufruf des ``?: Operators``. Dieser produziert **einen** ``Wert`` und ist deshalb ein ``Ausdruck``.

In JAVA und C# gibt es einen ``If-Ausdruck`` in der Form eines ``Operators``. Dieser ist der einzige welcher 3 ``Parameter`` hat und wird deshalb ``Ternärer Operator`` genannt. Ein alternativer Name ist der ``?:-Operator``.

Schauen wir uns die Bedeutung in einem Beispiel an und denken an die uns bekannte ``Verzweigung``.

```java
String antwort = alter >= 18 ? "Verstehe. Sie sind alt genug." : "Wir können einen solch komplexen Vertrag nicht abschließen.";
```

Um es ein wenig intuitiver zu gestalten schauen wir uns den ``If-Ausdruck`` in Python an.
```python
antwort = "Verstehe. Sie sind alt genug." if alter >= 18 else "Wir können einen solch komplexen Vertrag nicht abschließen."
```

Hier scheint *"Verstehe. Sie sind alt genug."* einer ``Variable`` welche den ``Typ`` *String* hat, zugewiesen zu werden. Jedoch nur **wenn** *alter >= 18* ist. **Ansonsten** *"Wir können einen solch komplexen Vertrag nicht abschließen."*.

Die Logik der Übersetzung zu JAVA ist somit folgende: 
* Das ``?`` ist ``if`` und der ``:`` ist ``else``.
* Wir beginnen mit der ``Zuweisung`` und nicht mit der ``Bedingung``.

Wir bemerken folgendes und merken uns:
> Die ``If-Ausdrücke`` scheinen ``Verzweigungen`` zu sein und nicht ``Bedingte Anweisungen``. Grund ist, es muss *immer* ein ``Wert`` zurück gegeben werden.

### Wann verwenden wir If-Anweisungen (If-Statements)?
Wir merken uns:
>Wir verwenden ``If-Anweisungen`` *eher*, wenn *mehrere Programmzeilen untereinander* in unseren einzelnen ``Verzweigungen`` benötigt werden.

Im folgenden Beispiel ist der Code innerhalb der ``Verzweigung`` von der Variable *connection* abhängig. Deshalb können wir diesen Code nicht außerhalb der ``Verzweigung`` schreiben.

Was genau hier passiert ist uns nicht klar, jedoch können wir beginnen zu erkennen was ``Variablen`` und was ``Typen`` sind. Weiters auch was die ``Bedingung`` ist um diesen Programmcode auszuführen. 

```java
if (connection != null) {
    if (!connection.isClosed()) {
        Statement statement = connection.createStatement(); // Achtung! Sicherheitsrisiko.
        ResultSet dataBaseresult = statement.executeQuery("SELECT username, email FROM users WHERE id = 1"); 
    
        String username = dataBaseresult.getString("username");
        String email = dataBaseresult.getString("email");
    
        User user = new User(username, email);
        System.out.println("Benutzer erstellt: " + user.getId());

    } else {
        connection.close();
    }
}
```

Weiters ist es oft nicht Zweckführend ``Bedingte Anweisungen`` als ``If-Ausdruck`` darzustellen. Grund dafür ist die fehlende alternative Zuweisung der ``Variable``, wenn die ``Bedingung`` nicht erfüllt ist. Deshalb bleiben wir hier bei ``If-Ausdrücke``. 

Wir merken uns:
> Wenn wir ``Bedingte Anweisungen`` schreiben wollen verwenden wir ``If-Anweisungen``.

### Wann verwenden wir If-Ausdrücke (If-Expressions)?
Wir werden hier zwei Beispiele von ``Ausdrücken`` in unserem Kurs sehen. Diese ist der ``Switch-Ausdruck`` und ``If-Ausdruck``. Letzteres wird auch ``?:-Operator`` bzw. ``ternärer Operator`` geannt. Beide haben verschiedene "sprachliche" limits, welche uns mehr oder weniger ausdruckskraft geben. Zudem werden wir in anderen Srpachen wie C# und Python den Begriff eines ``Pattern Matchers`` kennen lernen. Wir verstehen diesen als flexible und mächtige ``switch-expression``, welche die Logik einer ``Anweisungen`` obsolet (zwecklos) machen kann. Es ist also nicht so einfach generell vom Einsatzgebiet eines ``Ausdrucks`` zu sprechen. Wir beschränken uns daher auf den ``If-Ausdruck`` mit der Umsetzung als ``?:-Operator``.

Schauen wir uns konkret folgendes Programm welches [hier](#wann-verwenden-wir-eine-mehrfachverzweigung) beschreiben, an:
```java
// Mehrfachverzweigung (if else-if else-if ... else)
Integer bewertungInProzent = 62;

if (0 <= bewertungInProzent && bewertungInProzent < 50) {
    System.out.println("Nicht Genügend");

} else if (50 <= bewertungInProzent && bewertungInProzent < 62) {
    System.out.println("Genügend");

} else if (62 <= bewertungInProzent && bewertungInProzent < 75) {
    System.out.println("Befriedigend");

} else if (75 <= bewertungInProzent && bewertungInProzent < 87) {
    System.out.println("Gut");

} else if (87 <= bewertungInProzent && bewertungInProzent <= 100) {
    System.out.println("Sehr Gut");

} else {
    System.out.println("außerhalb der grenzen 0 und 100, beides inklusive");
}
```

Wir erkennen hier auf dem ersten Blick keine Notwendigkeit einen ``Wert`` mit einem ``If-Ausdruck`` zu erzeugen. Wir sehen nur Aufrufe von *System.out.println*`. Versuchen wir jedoch die Anzahl der Aufrufe von *System.out.println* zu reduzieren. Wir können das tun indem wir eine ``Variable`` vom ``Typ`` *String* ``definieren`` und in den verschiednen ``Zweigen`` der ``Verzweigung`` diese Variablen dem *System.out.println* übergeben. Siehe folgender Code.

```java
// Mehrfachverzweigung (if else-if else-if ... else)
Integer bewertungInProzent = 62;
String ausgabe;

if (0 <= bewertungInProzent && bewertungInProzent < 50) {
    ausgabe = "Nicht Genügend";

} else if (50 <= bewertungInProzent && bewertungInProzent < 62) {
    ausgabe = "Genügend";

} else if (62 <= bewertungInProzent && bewertungInProzent < 75) {
    ausgabe = "Befriedigend";

} else if (75 <= bewertungInProzent && bewertungInProzent < 87) {
    ausgabe = "Gut";

} else if (87 <= bewertungInProzent && bewertungInProzent <= 100) {
    ausgabe = "Sehr Gut";

} else {
    ausgabe = "außerhalb der grenzen 0 und 100, beides inklusive";
}

System.out.println(ausgabe);
```

Wir haben jedoch nun einen Anwendungsfall für einen ``If-Ausdruck`` erstellt.

Wir merken uns:
> Wenn ``Variablen`` ``definiert`` und in ``Verzweigungen`` "einfach" ``initialisiert`` werden, verwenden wir ``If-Ausdrücke``.

Wir versuchen nun die obige ``If-Anweisung`` in einen ``If-Ausdruck`` umzuschreiben.
Das Problem ist jedoch die ``Mehrfachverzweigung``, passt nicht direkt in das Muster des ``If-Ausdrucks``.

Wir starten jedoch mit folgendem Programm:
```java
String note = 87 <= bewertungInProzent && bewertungInProzent <= 100 ? "Sehr Gut" : "alle anderen Fälle";
System.out.println(note);
```

Wir [erinnern](TODO) uns, dass eine ``Mehrfachverzweigung`` auch als ``verschachtelte Verzweigung`` dargestellt werden kann.
Die gleiche Logik wenden wir nun hier an. In dem *Else*-``Zweig`` schreiben wir eine neue ``If-Verzewigung``. Bedeutet ein neues *if* mit *else*.
Wir ersetzen nun den ``Wert`` *"alle andern Fälle"* im  **Else*-``Zweig`` mit einem neuen ``?:-Operator``. Das ist nun hier die Schachtelung, auch wenn diese anders aussieht wie gewohnt.

```java
// If-Ausdruck (Expression)
String note = 87 <= bewertungInProzent && bewertungInProzent <= 100 ? "Sehr Gut" : 75 <= bewertungInProzent && bewertungInProzent < 87 ? "Gut" : "alle anderen Fälle"; // im else zweig, was der : hier ist starten wir eine neue expression
System.out.println(note);
```

**Anmerkung:** da ein ``If-Ausdruck`` einen ``Wert`` erzeugt, kann dieser auch in eine eigene neue ``Variable`` geschrieben werden. Das würde folgendermaßen aussehen. 

```java
// If-Ausdruck (Expression)
String zwischenErgebnis = 75 <= bewertungInProzent && bewertungInProzent < 87 ? "Gut" : "alle anderen Fälle";
String note = 87 <= bewertungInProzent && bewertungInProzent <= 100 ? "Sehr Gut" : zwischenErgebnis; // im else zweig, was der : hier ist starten wir eine neue expression
System.out.println(note);
```

Wir wiederholen nun das "schachteln" der ``If-Ausdrücke``, bis wir am Ende unserer Mehrfachverzweigung sind. Eine "sinnvolle" Formatierung (Darstellung des Codes) ist notwendig um hier den Überblick zu bewahren. Wir versuchen hier zwischen ``Bedingung`` und *?* gleiche Abstände einzufügen (Tabulator Taste) und pro Zeile eine ``Verzweigung`` darzustellen.

```java
String note =   87 <= bewertungInProzent && bewertungInProzent <= 100   ? "Sehr Gut" :
                75 <= bewertungInProzent && bewertungInProzent < 87     ? "Gut" :
                62 <= bewertungInProzent && bewertungInProzent < 75     ? "Befriedigend" :
                50 <= bewertungInProzent && bewertungInProzent < 62     ? "Genügend" :
                0 <= bewertungInProzent && bewertungInProzent < 50      ? "Nicht Genügend" :
                                                                        "außerhalb der grenzen 0 und 100, beides inklusive";
System.out.println(note);
```

Wir merken uns:
> ``If-Ausdrücke`` können geschachtelt werden. Da keine Klammern vorkommen, ist es für eine sinnvolle Lesbarkeit notwendig den ``Ausdruck`` zu formatieren.