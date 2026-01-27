package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class wiederholung {
    public static void main(String[] args) {
        // den user entscheiden lassen wie groß die form wird.
        Scanner scanner = new Scanner(System.in);

        System.out.print("Bitte gib eine Zahl wie 2 oder 4 ohne Komma ein: ");
        // Zuständigkeit: Frage solange nach, bis eine Zahl vom User eingegeben wurde.
        while (!scanner.hasNextInt()) {
            System.out.println("Eingabe nicht in eine Zahl umwandelbar -> bitte Zahl wie 2 oder 4 ohne Komma eingeben.");
            scanner.next(); // verbrauche input und verwerfe diesen -> sonst infinite loop.
        }

        int size = scanner.nextInt();

        String[][] field = createTriangle(size);
//        String[][] mirroredXField = mirrorX(field);
//        String[][] mirroredYField = mirrorY(field);
//        printForm(field);
//        printForm(mirroredXField);
//        printForm(mirroredYField);

//        printForm(field);
//        printForm(drehenRechts(field));
//        printForm(drehenLinks(field));


        // frage den user ob er diese form gedreht haben will (90, 180, 270)
        printForm(drehen(field, "rchTs"));
    }

    // Zuständigkeit: gib das 2D-Array (Eingangs-Parameter) auf der console aus. gib nichts zurück (Rückgabe-Parameter).
    public static void printForm(String[][] fieldtoBePlotted) {
        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < fieldtoBePlotted.length; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < fieldtoBePlotted[0].length; spalte++) {
                System.out.print(fieldtoBePlotted[zeile][spalte]);
            }
            System.out.println();
        }
    }

    // Zuständigkeit: generiere die form "dreieck". Die größe des dreiecks ist vom aufrufer zu übergeben (Eingangs-Parameter).
    //
    public static String[][] createTriangle(int size) {
        String[][] field = new String[size][size];

        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < size; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < size; spalte++) {
                // Zuständigkeiten: wann wird ein symbol ausgegeben für unser dreieck?
                if (zeile >= spalte) {
                    field[zeile][spalte] = "⬜"; // mit windows und punkt kann ein emoji menü aufgerufen werden.
                } else {
                    field[zeile][spalte] = "🔸";
                }
            }
        }

        return field;
    }

    // Zuständigkeit: drehen ein beliebiges 2D-String-Array 90°, 180° oder 270° nach rechts.
    public static String[][] drehenRechts(String[][] field) {
        return mirrorY(transponieren(field));
    }

    public static String[][] drehenLinks(String[][] field) {
        return mirrorX(transponieren(field));
    }

    // Zuständigkeit: spielgeln in X eines 2D-String-Arrays.
    public static String[][] mirrorX(String[][] field) {
        String[][] mirrored = new String[field.length][field.length];

        for (int zeile = 0; zeile < field.length; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < field[0].length; spalte++) {
                mirrored[field.length - 1 - zeile][spalte] = field[zeile][spalte];
            }
        }

        return mirrored;
    }

    // Zuständigkeit: spielgeln in Y eines 2D-String-Arrays.
    public static String[][] mirrorY(String[][] field) {
        String[][] mirrored = new String[field.length][field.length];

        for (int zeile = 0; zeile < field.length; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < field[0].length; spalte++) {
                mirrored[zeile][field.length - 1 - spalte] = field[zeile][spalte];
            }
        }

        return mirrored;
    }

    // Zuständigkeit:  vertausche x und y koordinaten eines 2D-Arrays.
    public static String[][] transponieren(String[][] field) {
        String[][] transposed = new String[field.length][field.length];

        for (int zeile = 0; zeile < field.length; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < field[0].length; spalte++) {
                transposed[spalte][zeile] = field[zeile][spalte];
            }
        }

        return transposed;
    }

    // Zuständigkeit: Der user soll angeben in welche Richtung und wie weit das 2D-Array gedreht werden soll.
    public static String[][] drehen(String[][] field, Richtung richtung, Winkel winkel) {
//        if (richtung.equalsIgnoreCase("rechts")) {
//            return drehenRechts(field);
//        } else if (richtung.equalsIgnoreCase("links")) {
//            return drehenLinks(field);
//        } else {
//            return field;
//        }

        return switch (richtung) {
            case RECHTS -> switch (winkel) {
                case d90 -> drehenRechts(field);
                case d180 -> drehenRechts(drehenRechts(field));
                case d270 -> drehenRechts(drehenRechts(drehenRechts(field)));
            };
            case LINKS -> switch (winkel) {
                case d90 -> drehenLinks(field);
                case d180 -> drehenLinks(drehenLinks(field));
                case d270 -> drehenLinks(drehenLinks(drehenLinks(field)));
            };
        };
    }
}

