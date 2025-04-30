package lerneinheiten.L09SchleifenFor.live;

import java.util.Random;
import java.util.Scanner;

public class C03Passwoerter {
    public static void main(String[] args) {
        // Variablen
        String RESET = "\u001B[0m";
        String WHITE = "\u001B[37m";
        String RED = "\u001B[31m";
        String GREEN = "\u001B[32m";
        String BLUE = "\u001B[34m";
        Random random = new Random();
        Scanner scanner = new Scanner(System.in);

        // Konstanten
        final String kleinbuchstaben = "abcdefghijklmnopqrstuvwxyz";
        final String grossbuchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        final String ziffern = "0123456789";
        final String sonderzeichen = "!\"§$%&/()=?{[]}\\@#*+~^.,;:-_<>|";

        String zeichenpool = kleinbuchstaben;

        // Userinput
        System.out.print("Soll das Passwort Großbuchstaben beinhalten [+/-]?");

        String userInputGrossbuchstaben;

        while ( true ) {
            userInputGrossbuchstaben = scanner.next();

            if (userInputGrossbuchstaben.equals("+") || userInputGrossbuchstaben.equals("-")) {
                break;
            }

            System.out.print("Die Eingabe " + RED + userInputGrossbuchstaben + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
        }

        if (userInputGrossbuchstaben.equals("+")) {
            zeichenpool += grossbuchstaben;
        }

        System.out.println();

        //Soll das Passwort Ziffern beinhalten [+/-]? +
        //Soll das Passwort Sonderzeichen beinhalten [+/-]? +
        //Wie lang soll das Passwort sein [ganze Zahl]? 10
        //Wie viele Passwörter sollen generiert werden? 3

        // Kontrollstrukturen
        // Zuständigkeit: Wie viele Passwörter sollen generiert werden
        for (int i = 0; i < 4; i++) {
            String password = "";

            // Zuständigkeit: Erzeuge Passwort - wiederhole "Länge des Passworts" mal
            for (int j = 0; j < 5; j++) {
                int position = random.nextInt(0, zeichenpool.length());
                password += zeichenpool.charAt(position);
            }

            System.out.println(password);
        }

    }
}
