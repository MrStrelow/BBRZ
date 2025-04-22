package lerneinheiten.L08SchleifenWhile.skripten;

import java.util.Random;
import java.util.Scanner;

public class test {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        int guess;
        int trial = 0;

        int draw = random.nextInt(101);
        System.out.println("Rate eine Zahl zwischen 1 und (inklusive) 100");

        do {
            System.out.print("Rate eine Zahl: ");
            guess = Integer.parseInt(scanner.nextLine());

            String hint =
                    guess > draw  ?
                            "groß" :
                            guess < draw ?
                                    "klein" : break; // unklar was hier bei einer Zuweisung passiert.

            System.out.println("Zahl ist zu " + hint + "!");

            trial++;

        } while (guess != draw);

        System.out.println("Richtig! Du hast " + trial + " Versuche gebraucht.");
    }
}
