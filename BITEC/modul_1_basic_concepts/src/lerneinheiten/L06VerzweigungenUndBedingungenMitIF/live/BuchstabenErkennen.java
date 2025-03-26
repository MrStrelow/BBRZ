package lerneinheiten.L06VerzweigungenUndBedingungenMitIF.live;

import java.util.Scanner;

public class BuchstabenErkennen {
    public static void main(String[] args) {
//        Vokal?
//        Schreiben Sie ein Java-Programm, das den Benutzer nach einem Buchstaben fragt und überprüft, ob es
//        sich um einen Vokal oder einen Konsonanten handelt. Wenn es ein Vokal ist, gibt das Programm "Das ist ein
//        Vokal" aus, ansonsten "Das ist ein Konsonant".

        // Variablen: scanner, eingabeDesUsers, variablen für Bedingungen
//        String userinput = System.console().readLine("prompt"); // ohne scanner
        System.out.print("Symbol eingeben: ");
        Scanner scanner = new Scanner(System.in);
        String userinput = scanner.nextLine().toLowerCase();

        // frage ob userput vokal ist
        // WENN ja, DANN sag ist vokal
        // ANSONSTEN sag ist kein vokal

        Integer userCharInput = (int) userinput.charAt(0);

        // Variante 1
        if (97 <= userCharInput && userCharInput <= (97 + 26) && userinput.length() == 1) {
            if (
                userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
                userinput.equals("o") || userinput.equals("u")
            ) {
                System.out.println("Usereingabe ist ein Vokal.");

            } else {
                System.out.println("Usereingabe ist ein Konsonant.");
            }
        } else {
            System.out.println("Fehlerhafte Eingabe.");
        }

        // Variante 2
        if (Character.isLetter(userCharInput) && userinput.length() == 1) {
            if (
                userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
                userinput.equals("o") || userinput.equals("u")
            ) {
                System.out.println("Usereingabe ist ein Vokal.");
            } else {
                System.out.println("Usereingabe ist ein Konsonant.");
            }
        } else {
            System.out.println("Fehlerhafte Eingabe.");
        }

        // Variante 3
        if (
            userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
            userinput.equals("o") || userinput.equals("u")
        ) {
            System.out.println("Usereingabe ist ein Vokal.");

        } else if(
            userinput.equals("b") || userinput.equals("c") || userinput.equals("d") ||
            userinput.equals("f") || userinput.equals("g") || userinput.equals("h") ||
            userinput.equals("j") || userinput.equals("k") || userinput.equals("l") ||
            userinput.equals("m") || userinput.equals("n") || userinput.equals("p") ||
            userinput.equals("q") || userinput.equals("r") || userinput.equals("s") ||
            userinput.equals("t") || userinput.equals("v") || userinput.equals("w") ||
            userinput.equals("x") || userinput.equals("y") || userinput.equals("z")
        ) {
            System.out.println("Usereingabe ist ein Konsonant.");

        } else {
            System.out.println("Usereingabe ist ein Konsonant.");
        }

        // Variante 4 - Guard Clause - basierend auf Variante 2
        // Guards: beschütze gegen ungewünschte Logik
        if (!Character.isLetter(userCharInput)) {
            System.out.println("Fehlerhafte Eingabe.");
            return;
        }

        if (userinput.length() != 1) {
            System.out.println("Fehlerhafte Eingabe.");
            return;
        }

        // Business Logic: gewünschte Logik
        if (
            userCharInput == 'a' || userinput.equals("e") || userinput.equals("i") ||
            userinput.equals("o") || userinput.equals("u")
        ) {
            System.out.println("Usereingabe ist ein Vokal.");
        } else {
            System.out.println("Usereingabe ist ein Konsonant.");
        }
    }
}
