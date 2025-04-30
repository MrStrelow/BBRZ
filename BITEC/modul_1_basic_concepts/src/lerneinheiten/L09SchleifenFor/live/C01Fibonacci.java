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

        if (grenze == 0) {
            System.out.println("fib(0) = " + fibCurrent);

        } else if (grenze == 1) {
            System.out.println("fib(1) = " + fibNext);

        } else {
            System.out.print("fib(" + grenze + ") = " + fibCurrent + " + " + fibNext);
        }

        // Kontrollstrukturen
        for (int i = 0; i < grenze - 1; i++) {
            ergebnis = fibCurrent + fibNext;

            fibCurrent = fibNext;
            fibNext = ergebnis;

            if (i != grenze - 2) {
                System.out.print(" + " + fibNext);
            }
        }

        if (grenze >= 2) {
            System.out.print(" = " + ergebnis);
        }

        scanner.close();
    }
}
