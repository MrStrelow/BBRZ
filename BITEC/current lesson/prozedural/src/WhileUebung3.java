import java.util.Scanner;
import java.util.SequencedCollection;

public class WhileUebung3 {
    public static void main(String[] args) {
//        Schreiben Sie eine While-Schleife, die von 10 bis 1 alle Zahlen im Format "10-9-8-7-6-5-4-3-2-1"
//        ausgibt.
//        - Speichern Sie hierbei die Zahl 10 in der Konstante *bound*
//        - Ändern Sie nun bound auf 100

        // Ohne Konstante.
        Integer zaehlvariable = 10;
        final Integer untereGrenze = 1;

        while (zaehlvariable >= untereGrenze) {

            if (zaehlvariable == untereGrenze) {
                System.out.print(zaehlvariable);

            } else {
                System.out.print(zaehlvariable + "-");
            }

            zaehlvariable--;
        }

        System.out.println();

        // Mit Konstante
        final Integer bound = 10;
        zaehlvariable = 0;

        while (zaehlvariable < bound) {

            if (zaehlvariable == bound-1) {
                System.out.print(bound-zaehlvariable);

            } else {
                System.out.print(bound-zaehlvariable + "-");
            }

            zaehlvariable++;
        }

        System.out.println();


//        Schreiben Sie ein Programm, das eine Zahl vom Benutzer einliest und dann die Summe aller Zahlen
//        von 1 bis zur eingegebenen Zahl ausgibt

        Scanner scanner = new Scanner(System.in);
        System.out.print("Bitte gib Zahl ein: ");
        Integer userInput = Integer.parseInt(scanner.nextLine());

        // 10 + 9 + 8 + 7 + 6 + 5 + 4 + 3 + 2 + 1

        // 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10
        zaehlvariable = 1;
        Integer summe = 0;

        while (zaehlvariable <= userInput) {
            summe += zaehlvariable;

//            System.out.println(summe + " : " + zaehlvariable);

            zaehlvariable++;
        }

        System.out.println("Die summe von 1 bis " + userInput + " ist: " + summe);


//        Schreiben Sie ein Programm, das den Benutzer nach einer Zahl fragt und dann die Fakultät dieser
//        Zahl berechnet. Verwenden Sie dazu eine While-Schleife. (Hinweis: Fakultät von 3 = 123 = 6, Fakultät
//        von 4 = 123*4 =24)

        scanner = new Scanner(System.in);
        System.out.print("Bitte gib Zahl ein: ");
        userInput = Integer.parseInt(scanner.nextLine());

        // 10 + 9 + 8 + 7 + 6 + 5 + 4 + 3 + 2 + 1

        // 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10
        zaehlvariable = 1;
        Integer fakultaet = 0;

        while (zaehlvariable <= userInput) {
            fakultaet += zaehlvariable;

//            System.out.println(summe + " : " + zaehlvariable);

            zaehlvariable++;
        }

        System.out.println("Die summe von 1 bis " + userInput + " ist: " + fakultaet);

    }
}
