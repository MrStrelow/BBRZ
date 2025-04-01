package lerneinheiten.L06VerzweigungenUndBedingungenMitIF.uebung.GemischteAufgaben;

import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
//        Die Eingabe ist über die Konsole zu erfassen.
        Scanner scanner = new Scanner(System.in);

//        1. - Wahl des Getränks:
//        Bitten Sie den Benutzer, eine Zahl von 1 bis 3 einzugeben, um ein Getränk auszuwählen
//                (1 = Kaffee, 2 = Tee, 3 = Limonade). Verwenden Sie if-Anweisungen, um das ausgewählte Getränk anzuzeigen.

        System.out.print("Wahl des Getränks (1 = Kaffee, 2 = Tee, 3 = Limonade): ");
        Double getraenkeId = Double.parseDouble( scanner.nextLine() );

        if (getraenkeId == 1) {

            System.out.println("Kaffee");

        } else if (getraenkeId == 2) {

            System.out.println("Tee");

        } else if (getraenkeId == 3) {

            System.out.println("Limonade");

        } else {

            System.out.println("Tut uns leid, das gewünschte Getränk bieten wir nicht an.");

        }

//        2. - Schulnoten:
//        Fordern Sie den Benutzer auf, eine Schulnote zwischen 1 und 5 einzugeben. Verwenden Sie ifAnweisungen, um eine Nachricht anzuzeigen,
//        die angibt, ob die Note "Sehr gut", "Gut", "Befriedigend", "Genügend", oder "Nicht genügend" ist.
        System.out.print("Schulnote (1-5): ");
        Integer schulnote = Integer.parseInt( scanner.nextLine() );

        if (schulnote == 1) {

            System.out.println("Sehr Gut");

        } else if (schulnote == 2) {

            System.out.println("Gut");

        } else if (schulnote == 3) {

            System.out.println("Befriedigend");

        } else if (schulnote == 4) {

            System.out.println("Genügend");

        } else if (schulnote == 5) {

            System.out.println("Nicht Genügend");

        } else {

            System.out.println("Unbekannte Schulnote");

        }

//        3. - Jahreszeiten:
//        Fordern Sie den Benutzer auf, den aktuellen Monat (als Zahl von 1 bis 12) einzugeben, und verwenden Sie
//        if-Anweisungen, um die zugehörige Jahreszeit (Frühling, Sommer, Herbst, Winter) anzuzeigen.
        System.out.print("Jahreszeit (1-12): ");
        Integer jahreszeit = Integer.parseInt( scanner.nextLine() );

        // Zusatzübung: Löse diese Aufgabe mittels modulo, um auch für Winter gleiche Logik verwenden zu können.

        if (jahreszeit >= 3 && jahreszeit <= 5) {

            System.out.println("Frühling");

        } else if (jahreszeit >= 6 && jahreszeit <= 8) {

            System.out.println("Sommer");

        } else if (jahreszeit >= 9 && jahreszeit <= 11) {

            System.out.println("Herbst");

        } else if (jahreszeit == 12 || jahreszeit == 1 || jahreszeit == 2) { // Ohje, andere Logik.
//        } else if (jahreszeit % 12 >= 0 && jahreszeit <= 2 ) { // oder doch nicht?

            System.out.println("Winter");

        } else {

            System.out.println("Unbekannte Jahreszeit");

        }


//        4. - Rabattberechnung:
//        Fordern Sie den Benutzer auf, den Gesamtbetrag eines Einkaufs und einen Rabatt (in %) einzugeben.
//        Verwenden Sie if-Anweisungen, um zu überprüfen, ob der Rabatt positiv ist. Berechnen Sie den endgültigen
//        Betrag nach Anwendung des Rabatts, sofern der Rabatt positiv ist. Ist der Rabatt negativ, soll eine
//        Fehlermeldung ausgegeben werden.
        System.out.print("Gesamtbetrag Rechnung [€]: ");
        Double rechnungsBetrag = Double.parseDouble( scanner.nextLine() );

        System.out.print("Rabatt [%]: ");
        Double rabatt = Double.parseDouble( scanner.nextLine() );

        if (rabatt < 0) {

            System.out.println("Rabatt negativ - Berechnung nicht möglich.");

        } else {

            Double rechnungsBetragReduziert = rechnungsBetrag * ((100 - rabatt) / 100);
            System.out.println("Neuer Rechnungsbetrag abzüglich Rabatt: " + rechnungsBetragReduziert);

        }

