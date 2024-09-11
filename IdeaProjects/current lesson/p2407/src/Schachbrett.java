import java.util.Arrays;

public class Schachbrett {
    public static void main(String[] args) {
        String[][] brett = new String[8][8];

        System.out.println(Arrays.deepToString(brett));

        System.out.println();
        char whiteSquare = 0x2588;
        char blackSquare = 0x2591;

        String whiteSquareSymbol = new String(Character.toChars(whiteSquare));
        String blackSquareSymbol = new String(Character.toChars(blackSquare));

        // Zeile:  i
        // Spalte: j
        for (int i = 0; i < brett.length; i++) {
            for (int j = 0; j < brett[0].length; j++) {

                if (i % 2 == 0) {

                    if (j % 2 == 0) {
                        brett[i][j] = whiteSquareSymbol;

                    } else {
                        brett[i][j] = blackSquareSymbol;
                    }

                } else {

                    if (j % 2 == 0) {
                        brett[i][j] = blackSquareSymbol;

                    } else {
                        brett[i][j] = whiteSquareSymbol;
                    }
                }

                System.out.print(brett[i][j]); // Index: zuerst Zeilen, dann Spalten angeben.
            }
            System.out.println();
        }
    }
}
