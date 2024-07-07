package block1.sonstige;

import java.util.Scanner;

public class LinesOnChessBoard {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Groesse des Spielbretts eingeben: ");
        Integer dimension = Integer.parseInt(scanner.nextLine());

        String[][] brett = new String[dimension][dimension];

        char whiteSquare = 0x2588;
        char blackSquare = 0x2591;

        // erstelle feld
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                if ((j + i) % 2 == 0)
                    brett[i][j] = new String(Character.toChars(whiteSquare));
                else
                    brett[i][j] = new String(Character.toChars(blackSquare));
            }
        }

        // figen waehlen
        Integer[] posX = new Integer[2];
        Integer[] posY = new Integer[2];

        System.out.print("Wähle Figur: ");
        posX[0] = scanner.nextInt();
        posY[0] = scanner.nextInt();
        scanner.nextLine();

        System.out.print("Bewege zu: ");
        posX[1] = scanner.nextInt();
        posY[1] = scanner.nextInt();
        scanner.nextLine();

        // linen zeichnen
        brett[posY[0]][posX[0]] = "o";
        brett[posY[1]][posX[1]] = "x";

        Integer deltaX = posX[0] - posX[1];
        Integer deltaY = posY[0] - posY[1];
        Double steigung = (0d + deltaY) / deltaX;
        System.out.println(steigung);

        for (int i = 1; i < Math.abs(deltaX); i++) {
            int neuePositionY = (int) Math.round(steigung * i + posY[0]); // k * x + d
            int neuePositionX = posX[0] + i;

            brett[neuePositionY][neuePositionX] = ".";
        }

        // feld ausgeben
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                System.out.print(brett[i][j]);
            }
            System.out.println();
        }
    }

}
