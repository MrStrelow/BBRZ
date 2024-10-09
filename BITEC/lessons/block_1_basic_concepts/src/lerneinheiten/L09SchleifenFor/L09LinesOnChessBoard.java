package lerneinheiten.L09SchleifenFor;

import java.util.Scanner;

public class L09LinesOnChessBoard {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Groesse des Spielbretts eingeben: ");
        Integer dimension = Integer.parseInt(scanner.nextLine());

        String[][] brett = new String[dimension][dimension];

        char whiteSquareCode = 0x2588;
        char blackSquareCode = 0x2591;

        String whiteSquare = new String(Character.toChars(whiteSquareCode));
        String blackSquare = new String(Character.toChars(blackSquareCode));

//        Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                if ((j + i) % 2 == 0)
                    brett[i][j] = whiteSquare;
                else
                    brett[i][j] = blackSquare;
            }
        }

//        Verbinde 2 gewählte Felder mit einer Linie
//        Berechne dazu die Steigung der Linie (Siehe Tafelbild 21.12.2023)

//        Userinput
        System.out.print("Wähle die Figur... [x y]: ");
        String[] userinput = scanner.nextLine().split(" ");

        Integer xStart = Integer.parseInt( userinput[0] );
        Integer yStart = Integer.parseInt( userinput[1] );

        System.out.print("... und wähle das Ziel [x y]: ");
        userinput = scanner.nextLine().split(" ");

        Integer xZiel = Integer.parseInt( userinput[0] );
        Integer yZiel = Integer.parseInt( userinput[1] );

        brett[yStart][xStart] = "o";
        brett[yZiel][xZiel] = "x";

        Integer deltaX = xZiel - xStart;
        Integer deltaY = yZiel - yStart;
        Double steigung;
        Integer longerDelta;
        Boolean longerIsX;
        Integer chosenY;
        Integer chosenX;

        // Variante 1: Wir haben zwar nicht alle Fälle hier abgedeckt, es entstehen also Bugs und Fehler,
        // aber die Logik ist prinzipiell implementiert!
        // Diese Variante beinhaltet die essenziellen Teile:
        // kommentiere diese aus, wenn die Version 2 bzw. 3 verwendet werden soll.

        // In der Variante 1 funktioniert:
        // - 0 5 und 7 7
        // aber nicht:
        // - 5 0 und 7 7
        // - 7 7 und 5 0
        // - 7 7 und 0 5
        // - 5 7 und 7 0
        // - 7 0 und 5 7
        // - 5 7 und 7 0
        // - 0 7 und 5 7
        // - 5 7 und 0 7

//        System.out.println("++++++++++++++ Version 1 ++++++++++++++");
//        steigung = Math.abs( (deltaY+0.) / deltaX);
//
//        for (int x = 1; x < deltaX; x++) {
//            Integer y = Math.toIntExact( Math.round(steigung * x) );
//            brett[yStart + y][xStart + x] = ".";
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
//        // - 7 7 und 5 0
//        // - 7 7 und 0 5
//        // - 5 7 und 7 0
//        // - 7 0 und 5 7
//        // - 5 7 und 7 0
//        // - 0 7 und 5 7
//        // - 5 7 und 0 7
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
//            brett[neuePositionY][neuePositionX] = ".";
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

        // In der Variante 3 funktioniert:
        // - 0 5 und 7 7
        // - 5 0 und 7 7
        // - 7 7 und 5 0
        // - 7 7 und 0 5
        // - 5 7 und 7 0 [fail]
        // - 7 0 und 5 7 [fail]
        // - 0 7 und 7 5 [fail]
        // - 5 7 und 0 7 [fail]

        if (Math.abs(deltaX) > Math.abs(deltaY)) {
            steigung = (0.d + deltaY) / deltaX;
            longerDelta = deltaX;
            longerIsX = true;

        } else {
            steigung = (0.d + deltaX) / deltaY;
            longerDelta = deltaY;
            longerIsX = false;
        }

        chosenX = xStart;
        chosenY = yStart;

        for (int i = 1; i < Math.abs(longerDelta); i++) {
            Integer neuePositionX;
            Integer neuePositionY;

            if (longerIsX) {

                if (deltaY < 0) { // TODO: here
                    neuePositionX = chosenX - i;
                    neuePositionY = Long.valueOf(Math.round(chosenY - i * steigung)).intValue();

                } else {
                    neuePositionX = chosenX + i;
                    neuePositionY = Long.valueOf(Math.round(chosenY + i * steigung)).intValue();
                }

            } else {

                if (deltaX < 0) { // TODO: here
                    neuePositionY = chosenY - i;
                    neuePositionX = Long.valueOf(Math.round(chosenX - i * steigung)).intValue();

                } else {
                    neuePositionY = chosenY + i;
                    neuePositionX = Long.valueOf(Math.round(chosenX + i * steigung)).intValue();
                }


            }

            brett[neuePositionY][neuePositionX] = ".";
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
