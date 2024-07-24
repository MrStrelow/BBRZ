import java.util.Scanner;

public class L09LinesOnChessBoard {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Groesse des Spielbretts eingeben: ");
        Integer dimension = Integer.parseInt(scanner.nextLine());

        String[][] brett = new String[dimension][dimension];

        char whiteSquare = 0x2588;
        char blackSquare = 0x2591;

//        Erstelle ein Schachbrettmuster beliebiger Größe welche vom User bestimmt wird.
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                if ((j + i) % 2 == 0)
                    brett[i][j] = new String(Character.toChars(whiteSquare));
                else
                    brett[i][j] = new String(Character.toChars(blackSquare));
            }
        }

//        Verbinde 2 gewählte Felder mit einer Linie
//        Berechne dazu die Steigung der Linie (Siehe Tafelbild 21.12.2023)
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

        brett[posY[0]][posX[0]] = "o";
        brett[posY[1]][posX[1]] = "x";

        Integer deltaX = posX[0] - posX[1];
        Integer deltaY = posY[0] - posY[1];
        Double steigung;
        Integer longerDelta;
        Boolean longerIsX;
        Integer chosenY;
        Integer chosenX;

        if (Math.abs(deltaX) > Math.abs(deltaY)) {

            steigung = (0.d + deltaY) / deltaX;
            longerDelta = deltaX;
            longerIsX = true;
            chosenX = posX[0];
            chosenY = posY[0];

        } else {

            steigung = (0.d + deltaX) / deltaY;
            longerDelta = deltaY;
            longerIsX = false;
            chosenX = posX[0];
            chosenY = posY[0];

        }

        for (int i = 1; i < Math.abs(longerDelta); i++) {
            Integer neuePositionX;
            Integer neuePositionY;

            if (longerIsX) {
                neuePositionY = Long.valueOf(Math.round(chosenY + i * steigung)).intValue();
                neuePositionX = chosenX + i;
            } else {
                neuePositionY = chosenY + i;
                neuePositionX = Long.valueOf(Math.round(chosenX + i * steigung)).intValue();
            }

            brett[neuePositionY][neuePositionX] = ".";
        }

        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                System.out.print(brett[i][j]);
            }
            System.out.println();
        }
    }
}
