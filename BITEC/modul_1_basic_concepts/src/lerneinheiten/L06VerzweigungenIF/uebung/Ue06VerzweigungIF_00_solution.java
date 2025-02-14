package lerneinheiten.L06VerzweigungenIF.uebung;

import java.util.Scanner;

public class Ue06VerzweigungIF_00_solution {
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

//        3. - Taschenrechner
//        Erstellen Sie einen einfachen Taschenrechner, der zwei Zahlen und einen Operator (+, -, *, /) akzeptiert und
//        das Ergebnis der Berechnung ausgibt. Verwenden Sie "if"-Anweisungen, um den Operator zu identifizieren
//        und die Berechnung durchzuführen.

        System.out.println("Geben Sie <Zahl><Leerzeichen><Operator><Leerzeichen><Zahl> ein. Ein Operator kann (+, -, *, /) sein.");
        Double a = scanner.nextDouble();
        String operator = scanner.next();
        Double b = scanner.nextDouble();
        scanner.nextLine();

        if (operator.equals("+")) {

            System.out.println(a + " + " + b + " = " + (a + b));

        } else if (operator.equals("-")) {

            System.out.println(a + " - " + b + " = " + (a - b));

        } else if (operator.equals("*")) {

            System.out.println(a + " * " + b + " = " + (a * b));

        } else if (operator.equals("/")) {

            System.out.println(a + " / " + b + " = " + (a / b));

        } else {

            System.out.println("Operator unbekannt!");

        }

//        3.1 - Taschenrechner mit sehr komischen Trennzeichen ...
//        Erstellen Sie einen einfachen Taschenrechner, der zwei Zahlen und einen Operator (+, -, *, /) akzeptiert und
//        das Ergebnis der Berechnung ausgibt. Verwenden Sie "if"-Anweisungen, um den Operator zu identifizieren
//        und die Berechnung durchzuführen.

        System.out.println("Geben Sie <Zahl><HELLO THIS IS PATTERN><Operator><HELLO THIS IS PATTERN><Zahl><HELLO THIS IS PATTERN> ein. Ein Operator kann (+, -, *, /) sein.");
        Scanner aCopyOfAScanner = scanner.useDelimiter("HELLO THIS IS PATTERN"); // hier kann eine regular expresion (REGEX) rein! dazu aber mehr in den nächsten Einheiten!
//        Scanner aCopyOfAScanner = scanner.useDelimiter("HELLO THIS \nIS PATTERN"); // warum geht das nicht?

        a = aCopyOfAScanner.nextDouble();
        operator = aCopyOfAScanner.next();
        b = aCopyOfAScanner.nextDouble();

        if (operator.equals("+")) {

            System.out.println(a + " + " + b + " = " + (a + b));

        } else if (operator.equals("-")) {

            System.out.println(a + " - " + b + " = " + (a - b));

        } else if (operator.equals("*")) {

            System.out.println(a + " * " + b + " = " + (a * b));

        } else if (operator.equals("/")) {

            System.out.println(a + " / " + b + " = " + (a / b));

        } else {

            System.out.println("Operator unbekannt!");

        }

        scanner.close();
        aCopyOfAScanner.close();
    }
}