//        5. - Klassifizierung Programmiersprache:
//        Abfrage von Programmiersprache in der Konsole (Java/Javascript)
//        Wenn die Eingabe Java ist, soll Kompilierte Sprache
//        Wenn die Eingabe Javascript ist, soll Interpretierte Sprache
//        Andernfalls soll Nicht bekannt ausgegeben werden
        System.out.print("Programmiersprache (Java, Javascript): ");
        String programmiersprache = scanner.nextLine();

        if (programmiersprache.equals("Java")) {

            System.out.println("komplilierte Sprache");

        } else if (programmiersprache.equals("Javascript")) {

            System.out.println("interpretierte Sprache");

        } else {
            System.out.println("unbekannte Sprache");
        }

//        6. - Teilbar
//        Der Benutzer gibt eine ganze Zahl ein, welche in einer Variable gespeichert wird. (siehe Beispiel)
//        Wenn die Zahl durch 2 Teilbar ist, dann soll Zahl X durch 2 teilbar , andernfalls soll Zahl X nicht
//        durch 2 teilbar ausgegeben werden.
//        Erweiterung, sodass der Teiler ebenso abgefragt wird.
//                Teiler eingeben: 3
//                Zahl eingeben: 7
//                Zahl 7 ist nicht durch 3 teilbar
        System.out.print("Ganze Zahl eingeben: ");
        Integer ganzeZahl = Integer.parseInt( scanner.nextLine() );

        System.out.print("Teiler eingeben: ");
        Integer teiler = Integer.parseInt( scanner.nextLine() );

        if (ganzeZahl % teiler == 0)
            System.out.println("Zahl " + ganzeZahl + " durch " + teiler + " teilbar.");

        else
            System.out.println("Zahl " + ganzeZahl + " NICHT durch " + teiler + " teilbar.");

//        7. - Aktuelle Version von Betriebssystem (if, else if, else)
//        Abfrage von Betriebssystem (iPhone, Android, Windows, MacOS)
//        Ausgabe des Betriebsystems aufgrund vom Betriebssytem-String
//        iPhone: iOS 16
//        Android: Android 13
//        Windows: Windows 11
//        MacOS: macOS Venttura

        String betriebssystem = System.getProperty("os.name");

        if (betriebssystem.equals("Windows 11"))
            System.out.println("Windows");

        else if (betriebssystem.equals("Android 13"))
            System.out.println("Android");

        else if (betriebssystem.equals("iOS 16"))
            System.out.println("iPhone");

        else if (betriebssystem.equals("macOS Venttura"))
            System.out.println("MacOS");

        else
            System.out.println("Unbekanntes oder nicht aktuelles Betriebssystem.");


//        8. - Uhrzeit
//        Abfrage von Uhrzeit Stunden und Minuten in der Konsole
//        Wenn Uhrzweit zwischen 11:30 und 12:30 ist, dann soll Mittagspause auf die Konsole ausgegeben
//        werden. Andernfalls soll Arbeitszeit ausgegeben werden.
        Scanner colonScanner = scanner.useDelimiter(":|\n"); //RegEx: doppelpunkt oder \n soll als Trennzeichen akzeptiert werden
        Boolean mittagspause = false;

        System.out.print("Uhrzeit in <Stunden><:><Minuten> angeben: ");
        Integer stunden = colonScanner.nextInt();
        Integer minuten = colonScanner.nextInt();

        if ( stunden == 11 && minuten >= 30 && minuten <= 59 )
            mittagspause = true;

        if ( stunden == 12 && minuten < 30 && minuten >= 0 )
            mittagspause = true;

        if (mittagspause)
            System.out.println("Mittagspause!");
        else
            System.out.println("Von 08:00 - 11:30 und 12:30 - 17:00 ist Arbeitszeit.");

