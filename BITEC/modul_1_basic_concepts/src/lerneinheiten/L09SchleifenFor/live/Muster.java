package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class Muster {
    public static void main(String[] args) {
        // userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++ ) {

            for (int spalten = groesseSpielfeld - 1; spalten >= 0; spalten--) {

                System.out.println("zeilen: " + zeilen + " - spalten: " + spalten);

            }

            System.out.println();

        }
    }
}
