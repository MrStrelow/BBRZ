package uebungen;

import java.util.Scanner;

public class Ue8While_empty {
    public static void main(String[] args) {
//        Schreiben Sie ein Programm, das 100 Mal Hello World auf die Konsole ausgibt.
//        Erweitern Sie das Programm, sodass 100 Mal Hello World auf die Konsole in
//        einer Zeile mit "," getrennt ausgegeben wird.
        Integer zaehlvariable = 0;

        while (zaehlvariable < 10) {
            System.out.println("Hello World");

            zaehlvariable++;
        }

        // Erweiterung
        zaehlvariable = 0;

        while (zaehlvariable < 10) {
            if (zaehlvariable == 9) {
                System.out.println("Hello World");

            } else {
                System.out.print("Hello World, ");
            }

            zaehlvariable++;
        }

//        Schreiben Sie eine While-Schleife, die von 1 bis 10 alle Zahlen ausgibt
//        Erweitern Sie die Ausgabe um die Info, ob die Zahl gerade oder ungerade ist. zB:
//        1(ungerade), 2(gerade), 3(ungerade), ...
//        Erweitern Sie das Programm, indem Sie vom Benutzer die untere und obere Grenze abfragen.
//        (zB. 4 bis 12)

        Scanner scanner = new Scanner(System.in);

        System.out.print("BIS wann soll gezählt werden? ");
        Integer obereGrenze = Integer.parseInt(scanner.nextLine());

        System.out.print("AB wann soll gezählt werden? ");
        Integer untereGrenze = Integer.parseInt(scanner.nextLine());
        Integer zaehler = untereGrenze;

        // Ich verwende eine Bedingung in der While Schleife, mit der ich weiter mache. Diese ist "solange der zaehler kleiner gleich der obereGrenze ist, mache weiter"
            while (zaehler <= obereGrenze) {

            // wenn zahl gerade dann gib "gerade" aus.
            if (zaehler % 2 == 0) {
                System.out.println(zaehler + " ist eine gerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");

                // wenn zahl ungerade dann gib "ungerade" aus.
            } else {
                System.out.println( zaehler + " ist eine ungerade Zahl und die Schleife wurde " + zaehler + " mal ausgeführt");
            }

            zaehler++;
        }

//        Schreiben Sie eine While-Schleife, die von 10 bis 1 alle Zahlen im Format "10-9-8-7-6-5-4-3-2-1"
//        ausgibt.
//        - Speichern Sie hierbei die Zahl 10 in der Konstante *bound*
//        - Ändern Sie nun bound auf 100

        final Integer bound = 10; // = 100;

        while (zaehlvariable >= 1) {
            if (zaehlvariable != 1) {
                System.out.print(zaehlvariable + "-");

            } else {
                System.out.print(zaehlvariable);
            }

            zaehlvariable--;
        }

//        Schreiben Sie ein Programm, das eine Zahl vom Benutzer einliest und dann die Summe aller Zahlen
//        von 1 bis zur eingegebenen Zahl ausgibt.

        // optional - Zeitmessung - Achtung! Interpretiere nicht genau die Zeiten! Diese sind unzuverlässig.
        Long startZeit = System.currentTimeMillis();

        zaehlvariable = 1;
        System.out.print("Gib eine Zahl ein. Bis zu dieser wird die Summe gebildet. z.B. Eingabe: 3 -> 1+2+3=6 ");
        Integer usereingabe = Integer.parseInt(scanner.nextLine());
        Integer summe = 0;

        while (zaehlvariable <= usereingabe) {
            summe += zaehlvariable;

            zaehlvariable++;
        }

        System.out.println("Die Summe von 1 bis " + usereingabe + " ist: " + summe);

        // optional - Zeitmessung
        long endZeit = System.currentTimeMillis();
        long vergangeneZeit = endZeit - startZeit;
        System.out.println("Vergangene Zeit: " + (vergangeneZeit) + " milliseconds");


        // Alternative:
        // optional - Zeitmessung - Achtung! Interpretiere nicht genau die Zeiten! Diese sind unzuverlässig.
        // Wir sehen aber einen großen Unterschied.
        startZeit = System.currentTimeMillis();

        System.out.println("Die Summe von 1 bis " + usereingabe + " ist: " + (usereingabe * (usereingabe + 1)) / 2);

        endZeit = System.currentTimeMillis();
        vergangeneZeit = endZeit - startZeit;
        System.out.println("Vergangene Zeit: " + (vergangeneZeit) + " milliseconds");

//        Schreiben Sie ein Programm, das den Benutzer nach einer Zahl fragt und dann die Fakultät dieser
//        Zahl berechnet. Verwenden Sie dazu eine While-Schleife. (Hinweis: Fakultät von 3 = 123 = 6, Fakultät
//        von 4 = 123*4 =24)
        zaehlvariable = 1;
        System.out.print("Gib eine Zahl ein. Bis zu dieser wird die Fakultät gebildet. z.B. Eingabe: 3 -> 1*2*3=6 ");
        usereingabe = Integer.parseInt(scanner.nextLine());
        Integer fakultaet = 1;

        while (zaehlvariable <= usereingabe) {
            fakultaet *= zaehlvariable;

            zaehlvariable++;
        }

        System.out.println("Die Fakultät von 1 bis " + usereingabe + " ist: " + fakultaet);
    }
}
