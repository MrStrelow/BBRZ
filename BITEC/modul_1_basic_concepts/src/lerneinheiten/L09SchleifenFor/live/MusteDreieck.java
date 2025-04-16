package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class MusteDreieck {
    public static void main(String[] args) {
        System.out.println("##ende außerste###");
        System.out.println();

        // userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        // Dreieck muster
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }

        // mustergenerierung
        // Muster von oben "gespiegelt"
        for (int zeilen = groesseSpielfeld - 1; zeilen >= 0; zeilen--) {
            // links oben
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }
    }
}
