package lerneinheiten.L05InterfacesUndAbstrakteKlassen.sorting;

import java.util.Arrays;

public class SortMe {
    public static void main(String[] args) {
        // 1. Ziel: vertausche die ersten zwei Zahlen des Arrays.
        // 2. Ziel: schiebe die größere Zahl immer weiter bis ans Ende des Arrays. Verwende dazu das Vertauschen aus 1.)
        // 3. Ziel: wiederhole nun 2. damit immer wieder die erste Zahl nach rechts geschoben wird.

        //1) vergleiche die ersten 2 zahlen im array und wenn die linke zahl größer als die rechte zahl ist,
        // dann schiebe diese nach rechts. sonts mach nix.
        Blume blume1 = new Blume(10, 5);
        Blume blume2 = new Blume(9,4);
        Blume blume3 = new Blume(8,3);
        Blume blume4 = new Blume(7,2);
        Blume blume5 = new Blume(6,1);

        Blume[] blumen = {blume1, blume2, blume3, blume4, blume5};

        //2) vergleiche alle paare in dem array
        for (int j = 0; j < blumen.length - 1; j++) {
            for (int i = 0; i < blumen.length - 1 - j; i++) {
                if (blumen[i].compareTo(blumen[i+1]) == 1) {
                    Blume hilfsvariable = blumen[i+1];// meistens tmp genannt
                    blumen[i+1] = blumen[i];
                    blumen[i] = hilfsvariable;
                }
                System.out.println(Arrays.toString(blumen));
            }
            System.out.println("~~~~~~~~~ERSTE ZAHL VERSCHOBEN~~~~~~~~~");
        }



        int[] zuSortieren = {28,26,6,4,2};

        //2) vergleiche alle paare in dem array
        for (int j = 0; j < zuSortieren.length - 1; j++) {
            for (int i = 0; i < zuSortieren.length - 1 - j; i++) {
                if (zuSortieren[i] > zuSortieren[i+1]) {
                    int hilfsvariable = zuSortieren[i+1];// meistens tmp genannt
                    zuSortieren[i+1] = zuSortieren[i];
                    zuSortieren[i] = hilfsvariable;
                }
                System.out.println(Arrays.toString(zuSortieren));
            }
            System.out.println("~~~~~~~~~ERSTE ZAHL VERSCHOBEN~~~~~~~~~");
        }



        //3) führe es aus bis alle zahlen sortiert sind
    }
}
