package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class wiederholung {
    public static void main(String[] args) {
        // lege ein 2d array an um unser feld speichern zu können.
        String[][] field;

        // den user entscheiden lassen wie groß die form wird.
        Scanner scanner = new Scanner(System.in);

        System.out.print("Bitte gib eine Zahl wie 2 oder 4 ohne Komma ein: ");
        // Zuständigkeit: Frage solange nach, bis eine Zahl vom User eingegeben wurde.
        while (!scanner.hasNextInt()) {
            System.out.println("Eingabe nicht in eine Zahl umwandelbar -> bitte Zahl wie 2 oder 4 ohne Komma eingeben.");
            scanner.next(); // verbrauche input und verwerfe diesen -> sonst infinite loop.
        }

        int size = scanner.nextInt();
        // zuerst zeile dann spalte!
        field = new String[size][size];

        // generiere die form (dreieck)
        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < size; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < size; spalte++) {
                // Zuständigkeiten: wann wird ein symbol ausgegeben für unser dreieck?
                if (zeile >= spalte) {
                    field[zeile][spalte] = "⬜";
                    // System.out.print("⬜"); // mit windows und punkt kann ein emoji menü aufgerufen werden.
                } else {
                    field[zeile][spalte] = "🔸";
                }
            }
            // System.out.println();
        }



        // frage den user ob er diese form gedreht haben will (90, 180, 270)
    }

    // Zuständigkeit: gib das 2D-Array (Eingangs-Parameter) auf der console aus. Gib nichts zurück (Rückgabeparameter).
    public static void printForm(String[][] fieldtoBePlotted) {
        // grafische ausgabe der form
        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < size; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < size; spalte++) {
                System.out.print(field[zeile][spalte]);
            }
            System.out.println();
        }
    }
}
