package lerneinheiten.L08SchleifenWhile.live;

import java.util.Random;
import java.util.Scanner;

public class ZahlenRaten {
    public static void main(String[] args) {
        // Zusammenfassung der Angabe
        // 1.) benutzereingabe von zahlen 0-100
        // 2.) 5 Leben, bei fehler soll eins abgezogen werden.
        // 3.) info ob größer oder kleiner.
        // 4.) falls gewonnen soll dies ausgegeben werden, falls verloren ebenso.
        // 5.) willst du nochmal spielen? (reset von leben, und neue zahl ziehen)

        /*
        Notizen:
            - while loop
            - scanner
            - verzweigungen für 3 fälle
            - falschen input abfangen
            - zahl erzeugen zufallszahl -> Random
        */

        // Variablen Anlegen
        Random random = new Random();
        Scanner scanner = new Scanner(System.in);
        boolean playAgain = true;

        while (playAgain) {
            int zahlZuRaten = random.nextInt(0,100);
            int leben = 5 - 1;
            int versuche = 0;

            System.out.println("Eine Zahl zwischen 0 und 100 wurde gewählt. Rate die Zahl!");

            // Beginne mit Logik (Kontrollstrukturen)
            while (true) {
                System.out.print("Gib eine Zahl ein [0-100]: ");

                // guards für falschen userinput
                while (!scanner.hasNextInt()) {
                    System.out.print("Falscher userinput, bitte neu eingeben: ");
                    String falscherInputWelcherVerworfenWird = scanner.next();
                }

                // Userinput
                int guess = scanner.nextInt();

                // hier leben abfragen
                if (leben == 0) {
                    System.out.println("Du hast keine Leben mehr. Die Zahl war " + zahlZuRaten + ".");
                    break;
                }

                leben--;
                versuche++;

                // Spiellogik
                if (guess > zahlZuRaten) {
                    System.out.println("Die Zahl ist kleiner. Du hast noch " + (leben + 1) + " Leben.");

                } else if (guess < zahlZuRaten) {
                    System.out.println("Die Zahl ist größer. Du hast noch " + (leben + 1) + " Leben.");

                } else if (guess == zahlZuRaten) {
                    System.out.println("gewonnen. Die Zahl war " + zahlZuRaten + ". Es wurden " + versuche + " benötigt.");
                    break;
                }
            }

            // Logik um spiel neuzustarten
            System.out.print("Möchtest du nochmals spielen? [+/-]: ");
            playAgain = scanner.next().equals("+");
        }

        System.out.println("Spiel beendet. Danke fürs Spielen!");
        scanner.close();
    }
}
