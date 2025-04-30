package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class C01Fibonacci {
    public static void main(String[] args) {
        // Variablen
        Scanner scanner = new Scanner(System.in);
        int fibCurrent = 0;
        int fibNext = 1;
        int ergebnis = 0;

        // Userinput
        System.out.print("Wie viele Fibonacci-Zahlen berechnen? ");
        int grenze = scanner.nextInt();
        System.out.print(fibCurrent + " + " + fibNext);

        // Kontrollstrukturen
        // TODO: funktioniert nicht für Eingabe: 0 und 1
        for (int i = 0; i < grenze - 1; i++) {
            ergebnis = fibCurrent + fibNext;

            fibCurrent = fibNext;
            fibNext = ergebnis;

            if (i != grenze - 2) {
                System.out.print(" + " + fibNext);
            }
        }

        System.out.print(" = " + ergebnis);

        scanner.close();
    }
}
