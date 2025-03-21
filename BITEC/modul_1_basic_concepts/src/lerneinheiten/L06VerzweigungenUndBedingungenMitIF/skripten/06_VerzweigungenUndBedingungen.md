# Verzweigungen und Bedingungen mit If

Wir haben 4 Grundlegende Werkzeuge erwähnt welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen 
* ✅ Operatoren (bzw. Methoden aufrufen) 
* ❔ Verzweigungen und Bedingungen
* ❔ Schleifen

Wir behandeln nun die ``Verzweigungen`` und ``Bedingungen`` und verwenden dazu vorerst die Varianten mittels dem ``If`` und ``else`` Keywords.

## Was ist unser Ziel mit diesem Werkzeug?
Stellen wir uns folgendes Problem vor. Wir haben eine Kontrolle einer Person bei einem Onlinevertragsabschluss und fragen ab, ob diese *alt genug* ist und einen *Führerschein* hat. Diese will ein Auto kaufen. Falls alt genug ist und einen Führerschein hat, befinden wir uns in einem Zustand welcher uns erlaubt den Kunden positiv abzuspeichern. Um dies umzusetzen brauchen wir ``Verzweigungen`` bzw. ``Bedingungen``. Diese steuern welcher Programmcode ausgeführt wird. Die Grundlage für eine solche Steuerung sind `logische Formeln` welche wir bereits kennen gelernt haben. Diese ``logischen Formeln`` bestehen aus ``booleschen Variablen`` welche mit ``logischen Operatoren`` bzw. ``Vergleichsoperatoren`` verknüpft werden. 

## Was ist eine Bedingung (Condition)?
Schreiben wir folgenden Code welcher die Kontrolle einer Person darstellt:

```java
System.out.print("Wie alt sind Sie? ");
Integer alter = ... // eine Zahl aus der Datenbank, oder aus der Usereingabe mittels Scanner.

if (alter >= 18) {
    System.out.println("Verstehe. Sie sind alt genug.");
}
```

Wir sehen hier, die Ausgabe *Verstehe. Sie sind alt genug.* wir nur ausgegeben wenn das *alter* größer oder gleich *18* ist. Diese Ausgabe ist also ``bedingt`` auf die ``logische Formel`` *alter >= 18*. Wir nennen dies eine ``If-Bedingung``. Die Ausgabe *Wie alt sind sie?* hat keine Bedingung und ist dadurch bedingungslos.

wir merken uns (jedoch ohne die genaue Definition von ``else`` und ``If-Anweisung`` zu kennen) folgendes:
> Wir nennen eine ``If-Anweisung`` eine **``If-Bedingung``**, wenn diese kein ``else`` hat.

### Wann verwenden wir eine If-Bedingung?
Wir modellieren mit einer ``IF-Bedingung`` so genannte *Wenn dann Aussage*. Wir dürfen diese also nur verwenden, wenn kein *alternatives* Verhalten angegeben wird. 

Ein Beispiel:
```java
// WENN ich alt genug bin, 
if (alter >= 18) {
    // DANN darf ich weiter.
    System.out.println("Verstehe. Sie sind alt genug.");
}
// ANSOSNTEN... ?
```

Wir wissen nicht was ansonsten passiert. Wir gehen in die ``If-Bedingung``, wenn dessen Bedingung erfüllt ist und springen drüber wenn nicht, denn wir haben keine Vorgabe was passieren soll wenn wir **nicht** *alt genug* sind.

### Warum erkennen wir nicht alle Variablen?
Da wir mit den geschwungenen Klammern ``{}`` einen so genannten neuen ``Scope`` oder auch ``Block`` genannt einführen müssen wir auf folgendes aufpassen, wenn wir mehrere dieser ``If-Bedingungen`` untereinanderschreiben.