//        9. - Vokal?
//        Schreiben Sie ein Java-Programm, das den Benutzer nach einem Buchstaben fragt und überprüft, ob es
//        sich um einen Vokal oder einen Konsonanten handelt. Wenn es ein Vokal ist, gibt das Programm "Das ist ein
//        Vokal" aus, ansonsten "Das ist ein Konsonant".

        System.out.print("Gib einen Buchstaben ein um zu überprüfen ob dieser ein Vokal ist: ");
        String userinput = scanner.nextLine().toLowerCase();

        // Variante 1
        Integer userCharInput = (int) userinput.charAt(0);
        if (97 <= userCharInput && userCharInput <= (97 + 26) && userinput.length() == 1) {
            if (
                    userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
                            userinput.equals("o") || userinput.equals("u")
            ) {
                System.out.println("Usereingabe ist ein Vokal.");

            } else {
                System.out.println("Usereingabe ist ein Konsonant.");
            }
        } else {
            System.out.println("Fehlerhafte Eingabe.");
        }

        // Variante 2
        if (Character.isLetter(userCharInput) && userinput.length() == 1) {
            if (
                    userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
                            userinput.equals("o") || userinput.equals("u")
            ) {
                System.out.println("Usereingabe ist ein Vokal.");
            } else {
                System.out.println("Usereingabe ist ein Konsonant.");
            }
        } else {
            System.out.println("Fehlerhafte Eingabe.");
        }

        // Variante 3
        if (
                userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
                        userinput.equals("o") || userinput.equals("u")
        ) {
            System.out.println("Usereingabe ist ein Vokal.");

        } else if(
                userinput.equals("b") || userinput.equals("c") || userinput.equals("d") ||
                        userinput.equals("f") || userinput.equals("g") || userinput.equals("h") ||
                        userinput.equals("j") || userinput.equals("k") || userinput.equals("l") ||
                        userinput.equals("m") || userinput.equals("n") || userinput.equals("p") ||
                        userinput.equals("q") || userinput.equals("r") || userinput.equals("s") ||
                        userinput.equals("t") || userinput.equals("v") || userinput.equals("w") ||
                        userinput.equals("x") || userinput.equals("y") || userinput.equals("z")
        ) {
            System.out.println("Usereingabe ist ein Konsonant.");

        } else {
            System.out.println("Usereingabe ist ein Konsonant.");
        }

        // Variante 4 - Guard Clause - basierend auf Variante 2
        // Guards: beschütze gegen ungewünschte Logik
        if (!Character.isLetter(userCharInput)) {
            System.out.println("Fehlerhafte Eingabe.");
            return;
        }

        if (userinput.length() != 1) {
            System.out.println("Fehlerhafte Eingabe.");
            return;
        }

        // Business Logic: gewünschte Logik
        if (
                userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
                        userinput.equals("o") || userinput.equals("u")
        ) {
            System.out.println("Usereingabe ist ein Vokal.");
        } else {
            System.out.println("Usereingabe ist ein Konsonant.");
        }

//        10. - Vergleichen von Strings
//        Speichern Sie die zwei String "abc" und "Hallo" in zwei Variablen str1 und str2
//        Mit str1.length() bzw str2.length() bekommt man die Anzahl der Zeichen
//        Erstellen Sie eine Ausgabe abhängig von den Längen der Variablen:
//        Wenn str1 länger als str2 ist: "str1 ist Länger mit dem Wert ..."
//        Wenn str2 länger als str1 ist: "str2 ist Länger mit dem Wert ..."
//        Sonst sind beide Variablen gleich str1 und str2 sind gleich lang
        String str1 = "abc";
        String str2 = "Hallo";

        if (str1.length() > str2.length()) {
            System.out.println("str1 ist Länger mit dem Wert ...");

        } else if (str2.length() > str1.length()) {
            System.out.println("str2 ist Länger mit dem Wert ...");

        } else {
            System.out.println("str2 ist Länger mit dem Wert ...");
        }


//        11. - Einlesen
//        Schreiben Sie ein Programm, bei welchem Sie zwei Zahlen einlesen können. Ihr Programm soll anschließend
//        ausgeben, welche der beiden Zahlen die größte und welche die kleinste Zahl ist. Falls gleiche Zahlen
//        eingegeben worden sind, so soll diese Zahl ebenfalls ausgegeben werden.

        Integer ersteZahl = scanner.nextInt();
        Integer zweiteZahl = scanner.nextInt();

        if (ersteZahl > zweiteZahl) {
            System.out.println("größte Zahl: " + ersteZahl + ", kleinste Zahl: " + zweiteZahl);
        } else if (zweiteZahl > ersteZahl) {
            System.out.println("größte Zahl: " + zweiteZahl + ", kleinste Zahl: " + ersteZahl);
        } else {
            System.out.println("Beide sind gleich.");
        }

        // nur um "\n" aufzufangen.
        scanner.nextLine();

