package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class Muster {
    public static void main(String[] args) {
        // userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
//            for (int spalten = groesseSpielfeld - 1; spalten >= 0; spalten--) {
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