Hier passiert ein Fehler... jedoch welcher?
```java
public static void main(String[] args) {    // runde Klammern!
    Integer alter = ... // diese Variable gibt es innerhalb umgebenen runden Klammern, bedeutet in der main methode

    if (alter >= 18) {                      // runde Klammern!
        Integer meinAlter = 21;
        System.out.println("Verstehe. Sie sind alt genug. Ich selbst bin " + meinAlter);
    }                                       // runde Klammern!

    if (alter >= 95) {                      // runde Klammern!
        System.out.println("Verstehe. Sie sind alt genug. Jedoch wollen Sie noch Autofahren? Ich selbst bin " + meinAlter);
    }                                       // runde Klammern!
}                                           // runde Klammern!
```

Wir sehen, die ``Variable`` *meinAlter* existiert nur innerhalb der runden Klammern. Wir können es nur innerhalb von ``if (alter >= 18) { ... }`` verwenden. Wir versuchen es aber innerhalb von ``if (alter >= 95) { ... }`` zu verwenden. Dort erkennt JAVA diese ``Variable`` nicht und verhindert die Ausführung des Programms. 

Wir erkennen zusätzlich, die ``Variable`` *alter* kann innerhalb von ``if (alter >= 18) { ... }`` sowie ``if (alter >= 95) { ... }`` verwendet werden. Es ist also möglich Variablen *außerhalb* eines ``Blockes`` zu ``definieren`` und diese *innerhalb* zu verwenden. Umgekehrt ist es jedoch nicht möglich. 

Allgemein wird dies ``Scoping`` oder der ``Scope`` einer ``Variable`` genannt. Dieser klärt wo welche Variable erkannt wird. Das ist z.B. innerhalb des ``Blocks`` von Zeile 10 ``{`` bis Zeile 25 ``}`` und dieser Bereich ist der ``Scope``. Wenn der Zugriff einer Variable *außerhalb* dieses ``Scopes`` ist, wird dies ``Variable is out of Scope`` genannt.

> Der ``Scope`` ist in JAVA jener ``BLock`` welcher durch geschwungene Klammern ``{`` auf und zu ``}`` gekennzeichnet wird. Variablen können nur innerhalb dieses ``Scopes`` verwendet werden.

**Anmerkung:** Der Lösungsvorschlag in Intellij "Bring Variable ... into Scope" meint die Variable in jenen ``Scope`` zu geben in dem wir gerade befinden. Dadurch können wir diese ``Variable`` verwenden. 

**Anmerkung:** Der Scope welcher durch ``{...}`` angegeben wird ist unabhängig von ``If-Bedingungen``. Dieses Konzept wird **immer** durch ``{...}`` angegeben, egal welches ``Keyword`` (z.B. *if*) daneben steht.

## Was ist eine Verzweigung (Branches)?
### Wann verwenden wir eine If-Verzweigung?
### Wann verwenden wir eine Mehrfachverzweigung?
### Wann verwenden wir eine verschachtelte If-Verzweigung?

## Was ist eine If-Anweisung (If-Statement) und was ein If-Ausdruck (If-Expression)?
**Wir verzichten auf folgendes.** Wir **könnten** jede Art von Programmzeile einen Namen geben. Diese sind ``Direktiven``, ``Anweisungen``, ``Deklarationen``, ``Definitionen``, ``Ausdrücke``, etc. Das ist jedoch sehr trocken und begrenzt nützlich.

Wir picken jedoch ``Ausdrücke`` und ``Anweisungen`` raus und beziehen diese auf unsere ``If-Verzweigung`` sowie ``If-Bedingung``. Wir nennen das einen ``If-Ausdruck`` bzw. eine ``If-Anweisung``. 

Zu ``If-Anweisung`` muss kein Beispiel gegeben werden. Es sind die uns bekannten ``If-Bedingungen`` oder ``If-Verzweigung``.

Merken wir uns folgendes:
> Eine **``If``**``-Anweisung`` ist in JAVA der Aufruf von ``If-Bedingungen`` oder ``If-Verzweigung``. Diese produzieren **keinen** ``Wert`` und sind deshalb ``Anweisungen``.

