package lerneinheiten.L11Arrays;

import java.util.Scanner;

public class L09LinesOnChessBoard {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Groesse des Spielbretts eingeben: ");
        Integer dimension = Integer.parseInt(scanner.nextLine());

        String[][] brett = new String[dimension][dimension];

//        char whiteSquareCode = 0x2588; // ░
//        String whiteSquare = new String(Character.toChars(whiteSquareCode)); // ░
//
//        char blackSquareCode = 0x2591; // █
//        String blackSquare = new String(Character.toChars(whiteSquareCode)); // █

//        String whiteSquare = "0x2591"; // █
//        String blackSquare= "\u2588"; // ░

//         String whiteSquare = "\u2B1C"; // ⬜
//         String blackSquare= "\u2B1B"; // ⬛

         String whiteSquare = "⬜";
         String blackSquare= "⬛";

//        Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
        for (int y = 0; y < dimension; y++) {
            for (int x = 0; x < dimension; x++) {
                // intuitiver: Was ist die Bedingung als logische Formel für das WhiteSquare?
                // if ( (y % 2 == 0 && x % 2 == 0) || (y % 2 == 1 && x % 2 == 1) ) {
                if ((x + y) % 2 == 0)
                    // (x + y) % 2 == 0) ist kurz, aber schwerer zu nachzuvollziehen.
                    brett[y][x] = whiteSquare;
                else
                    brett[y][x] = blackSquare;
            }
        }

// anders intuitiver:
//  - gleiche Denkweise wie oben im Kommentar, jedoch in anderer Darstellung.
//  - if untereinander ist ein logisches ODER
//  - if geschachtelt ist ein logisches UND
//                if (y % 2 == 0) {
//
//                    if (x % 2 == 0) {
//                        brett[y][x] = whiteSquare;
//
//                    } else {
//                        brett[y][x] = blackSquare;
//                    }
//
//                } else {
//                // Das "else" hat eine versteckte Bedingung! diese ist das Gegenteil von der Bedingung im oberen "if".
//                // Diese ist !(y % 2 == 0) was hier gleichbedeutend mit y % 2 == 1 ist.
//                // Der Grund dafür ist, dass wir nur 2 Zustände haben (weiß und schwarz).
//                // Das Gegenteil von gerade ist ungerade.
//                    if (x % 2 == 1) {
//                        brett[y][x] = whiteSquare;
//
//                    } else {
//                        brett[y][x] = blackSquare;
//                    }
//                }

//        Verbinde 2 gewählte Felder mit einer Linie
//        Berechne dazu die Steigung der Linie

//        Userinput
        System.out.print("Wähle die Figur... [x y]: ");
        String[] userinput = scanner.nextLine().split(" ");

        Integer xStart = Integer.parseInt( userinput[0] );
        Integer yStart = Integer.parseInt( userinput[1] );

        System.out.print("... und wähle das Ziel [x y]: ");
        userinput = scanner.nextLine().split(" ");

        Integer xZiel = Integer.parseInt( userinput[0] );
        Integer yZiel = Integer.parseInt( userinput[1] );

        brett[yStart][xStart] = "🟡";
        brett[yZiel][xZiel] = "❌";

        Integer deltaX = xZiel - xStart;
        Integer deltaY = yZiel - yStart;
        Double steigung;
        Integer longerDelta;
        Integer shorterDelta;
        Integer startLonger;
        Integer startShorter;
        Boolean longerIsX;

        // Variante 1: Wir haben zwar nicht alle Fälle hier abgedeckt, es entstehen also Bugs und Fehler,
        // aber die Logik ist prinzipiell implementiert!
        // Diese Variante beinhaltet die essenziellen Teile:
        // kommentiere diese aus, wenn die Version 2 bzw. 3 verwendet werden soll.

