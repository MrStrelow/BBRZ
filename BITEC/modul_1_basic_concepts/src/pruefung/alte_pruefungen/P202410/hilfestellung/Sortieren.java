package pruefung.alte_pruefungen.P202410.hilfestellung;

import java.util.Arrays;

public class Sortieren {
    public static void main(String[] args) {
//        erzeugt null pointer exception: Fehler, belege zuerst die Positionen mit Zahlen dass nicht mehr null drinnen steht.
//        Integer[] zahlenzwei = new Integer[5];
//        zahlenzwei[0].doubleValue();
//        System.out.println(Arrays.toString(zahlenzwei));

        Integer[] zahlen = {28, 26, 6, 4, 2};

        Integer platzhalter;

        // Schritt 3: Wiederhole 2. solange bis alle Zahlen sortiert sind.
        // Wir lassen also jede Zahl nach rechts "aufsteigen", bis diese an der richtigen Position ist.
        // Wie oft müssen wir diesen Algorithmus wiederholen?
//        for (int j = zahlen.length; j > 0; j--) {
        for (int j = 0; j < zahlen.length - 1; j++) {
            System.out.println((j+1) + " Durchlauf");

            // Schritt 2: Wiederhole 1. für alle Paare mit Index 0 und 1, 1 und 2, 2 und 3, 3 und 4.
            for (int i = 0; i < zahlen.length - 1 - j; i++) {

                if (zahlen[i] > zahlen[i+1]) {
                    platzhalter = zahlen[i];
                    zahlen[i] = zahlen[i+1];
                    zahlen[i+1] = platzhalter;
                }

                System.out.println((i + 1) + " Paar" + Arrays.toString(zahlen));
            }

        }




    }
}
