package lerneinheiten.L05VariablenUmwandeln.uebung;

import java.text.DecimalFormat;
import java.util.Locale;
import java.util.Scanner;

public class Loesung {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Wähle die Spielfigur [x y]: ");
        Integer xStart = scanner.nextInt();
        Integer yStart = scanner.nextInt();

        System.out.print("Wähle die das Ziel [x y]: ");
        Integer xEnd = scanner.nextInt();
        Integer yEnd = scanner.nextInt();

        Double distanz = Math.sqrt(Math.pow(xEnd - xStart, 2) + Math.pow(yEnd - yStart, 2));
        DecimalFormat df = (DecimalFormat) DecimalFormat.getInstance(Locale.GERMANY);
        df.applyPattern("#.##");
        String formattedDistanz = df.format(distanz);

        System.out.println("Die Figur auf Position [x:" + xStart + " y:" + yStart + "] wurde auf Position [x:" + xEnd +" y:" + yEnd + "] geschoben. Distanz: " + formattedDistanz);
    }
}