package lerneinheiten.L12Funktionen.live;

import java.sql.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

import static lerneinheiten.L12Funktionen.live.B01Muster.Richtung.*;

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
        String[][] diamant = erzeugeDiamant(groesseSpielfeld);
//        var diamant = erzeugeDiamant(groesseSpielfeld);
        print(diamant);

//        System.out.println(Arrays.deepToString(brett));
    }

    static String[][] spiegelnY(String[][] array) {
        String [][] gespiegeltesArray = new String[array.length][array[0].length];
        int anzahl_zeilen = array.length;
        int anzahl_spalten = array[0].length;

        for (int zeilen = 0; zeilen < anzahl_zeilen; zeilen++) {
            for (int spalten = 0; spalten < anzahl_spalten; spalten++) {
                gespiegeltesArray[zeilen][anzahl_spalten - 1 - spalten] = array[zeilen][spalten];
            }
        }

        return gespiegeltesArray;
    }

    static String[][] spiegelnX(String[][] array) {
        String [][] gespiegeltesArray = new String[array.length][array[0].length];
        int anzahl_zeilen = array.length;
        int anzahl_spalten = array[0].length;

        for (int zeilen = 0; zeilen < anzahl_zeilen; zeilen++) {
            for (int spalten = 0; spalten < anzahl_spalten; spalten++) {
                gespiegeltesArray[anzahl_zeilen - 1 - zeilen][spalten] = array[zeilen][spalten];
            }
        }

        return gespiegeltesArray;
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

    static String[][] erzeugeDiamant(int groesseSpielfeld) {
        String[][] dreieckRechtsOben = erzeugeDreieck(groesseSpielfeld);
        String[][] dreieckRechtsUnten = spiegelnX(dreieckRechtsOben);
        String[][] dreieckLinksUnten = spiegelnY(dreieckRechtsUnten);
        String[][] dreieckLinksOben = spiegelnY(dreieckRechtsOben);

        String[][] diamant = new String[2*groesseSpielfeld][2*groesseSpielfeld];
        diamant = kombiniereZuDiamant(diamant, dreieckRechtsOben, RechtsOben);
        diamant = kombiniereZuDiamant(diamant, dreieckRechtsUnten, RechtsUnten);
        diamant = kombiniereZuDiamant(diamant, dreieckLinksOben, LinksOben);
        diamant = kombiniereZuDiamant(diamant, dreieckLinksUnten, LinksUnten);

        return diamant;
    }

    static String[][] kombiniereZuDiamant(String[][] diamant, String[][] dreieck, Richtung richtung) {
        for (int zeilen = 0; zeilen < dreieck.length; zeilen++) {
            for (int spalten = 0; spalten < dreieck.length; spalten++) {
                switch (richtung) {
                    case LinksOben -> diamant[zeilen][spalten] = dreieck[zeilen][spalten];
                    case RechtsOben -> {}
                    case LinksUnten -> {}
                    case RechtsUnten -> {}
                }
            }
        }

        print(diamant);

        return diamant;
    }

    public enum Richtung {
        RechtsOben, LinksOben, RechtsUnten, LinksUnten
    }
}
