package VergangeneTests.ModulTest_2025_05.Aufgabe_1;

import java.util.Arrays;

public class Programmieren_02 {
    static String ANSI_RESET = "\u001B[0m";
    static String ANSI_RED = "\u001B[31m";
    static String ANSI_BLUE = "\u001B[34m";
    static String ANSI_YELLOW = "\u001B[33m";
    static String colorOfOuterLoop = ANSI_RED;
    static String colorOfInnerLoop = ANSI_BLUE;

    public static void main(String[] args) {
        int[] zahlen = {53, 5, 2, 26, -86};

        for (int j = 0; j < zahlen.length - 1; j++) {
            System.out.println(colorOfInnerLoop + "Durchgang: " + j + ANSI_RESET);
            
            for (int i = 0; i < zahlen.length - 1 - j; i++) {

                if (zahlen[i] > zahlen[i+1]) {
                    int platzhalter = zahlen[i+1];
                    zahlen[i+1] = zahlen[i];
                    zahlen[i] = platzhalter;
                }

                // Bunte - Ausgabe
                String zahlenColored = colorAt(
                    zahlen,
                    new int[]{i+1, i},
                    new String[]{colorOfOuterLoop, colorOfOuterLoop},
                    ANSI_RESET
                );

                System.out.println(
                    "[" +
                        colorOfOuterLoop + "i=" + i + ANSI_RESET + ", " +
                        colorOfInnerLoop + "j=" + j + ANSI_RESET +
                    "]: " +
                    zahlenColored + ANSI_RESET
                );

            }
            System.out.println();
        }

        System.out.println("🏁".repeat(14));
        System.out.println(ANSI_YELLOW + Arrays.toString(zahlen) + ANSI_RESET);
    }

    static String colorAt(int[] zahlen, int[] posToColor, String[] colorOfPos, String baseColor) {
        String[] coloredZahlen = new String[zahlen.length];

        for (int i = 0; i < zahlen.length; i++) {
            coloredZahlen[i] = Integer.toString(zahlen[i]);
        }

        for (int i = 0; i < posToColor.length; i++) {
            coloredZahlen[posToColor[i]] = colorOfPos[i] + zahlen[posToColor[i]] + baseColor;
        }

        return baseColor + Arrays.toString(coloredZahlen);
    }
}