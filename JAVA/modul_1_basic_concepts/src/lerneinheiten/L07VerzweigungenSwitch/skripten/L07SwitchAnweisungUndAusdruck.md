# Mehrfachverzweigungen mit Switch-Anweisungen und Switch-Ausdrücken

#### Welche Begriffe werden hier verwendet?
[``Wert``](../../../glossar.md#wert), [``Variable``](../../../glossar.md#variable), [``Typ``](../../../glossar.md#typ),  [``logische Formel``](../../../glossar.md#logische-formel), [``Anweisung``](../../../glossar.md#anweisung), [``Switch-Anweisung``](../../../glossar.md#switch-anweisung), [``Ausdruck``](../../../glossar.md#ausdruck), [``Switch-Ausdruck``](../../../glossar.md#switch-ausdruck), [``Bedingung``](../../../glossar.md#bedingung), [``Verzweigung``](../../../glossar.md#bedingung), [``Mehrfachverzweigung``](../../../glossar.md#mehrfachverzweigung), [``Block``](../../../glossar.md#bedingung), [``Zweig``](../../../glossar.md#zweig)

Wir haben 4 Grundlegende Werkzeuge erwähnt welche wir brauchen um Programme schreiben zu können.
Diese sind:
* ✅ Variablen 
* ✅ Operatoren (bzw. Methoden aufrufen) 
* ✅ Verzweigungen und Bedingte Ausdrücke
* ❔ Schleifen

Der Grund warum wir nun eine weitere ``Verzweigung`` kennenlernen, ist rein um unseren "Wortschatz" aufzubessern. 
An sich können Programme auch ohne ``Switch-Anweisugnen`` bzw. ``Ausdrücke`` geschreiben werden. Da ``switch`` eine speziellere ``Verzweigung`` als die ``Verzweigung`` ist, können wir nicht alles mit ``switch`` schreiben was mit ``if`` geht. *Speziellere* Sprachkonstrukte bedeuten aber, dass in passenden Situationen diese leichter lesbar oder effizienter vom Computer umgesetzt werden können. Allgemein ist die ``Switch-Anweisung``, sowie der ``Switch-Ausdruck``, nicht essentiell von Bedeutung in JAVA. Wir bereiten uns jedoch damit auf *mächtigere* Ausdrücke wie dem ``Pattern-Matcher`` vor. Diese werden mittels ``Switch-Ausdruck`` in C# oder Python umgesetzt. In Python wird ledeglich das Keyword *match* anstatt *switch* verwendet.

Wir beginnen hier anders als bei der ``Verzweigung`` mit dem Variante des ``Ausdrucks``. Der Grund ist die veraltete schreibweise der *klassischen* ``Switch-Anweisung``. Wir behandeln diese kurz später, denn diese hat ein *unerwartetes* Verhalten. 

## Wie schreibe ich eine Verzweigung als Switch-Ausdruck?
Ohne weiters diesen ``Ausdruck`` zu motivieren schauen wir uns die ``Syntax`` an anhand eines Beispiels an.
```java
Integer variable = 5;

String ergebnis = switch (variable) {
    case 1      -> "Die Variable hat den Wert eins";
    case 2, 5   -> "Die Variable hat den Wert zwei oder fünf.";
    default     -> "Die Variable hat nicht den Wert 1, 2 oder 5.";
}

System.out.println(ergebnis); // Die Variable hat den Wert zwei oder fünf.
```

Wir vergleichen den ``Switch-Ausdruck`` mit einem gleichbedeutender ``Mehrfachverzewigung`` welche als ``If-Ausdruck`` mit dem ``?: Operator`` umgesetzt wird. 
```java
Integer variable = 5;

String ergebnis = 
    variable == 1                  ? "Die Variable hat den Wert eins" : 
    variable == 1 || variable == 5 ? "Die Variable hat den Wert zwei oder fünf." : 
                                     "Die Variable hat nicht den Wert 1, 2 oder 5.";
```

Hier bemerken wir folgendes:
> Ein ``Switch-Ausdruck`` vergleicht eine ``Variable`` auf ``Gleichheit`` (*==* bzw. *.equals()*) mit einem ``Wert``. 
> Ist ein Vergleich erfoglreich, wird der entsprechende ``Programmcode`` ausgeführt. 
> Ist *kein* Vergleich erfolgreich, wird der ``Programmcode`` im *default-case* ausgeführt.

Weiters können wir in den *cases* mehrere ``Werte`` angeben. Dies ist eine schnellere schreibweise als wenn diese untereinander in einzelnen ``cases`` behandelt werden.
```java
case 2 -> "Die Variable hat den Wert zwei oder fünf.";
case 5 -> "Die Variable hat den Wert zwei oder fünf.";
```

Wir merken uns:
> Ein ``logisches ODER`` ist durch die Angabe von mehreren ``Werten`` in den *cases* umsetzbar.

**Anmerkung:**: Die eingefügten Tabulatoren (? steht über dem ?´in der näcshten Zeile), dienen der schöneren Lesbarkeit in **diesem Beispiel** hier. Es ist nicht immer möglich einen gut lesbaren Code mittels Tabulatoren oder anderen geometrischen Überlegungen zu erzeugen. Wenn in der Gruppe *professionell* programmiert wird, sollten ``Coding Conventions`` festgelegt werden. Solche legen fest wie der Code aussieht. ``IDEs`` bieten dazu automatisches styling an. Wie diese aussehen werden oft von den Erstellern von Programmiersprachen wie z.B. für JAVA von [Oracle](https://www.oracle.com/java/technologies/javase/codeconventions-contents.html), Python - [PEP 8](https://peps.python.org/pep-0008/) oder C# von [Mircorsoft](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).

### Brauche ich immer eine Rückgabe? - Switch-Anweisung.
Die Antwort hier ist *nein*. Wir können mit der gleichen ``Syntax`` auch eine ``Anweisung`` schreiben. Dazu lassen wir einfach den ``Zuweisungsoperator`` weg. Der Code welcher nun in jedem *case* ausgeführt wird, muss nun was machen. Wie z.B. eine Ausgabe. Ansosnten verlieren wir das Ergebnis.

```java
Integer variable = 5;

switch (variable) {
    case 1      -> System.out.println("Die Variable hat den Wert eins");
    case 2, 5   -> System.out.println("Die Variable hat den Wert zwei oder fünf.");
    default     -> System.out.println("Die Variable hat nicht den Wert 1, 2 oder 5.");
}
```

### Eine Anweisung verwende ich wenn ich mehr Zeilen schreiben will, geht das hier?
Wie bereits erwähnt gibt es Situationen in denen wir ``Anweisungen`` schreiben wollen. Ein Beispiel dazu ist, wenn wir mehrere Zeilen Code in einem ``Block`` schreiben müssen.

Ein Beispiel, welches wir nicht ganz verstehen müssen. Wir bemerken nur, dass mehrere Zeilen Code innerhalb des *if* benötigen werden. Diese Zeilen können auch nicht außerhalb des *if* stehen. 

```java
User databaseUser = userConnection.findUser(guiUser);
User user;

if(guiUser.kennung().equals("dasIstEineGültigeKennung")) {

    databaseUser.setLastLogin(LocalDateTime.now());
    databaseUser.setActive(true);
    databaseUser.setRememberMe(guiUser.getRememberMe());

    user = userConnection.updateUser(databaseUser);

} else {
    throw new FalscheKennungException(guiUser);
}
```

Wir versuchen nun dies in eine ``Switch-Anweisung`` umzuschreiben. Das dient rein der **Übung** einen If-Ausdruck in einen Switch-Ausdruck umzuschreiben und hat ansonsten keine Vorteile. Wir betrachen später wann ein ``Switch-Anweisung`` bzw. ``Switch-Ausdruck`` sinnvoll ist und wann nicht.

```java
User databaseUser = userConnection.findUser(guiUser);
User user;

String dieZuSwitchendeVariable = guiUser.kennung();

switch(dieZuSwitchendeVariable) {
    case "dasIstEineGültigeKennung" -> {
        databaseUser.setLastLogin(LocalDateTime.now());
        databaseUser.setActive(true);
        databaseUser.setRememberMe(guiUser.getRememberMe());

        user = userConnection.updateUser(databaseUser);
    }
    default -> {
        throw new FalscheKennungException(guiUser);
    }
}
```

Wir merken uns:
> Ein mehrzeiliger *case* einer ``Switch-Anweisung`` kann mit einem neuen ``Block`` *{ ... }* erzeugt werden.

### Kann ich auch mehrzeilige Switch-Ausdrücke schreiben?
Hier ist die Anwort ebenso *ja* und belassen es bei diesem Beispiel.

```java
User databaseUser = userConnection.findUser(guiUser);
String dieZuSwitchendeVariable = guiUser.kennung();

User user = switch(dieZuSwitchendeVariable) {
    case "dasIstEineGültigeKennung" -> {
        databaseUser.setLastLogin(LocalDateTime.now());
        databaseUser.setActive(true);
        databaseUser.setRememberMe(guiUser.getRememberMe());

        yield userConnection.updateUser(databaseUser);
    }
    default -> {
        throw new FalscheKennungException(guiUser);
    }
}
```

Wir merken uns:
> In einem mehrzeiligen *case* eines ``Switch-Ausdrucks`` muss innerhalb des ``Blocks`` *{ ... }* jene ``Variable`` welche *zurückgegeben* wird mit ``yield`` gekennzeichnet werden.

## Welche Typen von Variablen kann ich in einem Switch-Ausdruck verwenden?
### Double? Nein - Keine Bereiche
Ändern wir nun den Typ der ``Variable`` von *String* auf einen *Double*. Wir erinnern uns, dass durch die ``FLießkommadarstellung`` Rundungsfehler entstehen können und wir daher *Bereiche* angeben müssen um einen Vergleich zu tätigen. Wir fragen nicht ``a == b`` ab, sondern beginnen mit ``a - b == 0``. Danach lockern wir das ``== 0`` auf und schreiben z.B ``-0.1 < a - b && a - b < 0.1``. Wir legen also einen Bereich um 0 welcher -0.1 und 0.1 ist. Innerhalb dieses Bereichs sehen wir die Subtraktion ``a - b`` als gleichwertig an. Kürzer geht es mit der *absolut Value* Methode ``Math.abs(a - b)`` welche das Vorzeichen entfernt. Wir müsen damit nur mehr auf "eine Seite" des *Bereichs* abfragen und bekommen ``Math.abs(a - b) < 0.1`` als Bedingung.

Wir sehen jeodch schon das Problem. Dieser Ausdruck ``Math.abs(a - b) < 0.1`` hat nichts mehr mit Gleichheit zu tun und ist deshalb nicht Umsetzbar mit einem ``Switch-Ausdruck`` in **JAVA**. 

**Anmerkung**: Da die Handhabung von Kommazahlen fehleranfällig sein kann ist bei *wichtigen* Berechnungen bzw. Vergleichen eine ``Variable`` des Typs ``BigDecimal`` mit dessen Methode ``compareTo`` zu verwenden. Die Erstellung der Variable ist mittels eines **Strings** und nicht mit einem *Double* zu vollziehen! ``BigDecimal`` ist jedoch langsamer als der primitve ``double``. 

### Boolean? Nein - Keine logischen Ausdrücke
Der Grund kann nicht sein, dass wir diesmal auf einen Bereich abfragen, denn ``true == true`` ist in JAVA möglich. Wir können nun einfach akzeptieren dass es nicht geht und weiter machen. Dieser Fall erlaubt und jedoch kurz über den ``Hintergrund`` der ``Switch-Expresison`` zu sprechen. Der Grund warum die ``Switch-Verzweigung`` eingeschränkt im Vergleich zur ``If-Verzeigung`` ist, hat wenig mit der Lesbarkeit des Codes zu tun. Es hat mit dem Maschinencode welcher im ``Hintergrund`` erzeugt wird  zu tun. Schauen wir uns dazu nochmals die ``Mehrfachverzweigung`` welche mit dem ``?:Operator`` umgesetzt wird an. 

```java
Integer variable = 5;

String ergebnis = 
    variable == 1                  ? "Die Variable hat den Wert eins" : 
    variable == 1 || variable == 5 ? "Die Variable hat den Wert zwei oder fünf." : 
                                     "Die Variable hat nicht den Wert 1, 2 oder 5.";
```

Diese geht schrittweise von oben nach unten. Wir müssen zuerst abfragen ob ``variable == 1`` ist, falls ja, führe den Code dort aus. Falls nein, geh weiter zu ``variable == 1 || variable == 5``. Hier müssen wir sogar mehr arbeiten. Wir haben dort eine Formel welche 2 Teile besitzt. Wir müssen nun die Bedingung ausrechnen. Wir überprüfen zuerst ob ``variable == 1`` ist, Falls ja, gut das ``logische ODER`` ergibt wahr und damit auch die ``Bedingung``. Falls nicht, müssen wir noch weiter zu ``variable == 5`` schauen. Wenn auch dieser Fall nicht eintreten sollte, führen wir den letzten ``Zweig`` aus. 

Wenn wir dieses Verhalten als ``Switch-Ausdruck`` schreiben...
```java
Integer variable = 5;

String ergebnis = switch (variable) {
    case 1      -> "Die Variable hat den Wert eins";
    case 2, 5   -> "Die Variable hat den Wert zwei oder fünf.";
    default     -> "Die Variable hat nicht den Wert 1, 2 oder 5.";
}
```
... haben wir folgenen Vorteil. Wir müssen keine ``Bedingungen`` ausrechnen, denn ein ``Switch-Ausdruck`` lässt diese nicht zu. Wir können nur Werte angeben. Das nutzen wir aus und erzeugen dadurch eine so genannte *Jump Table*. Wir vereinfachen es hier und stellen uns folgendes vor. Wir haben einen ``Schlüssel``, den wir direkt verwenden können. Dieser ist der ``Wert`` welchen wir neben *case* schreiben. In unserem Beispiel ist es für *case 1*, *1* und für *case 2, 5* ist es *2* oder *5*. Diese ``Schlüssel`` erlauben uns einen *direkten Zugriff* auf den auszuführenden Code, ohne die oben genannten logischen Bedingunen jedes Zweigs einzeln abzugehen bzw. falls diese komplizierter sind, diese auszurechnen. 

Wenn wir später Datenstrukturen besprechen, geh hier zurück und lies den foglenden Satz nocheinmal: *"Jump Tables sind lowlevel Hashmaps und Mehrfachverzweigungen sind eine lowlevel Array/Listen suche."*

**Anmerkung:** Es geht hier um das allgemeine Konzept und die *ursprüngliche* Idee der ``Switch-Verzweigung``. Wie Compiler optimieren, ob ein switch **wirklich schneller** ist oder nicht, hängt von der Sprache, der spezielle Compiler (wie schlau ist er? wie viel darf er optimieren?) dieser Sprache und die spezielle Verwendung der ``Switch-Verzweigung`` ab. Wir können Ergebnisse mit Leichtigkeit erzeugen, welche dem hier erwähnten wiedersprechen. Compiler sind eines der komplexesten Themen in der Informatik. Dadurch sind solche vereinfachten Aussagen, welche wir hier aufstellen meistens falsch. Jedoch ist es wichtig sich in solche Themen hineindenken zu können. [Hier](../live/SpeedTest.java) ist ein Beispiel wo es scheint, der JAVA Compiler schafft es nicht aus der ``Mehrfachverzweigung`` mit *if* einen genau so schnellen Code wie mit der *Jump Table* des ``Switch-Ausdrucks`` zu erzeugen. Ansonsten müssten die Laufzeiten gleich sein. 

```java
//switch duration: 9 ms, 16 ms, 169 ms
//if duration: 455 ms, 308 ms, 579 ms
```

Wir erkenn jedoch, dass dieses Beispiel mit *1000* switch cases nicht gerade einem Beispiel aus der Praxis entspricht.


**Anmerkung:** Es ist egal ob wir hier einen ``Ausdruck`` oder ``Anweisung`` verwenden. Die Logik der "Jump Table" bleibt bestehen.

Wir merken uns:
> ``Switch-Verzweigungen`` sind historisch leicht von ``Compilern`` im Maschinencode zu *Jump Tables* umgewandelt worden. Diese sind schneller als ``Mehrfachverzweigugnen`` mit ``If-Verzweigugnen``. Es kann jedoch sein, dass der ``Compiler`` auch die ``If-Verzweigugnen`` zu *Jump Tables* umwandelt.

Wir merken uns zudem noch:
> ``Switch-Verzweigungen`` verwenden wir **nie** mit der Begründung "wir optimieren den Code" dadurch. Wir verwenden es, wenn der **Code leserlicher** dadurch wird.

### Was können wir nun für Typen verwenden?
Kurz gehalten merken wir uns:
> ``Switch-Ausdrücke`` haben folgenden Einschränkungen:
> * Der ``Typ`` der ``Variable`` darf nur: *char*, *Character*, *byte*, *Byte*, *short*, *Short*, *int*, *Integer*, *String*, oder *Enum* sein.
> * Der ``Bedingung`` ist auf *==* oder *.equals()* beschränkt.

und beschäftigen uns nun mit der wichtigsten Frage. *Wann verwenden wir einen Switch-Ausdruck?*

## Wann verwenden wir einen Switch-Ausdruck?
Wir haben hauptsächlich uns die ``Switch-Verzweigung`` in Vorbereitung auf die in C# oder Python verwendeten ``Pattern Matcher`` angeschaut. An sich ist der Anwendungsbereich eines ``Switch-Anweisung`` nicht gegeben, da der Compiler so oder so den Code optimiert und wir nicht in der hand haben ob *Jump Tables* verwendet werden. Es ist wie oven erwähnt nicht üblich ``Switch-Anweisung`` als Optimierungswerkzeug zu verwenden. Ein *Anwendungsfall* ist jedoch jener einer ``Merhfachverzweigung`` welche mit einem ``Switch-Ausdruck`` lesbarer umgesetzt werden kann als mit dem ``?: Operator``. Es kann zusätzlich der ``?: Operator`` aus Stilgründen nicht gewünscht sein und dadurch eine Verwendung des ``Switch-Ausdrucks`` in Betracht gezogen werden.

Dazu ein Beispiel:

```Schreiben Sie ein Java-Programm, das den Wochentag basierend auf einer Eingabe von 1 bis 7 (entsprechend den Wochentagen Montag bis Sonntag) ausgibt und dabei zufällige Emojis hinzufügt, um die Laune des jeweiligen Wochentages anzuzeigen. Es soll zusätzlich ein zufälliger Wert verwendet werden, um die Laune für bestimmte Wochentage zu variieren.```

```java
Random random = new Random();
Double zufallszahl = random.nextDouble();

String output = switch (input) {
    case 1 -> {
        String res = "Montag :(";

        if (zufallszahl < 0.8) {
            res = res + ":(".repeat(5);
        }

        yield res;
    }
    case 2 -> "Dienstag";
    case 3 -> "Mittwoch";
    case 4 -> "Donnerstag";
    case 5 -> {
        String res = "Freitag :)";

        if (zufallszahl < 0.3) {
            res += ":)".repeat(7);
        }

        yield res;
    }
    case 6 -> "Samstag";
    case 7 -> "Sonntag";
    default -> "kein Wochentag";
};

System.out.println(output);

```

Wir werden noch weitere Werkzeuge kennenlernen um diesen Code übersichtlicher zu gestalten. Bis jetzt ist es so halbwegs vertretbar.

Halten wir es kurz. Wir merken uns:
> ``Switch-Verzweigungen`` verwenden wir falls ein ``If-Ausdruck`` welche mit dem ``?: Operator`` umgesetzt wird, mehrere Zeilen innerhalb eines ``Blocks`` benötigt, oder der ``?: Operator`` einfach aus Stilgründen nicht gewünscht wird. 

## Historisch: Die klasische Switch-Anweisung - vermeide diese

### Warum ist break bei der Switch-Anweisung essentiell:
Wir verwenden break um aus ``Schleifen`` zu springen und auch hier um aus der ``Switch-Anweisung`` zu springen. 

```java
switch (Variable) {
    case Wert:
        // Code
        break;
    case Wert:
        // Code
        break;
    default:
        // Code
}
```

Schauen wir uns foglendes Beispiel an.

```java
Scanner scanner = new Scanner(System.in);
System.out.print("Geben Sie eine Zahl zwischen 1 und 7 ein um einen Wochentag zu erhalten: ");
Integer input = Integer.parseInt(scanner.nextLine());

switch (input) {
    case 1: System.out.println("Montag :("); break;
    case 2: System.out.println("Dienstag"); break;
    case 3: System.out.println("Mittwoch"); break;
    case 4: System.out.println("Donnerstag"); break;
    case 5: System.out.println("Freitag :)"); break;
    case 6: System.out.println("Samstag"); break;
    case 7: System.out.println("Sonntag"); break;
    default: System.out.println("Kein Wochentag.");
}
```

Hier Springen wir wenn die ``Variable`` *input* der ``Wert`` *1* hat, aus dem switch und führen die darunter liegenden *cases* nicht mehr aus.
Das klingt jedoch eher als ein *Fehler* als Absicht. Der Grund ist foglender. 

```java
switch (genre.toLowerCase()) {
    case "action":
        ausgabe = "Schauen wir einen Actionfilm!";
        break;
    case "komödie": // Achtung! Was passiert hier?
    case "lustig":
        ausgabe = "Lass uns eine Komödie sehen!";
        break;
}
```

Hier wird wenn komödie eingegeben wird der code daneben ausgeführt. Dieser ist jedoch zufällig leer. Ohne *break* führen wir den nächsten *case* aus, auch wenn das die ``Variable`` und der ``Wert`` nicht zusammenpassen. Wir führen also alles aus bis wir ein weiteres *break* sehen. Das passiet hier im case *"lustig"*. Bevor es möglich war mit Beistrich die Werte zusammenzufassen, war das die Umsetzung dieser Logik.
Besser also foglendes:
```java
switch (genre.toLowerCase()) {
    case "action":
        ausgabe = "Schauen wir einen Actionfilm!";
        break;
    case "lustig", "komödie":
        ausgabe = "Lass uns eine Komödie sehen!";
        break;
}
```

Zusätzlich konnte früher ohne *break* eine Art *Load from Save* umgesetzt werden.
```java
switch (status) {
    case 1: System.out.println("Loading first Asset...");
    case 2: System.out.println("Loading second Asset...");
    case 3: System.out.println("Caluclating distance... finished!");
}
```
Wenn nun ``status = 1`` ist, werden alle 3 *cases* ausgegeben. Wenn ``status = 2`` nur case *2* und case *3*, usw.