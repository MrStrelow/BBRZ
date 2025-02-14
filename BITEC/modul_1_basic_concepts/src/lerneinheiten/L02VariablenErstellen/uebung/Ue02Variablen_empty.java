package uebungen.vorlagen;

public class Ue02Variablen_empty {

    public static void main(String[] args) {
        // Erkennen von Typen
        // 1 Welche Datentypen haben folgende Aussagen?
        // 1.1 Alter eines Menschen
        // 1.2 Verwendungszweck Beispiel in Java
        // 1.3 Das Jahresgehalt in ganzen Euro-Beträgen
        // 1.4 Das Geschlecht einer Person
        // 1.5 Die Anrede einer Person (Herr, Frau, ...)
        // 1.6 Die eulerische Zahl e mit 14 Nachkommastellen
        // 1.7 Das Gewicht in kg
        // 1.8 Wurde Rechnung schon bezahlt?

        // Einstieg
        // 1 lokale int Variable a mit Wert 47 erstellen;
        // 1.1 globale int Konstante K1 mit Wert 111 erstellen
        // 1.2 Berechnen von a+K1 und speichern in c
        // 1.3 Ausgabe von c auf Konsole (System.out.println(...);)
        // 1.4 lokale double Variable b mit Wert 101,98 erstellen
        // 1.5 lokale double Variable d ohne Wert anlegen
        // 1.6 d = a+b berechnen
        // 1.7 d ausgeben
        // 1.8 d in int umwandeln und in neue int variable e speichern
        // 1.9 boolsche Variable b1 anlegen mit Wert false
        // 1.10 b1 auf true setzen
        // 1.11 String hello mit "Hallo" anlegen
        // 1.12 String name mit Ihren Namen anlegen
        // 1.13 Neue String Variable greeting erstellen, die aufgrund der Variablen hello und name den Wert "Hallo Max!" beinhalten soll.
        // 1.14 Geben Sie auf die Konsole aus: "Das Ergebnis von a + b ist c". a,b,c soll durch die aktuellen Werte ersetzt werden.

        // Kombiniert
        // 1 Taschenrechner light
        // 1.1 Erstellen Sie zwei integer Variablen x und y und speichern Sie die Ergebnisse folgender Berechnungen
        // 1.2 jeweils in Variablen und geben Sie diese schön formatiert in die Konsole aus (für x=4 und y=3):
        // 1.3 x+y x+y = 4+3 = 7
        // 1.4 x-y x-y = 4-3 = 1
        // 1.5 x/y x/y = 4/3 = 1 (Ergebnis als int)
        // 1.6 x/y x/y = 4/3 = 1,333 (Ergebnis als double)
        // 1.7 x%y %/y = 4%3 = 1

        // Rechnung
        // Legen Sie 3 globale Konstanten für Produkte an: cola=2€, wasser=1€, bier=4€.
        // Legen Sie 3 lokale Variablen an für anzCola, anzWasser, anzBier an.
        // Berechnen Sie die Summe der Rechnung und geben Sie folgendes in der Konsole aus: "Die Rechnung von 3 Cola, 2 Wasser und 1 Bier ergibt 12€"
        //  Berechnen Sie den Durchschnittspreis der 3 Produkte und geben Sie diesen auf die Konsole aus.

        // Rechteck
        // Legen Sie zwei Variablen für Länge und Breite eines Rechtecks an.
        // Berechnen Sie den Umfang des Rechtecks und geben Sie diesen in der Konsole aus: 2*(a+b)
        // Berechnen Sie die Fläche und geben Sie diese in die Konsole aus: a*b

        // Kreis
        // Legen Sie eine Variable für Radius an.
        // Berechnen Sie den Umfang des Kreises und geben Sie diesen in der Konsole aus: U = 2* pi* r
        // Berechnen Sie die Fläche und geben Sie diese in die Konsole aus: A = pi*r^2.
        // Hinweis: Der Wert für PI ist in der Konstante Math.PI gespeichert. Diese knn einfach verwendet
        // werden. r^2 kann entweder mit r*r oder mit Math.pow(r, 2)erreicht werden. Versuchen Sie beide Methoden.

        // Umwandlung von Datentypen
        // 1. Wie viele Bytes benötigt man mindestens, um folgende Dezimalzahlen binär kodiert zu speichern?
        // - 18
        // - 128
        // - 7635
        // - 897613
        // - 232
        // 2. Welche Rechenergebnisse liefern die folgenden 9 Ausdrücke jeweils für x?
        int i=4;
        int j=5;
        double x;
        x = (double) i / j;
        x = 1.0 * i / j * 10;
        x = i / j * 10;
        x = 1.0 * (i / j) * 10;
        x = i * 10 / j;
        x = 10.0 * i / j;
        x = (10.0 * i) / j;
        x = i / 0.1 * j;
        x = i / (0.1 * j);

        // Alle Übungen sollen anschließend auf die Konsole ausgegeben werden.

        // 1. Deklarieren Sie eine Variable des Datentyps int und weisen Sie ihr einen Wert zu.
        // 2. Deklarieren Sie eine Variable des Datentyps double und weisen Sie ihr einen Wert zu.
        // 3. Deklarieren Sie eine Variable des Datentyps char und weisen Sie ihr einen Buchstaben zu.
        // 4. Deklarieren Sie eine Variable des Datentyps boolean und weisen Sie ihr den Wert true zu.
        // 5. Deklarieren Sie eine Variable des Datentyps long und weisen Sie ihr einen Wert zu.
        // 6. Deklarieren Sie eine Variable des Datentyps float und weisen Sie ihr einen Wert zu.
        // 7. Führen Sie eine Addition zweier int-Variablen + speichern in neuer Variable. Geben Sie das Ergebnis auf die Konsole aus.
        // 8. Führen Sie eine Subtraktion zweier double-Variablen durch.
        // 9. Multiplizieren Sie zwei int-Variablen.
        // 10. Teilen Sie zwei float-Variablen.
        // 11. Erstellen Sie eine Variable vom Typ int und weisen Sie ihr den Wert einer double-Variable nach Typumwandlung (Casting) zu.
        // 12. Erstellen Sie eine Variable vom Typ double und weisen Sie ihr den Wert einer int-Variable nach Typumwandlung (Casting) zu.
        // 13. Führen Sie eine Division von zwei int-Variablen durch und speichern Sie das Ergebnis in einer doubleVariablen.
        // 14. Führen Sie eine Division von zwei double-Variablen durch und speichern Sie das Ergebnis in einer intVariablen.
        // 15. Vergleichen Sie, ob zwei int-Variablen gleich sind und speichern Sie das Ergebnis in einer booleanVariablen. (a == b)
        // 16. Vergleichen Sie zwei double-Variablen und speichern Sie das Ergebnis in einer boolean-Variablen.
        // 17. Deklarieren Sie eine char-Variable und weisen Sie ihr den Wert 'A' zu. Ändern Sie dann den Wert auf 'B'.
        // 18. Deklarieren Sie eine boolean-Variable und weisen Sie ihr den Wert true zu. Ändern Sie dann den Wert auf false.
        // 19. Berechnen Sie den Durchschnitt von drei double-Variablen und speichern Sie das Ergebnis in einer double-Variablen.
        // 20. Berechnen Sie die Summe der ersten 10 natürlichen Zahlen (1 + 2 + 3 + ... + 10) und speichern Sie das Ergebnis in einer int-Variablen.
        // 21. Deklarieren Sie eine int-Variable und weisen Sie ihr den Wert 1000 zu. Führen Sie eine Typumwandlung durch, um ihn in eine byte-Variable zu speichern.
        // 22. Deklarieren Sie eine double-Variable und weisen Sie ihr den Wert 3.14159265359 zu. Führen Sie eine
        // 23. Typumwandlung durch, um ihn in eine float-Variable zu speichern.
        // 24. Erstellen Sie eine boolean-Variable und weisen Sie ihr den Wert true zu. Führen Sie eine Typumwandlung durch, um ihn in eine int-Variable zu speichern (1 für true und 0 für false).
        // 25. Deklarieren Sie eine char-Variable und weisen Sie ihr den Wert 'X' zu. Führen Sie eine Typumwandlung durch, um ihn in eine int-Variable zu speichern.
    }
}
