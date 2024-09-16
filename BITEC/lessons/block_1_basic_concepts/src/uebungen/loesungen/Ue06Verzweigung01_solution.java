package uebungen.loesungen;

import java.util.Scanner;

public class Ue06Verzweigung01_solution {
    public static void main(String[] args) {
//        Die Eingabe ist über die Konsole zu erfassen.
        Scanner scanner = new Scanner(System.in);

//        1. - Altersüberprüfung:
//        Fordern Sie den Benutzer auf, sein Alter einzugeben. Verwenden Sie eine if-Anweisung, um zu überprüfen,
//        ob die Person volljährig ist (über 18 Jahre). Geben Sie eine Nachricht aus, die besagt, ob die Person volljährig ist oder nicht.
        System.out.print("alter eingeben: ");
        Integer alter = Integer.parseInt( scanner.nextLine() );

        if (alter >= 18) {

            System.out.println("volljährig");

        } else {

            System.out.println("minderjährig");

        }

//        2. - Größer-Kleiner-Vergleich:
//        Fordern Sie den Benutzer auf, zwei Zahlen einzugeben, und verwenden Sie eine if-Anweisung, um zu
//        überprüfen, ob die erste Zahl größer, kleiner oder gleich der zweiten Zahl ist. Geben Sie das Ergebnis aus.
        System.out.println("Sind zwei Zahlen kleiner, größer oder gleich?");
        System.out.print("Erste Zahl: ");
        Double ersteZahl = Double.parseDouble( scanner.nextLine() );

        System.out.print("Zweite Zahl: ");
        Double zweiteZahl = Double.parseDouble( scanner.nextLine() );

        if (ersteZahl > zweiteZahl) {

            System.out.println("Die erste Zahl ist größer als die zweite Zahl.");

        } else if (ersteZahl < zweiteZahl) {

            System.out.println("Die erste Zahl ist kleiner als die zweite Zahl.");

        } else {

            System.out.println("Die erste Zahl ist gleich der zweiten Zahl.");

        }

//        3. - Positiv oder negativ:
//        Fordern Sie den Benutzer auf, eine Zahl einzugeben, und verwenden Sie eine if-Anweisung, um zu
//        überprüfen, ob die Zahl positiv, negativ oder null ist. Geben Sie das Ergebnis aus.
        System.out.print("Zahl positiv, negativ, oder 0?: ");
        Double dritteZahl = Double.parseDouble( scanner.nextLine() );

        if (dritteZahl > 0) {

            System.out.println("Zahl ist größer als 0.");

        } else if (dritteZahl < 0) {

            System.out.println("Zahl ist kleiner als 0.");

        } else {

            System.out.println("Zahl ist gleich 0.");

        }

//        4. - Zahlengleichheit:
//        Fordern Sie den Benutzer auf, zwei Zahlen einzugeben, und verwenden Sie eine if-Anweisung, um zu
//        überprüfen, ob die beiden Zahlen gleich sind. Geben Sie eine Nachricht aus, die angibt, ob die Zahlen gleich
//        sind oder nicht.
        System.out.println("Zwei Zahlen gleich oder nicht?: ");
        System.out.print("Erste Zahl: ");
        Double vierteZahl = Double.parseDouble( scanner.nextLine() );

        System.out.print("Zweite Zahl: ");
        Double fuenfteZahl = Double.parseDouble( scanner.nextLine() );

        if (vierteZahl.equals(fuenfteZahl)) { // oder if (vierteZahl - fuenfterZahl == 0) falls wir "double" und nicht "Double" haben

            System.out.println("Zahlen sind gleich.");

        } else {

            System.out.println("Zahlen sind ungleich.");

        }


//        5. - Kreditwürdigkeitsprüfung:
//        Fordern Sie den Benutzer auf, sein monatliches Einkommen und seine monatlichen Ausgaben einzugeben.
//        Verwenden Sie eine if-Anweisung, um zu überprüfen, ob die Person aufgrund ihres Einkommens und ihrer
//        Ausgaben kreditwürdig ist. Geben Sie eine Nachricht aus, die angibt, ob die Person als kreditwürdig
//        eingestuft wird.
        System.out.print("Einkommen: ");
        Double einkommen = Double.parseDouble( scanner.nextLine() );

        System.out.print("Ausgaben: ");
        Double ausgaben = Double.parseDouble( scanner.nextLine() );

        if (einkommen - ausgaben > 0) {

            System.out.println("Kreditwürdig. Wir sind eine schädlich risikofreudige Bank und deshalb wird uns die Lizenz innerhalb der nächsten 2 Minuten entzogen :(");

        } else {

            System.out.println("Nicht Kreditwürdig.");

        }

//        6. - Wahl des Getränks:
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

//        7. - Schulnoten:
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

//        8. - Jahreszeiten:
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


//        9. - Rabattberechnung:
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

//        10. - Klassifizierung Programmiersprache:
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

//        11. - Teilbar
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

//        12. - Aktuelle Version von Betriebssystem (if, else if, else)
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


//        13. - Uhrzeit
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
    }
}
