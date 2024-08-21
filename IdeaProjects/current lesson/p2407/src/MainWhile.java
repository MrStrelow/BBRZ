import java.util.Random;
import java.util.Scanner;

public class MainWhile {
    public static void main(String[] args) {
        // Rate eine Zahl zwischen 0 und 100 (inklusive 0, exklusive 100)
        Scanner scanner = new Scanner(System.in);

        Random random = new Random();
        Integer toBeGuessed = 77; // random.nextInt(0,100);
        Integer versuche = 1; // Das ist eine Zählvariable

        System.out.print("Wie oft sollst du maximal raten können?: ");
        Integer maximaleVersuche = Integer.parseInt(scanner.nextLine());

        while (true) {
            // habe ich genug Versuche?
            if (versuche > maximaleVersuche) {
                System.out.println("Verloren! Keine Versuche mehr vorhanden.");
                break;
            }

            // das ist der userinput
            System.out.print("Gib eine Zahl ein: ");
            Integer guess = Integer.parseInt(scanner.nextLine());

            // das ist die "kernspiellogik"
            if (guess == toBeGuessed) {
                System.out.println("Gewonnen! Die Zahl wurde erraten! Sie haben " + versuche + " Versuche gebraucht.");
                break;

            } else if (guess > toBeGuessed) {
                System.out.println("Dein Guess war zu groß.");

            } else {
                System.out.println("Dein Guess war zu klein.");
            }

            versuche++;
        }
    }
}
