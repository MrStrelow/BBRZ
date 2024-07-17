import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    public static void main(String[] args) {
        Scanner myScanner = new Scanner(System.in);
        System.out.println("Gib eine ganze Zahl (Integer) ein: ");
        String userInput = myScanner.nextLine();
        int userInputZahl = Integer.parseInt(userInput);

        // WENN
        //      der userInput gleich 5 ist
        // DANN
        //      verdopple den userInput und gib einen Text deiner Wahl aus.

         /*
                   ()
                    \
           x == 5    \
                     ||
         */

        if (userInputZahl == 5) {
            System.out.println("mal schauen ob es ausgeführt wird.");
            userInputZahl *= 2;
        }

        System.out.println("Der User hat die Zahl " + userInputZahl + " eingegeben.");


        // WENN
        //      der userInput gleich 5 ist
        // DANN
        //      verdopple den userInput und gib einen Text deiner Wahl aus.
        // ANSONSTEN
        //      halbiere den userInput


        /*        ()  ()
                   \  /
           x == 5   \/   ELSE
                    ||
         */

        if (userInputZahl == 5) {
            System.out.println("mal schauen ob es ausgeführt wird.");
            userInputZahl *= 2;
        } else {
            userInputZahl /= 2;
        }

        // Wir haben Wochentage:
        // Wenn eine Integer-Variable (userInput) gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        // die Integer-Variable gleich 2 "Dienstag", usw. wenn bis Integer-Variable gleich 7, dann gib "Sonntag" aus.
        // Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.




    }
}