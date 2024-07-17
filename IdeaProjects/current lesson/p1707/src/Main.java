import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    public static void main(String[] args) {
        Scanner myScanner = new Scanner(System.in);
        System.out.println("Gib eine ganze Zahl (Integer) ein: ");
        String userInput = myScanner.nextLine();
        Integer userInputZahl = Integer.parseInt(userInput);

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

//        if (userInputZahl == 5) {
//            System.out.println("mal schauen ob es ausgeführt wird.");
//            userInputZahl *= 2;
//        }
//
//        System.out.println("Der User hat die Zahl " + userInputZahl + " eingegeben.");
//
//
//        // WENN
//        //      der userInput gleich 5 ist
//        // DANN
//        //      verdopple den userInput und gib einen Text deiner Wahl aus.
//        // ANSONSTEN
//        //      halbiere den userInput
//
//
//        /*        ()  ()
//                   \  /
//           x == 5   \/   ELSE
//                    ||
//         */
//
//        if (userInputZahl == 5) {
//            System.out.println("mal schauen ob es ausgeführt wird.");
//            userInputZahl *= 2;
//        } else {
//            userInputZahl /= 2;
//        }

        // Wir haben Wochentage:
        // Wenn eine Integer-Variable (userInput) gleich 1 ist, dann gib "Montag" aus, andernfalls, wenn
        // die Integer-Variable gleich 2 "Dienstag", usw. wenn bis Integer-Variable gleich 7, dann gib "Sonntag" aus.
        // Wenn wir "Freitag" ausgeben wollen füge ":)" dem Wochentag hinzu. Wenn wir Montag ausgeben füge einen ":(" hinzu.

        // WENN
        //      eine Integer-Variable gleich 1 ist
        // DANN
        //      gib "Montag" aus.
        // ANDERNFALLS

        /*
                      ()  ()
                       \  /
                ()  x<5 \/ ELSE
                 \      /
                  \    / *
                   \  /
             x==1   \/   ELSE
                    ||
         */

//        Integer userInputZahl = Integer.parseInt(userInput);

        if (userInputZahl == 1) {
            System.out.println("Montag");
        } else {

            System.out.println("KEIN MONTAG");

            if (userInputZahl == 2) {
                System.out.println("Dienstag");
            } else {
                if (userInputZahl == 3) {
                    System.out.println("Mittwoch");
                } else {
                    if (userInputZahl == 4) {
                        System.out.println("Donnerstag");
                    } else {
                        if (userInputZahl == 5) {
                            System.out.println("Freitag");
                        } else {
                            if (userInputZahl == 6) {
                                System.out.println("Samstag");
                            } else {
                                System.out.println("Sonntag");
                            }
                        }
                    }
                }
            }
        }

        /*
              ()    ()      ()
         x==5  \ x<5 | ELSE/
                \    |    /
                 \   |   /
                  \  |  /
                   \ | /
                    \|/
                    | |
         */

        if (userInputZahl == 1) {
            System.out.println("Montag");

        } else if (userInputZahl == 2) {
            System.out.println("Dienstag");

        } else if (userInputZahl == 3) {
            System.out.println("Mittwoch");

        } else if (userInputZahl == 4) {
            System.out.println("Donnerstag");

        } else if (userInputZahl == 5) {
            System.out.println("Freitag");

        } else if (userInputZahl == 6) {
            System.out.println("Samstag");

        } else {
            System.out.println("Sonntag");
        }

        // Übung:

        // 1.)
        // "WENN die Zahl die er User eingibt gleich 5 ist,
        //  DANN gib 'mal schauen ob es ausgeführt wird'. aus.
        //  ANSONSTEN gib ':(' aus und verdopple x"


        // 2.)
        // "WENN die Zahl die er User eingibt gleich 5 ist,
        //  DANN gib 'mal schauen ob es ausgeführt wird'. aus.
        //  ANSONSTEN
        //      WENN die Zahl die er User eingibt kleiner 5 ist
        //      DANN gib ':)' aus und halbiere x"
        //      ANSONSTEN gib ':(' aus und verdopple x".

        // 3.)
        // "WENN die Zahl die er User eingibt UNgleich 5 ist,
        //  DANN
        //      WENN die Zahl die er User eingibt kleiner 5 ist
        //      DANN gib ':)' aus und halbiere x"
        //      ANSONSTEN gib ':(' aus und verdopple x".
        //  ANSONSTEN
        //  gib 'mal schauen ob es ausgeführt wird'. aus.

        // 4.)
        // "WENN die Zahl die er User eingibt gleich 5 ist,
        //  DANN weise einem String 'user hat den 5er eingegeben'.
        //  ANSONSTEN weise den gleichen String 'user hat nicht den 5er eingegeben'

    }
}