//        12. - Taschenrechner
//        Das Programm soll zwei Zahlen und einen Operator (+,-,/,*) einlesen und abhängig vom gewählten Operator
//        die gewünschte Rechenoperation ausführen.
//        Beispiel:
//        Geben Sie die erste Zahl ein: 10
//        Geben Sie die zweite Zahl ein: 3
//        Geben Sie die die Rechenoperation ein: -
//        Das Ergebnis von 10 - 3 ergibt 7
        System.out.print("Geben Sie die erste Zahl ein: ");
        Double x = Double.parseDouble(scanner.nextLine());

        System.out.print("Geben Sie die zweite Zahl ein: ");
        Double y = Double.parseDouble(scanner.nextLine());

        System.out.println("Geben Sie die Rechenoperation ein: ");
        String operand = scanner.nextLine();

        Double ergebnis = 0.;

        if (operand.equals("+")) {
            ergebnis = x + y;

        } else if (operand.equals("-")) {
            ergebnis = x - y;

        } else if (operand.equals("*")) {
            ergebnis = x * y;

        } else if (operand.equals("/")) {
            ergebnis = x / y;

        } else {
            System.out.println("ungültige Operation.");
        }

        System.out.println("Das Ergebnis von " + x + " " + operand + " " + y + " = " + ergebnis);

//        13. - BMI
//        Für die Berechnung des Body-Mass-Index (BMI) sollen Sie ein Programm schreiben. Der Body-Mass- Index
//        dient als Maß zur generellen Beurteilung des Körpergewichts. Der Index gibt das Verhältnis des
//        Körpergewichts G (kg) zu der Größe h (m) an. Er kann mit der folgenden Formel berechnet werden:
//        BMI = G / h^2
//        Beurteilung:
//        < 20 Untergewicht
//        20 <= BMI < 25 Normalgewicht
//        25 <= BMI < 30 Übergewicht
//        30 <= BMI < 40 starkes Übergewicht
//        BMI >= 40 extremes Übergewicht
//
//        Mögliche Programmausgabe:
//        Weight (kg): 55
//        Height (m): 1.6
//        BMI = 21.48437499999 > Du hast Normalgewicht

        System.out.println("Gewicht [kg]");
        Double gewicht = Double.parseDouble(scanner.nextLine());

        System.out.println("Größe [m]");
        Double groesse = Double.parseDouble(scanner.nextLine());

//        Double bmi = gewicht / (groesse * groesse);
        Double bmi = gewicht / Math.pow(groesse, 2);

        System.out.print("BMI: " + bmi);

        if (bmi < 20) {
            System.out.println(" - Untergewicht.");
        } else if (20 <= bmi && bmi <= 25) {
            System.out.println(" - Normalgewicht.");
        } else if (25 <= bmi && bmi <= 30) {
            System.out.println(" - Übergewicht.");
        } else if (30 <= bmi && bmi <= 40) {
            System.out.println(" - starkes Übergewicht.");
        } else if (40 < bmi) {
            System.out.println(" - extremes Übergewicht.");
        }

//        14. - Rabattberechnung
//        Eine Firma die Tiernahrung verkauft hat Sie gebeten eine Software zu schreiben, welche den passenden
//        Mengenrabatt bei einer Bestellung berechnet. Ab 10kg soll es einen Rabatt von 10% geben und ab 50kg
//        von 20%. Schreiben Sie ein Programm, welches zunächst den Preis pro Kilogramm und danach die
//        Bestellmenge einließt. Danach soll das Programm den Preis ohne Rabatt, mit Rabatt und die Differenz
//        ausgeben.

        System.out.println("Bitte geben Sie den Preis pro Gewicht des Einkaufs ein [€/kg]: ");
        Double preisProGewicht = Double.parseDouble(scanner.nextLine());

        // bestellmenge sind die kg! also "bestellmenge = gewicht"!
        System.out.println("Bitte geben Sie die Bestellmenge des Einkaufs ein [kg]: ");
        Double bestellmenge = Double.parseDouble(scanner.nextLine());
        Double gesamtpreis = preisProGewicht * bestellmenge; // [€/kg]*[kg] -> [€]

        Double rabattInProzent;

        if (10 < bestellmenge) {
            rabattInProzent = 0.;

        } else if (10 < bestellmenge && bestellmenge < 50) {
            rabattInProzent = 0.1;

        } else  { //if (50 < bestellmenge)
            rabattInProzent = 0.2;

        }

        rabatt = gesamtpreis * rabattInProzent;
        Double gesamtpreisMitRabatt = gesamtpreis - rabatt;

        System.out.println("Preis: " + gesamtpreis + ", Rabatt: " + rabatt + ", Neuer Preis: " + gesamtpreisMitRabatt);

