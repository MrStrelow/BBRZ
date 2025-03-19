package lerneinheiten.L05VariablenUmwandeln.live;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.util.Locale;
import java.util.Scanner;

public class SchachbrettKoordinaten {
    public static void main(String[] args) {
        // 1. nextLine
        Scanner scanner = new Scanner(System.in);

        // Startpunkt einlesen
        System.out.print("Wähle die Spielfigur - x y: ");
        String input = scanner.nextLine(); // lies die ganze zeile ein
        String[] teile = input.split("[ \\-,/🧱🔺\n]"); // reiß diesen string an den angegebenen symbolen auseinander
        Integer xStart = Integer.parseInt(teile[0]); // nimm die erste zahl
        Integer yStart = Integer.parseInt(teile[1]); // nimm die 2. zahl

        // Endpunkt einlesen
        System.out.print("Wähle das Ziel - x y: ");
        input = scanner.nextLine();
        teile = input.split("[ \\-,/🧱🔺\n]"); // reiß diesen string an den angegebenen symbolen auseinander
        Integer xEnd = Integer.parseInt(teile[0]); // nimm die erste zahl
        Integer yEnd = Integer.parseInt(teile[1]); // nimm die 2. zahl

        // distanz berechnen
        Double distanz = Math.sqrt(Math.pow(xEnd - xStart,2) + Math.pow(yEnd - yStart,2));

        // formatiere distanz auf , mit 2 nachkommastellen
        DecimalFormat decimalFormat = new DecimalFormat();
        decimalFormat.applyPattern("#.##"); // 2 nachkommastellen
        decimalFormat.setDecimalFormatSymbols(new DecimalFormatSymbols(Locale.GERMAN)); //wir zwingen egal welche sprache am computer ist, einen beistrich zu machen.

        String formatedDistanz = decimalFormat.format(distanz);
        System.out.println(formatedDistanz);

    }
}
