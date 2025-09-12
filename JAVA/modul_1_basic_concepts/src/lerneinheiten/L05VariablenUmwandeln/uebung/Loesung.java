package lerneinheiten.L05VariablenUmwandeln.uebung;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.util.Locale;
import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {

        // 1. mit nextLine - kommentiere 1. aus mit Ctrl+/ auf dem numpad oder /* dazwischen ist alles ein Kommentar */
        Scanner scanner = new Scanner(System.in);
        String regex = "[ \\-,/🧱🔺\n]";

        System.out.print("Wähle die Spielfigur [x y]: ");
        String input = scanner.nextLine();

        String[] teile = input.split(regex);
        Integer xStart = Integer.parseInt(teile[0]);
        Integer yStart = Integer.parseInt(teile[1]);

        System.out.print("Wähle die das Ziel [x y]: ");
        input = scanner.nextLine(); // Achtung! wir überschreiben eine bestehende Variable.

        teile = input.split(regex); // Achtung! wir überschreiben eine bestehende Variable.
        Integer xEnd = Integer.parseInt(teile[0]);
        Integer yEnd = Integer.parseInt(teile[1]);

        Double distanz = Math.sqrt(Math.pow(xEnd - xStart, 2) + Math.pow(yEnd - yStart, 2));
        DecimalFormat df = new DecimalFormat();
        df.applyPattern("#.##");
        df.setDecimalFormatSymbols(new DecimalFormatSymbols(Locale.GERMANY));

        String formattedDistanz = df.format(distanz);

        System.out.println("Die Distanz beträgt: " + df.format(distanz));
        System.out.println("Die Figur auf Position [x:" + xStart + " y:" + yStart + "] wurde auf Position [x:" + xEnd +" y:" + yEnd + "] geschoben. Distanz: " + formattedDistanz);

        System.out.print("Wie geht es dir? ");
        String wieGehts = scanner.nextLine();
        System.out.println("Mir gehts " + wieGehts + ".");

//        // 2. nextInt
//        Scanner scanner = new Scanner(System.in);
//        scanner.useDelimiter("[ \\-,/🧱🔺\n]");
//
//        System.out.print("Wähle die Spielfigur [x y]: ");
//        Integer xStart = scanner.nextInt();
//        Integer yStart = scanner.nextInt();
//
//        System.out.print("Wähle die das Ziel [x y]: ");
//        Integer xEnd = scanner.nextInt();
//        Integer yEnd = scanner.nextInt();
//
//        Double distanz = Math.sqrt(Math.pow(xEnd - xStart, 2) + Math.pow(yEnd - yStart, 2));
//
//        DecimalFormat df = new DecimalFormat();
//        df.applyPattern("#.##");
//        df.setDecimalFormatSymbols(new DecimalFormatSymbols(Locale.GERMANY));
//
//        String formattedDistanz = df.format(distanz);
//
//        System.out.println("Die Figur auf Position [x:" + xStart + " y:" + yStart + "] wurde auf Position [x:" + xEnd +" y:" + yEnd + "] geschoben. Distanz: " + formattedDistanz);
//
//        System.out.print("Wie geht es dir? ");
//        String wieGehts = scanner.nextLine();
//        System.out.println("Mir gehts " + wieGehts + ".");
    }
}