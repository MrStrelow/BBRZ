package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class A05MusterDiamantFortgeschrittenKompaktSpitz {
    public static void main(String[] args) {
        // userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        int breite = 2 * groesseSpielfeld - 1;

        for (int zeile = 0; zeile < breite; zeile++) {
            for (int spalte = 0; spalte < breite; spalte++) {

                // abstand zur mitte berechnen
                int abstandZurMitteZeile = Math.abs(groesseSpielfeld - 1 - zeile);
                int abstandZurMitteSpalte = Math.abs(groesseSpielfeld - 1 - spalte);

                // sind innerhalb der Raute sind
                if (abstandZurMitteSpalte <= groesseSpielfeld - 1 - abstandZurMitteZeile) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }
    }
}
