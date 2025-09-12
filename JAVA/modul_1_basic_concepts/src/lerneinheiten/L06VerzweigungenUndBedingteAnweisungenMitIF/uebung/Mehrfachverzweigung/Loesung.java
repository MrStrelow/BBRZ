package lerneinheiten.L06VerzweigungenUndBedingteAnweisungenMitIF.uebung.Mehrfachverzweigung;

import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
//        1. - Laune der Wochentage
//        Wir haben Wochentage `[Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]`:
//        - Wenn eine Integer-Variable, welche der User eingibt, gleich `1` ist, dann gib `Montag` aus.
//        - Andernfalls, wenn die Integer-Variable gleich `2` ist, dann gib `Dienstag` aus.
//        - Dies geht weiter bis `7`, bei dem `Sonntag` ausgegeben wird.
//        - Wenn wir `Freitag` ausgeben, fügen wir `:)` hinzu.
//        - Wenn wir `Montag` ausgeben, fügen wir `:(` hinzu.
        System.out.print("Geben Sie eine Zahl zwischen 1 und 7 ein um einen Wochentag zu erhalten: ");
        Scanner scanner = new Scanner(System.in);
        Integer input = Integer.parseInt(scanner.nextLine());

        if (input == 1) {
            System.out.print("Montag :(");
        } else if (input == 2) {
            System.out.print("Dienstag");
        } else if (input == 3) {
            System.out.print("Mittwoch");
        } else if (input == 4) {
            System.out.print("Donnerstag");
        } else if (input == 5) {
            System.out.print("Freitag :)");
        } else if (input == 6) {
            System.out.print("Samstag");
        } else if (input == 7) {
            System.out.print("Sonntag");
        } else {
            System.out.print("Kein Wochentag.");
        }

//        Erweitere das vorherige Programm:
//        - `Montag` hat eine Chance von 80%, *fünfmal* `:(` hinzuzufügen.
//        - `Freitag` hat eine Chance von 30%, *siebenmal* `:)` hinzuzufügen.
//        - Jeder Tag hat eine Chance von 1%, dass ein zusätzlicher `:)` hinzugefügt wird.
        Double zufallszahl = Math.random();
        Double zufallszahlJederTag = Math.random();
        // oder verwende Random random = new Random();
        // Double zufallszahl = random.next();

        String output;

        if (input == 1) {
            output = "Montag :(";

            if (zufallszahl < 0.8) {
                output = output + ":(".repeat(5);
            }

        } else if (input == 2) {
            output = "Dienstag";

        } else if (input == 3) {
            output = "Mittwoch";

        } else if (input == 4) {
            output = "Donnerstag";

        } else if (input == 5) {
            output = "Freitag :)";

            if (zufallszahl < 0.3) {
                output = output + ":)".repeat(7);
            }

        } else if (input == 6) {
            output = "Samstag";

        } else if (input == 7) {
            output = "Sonntag";

        } else {
            output = "";
            System.out.println("Kein Wochentag.");
        }

        if (zufallszahlJederTag < 0.01) {
            System.out.print(output + ":)");
        } else {
            System.out.println(output);
        }

//        oder verwende einen If-Ausdruck
//        System.out.println(zufallszahlJederTag < 0.01 ? output + ":)" : output );

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

//        4. - Größer-Kleiner-Vergleich:
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

//        5. - Positiv oder negativ:
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

        scanner.close();
        aCopyOfAScanner.close();
    }
}
