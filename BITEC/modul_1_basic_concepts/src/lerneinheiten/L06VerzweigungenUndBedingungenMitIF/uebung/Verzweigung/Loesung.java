package lerneinheiten.L06VerzweigungenUndBedingungenMitIF.uebung.Verzweigung;

import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
//        Alle Eingaben sollen über die Konsole erfolgen
        Scanner scanner = new Scanner(System.in);

//        1. - Zahlen addieren oder multiplizieren
//        Schreiben Sie ein Programm, das zwei Zahlen entgegennimmt. Wenn die Summe der beiden Zahlen größer
//        als 100 ist, geben Sie die Multiplikation der beiden Zahlen aus, andernfalls geben Sie die Addition aus.
        System.out.print("Erste Zahl: ");
        Double ersterDouble = Double.parseDouble( scanner.nextLine() );

        System.out.print("Zweite Zahl: ");
        Double zweiterDouble = Double.parseDouble( scanner.nextLine() );

        Double summe = ersterDouble + zweiterDouble;
        Double schwelle = 100.d;

        if (summe > schwelle) {

            Double multiplikation = ersterDouble * zweiterDouble;
            System.out.println("Die Multiplikation der eingegebenen Zahlen ist " + multiplikation);

        } else {

            System.out.println("Die Summe (Addition) der eingegebenen Zahlen ist " + summe);

        }

//        2. - Teilbarkeit
//        Schreiben Sie ein Programm, das überprüft, ob eine gegebene Zahl durch 5 teilbar ist, und geben Sie
//        entsprechende Meldungen aus.

        Integer teiler = 5;
        System.out.print("Ist diese Zahl durch " + teiler + " teilbar?: ");
        Double kandidatTeilbarkeit = Double.parseDouble( scanner.nextLine() );

        if (kandidatTeilbarkeit % teiler == 0) {

            System.out.println(":) " + kandidatTeilbarkeit + " IST durch " + teiler + "teilbar.");

        } else {

            System.out.println(":( " + kandidatTeilbarkeit + "ist NICHT durch " + teiler + "teilbar.");

        }

//        3. - Altersüberprüfung:
//        Fordern Sie den Benutzer auf, sein Alter einzugeben. Verwenden Sie eine if-Anweisung, um zu überprüfen,
//        ob die Person volljährig ist (über 18 Jahre). Geben Sie eine Nachricht aus, die besagt, ob die Person volljährig ist oder nicht.
        System.out.print("alter eingeben: ");
        Integer alter = Integer.parseInt( scanner.nextLine() );

        if (alter >= 18) {

            System.out.println("volljährig");

        } else {

            System.out.println("minderjährig");

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

    }
}
