package uebungen.loesungen;

import java.util.Scanner;

public class Ue06Verzweigung02_solution {
    public static void main(String[] args) {
        Integer a = 4;
        Integer b = 3;
        Integer c = 3;
        Double d = 4.5;
        Integer e = 1;

        // Die Übung ist im Kopf/am Zettel zu machen!
        // Hier ist nur die Lösung.

        // a != 4
        System.out.println(a != 4);

        // a > b
        System.out.println(a > b);

        // b == c
        System.out.println(b == c);

        // (b+1) == 4
        System.out.println((b+1) == 4);

        // (a/b) == 1
        System.out.println((a/b) == 1);

        // e < c
        System.out.println(e < c);

        // (b/a) > 0
        System.out.println((b/a) > 0);

        // (a%e) != 0
        System.out.println((a%e) != 0);

        // (a > 0) && (a <= 4)
        System.out.println((a > 0) && (a <= 4));

        // !(a<c)
        System.out.println(!(a<c));

//        Vokal?
//        Schreiben Sie ein Java-Programm, das den Benutzer nach einem Buchstaben fragt und überprüft, ob es
//        sich um einen Vokal oder einen Konsonanten handelt. Wenn es ein Vokal ist, gibt das Programm "Das ist ein
//        Vokal" aus, ansonsten "Das ist ein Konsonant".
        Scanner scanner = new Scanner(System.in);

        System.out.print("Gib einen Buchstaben ein um zu überprüfen ob dieser ein Vokal ist: ");
        String userEingabe = scanner.nextLine();

        if (userEingabe.length() != 1) {

            System.err.println("FEHLER! Es wurde nicht nur ein Buchstabe eingegeben!");

        } else {

            if (userEingabe == "a" || userEingabe == "e" || userEingabe == "i" || userEingabe == "o" || userEingabe == "u") {
                System.out.println("Das ist ein Vokal");
            } else {
                System.out.println("Das ist ein Konsonant");
            }

        }

//        Vergleichen von Strings
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


//        Einlesen
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

//        Taschenrechner
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

//        BMI
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

//        Rabattberechnung
//        Eine Firma die Tiernahrung verkauft hat Sie gebeten eine Software zu schreiben, welche den passenden
//        Mengenrabatt bei einer Bestellung berechnet. Ab 10kg soll es einen Rabatt von 10% geben und ab 50kg
//        von 20%. Schreiben Sie ein Programm, welches zunächst den Preis pro Kilogramm und danach die
//        Bestellmenge einließt. Danach soll das Programm den Preis ohne Rabatt, mit Rabatt und die Differenz
//        ausgeben.

        System.out.println("Bitte geben Sie den Preis pro Gewicht des Einkaufs ein [€/kg]: ");
        Double preisProGewicht = Double.parseDouble(scanner.nextLine());

        System.out.println("Bitte geben Sie die Bestellmenge des Einkaufs ein [Stück]: ");
        Double bestellmenge = Double.parseDouble(scanner.nextLine());

        Double gesamtpreis = preisProGewicht * bestellmenge;

        Double gewichtProPreis = 1/preisProGewicht;
        gewicht = gewichtProPreis * gesamtpreis;

        Double rabattInProzent;

        if (10 < gewicht) {
            rabattInProzent = 0.;

        } else if (10 < gewicht && gewicht < 50) {
            rabattInProzent = 0.1;

        } else  { //if (50 < gewicht)
            rabattInProzent = 0.2;

        }

        Double rabatt = gesamtpreis * rabattInProzent;
        Double gesamtpreisMitRabatt = gesamtpreis - rabatt;

        System.out.println("Preis: " + gesamtpreis + ", Rabatt: " + rabatt + ", Neuer Preis: " + gesamtpreisMitRabatt);

//        Schaltjahrberechnung
//        Berechnen Sie, ob das eingegebene Jahr ein Schaltjahr ist. Ein Schaltjahr erfüllt folgende Bedingungen
//        Es ist ein Schaltjahr, wenn die Jahreszahl durch 4 teilbar ist
//        Ist es auch ganzzahlig durch 100 teilbar, so ist es kein Schaltjahr, außer ...
//          - ... das Jahr ist ebenfalls ganzzahlig durch 400 teilbar
//        Beispiel für Schaltjahre: 1808, 1904 2000, 2112, 2244, 2332, 2380, 2400
    }
}
