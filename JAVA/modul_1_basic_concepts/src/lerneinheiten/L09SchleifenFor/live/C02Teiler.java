package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class C02Teiler {
    public static void main(String[] args) {
        // Variablen
        String RESET = "\u001B[0m";
        String RED = "\u001B[31m";
        Scanner scanner = new Scanner(System.in);

        // userinput
        System.out.print("Gib eine Zahl ein um alle Teiler zu berechnen: ");

        while (!scanner.hasNextInt()) {
            System.out.print("Eingabe von " + RED + scanner.next() + RESET + " nicht möglich. Bitte eine ganze Zahl eingeben: ");
        }

        int grenze = scanner.nextInt();

        // kontrollstrukturen
        String ergebnis = "teiler(" + grenze + ") = ";
        boolean istkeinePrimzahl = false;

        for (int teiler = 1; teiler <= grenze; teiler++) {
            if (grenze % teiler == 0) {
                ergebnis += teiler + (teiler < grenze ? ", " : "");

                if (teiler != 1 && teiler != grenze) {
                    istkeinePrimzahl = true;
                }
            }
        }

        System.out.println(istkeinePrimzahl ? ergebnis : RED + ergebnis + RESET);
    }
}
