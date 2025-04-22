package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class A01MusteDreieck {
    public static void main(String[] args) {
        System.out.println();
        System.out.println("------Aufgabe 9------");
        Scanner scanner = new Scanner(System.in);
        System.out.print("Höhe des Baumes (ohne Stamm): ");
        int hoehe = scanner.nextInt();

        for (int i = 1; i <= hoehe; i++) {
            for (int j = hoehe - i; j > 0; j--) {
                System.out.print(" ");
            }

            for (int k = 1; k <= i; k++) {
                System.out.print("🌲");
            }

            System.out.println();
        }
//        end of upper part
//        beginning of lower part
        for (int i = 1; i <= hoehe/3; i++) {

            System.out.print(" ");

            for (int j = hoehe - 3; j > 0; j--) {
                System.out.print(" ");
            }

            for (int k = 2; k > 0; k--) {
                System.out.print("🟫");
            }

            System.out.println();
        }

        // userinput
        scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        // Dreieck muster
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen = 0) {
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
