import java.util.Scanner;

public class L05UserInput {
    public static void main(String[] args) {
        // Wir wollen uns in diesem Dokument den Scanner Typ (Klasse) anschauen.
        // Diese erlaubt und mit dem User auf der Console zu interagieren.
        // Die Console ist die Eingabeaufforderung wo wir normalerweise das Programm starten (javac und java Befehl).
        // Wir haben in einer Entwicklungsumgebung (IDE - hier Intellij) ebenfalls eine Console.
        // Das ist der Ort wo wir Ausgaben des Programmes bis jetzt hingeschrieben haben (System.out.println).

        // Wir können mit dem Scanner nun diesen Ort nutzen, um dort den User eine Eingabe eingeben zu lassen.
        // Wir legen dazu eine Variable myScanner an.
        // Hier sehen wir unser bekanntes "Dreierlei" bzw. wenn wir den Zuweisungsoperator zählen "Viererlei":
        // <Typ> <nameDerVariable> <Zuweisungsoperator> <Wert>
        // Hier sieht die Art wir wir den <Wert> Zuweisen aber unbekannt aus. Wir haben es schon mal gesehen, aber je öfter desto besser.
        // Die rechte Seite des Zuweisungsoperators "=" ist schon ein Konzept aus der Objektorientierung.
        // Wir verwenden das Keyword "new" um eine neue Variable anzulegen, gefolgt vom Typ der Variable.
        // In den Klammern können wir noch nähere Spezifikationen vollziehen (Für jene welche schon Objektorientiert programmiert haben,
        // hier legen wir ein Objekt myScanner, an welches den Konstruktor der Klasse Scanner aufruft und diesem ein Argument System.in gibt.
        // Das lässt vermuten, dass wir nicht nur die Console als "Ort der Eingabe" festlegen können, sondern auch z.B. ein Textfile, Word, usw.).
        Scanner myScanner = new Scanner(System.in);

        // Wir können nun den User eine Eingabe tätigen lassen. Dies geschieht mit der Variable "myScanner" und mit dem Zugriffsoperator ".".
        // Wir schreiben also
        myScanner.nextLine();

        // Dies wartet bis der User einen Text in die Console eingibt und mit der Enter Taste bestätigt.
        // geben sie also eine Zeichenkette in die unten angezeigte Console ein.

        // Um dies ein wenig "schöner" zu gestalten können wir vorher eine Ausgabe des Programmes erzeugen, indem wir
        System.out.println("Bitte gib eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
        myScanner.nextLine();

        // Dies erlaubt uns eine ganze Zeile einzulesen. Wir lesen somit alles ein, was der User eingegeben hat bis wir "\n" lesen.
        // Dies ist das Symbol für einen Zeilenumbruch welches wir durch das Drücken von <Enter> erzeugen.
        // Wir haben aber keine Zuweisung vollzogen. Da "nextLine" eine Methode ist, und eine Rückgabe vom Typ String erzeugt,
        // können wir diese einer Variable vom Typ String zuweisen. Also... nocheinmal
        System.out.println("Bitte gib nocheinmal eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
        String meineEingabe = myScanner.nextLine();

        // Da wir nun die Eingabe des Users einer Variable zugewiesen haben, können wir diese später für weitere Zwecke verwenden.
        // z.B.
        System.out.println("Deine Eingabe war: " + meineEingabe);

        // Wenn wir uns nun anschauen welche Methoden alle in "myScanner" vorhanden sind, sehen wir es gibt 2 Arten von next Methoden.
        // Diese sind "next" bzw. "next<Typ>" oder eben das verwendete "nextLine".
        // Was ist der Unterschied? Probieren wir Folgendes.

        System.out.println("Bitte gib nocheinmal eine Eingabe ein, und bestätigen Sie mit <Enter>: ");
        meineEingabe = myScanner.next();

        // Auf den ersten Blick scheint nichts anders zu sein, aber versuchen wir nun folgendes.
        System.out.println("Bitte gib zwei Zahlen getrennt mit leertaste ein z.B. 'a b', und bestätigen Sie mit <Enter>: ");
        String meineErsteEingabe = myScanner.next();
        String meineZweiteEingabe = myScanner.next();

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        // Wir sehen nun, was der Unterschied ist! nextLine liest solange bis ein \n kommt (INKLUSIVE DEM \n!) und
        // next liest bis ein Leerzeichen bzw. das ein \n kommt (EXKLUSIVE DEM \n!).
        // Wir können spezifizieren, was dieses Trennzeichen ist.

    }
}
