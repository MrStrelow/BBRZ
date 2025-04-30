package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class C01Fibonacci {
    public static void main(String[] args) {
        System.out.print("Wie viele Fibonacci-Zahlen berechnen? ");
        int grenze = new Scanner(System.in).nextInt();
        int fibCurrent = 0, fibNext = 1;

        if (grenze == 0)
            System.out.println("fib(0) = " + fibCurrent);
        else if (grenze == 1)
            System.out.println("fib(1) = " + fibNext);
        else
            System.out.print("fib(" + grenze + ") = " + fibCurrent + " + " + fibCurrent);

        for (int i = 0; i < grenze - 1; i++) {
            int temp = fibCurrent + fibNext;
            fibCurrent = fibNext;
            fibNext = temp;

            System.out.print(i == grenze-2 ? " = " + fibNext : " + " + fibNext);
        }

        System.out.println();
        System.out.println();
    }
}
