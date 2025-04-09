package lerneinheiten.L08SchleifenWhile;

import java.util.Random;
import java.util.Scanner;

public class L08ZahlenRaten {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();
        boolean playAgain = true;

        while (playAgain) {
            int geheimzahl = random.nextInt(101); // 0 bis 100 inkl.
            int leben = 5;
            int maximaleLeben = leben;

            System.out.println("Eine Zahl zwischen 0 und 100 wurde gewählt. Rate die Zahl!");

            // guess loop
            while (leben > 0) {
                System.out.print("Gib eine Zahl ein [0-100]: ");

                if (!scanner.hasNextInt()) {
                    System.out.println("Bitte eine gültige Zahl eingeben!");
                    scanner.next(); // ungültige Eingabe überspringen
                    continue;
                }

                int guess = scanner.nextInt();
                leben--;
                int versuche = maximaleLeben - leben;

                if (guess == geheimzahl) {
                    System.out.println("Glückwunsch! Du hast die Zahl erraten.");
                    break;
                } else if (guess > geheimzahl) {
                    System.out.println("Die Zahl ist kleiner. Du hast noch " + leben + " Leben.");
                } else {
                    System.out.println("Die Zahl ist größer. Du hast noch " + leben + " Leben.");
                }

                if (leben == 0) {
                    System.out.println("Leider verloren. Die richtige Zahl war " + geheimzahl +
                            ". Du hast " + versuche + " Versuche benötigt.");
                }
            }

            System.out.print("Möchtest du nochmals spielen? [+/-]: ");
            String antwort = scanner.next();
            playAgain = antwort.equals("+");
        }

        System.out.println("Spiel beendet. Danke fürs Spielen!");
        scanner.close();
    }
}
