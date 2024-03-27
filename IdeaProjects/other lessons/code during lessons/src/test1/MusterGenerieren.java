package test1;

import java.util.Arrays;
import java.util.Scanner;

public class MusterGenerieren {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Bitte geben Sie die zu generierende Form ein. ");
        String form = scanner.nextLine().toLowerCase();

        System.out.print("Wie hoch soll das Objekt sein? ");
        Integer hoehe = Integer.parseInt(scanner.nextLine());

        // erzeuge felder
        String[][] basisfeld = new String[hoehe][hoehe];                       // Fall 1 von der Tafel
        String[][] basisfeldGespiegelt = new String[hoehe][hoehe];             // Fall 2 von der Tafel
        String[][] basisfeldTransponiert = new String[hoehe][hoehe];           // Fall 3 von der Tafel
        String[][] basisfeldTransponiertGespiegelt = new String[hoehe][hoehe]; // Fall 4 von der Tafel

        // feld mit leerzeichen befüllen
        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                basisfeld[zeile][spalte] = " ";
            }
        }

        // ############ Fall 1 - Basisfeld ############
        // feld mit muster befüllen
        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                if (spalte <= zeile) {
                    basisfeld[zeile][spalte] = "#";
                }
            }
        }

        // ############ Fall 2 - Basisfeld spiegeln (x-achse) ############
        // spiegeln über die x achse - wir ziehen Usereingabe von den zeilen ab und lassen spalten gleich
        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                basisfeldGespiegelt[zeile][spalte] = basisfeld[hoehe-zeile-1][spalte];
            }
        }

        // ############ Fall 3 - Basisfeld transponieren ############
        // transponieren wir basisfeld (vertauschen zeilen mit spalten)
        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                basisfeldTransponiert[zeile][spalte] = basisfeld[spalte][zeile];
            }
        }

        // ############ Fall 4 - Basisfeld transponieren und dann spiegeln ############
        // wir verwenden hier gleich das transponierte und spiegeln das
        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                basisfeldTransponiertGespiegelt[zeile][spalte] = basisfeldTransponiert[hoehe-zeile-1][spalte];
            }
        }

        // ############ start userinput - formen ############
        if (form.equals("dreieck")) {

            // ausgabe an die konsole
            for (int zeile = 0; zeile < hoehe; zeile++) {
                for (int spalte = 0; spalte < hoehe; spalte++) {
                    System.out.print(basisfeld[zeile][spalte]);
                }
                System.out.println();
            }

        } else if (form.equals("pyramide")) {

            System.out.print("wo soll die spitze sein? ");
            String position = scanner.nextLine().toLowerCase();

            String[][] pyramide;

            if (position.equals("rechts")) {

                int hoehePyramide = 2 * hoehe - 1;
                int hoeheDreieck = hoehe;
                pyramide = new String[hoehePyramide][hoeheDreieck];

                // befülle obere hälfte der pyramide mit dem ersten der beiden dreiecke (basisfall)
                for (int zeile = 0; zeile < hoeheDreieck; zeile++) {
                    for (int spalte = 0; spalte < hoeheDreieck; spalte++) {
                        pyramide[zeile][spalte] = basisfeld[zeile][spalte];
                    }
                }

                // befülle untere hälfte der pyramide mit dem zweiten der beiden dreiecke (basisfallGespiegelt)
                for (int zeile = hoeheDreieck; zeile < hoehePyramide; zeile++) {
                    for (int spalte = 0; spalte < hoeheDreieck; spalte++) {
                        pyramide[zeile][spalte] = basisfeldGespiegelt[zeile - hoeheDreieck + 1][spalte];
                    }
                }

                // ausgabe an die konsole
                for (int zeile = 0; zeile < hoehePyramide; zeile++) {
                    for (int spalte = 0; spalte < hoeheDreieck; spalte++) {
                        System.out.print(pyramide[zeile][spalte]);
                    }
                    System.out.println();
                }

            }  else {

                System.out.println("Position gibt es nicht.");

            }

        } else if (form.equals("raute")) {

            int hoeheRaute = 2 * hoehe - 1;
            int hoeheDreieck = hoehe;
            String[][] raute = new String[hoeheRaute][hoeheRaute];

            // befülle das link obere viertel der Raute mit dem basisfeldTransponiertGespiegelt
            for (int zeile = 0; zeile < hoeheDreieck; zeile++) {
                for (int spalte = 0; spalte < hoeheDreieck; spalte++) {
                    raute[zeile][spalte] = basisfeldTransponiertGespiegelt[zeile][spalte];
                }
            }

            // befülle das recht obere viertel der Raute mit dem basisfeld
            for (int zeile = 0; zeile < hoeheDreieck; zeile++) {
                for (int spalte = hoeheDreieck; spalte < hoeheRaute; spalte++) {
                    raute[zeile][spalte] = basisfeld[zeile][spalte - hoeheDreieck + 1];
                }
            }

            // befülle das recht untere viertel der Raute mit dem basisfeldGespiegelt
            for (int zeile = hoeheDreieck; zeile < hoeheRaute; zeile++) {
                for (int spalte = hoeheDreieck; spalte < hoeheRaute; spalte++) {
                    raute[zeile][spalte] = basisfeldGespiegelt[zeile - hoeheDreieck + 1][spalte - hoeheDreieck + 1];
                }
            }

            // befülle das link untere viertel der Raute mit dem basisfeldTransponiert
            for (int zeile = hoeheDreieck; zeile < hoeheRaute; zeile++) {
                for (int spalte = 0; spalte < hoeheDreieck; spalte++) {
                    raute[zeile][spalte] = basisfeldTransponiert[zeile - hoeheDreieck + 1][spalte];
                }
            }

            // ausgabe an die konsole
            for (int zeile = 0; zeile < hoeheRaute; zeile++) {
                for (int spalte = 0; spalte < hoeheRaute; spalte++) {
                    System.out.print(raute[zeile][spalte]);
                }
                System.out.println();
            }

        } else {

            System.out.println("Form gibt es nicht.");

        }

    }
}




//        "".toLowerCase();
//        form.toLowerCase();
//        scanner.nextLine().toLowerCase();


//    int rows = 5;
//
//        for (int i = 1; i <= rows; i++) {
////            for (int space = 1; space <= rows - i; space++) {
////                System.out.print(" ");
////            }
////            for (int j = 1; j <= i; j++) {
////                System.out.print("#");
////            }
//                System.out.print(" ".repeat(rows - i));
//                System.out.print("#".repeat(i));
//
//                System.out.println();
//                }


//            for (int zeile = 0; zeile < hoehe; zeile++) {
//        feld[zeile][zeile] = "#";
//        }