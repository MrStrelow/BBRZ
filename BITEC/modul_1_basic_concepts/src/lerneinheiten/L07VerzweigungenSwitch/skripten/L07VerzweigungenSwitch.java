package lerneinheiten.L07VerzweigungenSwitch.skripten;

import java.util.Random;
import java.util.Scanner;

public class L07VerzweigungenSwitch {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Geben Sie eine Zahl zwischen 1 und 7 ein um einen Wochentag zu erhalten: ");
        Integer input = Integer.parseInt(scanner.nextLine());

        switch (input) {
            case 1: System.out.println("Montag :("); break;
            case 2: System.out.println("Dienstag"); break;
            case 3: System.out.println("Mittwoch"); break;
            case 4: System.out.println("Donnerstag"); break;
            case 5: System.out.println("Freitag :)"); break;
            case 6: System.out.println("Samstag"); break;
            case 7: System.out.println("Sonntag"); break;
            default: System.out.println("Kein Wochentag.");
        }

        // Alternativ ist auch eine "neue" Schreibweise ohne break möglich.
        // Diese geht nicht alle Fälle durch, sondern hat das "break" im hintergrund eingebaut.
        switch (input) {
            case 1 -> System.out.println("Montag :(");
            case 2 -> System.out.println("Dienstag");
            case 3 -> System.out.println("Mittwoch");
            case 4 -> System.out.println("Donnerstag");
            case 5 -> System.out.println("Freitag :)");
            case 6 -> System.out.println("Samstag");
            case 7 -> System.out.println("Sonntag");
            default -> System.out.println("Kein Wochentag.");
        }

        // Weiters können wir mehrere cases zusammenfassen (also mit oder Verknüpfen). Das geht mit einem Beisprich ",".
        switch (input) {
            case 1 -> System.out.println("Montag :(");
            case 2,3,4,5,6,7 -> System.out.println("jeder andere Tag, außer Montag");
            default -> System.out.println("Kein Wochentag.");
        }



        String output = switch (input) {
            case 1 -> "Montag :(";
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> "Freitag :)";
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        System.out.println(output);

                // 2 )
        // Wir haben Wochentage [Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag]:
        //  - Wenn eine Integer-Variable, welche der User eingibt gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        //    die Integer-Variable gleich 2 ist "Dienstag", usw. bis, wenn die Integer-Variable gleich 7 ist, dann gib "Sonntag" aus.
        //  - Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.
        //  - Zusätzlich hat der Montag eine chance von 80% 5 mal ":(", also ":(:(:(:(:(" zum String "Montag :(" hinzuzufügen.
        //  - Zusätzlich hat der Freitag eine chance von 30% 7 mal ":(", also ":):):):):):):)" zum String "Freitag :)" hinzuzufügen.
        //  - Zusätzlich hat jeder Tag eine Chance von 1%, dass dieser einen zusätzlichen Smiley ":)" hat.

//        Double zufallszahl = Math.random(); // das ist eine andere Variante.
        Random random = new Random();
        Double zufallszahl = random.nextDouble();
        Double zufallszahlJederTag = random.nextDouble();

        // Warum ist hier eine zusätzliche Zufallszahl für jeden Tag notwendig, aber für Freitag und Montag nicht?

        output = switch (input) {
            case 1 -> {
                String res = "Montag :)";

                if (zufallszahl < 0.8) {
                    res = res + ":(".repeat(5);
                }

                yield(res);
            }
            case 2 -> "Dienstag";
            case 3 -> "Mittwoch";
            case 4 -> "Donnerstag";
            case 5 -> {
                String res = "Freitag :)";

                if (zufallszahl < 0.3) {
                    res = res + ":)".repeat(7);
                }

                yield(res);
            }
            case 6 -> "Samstag";
            case 7 -> "Sonntag";
            default -> "kein Wochentag";
        };

        if (zufallszahlJederTag < 0.01) {
            System.out.print(output + ":)");
        } else {
            System.out.println(output);
        }

        // Wir können zusätzlich zu ganzen Zahlen auch Strings mit dem switch in cases aufspalten.
        // Wir sehen zudem, dass auch in der Basisvariante mehrere Zeilen Code in einem case hintereinander ausgeführt werden können.
        // Hier ein Beispiel:
        String wochentag = "Montag";
        Integer res;

        switch (wochentag) {
            case "Montag":
                res = 1;
                System.out.println("Heute ist Montag");
                break;

            case "Dienstag":
                res = 2;
                System.out.println("Heute ist Dienstag");
                break;

            default:
                res = -1;
                System.out.println("Heute ist irgend ein anderer Tag");
        }

        System.out.println("res (old Switch): " + res);

        // Hier noch die 2. Form des Switch.
        res = switch (wochentag) {
            case "Montag" -> {
                System.out.println("Heute ist Montag");
                yield(1);
            }
            case "Dienstag" -> {
                System.out.println("Heute ist Dienstag");
                yield(2);
            }
            default -> {
                System.out.println("Heute ist irgend ein anderer Tag");
                yield(-1);
            }
        };

        System.out.println("res (new Switch): " + res);
    }
}