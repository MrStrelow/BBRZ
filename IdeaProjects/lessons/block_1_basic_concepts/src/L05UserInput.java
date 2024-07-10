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
        System.out.println("Bitte gib zwei Zahlen getrennt durch die leertaste ein z.B. 'a b', und bestätigen Sie mit <Enter>: ");
        String meineErsteEingabe = myScanner.next();
        String meineZweiteEingabe = myScanner.next();

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        // Wir sehen nun, was der Unterschied ist! nextLine liest solange bis ein \n kommt (INKLUSIVE DEM \n!) und
        // next liest bis ein Leerzeichen bzw. das ein \n kommt (EXKLUSIVE DEM \n!).
        // Wir können spezifizieren, was dieses Trennzeichen ist. In diesem Fall ist es "ZZzZZ".
        // (Für jene welche wissen was ein RegEx ist - Regular Expression, eine solche kann auch hier verwendet werden!).
        // ACHTUNG! Hier wird nur mehr da Symbol ZZzZZ als Trennzeichen verwendet. \n nicht mehr!
        // Wir müssen also, wenn wir "a" und "b" einlesen wollen ZZzZZ hinter a und b schreiben!
        myScanner.useDelimiter("ZZzZZ");

        // Wenn wir nun die Eingabe von davor wiederholen sollte folgendes passieren.
        System.out.println("Bitte gib nochmal zwei Zahlen welches das Haltesymbol ZZzZZ hat ein z.B. 'aZZzZZbZZzZZ', und bestätigen Sie mit <Enter>: ");
        meineErsteEingabe = myScanner.next();
        meineZweiteEingabe = myScanner.next();

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        // Wenn wir nun der scanner nach ZZzZZ oder \n halten soll, müssen wir das angeben.
        // Hier nochmal das Beispiel:
        myScanner.useDelimiter("ZZzZZ|\n");

        // Wenn wir nun die Eingabe von davor wiederholen sollte folgendes passieren.
        System.out.println("Bitte gib nochmal zwei Zahlen getrennt durch ZZzZZ ein z.B. 'aZZzZZb', und bestätigen Sie mit <Enter>: ");
        meineErsteEingabe = myScanner.next();
        meineZweiteEingabe = myScanner.next();

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        // Wir haben jedoch noch nicht einen Fall besprochen welches zu einem unerwarteten Verhalten führt.
        // Wenn wir zuerst die Methode "next" verwenden und danach "nextLine" haben wir folgendes komisches Verhalten.
        System.out.println("komische eingabe: ");
        meineErsteEingabe = myScanner.next();

        System.out.println("komische zweite eingabe welche aber übersprungen wird!: ");
        meineZweiteEingabe = myScanner.nextLine();

        // Hier wird die Eingabe folgendermaßen aufgeteilt. Der eingegebene Text wird bis zum \n der Variable meineErsteEingabe
        // zugewiesen. nextLine springt aber auch auf das Symbol \n ohne weiteren Text an. Bedeutet die Variable meineZweiteEingabe
        // wird mit \n belegt, denn eine leer Zeile welche nur das Symbol \n besitzt ist auch eine Zeile.
        // Um dieses ungewollte Verhalten zu verhindern, müssen wir:
        //  1) next für meineErsteVariable verwenden
        //  2) nextLine für das übrig gebliebene \n
        //  3) nextLine für den Text welchen wir meinerZweitenVariable zuweisen wollen

        // Also:
        System.out.println("unkomische eingabe: ");
        meineErsteEingabe = myScanner.next();
        myScanner.nextLine();

        System.out.println("unkomische zweite eingabe welche nicht mehr übersprungen wird: ");
        meineZweiteEingabe = myScanner.nextLine();

        // Eine Variante welch ein solches Verhalten vermeidet, ist IMMER nextLine zu verwenden und danach die Variablen
        // entsprechend verarbeiten.
        // z.B
        System.out.println("meine ganzahlige Eingabe welche aber als 'String' mit 'nextLine' eingelesen wird.");
        Integer myInteger = Integer.parseInt(myScanner.nextLine());

        // z.B - Achtung hier wird ein neues Konzept verwendet! Ein Array! Dazu aber später mehr.

        System.out.println("meine doppelte Eingabe 'a b' welche ich danach Bearbeite");
        String ganzzeiligeEingabe = myScanner.nextLine();

        String[] mehrereStrings = ganzzeiligeEingabe.split(" ");
        meineErsteEingabe = mehrereStrings[0];
        meineErsteEingabe = mehrereStrings[1];

        System.out.println("meine Erste Eingabe: " + meineErsteEingabe + " - und meine zweite Eingabe: " + meineZweiteEingabe);

        // Am Schluss können/müssen wir noch den Scanner "schließen". Bedeutet wir geben die Verbindung zur Console auf und beenden diese.
        // Falls wir hier an einem Server arbeiten oder ein Programm verwenden, welches immer läuft, würde hier immer mehr
        // Ressourcen für offene Verbindungen verwenden. Um dies zu verhindern schreiben wir

        myScanner.close();

        // ACHTUNG! wenn der scanner geschlossen wird, kann die Conole nicht merh verwendet werden!
        // Auch ein neues Anlegen eines scanners mit = new Scanner(System.in) funktioniert dann nicht mehr!
        // Also nur den Scanner schließen wenn wir ihn nicht mehr benötigen!
    }
}
