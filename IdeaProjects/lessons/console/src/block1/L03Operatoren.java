package block1;

public class L03Operatoren {
    public static void main(String[] args) {
        // Operatoren verknüpfen Variablen bzw. Werte miteinander und erzeugen basierend auf denen einen neuen Wert.
        // Der folgende "+" Operator, welcher die Bedeutung "Addition" hat, verknüpft die Zahlen 35 und 17 und erzeugt den neuen Wert 52.
        System.out.println( 35 + 17 );

        // Die Bedeutung eines Operators ist abhängig von Typ der Variablen bzw. Werte welche in den Operator "hineingegeben" werden.
        // Das sehen wir bei dem Ausdruck "35" + "17". Hier hat der Operator "+" nicht die Bedeutung "Addition", sondern "Concatenation".
        // Wir fügen also die Zeichenkette "35" mit der Zeichenkette "17" zusammen, was "3517" ergibt.
        System.out.println( "35" + "17" );

        // Das gleiche Verhalten gilt für Variablen.
        Integer firstInt = 35;
        Integer secondInt = 17;
        System.out.println(firstInt + secondInt);

        String firstString = "35";
        String secondString = "17";
        System.out.println(firstString + secondString);

        // Im Allgemeinen kann angenommen werden, wenn ein "Ausdruck", was auch immer er ist, einen Wert mit einem Typ erzeugt,
        // kann dieses Ergebnis mit Operatoren weiter verknüpft werden.
        // Es kann also eine Kette gebildet werden.
        System.out.println(firstInt + secondInt + firstInt + secondInt);

        // Hier wird die Reihenfolge nicht beachtet das es bei dem Operator "+", interpretiert als "Addition", eine vordefinierte Reihenfolge gibt.
        // Diese ist, zuerst der am weitesten links stehende Ausdruck, dann der eins weiter rechts stehende Ausdruck. wird dem Operator übergeben und ein neues Ergebnis erzeugt.
        // Dieses Ergebnis wird mit dem ein weiter rechts stehenden verknüpft und ein Ergebnis erzeugt.
        // Wenn wir die Reihenfolge steuern wollen, muss dies mit einer Klammer gemacht werden.
        // Der nächste Ausdruck ist gleich dem vorherigen, jedoch wird hier die Reihenfolge direkt angegeben.
        System.out.println( ( (firstInt + secondInt) + firstInt ) +  secondInt );

        // Wir können nun die Reihenfolge ändern, indem wir die Klammern verschieben.
        // Das Ergebnis bleibt jedoch das gleiche, denn bei der Addition ist die Reihenfolge der Auswertung egal.
        System.out.println( (firstInt + secondInt) + (firstInt  +  secondInt) );

        // Für die andren arithmetischen Operatoren der Zahlen, "-", "*", "/" der Zahlen gelten die Regeln aus der Mathematik.

        //#################################### Arten von Operatoren ####################################
        // Unterschiedliche Bedeutungen von Operatoren, haben zur Folge, dass verschiedene Namen für diese existieren.
        // Diese unterschiedlichen Bedeutungen sind meistens aufgrund der Typen der Werte welche in eine Variable "reinfließen" bzw. "rausfließen"
        // Wir unterscheiden in folgende Operatoren:
        // - Operatoren welche den Typ erhalten:
        //      - string operatoren:
        //          - "+": concatenate bedeutet, füge Zeichen bzw. Zeichenketten zusammen.
        //      - arithmetische Operatoren:
        //          - "+", "-", "*", "/", bei Variablen welche Zahlen darstellen
        //      - logische (oder auch boolesche) Operatoren:
        //          - "!", "||", "&&", "^": das sind beispielsweise das logische nicht, logische und, logische oder, und exclusive oder.
        //      - bitweise Operatoren:
        //          - "|", "&", "^", "~", "<<", ">>", ">>>": bitweise operatoren nehmen die binäre Darstellung eine Zahl und verknüft diese bit pro bit. also 5 & 6 = 101 & 110 = [1&1 = 1, 0&1 = 0, 1&0=0] = 100 = 4
        // - Operatoren welche den Typ nicht erhalten:
        //      - Vergleichsoperatoren:
        //          - "==", "<", ">", "<=", ">=", "instanceof": hier ist "==" eine Frage.
        //              Ist der linke und der rechte Input in einer Beziehung? Wenn ja, dann gib "Wahr" zurück, wenn nein "Falsch".
        // - Zuweisungsoperatoren:
        //      - wir haben in JAVA nur einen und dieser ist das "=". Dieser weist den rechts stehenden Ausdruck der links
        //      stehenden Variable zu.
     // - gemischte Operatoren:
        //      - "+=", "-=", "*=", "/=": diese sind eine Kombination aus zuweisung und arithmetischen Oparatoren.
        //      - "++", "--": diese werden inkrement und dekrement Operatoren genannt und sind eine Kombination aus "x=x+1".
        // - selbst definierte Operatoren
        //      - das ist in JAVA nicht möglich (C++). Wir können aber Methoden erstellen, welche ein solches Verhalten abbilden.

        // Wir unterscheiden zudem in unäre, binäre und tertiäre Operatoren. Diese Kategorisierung gibt an, wie viele Inputs diese annehmen.
        // Achtung, damit ist nicht deren Verkettung gemeint, sondern wirklich ein Operator nimmt 1, 2 oder 3 Inputs an.
        // Beispiel für einen unären Operator ist:

        System.out.println(!true);
        // Beispiel für binäre Operatoren ist (hier sind sogar 2 binäre Operatoren mit einem neuen gemischten Operator zusammengefasst):
        System.out.println(firstInt *= 10);
        firstInt = firstInt * 10;

        // Hier ist eine Kombination aus beidem. Ein unärer Operator "nicht" mit Symbol "!" und der
        // binäre Oparator "logisches und" mit dem Symbol "&&".
        // Achtung! der Operator "&" bedeutet "bitweises und"!

        Boolean firstBoolean = false;
        Boolean ergebnis = !( firstBoolean && firstBoolean);


        // #################################### Zeichen(ketten) Operatoren ####################################
        // Das gewohnte "+".
        System.out.println( "hallo" + " " + "wir " + "verknüpfen" + " Strings");

        // Wir können hier auch Character mit Strings verknüpfen.
        System.out.println("Zeichenkette" + ' ' + "getrennt mit einem Character");

        // Ein weniger generischer Anwendungsfall ist, der wenn wir " und ' in einem Text darstellen wollen.
        System.out.println("'" + " das geht in dem wir die Symbole verdrehen " + '"');
        // Achtung" hier ist '"' ein Character wir können also nicht '"undnochmehr' schreiben, da dies eine Zeichenkette wäre.


        // #################################### arithmetische Operatoren ####################################
        // Typ des Inputs:  [Zahl, Zahl]
        // Typ des Outputs: [Zahl]
        // arithmetisch bedeutet hier "Grundlegende Operationen auf Zahlen bezogen". Streng genommen sind auch die boolschen Operatoren artimetisch,
        // aber wir verwenden den Begriff um auf plus, minus, mal und dividiert in den Zahlen zu verweisen.
        // Wichtig hier ist, dass die Operatoren überladen werden können. Bedeutet also ein Operator wie "/" kann mehrere Bedeutungen haben.
        // Schauen wir uns dazu folgendes an
        Double meinErsterDouble = 2.0;
        Integer meinErsteInteger = 2;
        Integer meinZweiterInteger = 5;

        // Wir erwarten hier die Zahl 2.5, bekommen aber 2.
        System.out.println( meinZweiterInteger / meinErsteInteger);

        // Was wir meinen ist folgendes.
        System.out.println( meinZweiterInteger / meinErsterDouble );

        // Wir haben als Input 2 Integer und bekommen einen Integer zurück. Wir haben also einen Operator der dividiert,
        // aber ohne Kommadarstellung. Da Operatoren nur einen Wert zurückgeben können, ist dies der Quotient (Dividend / Divisor = Quotient + Rest).
        System.out.println( 5 / 2 );

        // Den Rest (Dividend / Divisor = Quotient + Rest) können wir mit einem eigenen Operator, den Modulo Operator, bekommen.
        System.out.println( 5 % 2 );

        // Um klarzumachen, dass wir eine "fließkomma Division" haben wollen, müssen wir dem Operator einen anderen Typ als Input geben.
        // Wir können nicht anders mit Operatoren "kommunizieren", deshalb ist das der einzige Weg.
        // Wenn wir eines der Inputs eine Kommazahl ist, dann versteht JAVA dies als "Quotient=2.5"
        System.out.println( 5 / 2.);  // double
        System.out.println( 5 / 2.0); // double
        System.out.println( 5 / 2D);  // double
        System.out.println( 5 / 2d);  // double
        System.out.println( 5 / 2F);  // float
        System.out.println( 5 / 2f);  // float

        // Ein übersichtlicherer Weg, Operatoren darzustellen ist durch Methoden. Hier ist die divide Exact Methode verwendet worden.
        // Wir haben dadurch leider einen wenig kompakte schreibweise, jedoch ist hier klar welche Inputs und Outputs erzeugt werden.
        System.out.println( Math.divideExact(5, 2) );

        // #################################### logische Operatoren ####################################
        // Typ des Inputs:  [Boolean, Boolean]
        // Typ des Outputs: [Boolean]
        // Logische Operatoren verknüpfen Variablen vom Typ boolean. Also Wahrheitswerte. Wir verwenden solche Ausdrücke
        // um den Ablauf des Programms zu steuern.
        // Solche Aussagen sind "Wenn i kleiner als 6 und die Eingabe vom User eine Stadt in Europa ist, dann brich das Programm ab".
        // Mehr dazu bei Verzweigungen und Schleifen.
        // Zuerst wollen wir aber solche logischen Aussagen mithilfe von Operatoren erstellen.
        // Diese sind:
        // - ! (nicht):
        //      - negiert eine Aussage -> z.B. der Wert wahr wird zu falsch mit !wahr
        //      - wenn wir eine kompliziertere Aussage negieren wollen, müssen wir eine Klammer setzen: !(a && b)
        // - && (und):
        //      - nur wenn beide input Variablen des Operators wahr sind, dann ist der output wahr.
        //      Wir haben hier die Logik im Kopf, dass jede Variable ein Puzzlestein ist, den ich alle brauche um ans Ziel zu kommen.
        //      - wir modellieren damit eine Kette von Aussagen, welche alle eintreten müssen. z.B.
        //          der user muss berechtigt && aktiv && Ausweis ist hinterlegt && alter > 18
        // - || (oder):
        //      - wenn eine der input Variablen des Operators wahr ist, dann ist der output wahr.
        //      Wir haben hier die Logik im Kopf, dass jede Variable uns schon direkt ans Ziel bringt, wir aber mehrere Möglichkeiten haben um dort hinzukommen.
        //      - wir modellieren damit eine Kette von Aussagen, wo nur eine eintreten muss. z.B.
        //          der user kommt im Spiel weiter, wenn dieser genug Punkte || genug Zeit || genug Geld verwendet hat

        Boolean isOldEnough = true;
        Boolean isCitizen = true;

        Boolean eligibility = isOldEnough && isCitizen;
        System.out.println(eligibility);

        // Hier ein Beispiel mit einem ||
        Boolean bedingung = true;
        Boolean nochEineBedingung = false;
        Boolean undNochEineBedingung = true;

        Boolean result = bedingung || nochEineBedingung || undNochEineBedingung;
        result = bedingung || (nochEineBedingung || undNochEineBedingung);
        result = (bedingung || nochEineBedingung) || undNochEineBedingung;

        System.out.println(result);

        // #################################### bitweise Operatoren ####################################
        // Typ des Inputs:  [Boolean, Boolean]
        // Typ des Outputs: [Boolean]
        // Aber der Operator nimmt eine Zahl, und vergleicht die binäre Darstellung dieser, Bit für Bit.

        Integer bitwise = 6 & 5;
        // 6 ist in der binären Darstellung: 110
        // 5 ist in der binären Darstellung: 101
        // Wir vergleichen das erste Bit der 6 von links gelesen, mit dem dem ersten der 5.
        // Also 1 UND 1 = true  UND true  = true  = 1.
        // Danach das 2.
        // Also 1 UND 0 = true  UND false = false = 0.
        // Danach das 3.
        // Also 0 UND 1 = false UND true  = false = 0.
        // Wenn wir nun die 3 Ergebnisse als binäre Zahl interpretieren, ist diese 100 welche 4 ist.
        // Es sollte also "Bitwise: 4" ausgegeben werden
        System.out.println("Bitwise: " + bitwise);

        // hier gibt es auch ODER | als bitweisen Operator sowie das exclusive ODER ^ (dieses ist nur wahr, wenn die inputs verschieden sind).

        // Übung: stelle deine ITN-Nummer binär dar und verknüpfe diese mit |, & und ^ einer ITN nummer einer anderen Person.
        // Rechne diese Zahl dann in eine Dezimalzahl wieder um.

        // #################################### Vergleichsoperatoren ####################################
        // Typ des Inputs:  [X, Y]
        // Typ des Outputs: [Boolean]
        // Wir sehen, ein unbekannter Typ X, wird mit einem anderen Typ Y verglichen (input kann auch vom selben Typ sein).
        // Danach ist aber das Ergebnis IMMER vom Typ Boolean!
        // Wir können also Vergleichsoperatoren verwenden, um dessen Ergebnis mit logischen Operatoren weiter zu verknüpfen.
        // Konzeptionell, stellen bei Vergleichsoperatoren immer eine ja/nein-Frage. "Ist die 8 größer wie 7?" -> "ja".

        // Schauen wir uns zuerst "==" an.
        // ACHTUNG! nicht mit dem Zuweisungsoperator "=" verwechseln!
        // Wir stellen bei "==" uns die Frage "ist 7 dasselbe wie 8?"
        // Auch "!=" ist möglich. Hier ist die Frage "ist 7 nicht das dasselbe wie 8?"
        // Wir werden später bei komplexeren Datentypen (Objekte) sehen, dass wir mit == wirklich das SELBE meinen und nicht das GLEICHE.
        Integer a = 10;
        Integer b = 10;
        Integer c = 20;

        System.out.println("a == b: " + (a == b) );
        System.out.println("a == c: " + (a == c) );
        System.out.println("a != c: " + !(a == c) );
        System.out.println("a != c: " + (a != c) );

        String str1 = "hello";
        String str2 = "hello";
        // hier greifen wir ein wenig vor... aber damit wir uns hier was komischen anschauen können
        String str3 = new String("hello");

        System.out.println("str1 == str2: " + (str1 == str2));
        System.out.println("str1 das SELBE wie str3: " + (str1 == str3)); // ?

        // Wir sehen, wenn wir das Gleiche abfragen wollen, also interessiert an den Eigenschaften sind,
        // z.B. "steht der gleiche text in 2 Strings"? dann müssen wir mit <nameVonTyp1>.equals(<nameVonTyp2>); schreiben.
        // Das geht nur, wenn die verwendete Variable auch ein Objekt ist. also nicht bei z.B. boolean vs. Boolean oder int vs. Integer.
        // Wir werden das aber näher behandeln, wenn wir Variablen umwandeln.
        System.out.println("str1 das GLEICHE wie str3: " + str1.equals(str3));

        // Nun schauen wir uns die angesprochene Verbindung mit logischen Operatoren (und auch arithmetischen) an.
        // Alles ein Puzzle was wir zusammenstecken müssen. Die Teile sind die Typen der Operatoren.
        // Wichtig ist, wenn ein Operator einen booleschen Wert (wahr oder falsch) erzeugt, können wir diesen weiter
        // mit logischen Operatoren verknüpfen. Das sehen wir in folgendem Beispiel.

        String correctUsername = "admin";
        String correctPassword = "password123";
        Boolean active = true;
        Integer userMessage = 248;
        Integer saltForHash = 145;
        Boolean ausweisHinterlegt = true;
        Integer alter = 19;

        String username = correctUsername; // Ändere diesen Text auf "TODO CHANGE THIS";
        String password = correctPassword; // Ändere diesen Text auf "TODO CHANGE THIS";

        result =
                username.equals(correctUsername + "das ist ein gehackter teil des textes") &&
                password.equals(correctPassword) &&
                active &&
                (userMessage & saltForHash) % 2 == 0 &&
                ausweisHinterlegt &&
                alter > 18;

        System.out.println(result);

        // Ähnlich dazu ist kleiner "5 < 6", größer "8 > 8", sowie die kleiner oder gleich "<=" bzw. größer oder gleich ">=" Operatoren.
        // Ein weiterer Vergleichsoperator ist "instanceof". Dieser ist nur als Anmerkung hier angeführt da wir diesen erst in der Objektorientierung verwenden werden:
        // Es soll nur ein Beispiel sein, dass es auch andere, "abstraktere" Operatoren geben kann.

        // #################################### gemischte Operatoren ####################################
        // Wir haben mit diesen die Möglichkeit z.B. eine Zuweisung und eine arithmetische Opearation, mit einem Operator durchzuführen.
        // Beginnen wir mit:
        // - "+=", "-=", "*=", "/=": diese sind eine Kombination aus zuweisung und arithmetischen Oparatoren.
        // Diese verwenden den arithmetischen Operator welche am Anfang steht und den Zuweisungsoperator.

        // Wir können also
        alter = alter + 25;
        System.out.println(alter);

        // mit folgendem Ausdruck ersetzen.
        alter += 25;
        System.out.println(alter);

        // Gleiches gilt für
        System.out.println( alter /= 2);

        // Als Nächstes schauen wir uns Inkremente und Dekremente an.
        // Ein Inkrement bedeutet eine Erhöhung um eine Einheit, ein Dekrement eine Verringerung um eine Einheit.
        // - "++", "--": diese werden inkrement und dekrement Operatoren genannt und sind eine Kombination aus "x=x+1".
        // Diese sind ähnlich zu "+=", jedoch spezieller. Wir zählen nämlich immer 1 dazu oder ziehen 1 ab.
        // Folgendes ist also
        alter = alter + 1;
        System.out.println(alter);

        // Als Inkrement geschrieben
        alter++;
        System.out.println(alter);

        // und nun als Dekrement.
        alter--;
        System.out.println(alter);

        // Dieser Operator ist also ein unärer Operator wie das "!". Ansonsten waren bisher alle Operatoren binär.
        // Es gibt hier noch eine Anmerkung zu den Inkrement/Dekrement Operator.
        // Wir können beider schreiben und es wird das Gleiche ausgegeben.
        alter++;
        System.out.println(alter);

        ++alter;
        System.out.println(alter);

        // Der Unterschied ist subtil und hier nicht erkennbar.
        // Schauen wir uns jedoch folgendes an. Wir wollen nicht immer doppelt alter++; und danach die Ausgabe schreiben.
        // Geht das nicht in einer Zeile? Die Anwort ist ja, aber
        System.out.println("Das momentane Alter ist: " + alter);
        System.out.println("und jetzt erhöhen wir es auf: " + alter++);
        System.out.println("wieso erst jetzt? " + alter);

        // Schreiben wir es ohne Dekrement Operator, sondern als 2 seperate Operationen.
        System.out.println("Zuweisung und Erhöhung seperat: " + (alter = alter + 1) );
        System.out.println("Das momentane Alter ist: " + alter);

        // Komisch. Das Verhalten ist hier zwischen alter++ und alter = alter + 1 verschieden.
        // alter++ gibt die Änderung der Variable nicht sofort an die übergebene Methode weiter!
        // Die Variable wird aber um 1 erhöht und gespeichert.
        // In der Gleichen Zeile können wir jedoch nicht auf den erhöhten Wert zugreifen.

        // mit alter = alter + 1 passiert aber alles sofort.
        // Wir können das Verhalten mit ++alter erzeugen.
        System.out.println("Inkrement mit ++alter: " + ++alter );
        System.out.println("Das momentane Alter ist: " + alter);

        // Wir können auch den ++ und -- Operator nicht hintereinander schachteln wie + und -.
        // z.B. schachteln wir hier
        Integer index = 0;
        System.out.println( ((index+1)+1)+1 );
        System.out.println(index);

        // Hier mit Zuweisung damit am Schluss die Berechnung des Index erhalten bleibt.
        index = 0;
        System.out.println( index=((index+1)+1)+1 );
        System.out.println(index);

        // aber das geht nicht. JAVA will damit "unklare" Befehlsabfolgen verhindern.
//        System.out.println(++(++(++index)));
        // Ansonsten könne folgender Ausdruck möglich sein?
        // Wann hier was ausgeführt wird, ist nicht ganz offensichtlich und kann eine Grundlage für Bugs sein.
//        System.out.println( (++((++index)++))++ );


        // // #################################### OPERATOREN VS. METHODEN ####################################
        // in der Praxis werden Operatoren meist bei Zahlen verwendet und methoden für alles andere.
        // In C++ oder C# können auch Operatoren "überladen" werden. Also das z.B. "+" Symbol kann für das Kombinieren von eigenen block2.Klassen verwendet werden.
        // ASCII - Table -> gibt Nummer rein, hier 195 und gibt das Symbol an dieser Stelle aus.
        // a -> 97, b -> 98, usw.

        Integer zahl = (((97 + 98) + 82) + 16);
        Integer andereZahl = Math.addExact(97, 98);
        Integer neueZahl1 = Math.addExact(andereZahl, 82);
        Integer neueZahl2 = Math.addExact(neueZahl1, 16);
        Integer andereZahl2 = Math.addExact( Math.addExact(97, 98), 82 );

        // Wir verwenden hier Integer und nicht int, weil es einfacher für uns ist,
        // da wir damit schon mit Objekten in berührung kommen. Denn kommazahl ist ein Objekt und hat dementsprechend Methoden für
        // die weitere Verarbeitung zur Verfügung.
        Double kommazahl = zahl.doubleValue();
    }
}