//        15. - Schaltjahrberechnung
//        Berechnen Sie, ob das eingegebene Jahr ein Schaltjahr ist. Ein Schaltjahr erfüllt folgende Bedingungen
//        Es ist ein Schaltjahr, wenn die Jahreszahl durch 4 teilbar ist
//        Ist es auch ganzzahlig durch 100 teilbar, so ist es kein Schaltjahr, außer ...
//          - ... das Jahr ist ebenfalls ganzzahlig durch 400 teilbar
//        Beispiel für Schaltjahre: 1808, 1904, 2000, 2112, 2244, 2332, 2380, 2400
//          Kein Schaltjahr: 2100 (durch 4 teilbar, durch 100, und nicht durch 400)

        System.out.print("Geben sie ein Jahr ein um zu überprüfen ob es ein Schaltjahr ist: ");
        Integer jahr = Integer.parseInt(scanner.nextLine());

        if (jahr % 4 == 0) {

            if (jahr % 100 == 0) {

                if (jahr % 400 == 0) {
                    System.out.println("Schaltjahr, da durch 4 und durch 400 teilbar.");
                } else {
                    System.out.println("Kein Schaltjahr, da durch 100, jedoch nicht durch 400 teilbar.");
                }

            } else {

                System.out.println("Schaltjahr, da durch 4 Teilbar aber nicht durch 100.");

            }

        } else {

            System.out.println("Kein Schaltjahr, da nicht durch 4 teilbar.");

        }

        // 16. - Alter prüfen
        System.out.print("Geben Sie Ihr Alter ein: ");
        int alter = scanner.nextInt();
        if (alter < 0) {
            System.out.println("Fehlermeldung: Alter kann nicht negativ sein.");
        } else if (alter >= 18 && alter <= 65) {
            System.out.println("Sie sind im erwerbsfähigen Alter.");
        } else {
            System.out.println("Sie sind nicht im erwerbsfähigen Alter.");
        }

        // 16. - Mindestens eine Zahl > 10
        System.out.print("Geben Sie die erste Zahl ein: ");
        int zahl1 = scanner.nextInt();
        System.out.print("Geben Sie die zweite Zahl ein: ");
        int zahl2 = scanner.nextInt();
        if (zahl1 > 10 || zahl2 > 10) {
            System.out.println("Mindestens eine der eingegebenen Zahlen ist größer als 10.");
        } else {
            System.out.println("Keine der eingegebenen Zahlen ist größer als 10.");
        }

        // 17. - Gerade oder beide ungerade
        System.out.print("Geben Sie die erste Zahl ein: ");
        int num1 = scanner.nextInt();
        System.out.print("Geben Sie die zweite Zahl ein: ");
        int num2 = scanner.nextInt();
        if (num1 % 2 == 0 || num2 % 2 == 0 || (num1 % 2 != 0 && num2 % 2 != 0)) {
            System.out.println("Mindestens eine der Zahlen ist gerade oder beide sind ungerade.");
        } else {
            System.out.println("Keine der Zahlen ist gerade oder beide sind gerade.");
        }

        // 18. - Vokal, Konsonant oder Zahl prüfen
        System.out.print("Geben Sie einen Buchstaben oder eine Zahl ein: ");
        char zeichen = scanner.next().charAt(0);
        if (Character.isDigit(zeichen)) {
            System.out.println("Die Eingabe " + zeichen + " ist eine Zahl.");
        } else {
            char lowerChar = Character.toLowerCase(zeichen);
            if (lowerChar == 'a' || lowerChar == 'e' || lowerChar == 'i' || lowerChar == 'o' || lowerChar == 'u') {
                System.out.println("Die Eingabe " + zeichen + " ist ein Vokal.");
            } else if (lowerChar == 'b' || lowerChar == 'c' || lowerChar == 'd' || lowerChar == 'f' || lowerChar == 'g' ||
                    lowerChar == 'h' || lowerChar == 'j' || lowerChar == 'k' || lowerChar == 'l' || lowerChar == 'm' ||
                    lowerChar == 'n' || lowerChar == 'p' || lowerChar == 'q' || lowerChar == 'r' || lowerChar == 's' ||
                    lowerChar == 't' || lowerChar == 'v' || lowerChar == 'w' || lowerChar == 'x' || lowerChar == 'y' ||
                    lowerChar == 'z') {
                System.out.println("Die Eingabe " + zeichen + " ist ein Konsonant.");
            } else {
                System.out.println("Die Eingabe " + zeichen + " ist unbekannt.");
            }
        }

        scanner.close();
    }
}
