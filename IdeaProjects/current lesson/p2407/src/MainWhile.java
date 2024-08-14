import java.util.Random;
import java.util.Scanner;

public class MainWhile {
    public static void main(String[] args) {
        // Rate eine Zahl zwischen 0 und 100 (inklusive 0, exklusive 100)
        Scanner scanner = new Scanner(System.in);

        Random random = new Random();
        Integer toBeGuessed = random.nextInt(0,100);

        while (true) {

            System.out.print("Gib eine Zahl ein: ");
            Integer guess = Integer.parseInt(scanner.nextLine());

            if (guess == toBeGuessed) {
                System.out.println("Die Zahl wurde erraten!");
                break;

            } else if (guess > toBeGuessed) {
                System.out.println("Dein Guess war zu groß.");

            } else {
                System.out.println("Dein Guess war zu klein.");
            }

        }
    }
}