Wir können also folgendes **nicht** schreiben. 
```java
String antwort = if (alter >= 18) {
    yield "Verstehe. Sie sind alt genug.";
} else {
    yield "Wir können einen solch komplexen Vertrag nicht abschließen."
}
```

In manchen Situationen wäre jedoch eine solches Sprachkonstrukt nützlich. Genau solche Konstrukte werden ``Ausdrücke`` (Expressions) genannt. 

> Ein **``If``**``-Ausdruck`` ist in JAVA der Aufruf des ``?: Operators``. Dieser produziert **einen** ``Wert`` und ist deshalb ein ``Ausdruck``.

In JAVA und C# gibt es einen ``If-Ausdruck`` in der Form eines ``Operators``. Dieser ist der einzige welcher 3 ``Parameter`` hat und wird deshalb ``Ternärer Operator`` genannt. Ein alternativer Name ist der ``?:-Operator``.

Schauen wir uns die Bedeutung in einem Beispiel an und denken an die uns bekannte ``If-Verzweigung``.

```java
String antwort = alter >= 18 ? "Verstehe. Sie sind alt genug." : "Wir können einen solch komplexen Vertrag nicht abschließen.";
```

Um es ein wenig direkter zu gestalten schauen wir uns den ``If-Ausdruck`` in Python an.
```python
antwort = "Verstehe. Sie sind alt genug." if alter >= 18 else "Wir können einen solch komplexen Vertrag nicht abschließen."
```

Hier scheint *"Verstehe. Sie sind alt genug."* einer ``Variable`` welche den ``Typ`` *String* hat, zugewiesen zu werden. Jedoch nur **wenn** *alter >= 18* ist. **Ansonsten** *"Wir können einen solch komplexen Vertrag nicht abschließen."*.

Die Logik der Übersetzung zu JAVA ist somit folgende: 
* Das ``?`` ist ``if`` und der ``:`` ist ``else``.
* Wir beginnen mit der ``Zuweisung`` und nicht mit der ``Bedingung``.

Wir bemerken:
> Die ``If-Ausdrücke`` scheinen ``If-Verzweigungen`` zu sein und nicht ``If-Bedingungen``. Grund ist, es muss *immer* ein ``Wert`` zurück gegeben werden.



### Wann verwenden wir Anweisungen (Statements)?
Wir verwenden ``If-Statements`` *eher*, wenn *mehrere Programmzeilen untereinander* in unseren einzelnen ``Verzweigungen`` benötigt werden.
Ein Beispiel:

```java
if (connection != null && !connection.isClosed()) {
    ResultSet dataBaseresult = executeQuery("SELECT username, email FROM users WHERE id = 1");

    String username = dataBaseresult.getString("username");
    String email = dataBaseresult.getString("email");

    User user = new User(username, email);
    System.out.println("Benutzer erstellt: " + user.getId());
} else {
    connection.close();
}
```

Wir werden hier 2 Beispiele in unserem Kurs sehen. Diese ist die ``Switch-expression`` und ``If-Expression``. Letzteres wird auch ``?:-Operator`` bzw. ``ternärer Operator`` geannt.
 TODO
Es sind quasi alle ``Kontrollstrukturen`` was wir in diesem Kurs kennen lernen werden ``Anweisungen`` (mit 2 Ausnahmen). Dabei ist eine ``Kontrollstruktur`` ein Sammelbegriff von jenen ``Anweisungen`` und ``Ausdrücke`` welche sich um den Ablauf eines Programmes kümmern. Das erwähnte hilft uns jedoch nicht wirklich um zu wissen was ``Anweisungen`` ausmachen. 


und ist zudem eine ``Kontrollstruktur``, wenn
> Eine ``Anweisung`` ist eine ``Kontrollstruktur`` wenn diese den Ablauf des Programms steuert.
