import java.util.Scanner;

public class Verzweigungen {

    public static void main(String[] args) {
//        int alter = 18;

        // hier muss in der rundne klammer () true oder false rauskommen.
        // 2 möglichkeiten hier:
        // - logische operatoren: &&, ||, !
        // - ==, <, >, <=, >=

        // Aufgabe: gib du bist alt genug aus, wenn volljährig (großer als 18),
        // ansonsten gib sorry nicht alt genug aus.

        // Variante 1:
        // <IF>:
//        if (alter > 18) {
//            System.out.println("du bist alt genug");
//        }
//
//        if (alter <= 18) {
//            System.out.println("sorry. nicht alt genug.");
//        }

        // Variante 2
        // <IF-ELSE>
        // ENTWEDER ich bin alt genug ODER eben nicht.
//        if (alter > 18) {
//            System.out.println("du bist alt genug");
//        } else {
//            System.out.println("sorry. nicht alt genug.");
//        }

        // Aufgabe: gib
        // - "du bist alt genug aus", wenn volljährig (großer als 18),
        // - wenn du 18 bist "ah fast. leider aber noch nicht alt genug"
        // - ansonsten, gib "sorry nicht alt genug" aus.

        // Variante 1:
        // <verschachteltes IF-ELSE>
//        if (alter > 18) {
//            System.out.println("du bist alt genug");
//
//        } else {
//            if (alter == 18) {
//                System.out.println("ah fast. leider aber noch nicht alt genug");
//
//            } else {
//                System.out.println("sorry, nicht alt genug");
//            }
//        }
//
//        // Variante 2:
//        // <ELSE-IF>
//        if (alter > 18) {
//            System.out.println("du bist alt genug");
//
//        } else if (alter == 18) {
//            System.out.println("ah fast. leider aber noch nicht alt genug");
//
//        } else {
//            System.out.println("sorry, nicht alt genug");
//        }



        // Schreibe ein Programm welches die Zahlen 1 bis 7 von der Konsole einliest und bei:
        // * 1 Montag ausgibt,
        // * 2 Dienstag ausgibt,
        // * ...
        // * 6 Samstag ausgibt,
        // * 7 Sonntag ausgibt,
        // wenn <1 oder >7 eingegeben wird, soll eine Fehlermeldung ausgegeben werden.

        // Schreibe es mit if, if-else, else-if artigen Konstrukten.
        Scanner scanner = new Scanner(System.in);

        int idWochentag;

        do {
            System.out.print("Geben Sie eine Zahl zwischen 1 und 7 ein um den entsprechenden Wochentag zu erhalten: ");

            idWochentag = scanner.nextInt();

            if (idWochentag == 1) {
                System.out.println("Montag");

            } else if (idWochentag == 2) {
                System.out.println("Dienstag");

            } else if (idWochentag == 3) {
                System.out.println("Mittwoch");

            } else if (idWochentag == 4) {
                System.out.println("Donnerstag");

            } else if (idWochentag == 5) {
                System.out.println("Freitag");

            } else if (idWochentag == 6) {
                System.out.println("Samstag");

            } else if (idWochentag == 7) {
                System.out.println("Sonntag");

            } else {
                System.out.println("Fehler");
            }
        } while ( !(1 <= idWochentag && idWochentag <= 7) );

        // Schreibe es mit einem switch.


    }
}
