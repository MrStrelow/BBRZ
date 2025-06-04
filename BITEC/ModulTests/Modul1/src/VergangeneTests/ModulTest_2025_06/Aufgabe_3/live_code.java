package VergangeneTests.ModulTest_2025_06.Aufgabe_3;

import java.util.Random;
import java.util.Scanner;

public class live_code {
    static final int MAX_LIVES = 5;
    static final int MIN_NUMBER = 0;
    static final int MAX_NUMBER = 100;

    public static void main(String[] args) {
        Random random = new Random();
        Scanner scanner = new Scanner(System.in);
        boolean playAgain = true;

        while (playAgain) {
            playSingleGame(scanner, random);
            playAgain = askToPlayAgain(scanner);
        }

        System.out.println("Spiel beendet. Danke fürs Spielen!");
        scanner.close();
    }

    static void playSingleGame(Scanner scanner, Random random) {
        ...
    }

    static int getUserGuess(Scanner scanner, Random random) {
        ...
        return getWordInput(...);
        ...
        return getNumericInput(...);
    }

    static int getNumericInput(Scanner scanner) {
        ...
    }

    static int getWordInput(Scanner scanner) {
        ...
    }

    static int convertWordToNumber(String wordInput) {
        ...
    }

    static void displayGameStatus(int guess, int zahlZuRaten, int livesLeft) {
        ...
    }

    static boolean askToPlayAgain(Scanner scanner) {
        ...
    }
}