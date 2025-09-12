package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class A04MusterDiamantFortgeschrittenKompakt {
    public static void main(String[] args) {
        // userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        int breite = 2 * groesseSpielfeld;

        for (int zeile = 0; zeile < breite; zeile++) {
            for (int spalte = 0; spalte < breite; spalte++) {

                // abstand zur mitte berechnen
                // Ist hier schwerer wie bei de mSpitz, da wir hier uns auf +2 und -2 ist das Gleiche verlassen.
                // Durch Math.abs() wird beides 2.
                // Was passiert aber bei 0? Wir haben nur eine 0.
                // Deshalb ist hier ein If-Ausdruck, welcher ab der Mitte so tut als wir noch einmal in der Mitte wären.
                // Wir ziehen deshalb -1 noch zusätzlich ab.
                int abstandZurMitteZeile =
                    zeile >= groesseSpielfeld ?
                        Math.abs(groesseSpielfeld - 1 - zeile) - 1 :
                        Math.abs(groesseSpielfeld - 1 - zeile);

                int abstandZurMitteSpalte =
                        spalte >= groesseSpielfeld ?
                            Math.abs(groesseSpielfeld - 1 - spalte) - 1 :
                            Math.abs(groesseSpielfeld - 1 - spalte);

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
