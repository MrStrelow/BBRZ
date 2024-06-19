public class Operatoren {
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
        //      - arithmetische Operatoren:
        //          - "+", "-", "*", "/", bei Variablen welche Zahlen darstellen
        //      - logische (oder auch boolesche) Operatoren:
        //          - "!", "||", "&&", "^": das sind beispielsweise das logische nicht, logische und, logische oder, und exclusive oder.
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
        // - selbst definierte Opertoren
        //      - das ist in JAVA nicht möglich.

        // Wir unterscheiden zudem in unäre, binäre und tertiäre Operatoren. Diese Kategorisierung gibt an, wie viele Inputs diese annehmen.
        // Achtung, damit ist nicht deren Verkettung gemeint, sondern wirklich ein Operator nimmt 1, 2 oder 3 Inputs an.
        // Beispiel dafür einen unären Operator ist:
        firstInt++;

        // Beispiel für binöre Operatoren ist:
        firstInt *= 10;

        // Hier ist eine Kombination aus beidem. Ein unärer Operator "nicht" mit Symbol "!" und der
        // binäre Oparator "logisches und" mit dem Symbol "&&".
        // Achtung! der Operator "&" bedeutet "bitweises und"!

        Boolean firstBoolean = false;
        Boolean ergebnis = !( firstBoolean && firstBoolean);

        Integer bitwise = 3 & 5;
        System.out.println("Bitwise: " + bitwise);

        // Hier ist
        // Weiters
        Double meinErsterDouble = 7.0;
        Integer meinErsteInteger = 5;
        Integer meinZweiterInteger = 10;

        System.out.println( meinErsteInteger / meinErsterDouble );

        System.out.println( meinZweiterInteger / meinErsteInteger);

        System.out.println( 11 / 5 );

        System.out.println( 11 / 5.0);

        System.out.println( Math.divideExact(11, 5) );

        System.out.println( 11 % 5 );

        // OPERATOREN VS. METHODEN:
        // in der Praxis werden Operatoren meist bei Zahlen verwendet und methodne für alles andere.
        // In C++ oder C# können auch Operatoren "überladen" werden. Also das z.B. "+" Symbol kann für das Kombinieren von eigenen Klassen verwendet werden.
        // ASCII - Table -> gibt Nummer rein, hier 195 und gibt das Symbol an dieser Stelle aus.
        // a -> 97, b -> 98, usw.

        Integer zahl = (((97 + 98) + 82) + 16);
        Integer andereZahl = Math.addExact(97, 98);
        Integer neueZahl1 = Math.addExact(andereZahl, 82);
        Integer neueZahl2 = Math.addExact(neueZahl1, 16);

        Integer andereZahl2 = Math.addExact( Math.addExact(97, 98), 82 );

        // ein paar "Tricks"
        Integer asdf = 11;
//        Integer qwer = 3;
        Float qwer = 3.f;
        System.out.println(11./3);


        // verwende Integer und nicht int weil...
        Double kommazahl = zahl.doubleValue();

//        System.out.println(zahl);
//        System.out.println(neueZahl2);


        // logische Werte:
        Boolean wahrerWert = true;
        Boolean falscherWert = false;

        // Operatoren:
        // Zahlen: +, -, *, /, %
        // Zeichen(ketten): +
        // logische Werte: ||, &&, !, ^

        // Vergleichsoperatoren (geben immer wahr/falsch zurück):
        // >= oder <= was kommt rein:
        // int, int     -> boolean
        // int, double  -> boolean

        // != oder == was kommt rein:
        // int, int         -> boolean
        // boolean, boolean -> boolean
        // double, double   -> boolean

        // kann alles vergleichen: ==, !=

        boolean wahrheitswert1 = true;
        boolean wahrheitswert2 = false;

//        System.out.println(wahrheitswert1 || wahrheitswert2);
//        System.out.println(wahrheitswert1 && wahrheitswert2);
//        System.out.println(wahrheitswert1 == wahrheitswert2);
        System.out.println(wahrheitswert1 != wahrheitswert2);
//        System.out.println(zahl >= andereZahl);
//        System.out.println(kommazahl >= andereZahl);

        System.out.println(!wahrheitswert1);

        double largeNumber = 1e16; // A very large number
        double smallNumber = 1e-4; // A very small number

        // Expected result if there were no precision issues
        double expectedResult = largeNumber + 100; //1000000 * smallNumber; // 1e16 + 1.0

        // Actual result due to floating-point precision
        double actualResult = largeNumber;
        for (int i = 0; i < 1000000; i++) {
            actualResult += smallNumber;
        }

        System.out.println("Expected result: " + expectedResult);
        System.out.println("Actual result: " + actualResult);
        System.out.println("Difference: " + (expectedResult - actualResult));
    }
}
