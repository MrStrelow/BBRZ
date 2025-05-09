package lerneinheiten.L10StringManipulation.live;

import java.util.Random;
import java.util.Scanner;

public class SinnvolleHasNextMitRegex {
    public static void main(String[] args) {
        // Konstanten
        final String RESET = "\u001B[0m";
        final String RED = "\u001B[31m";

        final String kleinbuchstaben = "abcdefghijklmnopqrstuvwxyz";
        final String grossbuchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // Variablen
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        // Achtung! Nach jeder Wiederholung zurücksetzen.
        String zeichenpool = kleinbuchstaben;

        // ~~~~~~~~~~~~~~~~~~~ START UserInput ~~~~~~~~~~~~~~~~~~~
        // ------------------- Soll das Passwort Großbuchstaben beinhalten [+/-]? -------------------
        System.out.print("Soll das Passwort Großbuchstaben beinhalten [+/-]? ");

        // kurz mit regex
        while (!scanner.hasNext("[+-]")) {
            System.out.print("Die Eingabe " + RED + scanner.nextLine() + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
        }

        if( scanner.next().equals("+")) {
            zeichenpool += grossbuchstaben;
        }

        System.out.println(zeichenpool);

//            // lange
//            String userInputGrossbuchstaben;
//
//            while ( true ) {
//                userInputGrossbuchstaben = scanner.next();
//
//                if (userInputGrossbuchstaben.equals("+") || userInputGrossbuchstaben.equals("-")) {
//                    break;
//                }
//
//                System.out.print("Die Eingabe " + RED + userInputGrossbuchstaben + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
//            }
//
//            if (userInputGrossbuchstaben.equals("+")) {
//                zeichenpool += grossbuchstaben;
//            }
    }
}