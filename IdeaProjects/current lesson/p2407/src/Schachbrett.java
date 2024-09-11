import java.util.Arrays;
import java.util.Scanner;

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

                // GERADE zeilen (wir beginnen bei 0 und das ist gerade) haben an den UNGERADEN Spalten ein Schwarzes Symbol.
                if ( (i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0) ) {
                    brett[i][j] = blackSquareSymbol;
                }
                    // Ansonsten ist das Symbol weiß.
                // (explizit, also direkt ist die Formel für weiß...)
                // Achtung! das Gegenteil ist nicht einfach die 0 zu 1 machen!
                // Ja in den Spalten ist es so, aber die Logik der Zeilen bleibt gleich.
//                if ((i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1) ){
                else {
                    brett[i][j] = whiteSquareSymbol;
                }

//                if (i % 2 == 0) {
//
//                    if (j % 2 == 0) {
//                        brett[i][j] = whiteSquareSymbol;
//
//                    } else {
//                        brett[i][j] = blackSquareSymbol;
//                    }
//
//                } else {
//
//                    if (j % 2 == 0) {
//                        brett[i][j] = blackSquareSymbol;
//
//                    } else {
//                        brett[i][j] = whiteSquareSymbol;
//                    }
//                }

                System.out.print(brett[i][j]); // Index: zuerst Zeilen, dann Spalten angeben.
            }
            System.out.println();
        }


        // Userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Wähle die Figur... [x y]: ");
        String[] userinput = scanner.nextLine().split(" ");

        Integer xStart = Integer.parseInt( userinput[0] );
        Integer yStart = Integer.parseInt( userinput[1] );

        System.out.print("... und wähle das Ziel [x y]: ");
        userinput = scanner.nextLine().split(" ");

        Integer xZiel = Integer.parseInt( userinput[0] );
        Integer yZiel = Integer.parseInt( userinput[1] );

        System.out.println(xStart + yStart + xZiel + yZiel);

        brett[xStart][yStart] = "O";
        brett[xZiel][yZiel] = "X";



        for (int i = 0; i < brett.length; i++) {
            for (int j = 0; j < brett[0].length; j++) {
                System.out.print(brett[i][j]);
            }
        System.out.println();
        }
    }
}