        // In der Variante 1 funktioniert:
        // - 0 5 und 7 7
        // aber nicht:
        // - 5 0 und 7 7
        // - 5 7 und 7 0
        // - 0 7 und 7 5
        // - 7 7 und 0 5
        // - 7 7 und 5 0
        // - 5 7 und 0 7
        // - 0 7 und 5 7
        // - 0 5 und 7 7
        // - 0 0 und 0 7
        // - 0 7 und 0 0

//        System.out.println("++++++++++++++ Version 1 ++++++++++++++");
//        steigung = Math.abs( (deltaY+0.) / deltaX);
//
//        for (int x = 1; x < deltaX; x++) {
//            Integer y = Math.toIntExact( Math.round(steigung * x) );
//            brett[yStart + y][xStart + x] = "🔸";
//        }
//
//        // Ausgabe
//        for (int i = 0; i < brett.length; i++) {
//            for (int j = 0; j < brett[0].length; j++) {
//                System.out.print(brett[i][j]);
//            }
//            System.out.println();
//        }

//        System.out.println("++++++++++++++ Version 2 ++++++++++++++");
//
//        // In der Variante 2 funktioniert:
//        // - 0 5 und 7 7
//        // - 5 0 und 7 7
//        // aber nicht:
//        // - 5 7 und 7 0
//        // - 0 7 und 7 5
//        // - 7 7 und 0 5
//        // - 7 7 und 5 0
//        // - 5 7 und 0 7
//        // - 0 7 und 5 7
//        // - 0 5 und 7 7
//        // - 0 0 und 0 7
//        // - 0 7 und 0 0
//
//        if (Math.abs(deltaX) > Math.abs(deltaY)) {
//            steigung = (0.d + deltaY) / deltaX;
//            longerDelta = deltaX;
//            longerIsX = true;
//
//        } else {
//            steigung = (0.d + deltaX) / deltaY;
//            longerDelta = deltaY;
//            longerIsX = false;
//        }
//
//        chosenX = xStart;
//        chosenY = yStart;
//
//        for (int i = 1; i < Math.abs(longerDelta); i++) {
//            Integer neuePositionX;
//            Integer neuePositionY;
//
//            if (longerIsX) {
//                neuePositionY = Long.valueOf(Math.round(chosenY + i * steigung)).intValue();
//                neuePositionX = chosenX + i;
//            } else {
//                neuePositionY = chosenY + i;
//                neuePositionX = Long.valueOf(Math.round(chosenX + i * steigung)).intValue();
//            }
//
//            brett[neuePositionY][neuePositionX] = "🔸";
//        }
//
//        // Ausgabe
//        for (int i = 0; i < dimension; i++) {
//            for (int j = 0; j < dimension; j++) {
//                System.out.print(brett[i][j]);
//            }
//            System.out.println();
//        }

        System.out.println("++++++++++++++ Version 3 ++++++++++++++");

        // Tests:
        // Hier funktioniert
        // - 0 5 und 7 7
        // - 5 0 und 7 7
        // - 5 7 und 7 0
        // - 0 7 und 7 5
        // - 7 7 und 0 5
        // - 7 7 und 5 0
        // - 5 7 und 0 7
        // - 0 7 und 5 7
        // - 0 5 und 7 7
        // - 0 0 und 0 7
        // - 0 7 und 0 0

//        if (Math.abs(deltaX) > Math.abs(deltaY)) {
//            longerDelta = deltaX;
//            shorterDelta = deltaY;
//            startLonger = xStart;
//            startShorter = yStart;
//            longerIsX = true;
//
//        } else {
//            longerDelta = deltaY;
//            shorterDelta = deltaX;
//            startLonger = yStart;
//            startShorter = xStart;
//            longerIsX = false;
//        }
//
//        for (int i = 1; i < Math.abs(longerDelta); i++) {
//            Integer indexForShorter;
//            Integer indexForLonger;
//
//            if (shorterDelta < 0 && longerDelta < 0) {
//                indexForLonger = startLonger - i;
//                steigung = -(0.d + shorterDelta) / longerDelta;
//
//            } else if (shorterDelta < 0 && longerDelta > 0) {
//                indexForLonger = startLonger + i;
//                steigung = (0.d + shorterDelta) / longerDelta;
//
//            } else if (shorterDelta > 0 && longerDelta < 0) {
//                indexForLonger = startLonger - i;
//                steigung = -(0.d + shorterDelta) / longerDelta;
//
//            } else if (shorterDelta > 0 && longerDelta > 0) {
//                indexForLonger = startLonger + i;
//                steigung = (0.d + shorterDelta) / longerDelta;
//
//            } else if (shorterDelta == 0 && longerDelta > 0){
//                indexForLonger = startLonger + i;
//                steigung = (0.d + shorterDelta) / longerDelta;
//
//            } else if (shorterDelta == 0 && longerDelta < 0){
//                indexForLonger = startLonger - i;
//                steigung = (0.d + shorterDelta) / longerDelta;
//
//            } else {
//                indexForLonger = null;
//                steigung = null;
//            }
//
//            indexForShorter = Long.valueOf(Math.round(startShorter + i * steigung)).intValue();
//
//            if(longerIsX) {
//                brett[indexForShorter][indexForLonger] = "🔸";
//            } else {
//                brett[indexForLonger][indexForShorter] = "🔸";
//            }
//        }

        // Version 4
        // Tests:
        // Hier funktioniert
        // - 0 5 und 7 7
        // - 5 0 und 7 7
        // - 5 7 und 7 0
        // - 0 7 und 7 5
        // - 7 7 und 0 5
        // - 7 7 und 5 0
        // - 5 7 und 0 7
        // - 0 7 und 5 7
        // - 0 5 und 7 7
        // - 0 0 und 0 7
        // - 0 7 und 0 0

        longerDelta = Math.max(Math.abs(deltaX), Math.abs(deltaY));
        double stepX = (double) deltaX / longerDelta;
        double stepY = (double) deltaY / longerDelta;

        for (int i = 1; i < longerDelta; i++) {
            int x = xStart + (int) Math.round(i * stepX);
            int y = yStart + (int) Math.round(i * stepY);
            brett[y][x] = "🔸";
        }

        // Ausgabe
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                System.out.print(brett[i][j]);
            }
            System.out.println();
        }
    }
}
