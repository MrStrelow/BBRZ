package lerneinheiten.L02VariablenErstellen.uebung;

public class Loesung {

    static final Integer K1 = 111;
    static final Integer cola = 2;
    static final Integer wasser = 1;
    static final Integer bier = 4;


    public static void main(String[] args) {
        // Erkennen von Typen
        // 1 Welche Datentypen haben folgende Aussagen?
        // 1.1 Alter eines Menschen
        Integer alter;

        // 1.2 Verwendungszweck Beispiel in Java
        String verwendungszweck;

        // 1.3 Das Jahresgehalt in ganzen Euro-Beträgen
        Double gehalt;

        // 1.4 Das Geschlecht einer Person
        String geschlecht;

        // 1.5 Die Anrede einer Person (Herr, Frau, ...)
        String anrede;

        // 1.6 Die eulerische Zahl e mit 14 Nachkommastellen
        Double eulerscheZahl;

        // 1.7 Das Gewicht in kg
        Double gewicht; // Integer passt auch. Kommt auf den Kontext drauf an.

        // 1.8 Wurde Rechnung schon bezahlt?
        Boolean istBezahlt;

        // Einstieg
        // 1.1 lokale int Variable a mit Wert 47 erstellen;
        Integer a = 47;

        // 1.2 globale int Konstante K1 mit Wert 111 erstellen
        // siehe ausserhalb der methode main(String[] args)

        // 1.3 Berechnen von a+K1 und speichern in c
        Integer c = a + K1; //wenn K1 nicht static ist, dann darf es nicht in der static methode main(String[] args) verwendet werden.

        // 1.4 Ausgabe von c auf Konsole (System.out.println(...);)
        System.out.println(c);

        // 1.5 lokale double Variable b mit Wert 101,98 erstellen
        Double b = 101.98;

        // 1.6 lokale double Variable d ohne Wert anlegen
        Double d;

        // 1.7 d = a+b berechnen
        d = a + b;

        // 1.8 d ausgeben
        System.out.println(d);

        // 1.9 d in int umwandeln und in neue int variable e speichern
        Integer e = d.intValue();

        // 1.10 boolsche Variable b1 anlegen mit Wert false
        Boolean b1 = false;

        // 1.11 b1 auf true setzen
        b1 = true;

        // 1.12 String hello mit "Hallo" anlegen
        String hello = "Hallo";

        // 1.13 String name mit Ihren Namen anlegen
        String name = "Mathias Cammerlander";

        // 1.14 Neue String Variable greeting erstellen, die aufgrund der Variablen hello und name den Wert "Hallo Max!" beinhalten soll.
        String greeting = hello + "Max!";

        // 1.15 Geben Sie auf die Konsole aus: "Das Ergebnis von a + b ist d". a,b,d soll durch die aktuellen Werte ersetzt werden.
        System.out.println("Das Ergebnis von " + a + " + " + b + " ist " + d);

        // Kombiniert
        // 1 Taschenrechner light
        // 1.1 Erstellen Sie zwei integer Variablen x und y und speichern Sie die Ergebnisse folgender Berechnungen
        // jeweils in Variablen und geben Sie diese schön formatiert in die Konsole aus (für x=4 und y=3):
        Integer x = 4;
        Integer y = 3;

        // 1.3 x+y = 4+3 = 7
        System.out.println("x+y = " + x + "+"  + y + " = " + (x+y) );

        // 1.4 x-y = 4-3 = 1
        System.out.println("x-y = " + x + "-"  + y + " = " + (x-y) );

        // 1.5 x/y = 4/3 = 1 (Ergebnis als int)
        System.out.println("x/y = " + x + "/"  + y + " = " + (x/y) );

        // 1.6 x/y = 4/3 = 1,333 (Ergebnis als double)
        // "dirty fix" - zuerst wird x welches ein Integer ist zu einem double, da es mit 0.0 addiert wird.
        System.out.println("x/y = " + x + "/"  + y + " = " + ( (0.0+x)/y ) );
        // Schoener vl mit primitive type casting - x wird zu einem double dann wird es durch y dividiert.
        System.out.println("x/y = " + x + "/"  + y + " = " + ( (double)x /y ) );

        // 1.7 %/y = 4%3 = 1
        // Ist die Modulo operation - ist der Rest, welcher bei einer Division entsteht.
        System.out.println("x%y = " + x + "%"  + y + " = " + ( x%y ) );

        // Rechnung
        // Legen Sie 3 globale Konstanten für Produkte an: cola=2€, wasser=1€, bier=4€.
        // siehe ausserhalb der main(String[] args) Methode

        // Legen Sie 3 lokale Variablen an für anzCola, anzWasser, anzBier an.
        Integer anzCola;
        Integer anzWasser;
        Integer anzBier;

        // Berechnen Sie die Summe der Rechnung und geben Sie folgendes in der Konsole aus: "Die Rechnung von 3 Cola, 2 Wasser und 1 Bier ergibt 12€"
        anzCola = 3;
        anzWasser = 2;
        anzBier = 1;

        Integer gesamtBetrag = anzCola * cola + anzWasser * wasser + anzBier * bier;
        System.out.println("Die Rechnung von " + anzCola + " Cola, " + anzWasser + " Wasser und " + anzBier + " Bier ergibt " + gesamtBetrag + "€");

        //  Berechnen Sie den Durchschnittspreis der 3 Produkte und geben Sie diesen auf die Konsole aus.
        System.out.println( (cola + wasser + bier) / 3d ); //d fuer double, geht auch mit f oder + 0.0

        // Rechteck
        // Legen Sie zwei Variablen für Länge und Breite eines Rechtecks an.
        Double laenge = 2.0;
        Double breite = 4.0;

        // Berechnen Sie den Umfang des Rechtecks und geben Sie diesen in der Konsole aus: 2*(a+b)
        System.out.println(2 * (laenge + breite));

        // Berechnen Sie die Fläche und geben Sie diese in die Konsole aus: a*b
        System.out.println(laenge * breite);

        // Kreis
        // Legen Sie eine Variable für Radius an.
        // Hinweis: Der Wert für PI ist in der Konstante Math.PI gespeichert. Diese knn einfach verwendet
        // werden. r^2 kann entweder mit r*r oder mit Math.pow(r, 2)erreicht werden. Versuchen Sie beide Methoden.
        Double radius = 4.0;

        // Berechnen Sie den Umfang des Kreises und geben Sie diesen in der Konsole aus: U = 2* pi* r
        System.out.println(2 * Math.PI * radius);

        // Berechnen Sie die Fläche und geben Sie diese in die Konsole aus: A = pi*r^2.
        System.out.println(Math.PI * Math.pow(radius, 2));
        System.out.println(Math.PI * radius * radius);


        // Umwandlung von Datentypen
        // 1. Wie viele Bytes benötigt man mindestens, um folgende Dezimalzahlen binär kodiert zu speichern?
        // - 18
        System.out.println( Math.floor( Math.log(18) / Math.log(2) ) + 1 );
        // - 128
        System.out.println( Math.floor( Math.log(128) / Math.log(2) ) + 1 );
        // - 7635
        System.out.println( Math.floor( Math.log(7635) / Math.log(2) ) + 1 );
        // - 897613
        System.out.println( Math.floor( Math.log(897613) / Math.log(2) ) + 1 );
        // - 232
        System.out.println( Math.floor( Math.log(232) / Math.log(2) ) + 1 );

        // 2. Welche Rechenergebnisse liefern die folgenden 9 Ausdrücke jeweils für x?

        int i=4;
        int j=5;
        double X;
        X = (double) i / j;             // 4/5 als kommazahl = 0.8
        X = 1.0 * i / j * 10;           // i wird kommazahl durch *1.0 -> 4/5*10 = (4*10)/5 = 40/5 = 8.0
        X = i / j * 10;                 // 0.0
        X = 1.0 * (i / j) * 10;         // 0.0
        X = i * 10 / j;                 // 8.0
        X = 10.0 * i / j;               // 8.0
        X = (10.0 * i) / j;             // 8.0
        X = i / 0.1 * j;                // 4/0.1 * 5 = 4*10 * 5 = 40 * 5 = 200
        X = i / (0.1 * j);              // 4 / 0.5 = 4*2 = 8.0

        System.out.println(X);

        // Alle Übungen sollen anschließend auf die Konsole ausgegeben werden.

        // 1. Deklarieren Sie eine Variable des Datentyps int und weisen Sie ihr einen Wert zu.
        Integer yetAnotherInteger; // deklariert
        yetAnotherInteger = 0; // Wertzuweisung

        // 2. Deklarieren Sie eine Variable des Datentyps double und weisen Sie ihr einen Wert zu.
        Double yetAnotherDouble;
        yetAnotherDouble= 0.0;

        // 3. Deklarieren Sie eine Variable des Datentyps char und weisen Sie ihr einen Buchstaben zu.
        Character aChar;
        aChar = 'a'; // geht nur mit ' ' und nicht mit " "

        // 4. Deklarieren Sie eine Variable des Datentyps boolean und weisen Sie ihr den Wert true zu.
        Boolean bool;
        bool = true;

        // 5. Deklarieren Sie eine Variable des Datentyps long und weisen Sie ihr einen Wert zu.
        Long yetAnotherLong;
        yetAnotherLong = 0L;

        // 6. Deklarieren Sie eine Variable des Datentyps float und weisen Sie ihr einen Wert zu.
        Float yetAnotherFloat;
        yetAnotherFloat = 0.0f;

        // 7. Führen Sie eine Addition zweier int-Variablen + speichern in neuer Variable. Geben Sie das Ergebnis auf die Konsole aus.
        Integer ausgabe = yetAnotherInteger + yetAnotherInteger;
        System.out.println(ausgabe);

        // 8. Führen Sie eine Subtraktion zweier double-Variablen durch.
        ausgabe = yetAnotherInteger - yetAnotherInteger;

        // 9. Multiplizieren Sie zwei int-Variablen.
        ausgabe = yetAnotherInteger * yetAnotherInteger;

        // 10. Teilen Sie zwei float-Variablen.
        Float yetAnotherAusgabe = yetAnotherFloat / yetAnotherFloat;

        // 11. Erstellen Sie eine Variable vom Typ int und weisen Sie ihr den Wert einer double-Variable nach Typumwandlung (Casting) zu.
        double yetAnotherPrimitiveFloat = yetAnotherFloat;
        yetAnotherInteger = (int) yetAnotherPrimitiveFloat;

        // 12. Erstellen Sie eine Variable vom Typ double und weisen Sie ihr den Wert einer int-Variable nach Typumwandlung (Casting) zu.
        yetAnotherDouble = (double) yetAnotherInteger;

        // 13. Führen Sie eine Division von zwei int-Variablen durch und speichern Sie das Ergebnis in einer doubleVariablen.
        double strangeDouble = yetAnotherInteger / (yetAnotherInteger+1);

        // 14. Führen Sie eine Division von zwei double-Variablen durch und speichern Sie das Ergebnis in einer intVariablen.
        int strangeInteger = (int) ( yetAnotherDouble / (yetAnotherDouble+1.0) );

        // 15. Vergleichen Sie, ob zwei int-Variablen gleich sind und speichern Sie das Ergebnis in einer booleanVariablen. (a == b)
        Boolean istGleich = yetAnotherInteger == yetAnotherInteger;

        // 16. Vergleichen Sie zwei double-Variablen und speichern Sie das Ergebnis in einer boolean-Variablen.
        Boolean anotherIstGleich = yetAnotherDouble == yetAnotherDouble;

        // 17. Deklarieren Sie eine char-Variable und weisen Sie ihr den Wert 'A' zu. Ändern Sie dann den Wert auf 'B'.
        char aCharacter = 'A';// Hier gibt es kein Char!
        aCharacter = 'B';

        // 18. Deklarieren Sie eine boolean-Variable und weisen Sie ihr den Wert true zu. Ändern Sie dann den Wert auf false.
        Boolean yetAnotherBoolean = true;
        yetAnotherBoolean = false;

        // 19. Berechnen Sie den Durchschnitt von drei double-Variablen und speichern Sie das Ergebnis in einer double-Variablen.
        Double durchschnitt = (yetAnotherDouble + yetAnotherDouble + yetAnotherDouble)/3;

        // 20. Berechnen Sie die Summe der ersten 10 natürlichen Zahlen (1 + 2 + 3 + ... + 10) und speichern Sie das Ergebnis in einer int-Variablen.
        Integer summeNatuerlicherZahlen = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10;
        // oder
        summeNatuerlicherZahlen = (10*11)/2;

        // 21. Deklarieren Sie eine int-Variable und weisen Sie ihr den Wert 1000 zu. Führen Sie eine Typumwandlung durch, um ihn in eine byte-Variable zu speichern.
        Integer yetAnotherAnotherInteger = 1000;
        Byte einByte = yetAnotherAnotherInteger.byteValue();

        // 22. Deklarieren Sie eine double-Variable und weisen Sie ihr den Wert 3.14159265359 zu. Führen Sie eine Typumwandlung durch, um ihn in eine float-Variable zu speichern.
        Double pi = 3.14159265359;
        Float piNurEtwasKuerzer = pi.floatValue();

        // 24. Erstellen Sie eine boolean-Variable und weisen Sie ihr den Wert true zu. Führen Sie eine Typumwandlung durch, um ihn in eine int-Variable zu speichern (1 für true und 0 für false).
        Boolean yetAnotherAnotherBoolean = true;
        Integer ahaStrange = yetAnotherAnotherBoolean.compareTo(false);

        // 25. Deklarieren Sie eine char-Variable und weisen Sie ihr den Wert 'X' zu. Führen Sie eine Typumwandlung durch, um ihn in eine int-Variable zu speichern.
        char yetAnotherChar = 'X';
        int ahaCharsAreNumbers = yetAnotherChar; // hier funktioniert Integer nicht direkt, nur int!
    }
}
