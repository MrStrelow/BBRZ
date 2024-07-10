import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    public static void main(String[] args) {
        Scanner myScanner = new Scanner(System.in);

        System.out.println("Gib erstes ein: ");
        Integer meinErsterInput = myScanner.nextInt();
        String meinZweiterInput = myScanner.nextLine();

        System.out.println("Deine erste Eingabe war " + meinErsterInput + " - deine zweite Eingabe war " + meinZweiterInput + ".");

        System.out.println("gib bitte eine Zeile ein: ");
        String meinDritterInput = myScanner.nextLine();
        System.out.println(meinDritterInput);
    }
}