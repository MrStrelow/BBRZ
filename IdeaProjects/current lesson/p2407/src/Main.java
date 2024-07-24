import java.util.Random;
import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    public static void main(String[] args) {
        // 1 )
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.

        Scanner myScanner = new Scanner(System.in);

        System.out.println("Eingabe 1-7: ");
        Integer input = Integer.parseInt(myScanner.nextLine());
//
//        if (input == 1) {
//            System.out.println("Montag" + ":(");
//
//        } else if (input == 2) {
//            System.out.println("Dienstag");
//
//        } else if (input == 3) {
//            System.out.println("Mittwoch");
//
//        } else if (input == 4) {
//            System.out.println("Donnerstag");
//
//        } else if (input == 5) {
//            System.out.println("Freitag" + ":)");
//
//        } else if (input == 6) {
//            System.out.println("Samstag");
//
//        } else if (input == 7) {
//            System.out.println("Sonntag");
//
//        } else {
//            System.out.println("Falsche Eingabe");
//        }

        // 2 )
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.
        //  - Zusätzlich hat der Montag eine chance von 80% 5 mal ":(", also ":(:(:(:(:(" zum String "Montag :(" hinzuzufügen.
        //  - Zusätzlich hat der Freitag eine chance von 30% 7 mal ":(", also ":):):):):):):)" zum String "Freitag :)" hinzuzufügen.
        //  - Zusätzlich hat jeder Tag eine Chance von 1%, dass dieser einen zusätzlichen Smiley ":)" hat.

        Double chance = Math.random();
        // ACHTUNG! Wir müssen eine zusätzliche Zufallszahl für "jeden Tag" generieren!
        // Wir lassen das aber für den Anfang aus, da es einfach am Ende hinzuzufügen ist.

//        Random random = new Random();
//        random.nextInt(10,20);
//        random.nextDouble(0,1);

        String res = "";
        String padding;

        if (chance < 0.01) {
            padding = ":)";

        } else {
            padding = "";
        }

        if (input == 1) {

            if (chance < 0.8) {
                res = "Montag" + ":(".repeat(6);

            } else {
                res = "Montag" + ":(";
            }

        } else if (input == 2) {
            res ="Dienstag";

        } else if (input == 3) {
            res = "Mittwoch";

        } else if (input == 4) {
            res = "Donnerstag";

        } else if (input == 5) {

            if (chance < 0.3) {
                res = "Freitag" + ":)".repeat(8);

            } else {
                res = "Freitag" + ":)";
            }

        } else if (input == 6) {
            res = "Samstag";

        } else if (input == 7) {
            res = "Sonntag";

        } else {
            System.out.println("Falsche Eingabe");
        }

        System.out.println(res);

    }
}