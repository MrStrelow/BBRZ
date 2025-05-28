package lerneinheiten.L12Funktionen.live;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class B01Muster {
    public static void main(String[] args) {
        // 7. 🙂 Diamant aus Dreiecken bauen
        // 🔹🔹🔹🔹⬜⬜🔹🔹🔹🔹
        // 🔹🔹🔹⬜⬜⬜⬜🔹🔹🔹
        // 🔹🔹⬜⬜⬜⬜⬜⬜🔹🔹
        // 🔹⬜⬜⬜⬜⬜⬜⬜⬜🔹
        // ⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
        // ⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
        // 🔹⬜⬜⬜⬜⬜⬜⬜⬜🔹
        // 🔹🔹⬜⬜⬜⬜⬜⬜🔹🔹
        // 🔹🔹🔹⬜⬜⬜⬜🔹🔹🔹
        // 🔹🔹🔹🔹⬜⬜🔹🔹🔹🔹

        // 1. 🤔 Dreieck
        // ❎0️⃣1️⃣2️⃣3️⃣4️⃣
        // 0️⃣⬜🔹🔹🔹🔹
        // 1️⃣⬜⬜🔹🔹🔹
        // 2️⃣⬜⬜⬜🔹🔹
        // 3️⃣⬜⬜⬜⬜🔹
        // 4️⃣⬜⬜⬜⬜⬜

        // ❎0️⃣1️⃣2️⃣3️⃣4️⃣
        // 0️⃣⬜⬜⬜⬜⬜
        // 1️⃣⬜⬜⬜⬜🔹
        // 2️⃣⬜⬜⬜🔹🔹
        // 3️⃣⬜⬜🔹🔹🔹
        // 4️⃣⬜🔹🔹🔹🔹

        int groesseSpielfeld = 5;
        String[][] dreieck = erzeugeDreieck(groesseSpielfeld);
//        var dreieck = erzeugeDreieck(groesseSpielfeld);
        String[][] gespiegeltesDreieck = spiegelnX(dreieck);

        print(gespiegeltesDreieck);
//        System.out.println(Arrays.deepToString(brett));
    }

    static String[][] spiegelnX(String[][] array) {
        for (int zeilen = 0; zeilen < array.length; zeilen++) {
            for (int spalten = 0; spalten < array[0].length; spalten++) {
                array[array.length-1-zeilen][spalten] = array[zeilen][spalten];
            }
        }

        return array;
    }

    static void print(String[][] array) {
        for (int zeilen = 0; zeilen < array.length; zeilen++) {
            for (int spalten = 0; spalten < array[0].length; spalten++) {
                System.out.print(array[zeilen][spalten]);
            }
            System.out.println();
        }
    }

    static String[][] erzeugeDreieck(int groesseSpielfeld) {
        String[][] dreieck = new String[groesseSpielfeld][groesseSpielfeld];

        for (int zeilen = 0; zeilen < groesseSpielfeld; zeilen++) {
            for (int spalten = 0; spalten < groesseSpielfeld; spalten++) {
                if (zeilen >= spalten) {
                    dreieck[zeilen][spalten] = "⬜";
//                    System.out.print("⬜");

                } else {
                    dreieck[zeilen][spalten] = "🔹";
//                    System.out.print("🔹");
                }
            }
        }

        return dreieck;
    }
}
