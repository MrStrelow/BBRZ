import jdk.jshell.spi.ExecutionControl;

public class FunktionenBeispielMuster {
    public static void main(String[] args) {
        String[][] feld = fillCanvas(new String[6][6], "~");
        String[][] dreieck = drawTriangle(feld, "#");
        print(dreieck);
//        String[][] diamant = drawDiamond(dreieck);
//        print(diamant);
    }

    // Achtung! static immer vor die Funktion schreiben. Brauchen wir hier wegen der Objektorientierung. Das lernen wir später kennen.
    // funktion welche ein 2d Array auf die Console ausgibt
    static void print(String[][] field) {
        for (int i = 0; i < field.length; i++) {
            for (int j = 0; j < field.length; j++) {
                System.out.print(field[i][j]);
            }
            System.out.println();
        }
    }

    // funktion welche in ein 2d Array eine Raute(Diamant) zeichnet
    static String[][] drawDiamond(String[][] triangle) {
        String[][] topRight = triangle;
        String[][] botRight = mirrorX(triangle);
        String[][] botLeft = mirrorY(botRight);
        String[][] topLeft = mirrorX(botLeft);

        String[][] diamond = new String[2*triangle.length][2*triangle[0].length];
        diamond = combineForm(diamond, topRight, Position.TOPRIGHT);
        diamond = combineForm(diamond, botRight, Position.BOTRIGHT);
        diamond = combineForm(diamond, botLeft, Position.BOTLEFT);
        diamond = combineForm(diamond, topLeft, Position.TOPLEFT);

        return diamond;
    }

    // funktion welche in ein 2d Array ein Dreieck zeichnet
    static String[][] drawTriangle(String[][] field, String symbol) {
        for (int i = 0; i < field.length; i++) {
            for (int j = 0; j < field.length; j++) {
                if (j <= i) {
                    field[i][j] = symbol;
                }
            }
        }

        return field;
    }

    // funktion welche ein 2d Array mit einem Symbol befüllt
    static String[][] fillCanvas(String[][] field, String symbol) {
        for (int i = 0; i < field.length; i++) {
            for (int j = 0; j < field.length; j++) {
                field[i][j] = symbol;
            }
        }

        return field;
    }

    // funktion um alles zusammenzufügen - diese funktion wird in der drawDiamant aufgerufen
    static String[][] combineForm(String[][] diamond, String[][] triangle, Position position) {
        return null;
    }

    // funktion welche muster um x achse spiegelt - diese funktion wird in der drawDiamant aufgerufen
    static String[][] mirrorX(String[][] field) {
        return null;
    }

    // funktion welche muster um y achse spiegelt - diese funktion wird in der drawDiamant aufgerufen
    static String[][] mirrorY(String[][] field) {
        return null;
    }

}

enum Position {
    TOPRIGHT, TOPLEFT, BOTRIGHT, BOTLEFT
}
