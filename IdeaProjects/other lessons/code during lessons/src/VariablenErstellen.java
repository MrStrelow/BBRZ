public class VariablenErstellen {
    public static void main(String[] args) {
        // Variablen sind Platzhalter für Wertes eines bestimmten Typs.
        // Mögliche Werte einer Variable vom Typ String (eine Zeichenkette) sind
        // z.B. "qwer", "greetings", oder "jeder andere Satz der mir einfällt".
        // Wir kennzeichnen Zeichenketten mit "", damit der Computer es von Symbolen der Programmiersprache unterscheiden kann.
        // Wir wollen also Zeichenketten verwenden um "Befehle" in der Programmiersprache einzugeben.
        // Aber auch Werte für Variablen, welche Zeichenketten sind, eingeben. Wir kennzeichnen eben das mit "".

        // #################################### Variable deklarieren (KEINEN Wert zuweisen) ####################################
        // Wir sagen dem Computer "erstelle mir eine Variable welche mit Zeichenketten umgehen soll".
        // Wir sagen aber nicht, welchen Wert diese haben soll.
        // Wir legen also im "Speicher" einen Platz welcher für unsere Variable reserviert wird, "belegen" aber noch nichts.
        // (Wir kaufen eine Leinwand, aber haben uns noch nicht entschieden, was wir malen wollen.)

        // Wir schreiben also zuerst den TYP der Variable und danach einen NAMEN mit den wir die Variable in zukunft "ansprechen" wollen.
        String firstString;

        // #################################### Variable definieren/initialisieren (EINEN Wert zuweisen) ####################################
        // Wir sagen dem Computer "erstelle mir eine Variable welche mit Zeichenketten umgehen soll UND schreibe den Wert 'Hallo' hinein".
        // (Wir kaufen eine Leinwand, und malen schon im Geschäft unser Bild.)

        // Aus allen möglichen Werten, der ein String annehmen kann, ist dieser Variable die Zeichenkette "Hallo" zugewiesen worden.
        // Wir schreiben also zuerst den TYP der Variable und danach einen NAMEN mit den wir die Variable in zukunft "ansprechen" wollen
        // und gleichzeitig verwenden wir das "=" (ZUWEISUNGSOPERATOR) um unserer Variable eine Zeichenkette "Hallo" zuzuweisen.
        // Was Operatoren sind besprechen wir später genauer.
        // Wir können uns auch einen Pfeil nach links denken "<-", wenn wir das "=" bei einer Zuweisung sehen.
        // Die Zeichenkette "hallo" wird von der rechten Seite, nach links in die Variable myString "reingeschoben".
        String myString = "Hallo";

        // Wir können also mit dem Muster <Typ> <Name> = <Wert> eine Variable belegen. Das Muster ist jedoch allgemeiner als hier dargestellt.
        // Eigentlich müsste es <Typ> <Name> = <"alles was einen Wert mit gleichem Typ wie <Typ> erzeugt kann hier stehen"> heißen.
        // Das klingt sehr allgemein, und ist es auch.
        String otherString = myString;

        // Der Wert ist abhängig von der Variable myString. Bedeutet, was auch immer in myString steht, steht auch in otherString.
        // Das funktioniert, da myString den Typ String hat. Dadurch ist hier "etwas erzeugt worden mit Typ String".
        // Mehr zu "alles was einen Wert mit gleichem Typ wie <Typ> erzeugt kann hier stehen", wenn wir uns über Operatoren unterhalten.

        // #################################### Typen von Variablen ####################################
        // Wenn wir den <Typ>...
        //  - klein schrieben → primitive Datentypen (keine Klassen),
        //  - groß schrieben → (sind Klassen).
        // Klassen sind die "Grundbausteine" in JAVA und jeder objektorientierten Sprache und erlauben uns
        // aus Klassen, Objekte zu erzeugen. Das erlaubt uns dann "elegantere" Programme zu schreiben.

        // Was sind nun die Typen von Variablen?
        // - Zeichen(ketten):
            // String (oder für mehr funktionalität, StringBuilder)
            // char oder Character (16 Bits - ein Symbol einer Zeichenkette kann nur gespeichert werden. Diese ist im Hintergrund eine ganze Zahl)
        // - Ganze Zahlen:
            // - long oder Long     (ganze Zahl -> [-2^32, +2^32],  keine Kommazahlen)
            // - int oder Integer   (ganze Zahl -> [-2^16, +2^16],  keine Kommazahlen)
            // - short oder Short   (ganze Zahl -> [-2^8,   +2^8],  keine Kommazahlen)
            // - byte oder Byte     (ganze Zahl -> [-2^4,   +2^4],  keine Kommazahlen)
        // - Kommazahlen:
            // - float oder Float   (Kommazahl, weniger genau wie Double)
            // - double oder Double (Kommazahl)
        // - logische Werte:
            // - boolean oder Boolean (hat 0 oder 1 als Wert)

        // Hier definieren wir unsere erste Variable vom Typ Integer (myInteger) sowie die Variable vom primitiven Typ (myPrimitiveInteger).
        Integer myInteger = 8;
        int myPrimitiveInteger = 8;

        // JAVA erlaubt und unabhängig, ob eine Variable primitive ist oder nicht, diese mit dem Zuweisungsoperator "=" gleich zusetzten.
        // An sich ist JAVA hier streng. wir können nicht eine Variable vom Typ String und eine vom Typ StringBuilder gleich setzten,
        // das diese nicht den exakt gleichen Tpy haben.
        // Zudem sehen wir hier auch folgendes.
        // Wenn eine Variable einmal definiert bzw. deklariert wird, dann muss diese nur mehr mit dem <Namen> angesprochen werden.
        // int myPrimitiveInteger = myInteger; würde hier nicht funktionieren, da bereits eine Variable definiert wurde, welche myPrimitiveInteger heitß.
        myPrimitiveInteger = myInteger;
        myInteger = myPrimitiveInteger;

        // Wir werden zuerst einfachheitshalber nur die "Klassen" als Typen verwenden. Also keine primitiven Datentypen.
        // Der Vorteil von Variablen, welche einen primitiven Typen haben ist, sie sind schlänker und verbrauchen "weniger" Speicher.
        // Auch ist der Ort an dem sie sich befinden (Stack) schneller für den Computer verwendbar, als der Ort wo Objekte liegen (Heap).
        // Der Nachteil, primitive Datentypen erlauben einen weniger "Funktionalität".

        // Das sehen wir hier, wenn wir eine Zahl in einen String umwandeln wollen.
        // Wir werden umwandlungen von Variablen in einem eigenen JAVA file behandeln.
        // Wichtig für uns jetzt ist, Variablen, welche eine Klasse als Typ haben, haben Methoden
        // und Variablen welche einen primitiven Datentyp haben, nicht.
        // Methoden sind wie Operatoren, welche Werte/Variablen entgegennehmen, diese umwandeln, und einen neuen Wert zurückgeben.
        // Das sehen wir hier, wenn wir aus unserem Integer myInteger mit der Methode toString() eine Zahl nehmen und diese in einen String umwandeln.
        // Methoden werden von Variablen (auch Objekten genannt, wenn der Typ eine Klasse ist) mit dem "." Operator aufgerufen.
        String yetAnotherString = myInteger.toString();

        // Wichtig, das Ergebnis der Methode ist ein Wert, welcher wie auch bei Operatoren, einen Typ hat.
        // Hier kommt also eine Zahl in die Methode rein und ein String raus.
        // Dieses Ergebnis kann wie jeder andere String verwendet werden.
        // Deshalb ist auch eine Zuweisung zu einer Variable mit dem Zuweisungsoperator = möglich!

        // Wir können nun yetAnotherString weiter verwenden. Diesen z.B. ausgeben.
        System.out.println(yetAnotherString);

        // Oder nochmals bevor wir diesen verwenden weiter manipulieren. Mit der Methode toUpperCase();
        // Wir sehen auch, dass wir das Ergebnis der Methode toUpperCase() direkt verwenden können und dieses nicht
        // in einer Variable speichern müssen. Der Nachteil, falls wir später im Programm das Ergebnis von yetAnotherString.toUpperCase()
        // verwenden wollen ist dieses verloren. Wir müssen also nochmals yetAnotherString.toUpperCase() aufrufen.
        // Wenn wir dieses gleich in eine Variable speichern, muss nicht nochmal der Computer den Aufwand betreiben und dieses neu ausrechnen.
        // Hier hat es keinen Effekt, aber denken Sie an einen Methodenaufruf, welcher 3 Stunden benötigt, um ein Ergebnis zu erzeugen.
        // Ein solches Ergebnis sollte auf jeden Fall einer Variable zugewiesen werden.
        System.out.println(yetAnotherString.toUpperCase());

        // Gehen wir nun die verschiedenen Variablen Typen durch. Beginnen wir mit Zeichenketten und einzelnen Zeichen.

        // #################################### Zeichenketten ####################################:

        // ############ Character ############

        // Betrachten wir aber zunächst einen Typ welcher nur eine Zuweisung zu einer Variable von einem Symbol erlaubt - Character.
        // Dieser Typ ist der "komplizierteste", denn dieser benötigt ein wenig Vorwissen wie der Computer Symbole darstellt.
        // Fast immer ist dies jedoch nicht notwendig zu verstehen, wenn wir in Zukunft Programme schreiben.
        // Trotzdem, ist es nicht schlecht einmal darüber nachgedacht zu haben, denn abstrakte Strukturen zu erkennen und zu verstehen,
        // hilft sehr im alltag des Programmierer darseins. Besonders wenn wir fehlerhaftes Verhalten programmieren und den Fehler suchen müssen.
        // Seht diesen Abschnitt also mehr als eine Denkaufgabe, als wie praktisches direkt täglich anwendbares Wissen.
        // Wir reden von Symbolen wie 'a', 'ø' oder '҈', wieso beginnen wir also mit einer Variable userInput,
        // welche zwar vom Typ Character ist, aber den Wert einer Zahl zugewiesen bekommt?
        Character userInputDecimalNumber = 97;
        Character userInputHexNumber = 0x61;
        Character userInputChar = 'a';

        System.out.println("'" + userInputChar + "' ist das gleiche wie '" + userInputDecimalNumber + "' und auch das gleich wie '" + userInputHexNumber + "'");

        // Da der Computer meist nur mit Zahlen umgehen kann, gibt es ein "Mapping" von Zahlen zu Symbolen.
        // Ein Beispiel dafür ist der Wert 97 ist dem Symbol 'A' zugewiesen. Diese Codes haben namen wie zum Beispiel
        // ASCII-Codes oder auch Uni-Codes. In Windows gibt es eine Zeichentabelle (bei englischen Betriebssystemen "Character Map")
        // welche es erlaubt diese Codes bzw. Tastenkürzel sich anzusehen.
        // Dazu Windows-Taste drücken und nach Zeichentabelle oder Character Map suchen.

        // ASCII-Codes:
            // - bis 0 bis 255 Zeichen (mit 7 Bit darstellbar) → diese sind mit Alt + <vierstelliger Code> anzusprechen.
            // - ø ist z.B. Alt + 0248. Es geht bis von 0032 bis 0255. Die ersten 32 Zahlen sind Symbole welche
            // keine grafische darstellung haben.
            // Das klingt komisch, aber es sind Symbole welche z.B. das Ende eines Strings in C/C++ signalisieren.
            // Das sind z.B.
                // - Alt + 0000 → (NUL): Null Symbol,
                // - Alt + 0001 → (SOH): Start einer Heading,
                // - Alt + 0002 → (STX): Start des Streams.
                // - Alt + 0003 → (ETX): Ende des Streams. (verwendet on manchen Netzwerkprotokollen)

        // Ein zeichen welches außerhalb der 256 ASCII-Zeichen ist, ist folgendes Symbol (Cyrillic Million Symbol).
        Character million = '҉';

        // Dieses hat den Unicode U+0489. Achtung! Diese Symbole sind als hexadezimale Zahlen angegeben.
        // Also 16 Ziffern statt 10! Wir stellen das mit 0-9 und weiters A-F dar.
        // Wie zuvor hat auch das Symbol 'a' den hexadezimalen Wert 0x61 und auch den Unicode U+0061.
        // Der ASCII-Code ist also dezimal und der Unicode hexadezimal.

        // Smileys haben auch einen Unicode. z.B. 🌲 hat den Unicode 0x1F332. ACHTUNG! hier ist ein 5. Hex-Bit dazugekommen!
        // Der Standardsatz von Unicode hat aber nur 4 Hex-Bit U+0000. Die Lösung dazu schauen wir uns in einem späteren JAVA programm an.
        // Für uns funktioniert vorerst wenn wir direkt das Symbol einfügen. Dazu drücke die Windowstaste und "Punkt".
        String tannenbaum = "🌲";
        System.out.println(tannenbaum);

        // Wir müssen uns zuerst mit dem hier zufrieden geben, wenn wir nicht "diesen Trick" verwenden wollen.
        Character basicSmiley = 0x263A;
        System.out.println(basicSmiley);

        // Wenn wir nun Operatoren verwenden von Zahlen wie + verwenden, können wir dann auch neue Symbole erzeugen?
        // Die Antwort ist ja, denn wir verwenden nur das Ergebnis des Operators, welches hier 195 ist.
        Character aPlusB = 97 + 98;
        Character AMitToupee = 195;

        System.out.println(aPlusB + " ist das gleiche Symbol wie " + AMitToupee);

        // Wenn wir nun die Zahlen zuerst in Variablen mit Typ Integer speichern funktioniert, das leider nicht mehr.
        // Wir müssen jetzt dem Computer explizit sagen, dass er aus den Variablen welche den Typ Integer haben, in einen Character umwandeln soll.
        Integer a = 97;
        Integer b = 98;
        Integer AMitToupeeInteger = a + b;

        // Diese umwandlung geschieht mittels "Type Casting". wir schreiben vor der Zuweisung in runden Klammern den gewünschten Typ der Variable.
        // Da wir noch die Reihenfolge definieren müssen, müssen wir sagen, "Bitte zuerst a+b rechnen und danach umwandeln".
        // Das geschieht mit dem Klammern von (a + b).
        Character aPlusBAlsInteger = (char) (a + b);

        // Dazu ist JAVA nicht klar, ob es eine sinnvolle Umwandlung von Integer zu Character geben kann.
        // Der Grund ist, dass Characters 16 Bit (4 Hex-Bits), aber Integer 32 Bit zum Speichern zur Verfügung haben.
        // Wir können also nicht eine Zahl welche größer als 2^16 = 65535 (und in binär 1111 1111 1111 1111) ist in einem Character speichern.
        // Dazu würden wir ein 17. Bit benötigen, denn 1111 1111 1111 1111 is voll (also ein Bit dazu und 1 0000 0000 0000 0000).
        Character geht = 65535;
//        Character gehtNicht = 65536;

        // Versuchen wir deshalb den Typ Short zu verwenden, welcher 16 bit hat und nicht Integer welcher 32 Bit hat.
        // Aber leider geht das nicht, da Short eine signed Variable ist. Bedeutet wir haben positive und negative Zahlen abzubilden.
        // Deshalb haben wir 32 767 positve Zahlen (0|111 1111 1111 1111) und negative Zahlen (1|111 1111 1111 1111)
        // Passt also leider auch nicht zusammen.

        // Wir verwenden hier einen Trick, welcher eine Umwandlung erzwingt. Diese ist das Ergebniss eines Operators wird in JAVA
        // anders handgehabt als eine Variable welche diesen Wert hat. Deshalb suchen wir eine Operation mit einer Zahl welche nichts
        // am Ergebnis ändert. Hier die +0 oder *1.
        Short AMitToupeeShort =  AMitToupeeInteger.shortValue();
        Character AMitToupeeCharacter = (char) (AMitToupeeShort + 0);
        AMitToupeeCharacter = (char) (AMitToupeeInteger * 1);

        System.out.println(aPlusBAlsInteger + " ist das gleiche Symbol wie " + AMitToupeeCharacter);

        // Wir haben aber bis jetzt nur uns mit den dahinterliegenden Mechanismen beschäftigt.
        // Wir wollen und müssen natürlich nicht so programmieren!
        // Um eine Variablen vom Typ character zuweisen zu können verwenden wir '' ähnlich wie beim String "".
        Character aSehrVielAngenehmer = 'a';
        Character bSehrVielAngenehmer = 'b';

        // Was passiert aber wenn wir diese Variablen mit dem "+" Operator verknüpfen wollen.
//        Character aPlusBSehrVielAngenehmer = aSehrVielAngenehmer + bSehrVielAngenehmer;

        // Das ist leider eine Falle. Wir können leider auch nicht 2 Symbole miteinander verknüpfen, denn
        // eine Variable vom Typ Character kann nur ein Symobl halten!

        // Wenn wir es aber als Integer speichern können wir die beiden Symbole zusammenzählen, denn JAVA interpretiert
        // Variablen vom Typ Character als einfache Zahlen, mit denen wir natürlich rechnen können.
        Integer aPlusBSehrVielAngenehmer = aSehrVielAngenehmer + bSehrVielAngenehmer;
        System.out.println("Immer noch " + (char) (aPlusBSehrVielAngenehmer + 0));

        // ############ String ############
        // String besitzt keinen primitiven Datentyp string. Denn es ist eine Verallgemeinerung von einem Symbol zu mehrere Symbole.
        // Wir können also einen String als ein "aneinanderkleben" von Variablen des Typs Character verstehen.
        // Da wir hier "beschützt" von der darunter liegenden Darstellung sind, haben wir hier nur die Möglichkeit Text einzugeben.

        // Wir haben also die gewohnte Darstellung der Variablen definition und zusätzlich mit einem Operator "+" welcher eine "concatenation" beschreibt.
        // Das bedeutet aneinanderheften.
        String myNewString = "hallo " + " " + "du";
        System.out.println(myNewString);

        // Ein Variablentyp welcher mehr Funktionalität bietet wie der String ist der StringBuilder.
        // Er erlaubt uns viele Methoden zu verwenden welche uns es leichter macht mit Zeichenkettern umzugehen.
        // Dazu aber mehr im nächsten JAVA programm.
        // Hier jedoch ein kleiner, nicht sinnvoller, Vorgeschmack, mit der Methode reverse().
        System.out.println(new StringBuilder("hallo").append(" ").append("du").reverse());

        // StringBuilder ist gut, wenn ein String viel manipuliert wird, und String, wenn dieser sich nicht oft ändert.

        // #################################### Ganze Zahlen ####################################
        // Ganze Zahlen (keine Kommazahl, welche aber negativ und positiv sein kann) können wir mittels mehreren Typen darstellen. Der Unterschied dazu ist nur die maximale Größe der
        // darzustellenden Zahl.

        // ############ Byte ############
        // Wir haben die kleinste mit dem Typ Byte - 8 Bit - welche hier eine sogenannte "signed Variable" ist. Wir berücksichtigen also das Vorzeichen.
        // Bedeutet wir haben negative und positive Zahlen welche wir mit 8 Bit darstellen können (0|000 0000).
        // Es gibt also 2^8 = 256 mögliche Darstellungen von Zahlen.
            // - 127 positive
            // - 128 negative
            // und eine 0.

        Byte kleinsteGanzeZahlPositive = 127;
        Byte kleinsteGanzeZahlNegative = -128;
        Byte kleinsteGanzeZahlNull = 0;

        // Wir können hier für diese maximalen und minimalen Werte den Computer fragen.
        // Dazu müssen wir uns ein zuerst verwirrendes Konzept anschauen.
        // Wir haben gesehen, dass wenn wir mit dem "." Operator methoden von variablen aufrufen können.
        // Das geht auch für die Typen selbst. Wir können also einen Typ schreiben und dort mit "." dessen Methoden anschauen.
        // Weiters sind dort auch Variablen selbst versteckt! Ein Beispiel dafür ist Folgendes.

        kleinsteGanzeZahlPositive = Byte.MAX_VALUE;
        kleinsteGanzeZahlNegative = Byte.MIN_VALUE;
        Integer bitsOfByte = Byte.SIZE;

        System.out.println(kleinsteGanzeZahlPositive + " " + kleinsteGanzeZahlNegative + " " + bitsOfByte);

        // ############ Short ############
        // Die nächste ist eine Variable dem Typ Short - 16 Bit - welche hier eine sogenannte "signed Variable" ist. Wir berücksichtigen also das Vorzeichen.
        // Bedeutet wir haben negative und positive Zahlen welche wir mit 16 Bit darstellen können (0|000 0000 0000 0000).
        // Es gibt also 2^16 = 65 536 mögliche Darstellungen von Zahlen.
        // - 32767 positive
        // - 32768 negative
        // und eine 0.

        Short kleineGanzeZahlPositive = 32767;
        Short kleineGanzeZahlNegative = -32768;
        Short kleineGanzeZahlNull = 0;

        // Wir können hier für diese maximalen und minimalen Werte den Computer fragen.
        // Dazu müssen wir uns ein zuerst verwirrendes Konzept anschauen.
        // Wir haben gesehen, dass wenn wir mit dem "." Operator methoden von variablen aufrufen können.
        // Das geht auch für die Typen selbst. Wir können also einen Typ schreiben und dort mit "." dessen Methoden anschauen.
        // Weiters sind dort auch Variablen selbst versteckt! Ein Beispiel dafür ist Folgendes.

        kleineGanzeZahlPositive = Short.MAX_VALUE;
        kleineGanzeZahlNegative = Short.MIN_VALUE;
        Integer bitsOfShort = Short.SIZE;

        System.out.println(kleineGanzeZahlPositive + " " + kleineGanzeZahlNegative + " " + bitsOfShort);

        // ############ Integer ############
        // Die nächste ist eine Variable dem Typ Integer - 32 Bit - welche hier eine sogenannte "signed Variable" ist. Wir berücksichtigen also das Vorzeichen.
        // Bedeutet wir haben negative und positive Zahlen welche wir mit 32 Bit darstellen können (0|000 0000 0000 0000 0000 0000 0000 0000).
        // Es gibt also 2^32 = 4 294 967 296 mögliche Darstellungen von Zahlen.
        // - 2 147 483 647 positive
        // - 2 147 483 648 negative
        // und eine 0.

        Integer ganzeZahlPositive = 2147483647;
        Integer ganzeZahlNegative = -2147483648;
        Integer ganzeZahlNull = 0;

        // Wir können hier für diese maximalen und minimalen Werte den Computer fragen.
        // Dazu müssen wir uns ein zuerst verwirrendes Konzept anschauen.
        // Wir haben gesehen, dass wenn wir mit dem "." Operator methoden von variablen aufrufen können.
        // Das geht auch für die Typen selbst. Wir können also einen Typ schreiben und dort mit "." dessen Methoden anschauen.
        // Weiters sind dort auch Variablen selbst versteckt! Ein Beispiel dafür ist Folgendes.

        ganzeZahlPositive = Integer.MAX_VALUE;
        ganzeZahlNegative = Integer.MIN_VALUE;
        Integer bitsOfInteger = Integer.SIZE;

        System.out.println(ganzeZahlPositive + " " + ganzeZahlNegative + " " + bitsOfInteger);

        // ############ Long ############
        // Die nächste ist eine Variable dem Typ Long - 64 Bit - welche hier eine sogenannte "signed Variable" ist. Wir berücksichtigen also das Vorzeichen.
        // Bedeutet wir haben negative und positive Zahlen welche wir mit 32 Bit darstellen können (0|000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000).
        // Es gibt also 2^64 = 18 446 744 073 709 551 616 mögliche Darstellungen von Zahlen.
        // - 9 223 372 036 854 775 807 positive
        // - 9 223 372 036 854 775 808 negative
        // und eine 0.

        // Wenn wir Zahlen in die Entwicklungsumgebung direkt schreiben, sind dies Integers (32 bit).
        // Deshalb müssen wir, wenn wir einen Long definieren wollen, ein "L" am Ende der Zahl hinschreiben,
        // um dem Computer explizit (direkt) zu sagen, dass er 64 bit verwenden soll.

        Long grosseGanzeZahlPositive = 9223372036854775807L;
        Long grosseGanzeZahlNegative = -9223372036854775808L;
        Integer grosseGanzeZahlNull = 0;

        // Wir können hier für diese maximalen und minimalen Werte den Computer fragen.
        // Dazu müssen wir uns ein zuerst verwirrendes Konzept anschauen.
        // Wir haben gesehen, dass wenn wir mit dem "." Operator methoden von variablen aufrufen können.
        // Das geht auch für die Typen selbst. Wir können also einen Typ schreiben und dort mit "." dessen Methoden anschauen.
        // Weiters sind dort auch Variablen selbst versteckt! Ein Beispiel dafür ist Folgendes.

        grosseGanzeZahlPositive = Long.MAX_VALUE;
        grosseGanzeZahlNegative = Long.MIN_VALUE;
        Integer bitsOflong = Long.SIZE;

        System.out.println(grosseGanzeZahlPositive + " " + grosseGanzeZahlNegative + " " + bitsOflong);

        // #################################### Komma Zahlen ####################################
        // Komma Zahlen unterscheiden sich von ganzen Zahlen, indem wir Nachkommastellen haben.
        // Wir könnten einfach sagen wir nehmen 2 Integer, einer für vor dem Komma und einen für die Zahl nach dem Komma.
        // Es gibt aber eine kompaktere Variante, welche sich Fließkommazahl nennt.
        // Hier wird bestimmt, wie viel Bits wir für Vor- und Nachkommastelle brauchen.
        // haben also keine fixe große Vor- und Nachkommastelle, sondern eine die "fließen" kann.

        // ############ Float ############
        // Für die Darstellung sind 32 bit zur Verfügung.
        // Da wir uns nicht direkt mit der Darstellung auseinandersetzten müssen, sollten wir uns aber eines merken.
        // Wenn wir viel Speicher für die Vorkommastelle brauchen, haben wir weniger Platz für die Nachkommastelle.
        // Auch wenn wir Operatoren verwenden, kann es dadurch zu Ungenauigkeiten kommen.

        // Zuerst schauen wir uns aber an wie wir eine Variable mit Typ float definieren.
        // Da wir standard mäßig einen Wert mit Typ Double erzeugen, wenn wir eine Kommazahl schreiben, müssen wir dem Computer
        // mitteilen, dass es sich um einen Float handelt. Wir tun das mithilfe des "F" oder "f" am Ende der Kommazahl.
        Float myFirstFloat = 0.25F;
        System.out.println(myFirstFloat);

        // Durch die Art wie wir Fließkommazahlen darstellen, ist es uns möglich scheinbar größere Zahlen als mit Long darzustellen.
        Float myStrngeAndBigFloat = 182255459184527355549958849981255210445.0F;
//        Long tooLongforLong = 182255459184527355549958849981255210445L;

        // Aber das ist nur scheinbar so. Wir schneiden nämlich einige Zahlen weg, indem der Computer es so genau wie möglich approximiert.
        // 1.8225546E38 bedeutet wir nehmen die Zahl 1.8225546 und multiplizieren es mit 10^38. 10^38 bedeutet eine Zahl mit 38 Nullen.
        // Also lässt sich 18225546 sehr genau darstellen und die restlichen 31 Stellen werden weggelassen.
        System.out.println(myStrngeAndBigFloat);

        // ############ Double ############
        // Genau das gleiche kann von Double behauptet werden, außer dass es doppelt so viele bits hat. 64 statt 32.
        // Da wir ca 7 Nachkommastellen mit Float und ca 16 mit Double wird Double standardmäßig verwendet, da es sehr schnell
        // passieren kann, dass wir mehr wie 6 Nachkommastellen brauchen. Grund dafür sind Rundungsfehler bei Operatoren.

        Double myFirstDouble = 0.25;
        System.out.println(myFirstDouble);

        // Durch die Art wie wir Fließkommazahlen darstellen, ist es uns möglich scheinbar größere Zahlen als mit Long darzustellen.
        Double myStrngeAndBigDouble = 18225545918452735554995884998125521044555555555555555555544444444444481521515.0;
        System.out.println(myStrngeAndBigDouble);

        // #################################### Boolesche Werte ####################################
        // Jetzt zu einem ganz andern Typ von Variablen. Boolesche Werte sind 2 Wertige Variablen wie "Falsch" und "Wahr",
        // 0 oder 1, oder auch 24155 und 41. Wir brauchen nur 2 bestimmte voneinander unterscheidbare Werte, wo ein Wert als "Wahr"
        // und ein andere als "Falsch" interpretiert wird.
        // Es macht aber durchaus Sinn hier 0 und 1 im Kopf zu behalten.

        // Wir legen wir nun eine Boolesche Variable an.
        Boolean myFirstBoolean = true;
        myFirstBoolean = false;

        // Hier können wir nicht mit 0 oder 1 direkt arbeiten wie bei den Characters. Müssen also true und false verwenden.
        // Boolesche Werte für das Programmieren selbst eine der wichtigsten Werte, da wir mithilfe von logischen Operatoren
        // bzw. Vergleichsoperatoren den Ablauf eines Programmes steuern.
        // Dazu aber mehr im JAVA Programm zu Operatoren.
    }
}