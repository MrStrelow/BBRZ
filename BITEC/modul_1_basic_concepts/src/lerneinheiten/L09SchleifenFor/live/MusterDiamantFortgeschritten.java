package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class MusterDiamantFortgeschritten {
    public static void main(String[] args) {
        System.out.println("##ende außerste###");
        System.out.println();

        // userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        for (int zeilen = groesseSpielfeld - 1; zeilen >= 0; zeilen--) {
            // links oben
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {

                if (spalten >= zeilen) {
                    System.out.print("⬜");

                } else {
                    System.out.print("🔹");
                }

            }

            // rechts oben
            int verkehrzeZeilen = groesseSpielfeld - 1 - zeilen;
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {

                if (verkehrzeZeilen >= spalten) {
                    System.out.print("⬜");

                } else {
                    System.out.print("🔹");
                }

            }

            System.out.println();
        }

        // mustergenerierung
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            // links unten
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {

                if (spalten >= zeilen) {
                    System.out.print("⬜");

                } else {
                    System.out.print("🔹");
                }

            }

            // rechts unten
            int verkehrzeZeilen = groesseSpielfeld - 1 - zeilen;
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {

                if (verkehrzeZeilen >= spalten) {
                    System.out.print("⬜");

                } else {
                    System.out.print("🔹");
                }

            }

            System.out.println();
        }
    }
}
