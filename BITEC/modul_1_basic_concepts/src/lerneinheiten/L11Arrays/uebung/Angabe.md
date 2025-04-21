// Pakete einlagern
// Erstellen Sie einen String mit dem Inhalt ``"📦📦📦📦📦"``. Es sollen nun nach Benutzereingaben in leere Pakete Produkte eingelagert und entnommen werden können. Die Identifikation passiert über eine **Paketnummer**. Der String hat 5 leere Plätze mit den Indizes ``0, 1, 2, 3, 4``. (📦 bedeutet, dass der Platz leer ist.)
// * Legen Sie den ``String storage`` mit ``"📦📦📦📦📦"`` an.
// * Fragen Sie den Benutzer, welche Aktion er ausführen möchte. Geben Sie hierzu folgende Optionen:
//     * einlagern, auslagern, beenden
// * Nach der Wahl der Option, soll die **Paketnummer** angegeben werden. Es soll dieser **Paketnummer** eines einer der 10 verschiedene **Produkte** (``{0:"🌂", 1:"🧯", 2:"🧺", 3:"🧹", 4:"🪒", 5:"🧼", 6:"🪞", 7:"🚽", 8:"🪠", 9:"💍"}``) zugewisen werden. Die Zahlen in der Auflistung sind die **Produktnummern**. Diese ändern sich nicht.
// * Überschreiben den nächsten freien Platz mit dem Produkte anhand folgender Logik:
//     * einlagern: das erste 📦 wird durch die **Paketnummer** identifiziert und der user wird gefragt welches Produkt er will. Dazu gibt dieser die **Produktnummer** an. Gibt es keinen freien Platz mehr, so wird eine Meldung ausgegeben.
//     * auslagern: das Produkt welches über die Produktnummer identifiziert wird, wird durch 📦 ersetzt.
//     * beenden: beendet das Programm.
// * Geben Sie in jedem Schleifendurchlauf die Variable storage aus.
// Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.
// *Hinweis: Lege folgenden String an ``String produkte = "🌂🧯🧺🧹🪒🧼🪞🚽🪠💍"`` und lass die Benutzer die Position des Strings eingeben. Nehen wir an die Postion ist 4, wir schreiben ``int wahlDesUsersAlsUnicode = produkte.codePointAt(4)`` um den Unicode davon zu bekommen. Dieser ist im Dezimalsystem. Wir können mit``String produkt = new String(Character.toChars(wahlDesUsersAlsUnicode))`` einen String machen welchen wir direkt verwenden können.*.
// **Frage:** Warum funktioniert hier nicht ``produkte.charAt(4)``? (Siehe [L02](../../L02VariablenErstellen/skripten/L02VariablenErstellen.md))
// * Was gibt von charAt() für einen Typ zurück?
// * Wie viele Bits bzw. Hex-Bits hat ein Character zur Verfügung?
// * Was ist der Unicode von 🌂 ``int unicode = produkte.codePointAt(0)`` ?
// * Wandle diese Zahl in eine Hexadezimalzahl um. (``String hexNumber = Integer.toHexString(unicode))``)
// * Wie viele ist Hex-Bits hat ``hexNumber``?
// Beispiel:
// Willkommen: Wie groß ist das Lager [ganze Zahl]? 5
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 2425 2
// 🧯📦📦📦📦
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 6472115482 6
// 🧯🧼📦📦📦
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1 6
// 🧯🧼💍📦📦
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): auslagern
// Geben Sie die Paketnummer ein: 2425
// 📦🧼💍📦📦
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1 8
// Paketnummer bereits vergeben!
// 📦🧼💍📦📦
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 13884 8
// 🪠🧼💍📦📦
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1388451 8
// 🪠🧼💍🪠📦
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 16 8
// 🪠🧼💍🪠🪠
// Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern
// Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 999 8
// Lager ist Voll. Wir melden uns wenn dieses frei ist.
// 🪠🧼💍🪠🪠
String[] produkte = {"🌂", "🧯", "🧺", "🧹", "🪒", "🧼", "🪞", "🚽", "🪠", "💍"};

        System.out.print("Willkommen: Wie groß ist das Lager [ganze Zahl]? ");
        int groesse = scanner.nextInt();
        scanner.nextLine();

        String[] lager = new String[groesse];
        String[] paketnummern = new String[groesse];

        for (int i = 0; i < groesse; i++) {
            lager[i] = "📦";
            paketnummern[i] = null;
        }

        System.out.println();

        while (true) {
            System.out.print("Wählen Sie eine Aktion (einlagern, auslagern, beenden): ");
            String aktion = scanner.nextLine();

            if (aktion.equals("beenden")) {
                System.out.println("Programm beendet.");
                break;
            } else if (aktion.equals("einlagern")) {
                System.out.print("Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: ");
                String[] eingabe = scanner.nextLine().split(" ");

                if (eingabe.length != 2) {
                    System.out.println("Ungültige Eingabe. Bitte genau zwei Werte angeben.");
                    continue;
                }

                String paketnummer = eingabe[0];
                int produktnummer;

                try {
                    produktnummer = Integer.parseInt(eingabe[1]);
                } catch (NumberFormatException e) {
                    System.out.println("Produktnummer muss eine Zahl sein.");
                    continue;
                }

                if (produktnummer < 0 || produktnummer >= produkte.length) {
                    System.out.println("Ungültige Produktnummer.");
                    continue;
                }

                // Prüfe auf doppelte Paketnummer
                boolean bereitsVergeben = false;
                for (String pnr : paketnummern) {
                    if (paketnummer.equals(pnr)) {
                        bereitsVergeben = true;
                        break;
                    }
                }

                if (bereitsVergeben) {
                    System.out.println("Diese Paketnummer ist bereits vergeben.");
                    continue;
                }

                // Einlagern
                boolean eingelagert = false;
                for (int i = 0; i < groesse; i++) {
                    if (lager[i].equals("📦")) {
                        lager[i] = produkte[produktnummer];
                        paketnummern[i] = paketnummer;
                        eingelagert = true;
                        break;
                    }
                }

                if (!eingelagert) {
                    System.out.println("Lager ist voll. Wir melden uns, wenn es wieder Platz gibt.");
                }

            } else if (aktion.equals("auslagern")) {
                System.out.print("Geben Sie die Paketnummer ein: ");
                String paketnummer = scanner.nextLine();

                boolean gefunden = false;
                for (int i = 0; i < groesse; i++) {
                    if (paketnummer.equals(paketnummern[i])) {
                        lager[i] = "📦";
                        paketnummern[i] = null;
                        gefunden = true;
                        System.out.println("Paket " + paketnummer + " wurde ausgelagert.");
                        break;
                    }
                }

                if (!gefunden) {
                    System.out.println("Diese Paketnummer wurde nicht gefunden.");
                }

            } else {
                System.out.println("Ungültige Aktion.");
            }

            // Lageranzeige
            System.out.print("Lager: ");
            for (String fach : lager) {
                System.out.print(fach + " ");
            }

        }

        System.out.println();


