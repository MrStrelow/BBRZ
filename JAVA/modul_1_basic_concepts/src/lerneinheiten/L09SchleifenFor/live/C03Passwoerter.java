package lerneinheiten.L09SchleifenFor.live;

import java.util.Random;
import java.util.Scanner;

public class C03Passwoerter {
    public static void main(String[] args) {
        // Konstanten
        final String RESET = "\u001B[0m";
        final String WHITE = "\u001B[37m";
        final String RED = "\u001B[31m";
        final String GREEN = "\u001B[32m";
        final String BLUE = "\u001B[34m";

        final String kleinbuchstaben = "abcdefghijklmnopqrstuvwxyz";
        final String grossbuchstaben = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        final String ziffern = "0123456789";
        final String sonderzeichen = "!\"§$%&/()=?{[]}\\@#*+~^.,;:-_<>|";


        // Variablen
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        boolean nochmal;
        String zeichenpool;

        do {
            // Achtung! Nach jeder Wiederholung zurücksetzen.
            zeichenpool = kleinbuchstaben;

            // ~~~~~~~~~~~~~~~~~~~ START UserInput ~~~~~~~~~~~~~~~~~~~
            // ------------------- Soll das Passwort Großbuchstaben beinhalten [+/-]? -------------------
            System.out.print("Soll das Passwort Großbuchstaben beinhalten [+/-]? ");

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

            // ------------------- Soll das Passwort Ziffern beinhalten [+/-]? -------------------
            System.out.print("Soll das Passwort Ziffern beinhalten [+/-]? ");

            String userInputZiffer;

            while ( true ) {
                userInputZiffer = scanner.next();

                if (userInputZiffer.equals("+") || userInputZiffer.equals("-")) {
                    break;
                }

                System.out.print("Die Eingabe " + RED + userInputZiffer + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
            }

            if (userInputZiffer.equals("+")) {
                zeichenpool += ziffern;
            }

            // ------------------- Soll das Passwort Sonderzeichen beinhalten [+/-]? -------------------
            System.out.print("Soll das Passwort Sonderzeichen beinhalten [+/-]? ");

            String userInputSonderzeichen;

            while ( true ) {
                userInputSonderzeichen = scanner.next();

                if (userInputSonderzeichen.equals("+") || userInputSonderzeichen.equals("-")) {
                    break;
                }

                System.out.print("Die Eingabe " + RED + userInputSonderzeichen + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
            }

            if (userInputSonderzeichen.equals("+")) {
                zeichenpool += sonderzeichen;
            }

            // ------------------- Wie lang soll das Passwort sein [ganze Zahl]? -------------------
            System.out.print("Wie lang soll das Passwort sein [ganze Zahl]? ");

            while (!scanner.hasNextInt()) {
                System.out.print("Eingabe von " + RED + scanner.next() + RESET + " ist nicht zulässig. Bitte eine ganze Zahl eingeben: ");
            }

            int laengePasswort = scanner.nextInt();

            // ------------------- Wie viele Passwörter sollen generiert werden [ganze Zahl]? -------------------
            System.out.print("Wie viele Passwörter sollen generiert werden [ganze Zahl]? ");

            while (!scanner.hasNextInt()) {
                System.out.print("Eingabe von " + RED + scanner.next() + RESET + " ist nicht zulässig. Bitte eine ganze Zahl eingeben: ");
            }

            int anzahlPasswoerter = scanner.nextInt();

            // ~~~~~~~~~~~~~~~~~~~ ENDE UserInput ~~~~~~~~~~~~~~~~~~~

            // Kontrollstrukturen
            System.out.println();
            System.out.println("Es wurden folgende Passwörter...");

            // Zuständigkeit: Erzeuge mehrere Passwörter.
            // Wie viele Passwörter sollen generiert werden? - wiederhole "anzahl der Passwörter" mal
            for (int i = 0; i < anzahlPasswoerter; i++) {
                String password = "";

                // Zuständigkeit: Erzeuge ein Passwort.
                // Wie lange soll das Passwort sein? - wiederhole "Länge des Passwort" mal
                for (int j = 0; j < laengePasswort; j++) {
                    int position = random.nextInt(0, zeichenpool.length());
                    password += zeichenpool.charAt(position);
                }

                System.out.println(BLUE + password + RESET);
            }

            System.out.println("... generiert.");
            System.out.println();

            System.out.print("Neue Passwörter generieren [+/-]? ");

            // ------------------- UserInput -------------------
            String userInputNeustart;

            while ( true ) {
                userInputNeustart = scanner.next();

                if (userInputNeustart.equals("+") || userInputNeustart.equals("-")) {
                    break;
                }

                System.out.print("Die Eingabe " + RED + userInputNeustart + RESET + " ist nicht zulässig. Bitte + oder - eingeben: ");
            }

            if (userInputNeustart.equals("-")) {
                System.out.println("Programm wurde auf Wunsch des Benutzers beendet.");
                nochmal = false;

            } else {
                nochmal = true;
            }

            System.out.println();

        } while (nochmal);
    }
}
