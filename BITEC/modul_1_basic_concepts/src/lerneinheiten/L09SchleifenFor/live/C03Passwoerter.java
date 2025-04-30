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

        System.out.println();
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

        System.out.println();
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

        System.out.println();
        System.out.print("Wie lang soll das Passwort sein [ganze Zahl]? ");

        while (!scanner.hasNextInt()) {
            System.out.print("Eingabe von " + RED + scanner.next() + RESET + " ist nicht zulässig. Bitte eine ganze Zahl eingeben: ");
        }

        int laengePasswort = scanner.nextInt();

        System.out.println();
        System.out.print("Wie viele Passwörter sollen generiert werden [ganze Zahl]? ");

        while (!scanner.hasNextInt()) {
            System.out.print("Eingabe von " + RED + scanner.next() + RESET + " ist nicht zulässig. Bitte eine ganze Zahl eingeben: ");
        }

        int anzahlPasswoerter = scanner.nextInt();

        // Kontrollstrukturen
        // Zuständigkeit: Wie viele Passwörter sollen generiert werden
        for (int i = 0; i < anzahlPasswoerter; i++) {
            String password = "";

            // Zuständigkeit: Erzeuge Passwort - wiederhole "Länge des Passworts" mal
            for (int j = 0; j < laengePasswort; j++) {
                int position = random.nextInt(0, zeichenpool.length());
                password += zeichenpool.charAt(position);
            }

            System.out.println(password);
        }

    }
}