## Pakete einlagern
Erstellen Sie einen String mit dem Inhalt ``"📦📦📦📦📦"``. Es sollen nun nach Benutzereingaben in leere Pakete Produkte eingelagert und entnommen werden können. Die Identifikation passiert über eine **Paketnummer**. Der String hat 5 leere Plätze mit den Indizes ``0, 1, 2, 3, 4``. (📦 bedeutet, dass der Platz leer ist.)
* Legen Sie den ``String storage`` mit ``"📦📦📦📦📦"`` an.
* Fragen Sie den Benutzer, welche Aktion er ausführen möchte. Geben Sie hierzu folgende Optionen:
    * einlagern, auslagern, beenden

* Nach der Wahl der Option, soll die **Paketnummer** angegeben werden. Es soll dieser **Paketnummer** eines einer der 10 verschiedene **Produkte** (``{0:"🌂", 1:"🧯", 2:"🧺", 3:"🧹", 4:"🪒", 5:"🧼", 6:"🪞", 7:"🚽", 8:"🪠", 9:"💍"}``) zugewisen werden. Die Zahlen in der Auflistung sind die **Produktnummern**. Diese ändern sich nicht.
* Überschreiben den nächsten freien Platz mit dem Produkte anhand folgender Logik:
    * einlagern: das erste 📦 wird durch die **Paketnummer** identifiziert und der user wird gefragt welches Produkt er will. Dazu gibt dieser die **Produktnummer** an. Gibt es keinen freien Platz mehr, so wird eine Meldung ausgegeben.
    * auslagern: das Produkt welches über die Produktnummer identifiziert wird, wird durch 📦 ersetzt.
    * beenden: beendet das Programm.

* Geben Sie in jedem Schleifendurchlauf die Variable storage aus.

Erweitere das Programm so, dass der Benutzer die bisherige Grenze von 5 beliebig anpassen kann.

*Hinweis: Lege folgenden String an ``String produkte = "🌂🧯🧺🧹🪒🧼🪞🚽🪠💍"`` und lass die Benutzer die Position des Strings eingeben. Nehen wir an die Postion ist 4, wir schreiben ``int wahlDesUsersAlsUnicode = produkte.codePointAt(4)`` um den Unicode davon zu bekommen. Dieser ist im Dezimalsystem. Wir können mit``String produkt = new String(Character.toChars(wahlDesUsersAlsUnicode))`` einen String machen welchen wir direkt verwenden können.*.

