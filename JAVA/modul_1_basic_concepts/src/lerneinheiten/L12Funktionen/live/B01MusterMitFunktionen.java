package lerneinheiten.L12Funktionen.live;

import static lerneinheiten.L12Funktionen.live.B01MusterMitFunktionen.Richtung.*;

public class B01MusterMitFunktionen {
    public static void main(String[] args) {
        // Ziel: 🙂 Diamant aus Dreiecken bauen
        // ❎0️⃣1️⃣2️⃣3️⃣4️⃣5️⃣6️⃣7️⃣8️⃣9️⃣
        // 0️⃣🔹🔹🔹🔹⬜⬜🔹🔹🔹🔹
        // 1️⃣🔹🔹🔹⬜⬜⬜⬜🔹🔹🔹
        // 2️⃣🔹🔹⬜⬜⬜⬜⬜⬜🔹🔹
        // 3️⃣🔹⬜⬜⬜⬜⬜⬜⬜⬜🔹
        // 4️⃣⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
        // 5️⃣⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
        // 6️⃣🔹⬜⬜⬜⬜⬜⬜⬜⬜🔹
        // 7️⃣🔹🔹⬜⬜⬜⬜⬜⬜🔹🔹
        // 8️⃣🔹🔹🔹⬜⬜⬜⬜🔹🔹🔹
        // 9️⃣🔹🔹🔹🔹⬜⬜🔹🔹🔹🔹

        // Schritt 1: 🙂 Dreieck "normal"
        // ❎0️⃣1️⃣2️⃣3️⃣4️⃣
        // 0️⃣⬜🔹🔹🔹🔹
        // 1️⃣⬜⬜🔹🔹🔹
        // 2️⃣⬜⬜⬜🔹🔹
        // 3️⃣⬜⬜⬜⬜🔹
        // 4️⃣⬜⬜⬜⬜⬜

        // Schritt 2: 🙂 Dreieck gespiegelt
        // ❎0️⃣1️⃣2️⃣3️⃣4️⃣
        // 0️⃣⬜⬜⬜⬜⬜
        // 1️⃣⬜⬜⬜⬜🔹
        // 2️⃣⬜⬜⬜🔹🔹
        // 3️⃣⬜⬜🔹🔹🔹
        // 4️⃣⬜🔹🔹🔹🔹

        // ...

        int groesseSpielfeld = 5;
        String[][] diamant = erzeugeDiamant(groesseSpielfeld);
        String[][] pfeilOben = spiegelnX(erzeugePfeil(groesseSpielfeld));
        String[][] pfeilUnten = erzeugePfeil(groesseSpielfeld);
//        var diamant = erzeugeDiamant(groesseSpielfeld);

        print(pfeilOben);
        print(diamant);
        print(pfeilUnten);

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
        diamant = kombiniere(diamant, dreieckRechtsOben, RechtsOben);
        diamant = kombiniere(diamant, dreieckRechtsUnten, RechtsUnten);
        diamant = kombiniere(diamant, dreieckLinksOben, LinksOben);
        diamant = kombiniere(diamant, dreieckLinksUnten, LinksUnten);

        return diamant;
    }

    static String[][] erzeugePfeil(int groesseSpielfeld) {
        String[][] dreieckRechtsOben = erzeugeDreieck(groesseSpielfeld);
        String[][] dreieckRechtsUnten = spiegelnX(dreieckRechtsOben);
        String[][] dreieckLinksUnten = spiegelnY(dreieckRechtsUnten);
        String[][] dreieckLinksOben = spiegelnY(dreieckRechtsOben);

        String[][] diamant = new String[2*groesseSpielfeld][2*groesseSpielfeld];
        diamant = kombiniere(diamant, dreieckRechtsOben, LinksOben);
        diamant = kombiniere(diamant, dreieckRechtsUnten, RechtsUnten);
        diamant = kombiniere(diamant, dreieckLinksOben, RechtsOben);
        diamant = kombiniere(diamant, dreieckLinksUnten, LinksUnten);

        return diamant;
    }

    static String[][] kombiniere(String[][] diamant, String[][] dreieck, Richtung richtung) {
        for (int zeilen = 0; zeilen < dreieck.length; zeilen++) {
            for (int spalten = 0; spalten < dreieck.length; spalten++) {
                switch (richtung) {
                    case LinksOben -> diamant[zeilen][spalten] = dreieck[zeilen][spalten];
                    case RechtsOben -> diamant[zeilen][spalten + dreieck.length] = dreieck[zeilen][spalten];
                    case LinksUnten -> diamant[zeilen + dreieck.length][spalten] = dreieck[zeilen][spalten];
                    case RechtsUnten -> diamant[zeilen + dreieck.length][spalten + dreieck.length] = dreieck[zeilen][spalten];
                }
            }
        }

        return diamant;
    }

    public enum Richtung {
        RechtsOben, LinksOben, RechtsUnten, LinksUnten
    }
}