**Frage:** Warum funktioniert hier nicht ``produkte.charAt(4)``? (Siehe [L02](../../L02VariablenErstellen/skripten/L02VariablenErstellen.md))
* Was gibt von charAt() für einen Typ zurück?
* Wie viele Bits bzw. Hex-Bits hat ein Character zur Verfügung?
* Was ist der Unicode von 🌂 ``int unicode = produkte.codePointAt(0)`` ?
* Wandle diese Zahl in eine Hexadezimalzahl um. (``String hexNumber = Integer.toHexString(unicode))``)
* Wie viele ist Hex-Bits hat ``hexNumber``?

Beispiel:
```
Willkommen: Wie groß ist das Lager [ganze Zahl]? 5 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 2425 2 
🧯📦📦📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 6472115482 6 
🧯🧼📦📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1 6 
🧯🧼💍📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): auslagern 
Geben Sie die Paketnummer ein: 2425
📦🧼💍📦📦 
 
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1 8 
Paketnummer bereits vergeben!
📦🧼💍📦📦

Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 13884 8 
🪠🧼💍📦📦 

Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 1388451 8 
🪠🧼💍🪠📦 
[
Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an Paketnummer Produktnummer]: 16 8 
🪠🧼💍🪠🪠

Wählen Sie eine Aktion (einlagern, auslagern, beenden): einlagern 
Geben Sie die Paketnummer sowie Produktnummer an [Paketnummer Produktnummer]: 999 8 
Lager ist Voll. Wir melden uns wenn dieses frei ist.
🪠🧼💍🪠🪠
```


### Tic Tac Toe
Implementieren Sie ein Tic Tac Toe-Spiel mit do-while:
- X und O abwechselnd setzen
- Spielbrett nach jedem Zug ausgeben
- Spielende bei Sieg oder Unentschieden

Beispiel:
```
-------------
| X | X | X |
-------------
|   | O |   |
-------------
|   |   | O |
-------------
```

// Tic Tac Toe
            // Implementieren Sie ein Tic Tac Toe-Spiel mit do-while:
            // - X und O abwechselnd setzen
            // - Spielbrett nach jedem Zug ausgeben
            // - Spielende bei Sieg oder Unentschieden
            // Beispiel:
            // -------------
            // | X | X | X |
            // -------------
            // |   | O |   |
            // -------------
            // |   |   | O |
            // -------------

            import java.util.Scanner;

public class TicTacToe {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char[][] brett = {
                {' ', ' ', ' '},
                {' ', ' ', ' '},
                {' ', ' ', ' '}
        };

        char aktuellerSpieler = 'X';
        boolean spielBeendet = false;
        int zuege = 0;

        do {
            // Spielfeld anzeigen
            zeigeBrett(brett);

            // Eingabe abfragen
            System.out.println("Spieler " + aktuellerSpieler + ", gib deine Position ein (Zeile 1-3 und Spalte 1-3):");
            int zeile = 0;
            int spalte = 0;
            boolean gueltigeEingabe = false;

            while (!gueltigeEingabe) {
                System.out.print("Zeile: ");
                zeile = scanner.nextInt() - 1;

                System.out.print("Spalte: ");
                spalte = scanner.nextInt() - 1;

                if (zeile >= 0 && zeile < 3 && spalte >= 0 && spalte < 3 && brett[zeile][spalte] == ' ') {
                    gueltigeEingabe = true;
                } else {
                    System.out.println("Ungültige Eingabe. Feld ist belegt oder außerhalb des Bereichs.");
                }
            }

            // Spielzug setzen
            brett[zeile][spalte] = aktuellerSpieler;
            zuege++;

            // Sieg prüfen
            if (hatGewonnen(brett, aktuellerSpieler)) {
                zeigeBrett(brett);
                System.out.println("Spieler " + aktuellerSpieler + " hat gewonnen!");
                spielBeendet = true;
            } else if (zuege == 9) {
                zeigeBrett(brett);
                System.out.println("Unentschieden!");
                spielBeendet = true;
            } else {
                // Spieler wechseln
                aktuellerSpieler = (aktuellerSpieler == 'X') ? 'O' : 'X';
            }

        } while (!spielBeendet);

        scanner.close();
    }

    // Spielfeld anzeigen
    public static void zeigeBrett(char[][] brett) {
        System.out.println("-------------");
        int i = 0;
        while (i < 3) {
            int j = 0;
            System.out.print("|");
            while (j < 3) {
                System.out.print(" " + brett[i][j] + " |");
                j++;
            }
            System.out.println();
            System.out.println("-------------");
            i++;
        }
    }

    // Gewinn prüfen
    public static boolean hatGewonnen(char[][] b, char sp) {
        int i = 0;
        while (i < 3) {
            if (b[i][0] == sp && b[i][1] == sp && b[i][2] == sp) return true; // Zeile
            if (b[0][i] == sp && b[1][i] == sp && b[2][i] == sp) return true; // Spalte
            i++;
        }
        if (b[0][0] == sp && b[1][1] == sp && b[2][2] == sp) return true;     // Diagonale \
        if (b[0][2] == sp && b[1][1] == sp && b[2][0] == sp) return true;     // Diagonale /
        return false;
    }
}
