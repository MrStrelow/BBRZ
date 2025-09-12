package lerneinheiten.L12Funktionen;

public class L12MusterMitFunktionen {
    public static void main(String[] args) {
    // Hier nun ein Beispiel um die Funktionen zu motivieren. Wir wollen aus einem Dreieck einen Diamanten machen.
    // Dreiecke sind rechtwinklige und gleichschenklige Dreiecke.
    // z.B.
    // #
    // ##
    // ###
    // ####

    // Wir wollen dieses "drehen" (oder besser spiegeln), dass
    //    #
    //   ##
    //  ###
    // ####

    // ####
    // ###
    // ##
    // #

    // und
    // ####
    //  ###
    //   ##
    //    #
    // rauskommt.

    // Wir werden das dann zusammenfügen, um
    //           ##
    //          ####
    //         ######
    //        ########
    //        ########
    //         ######
    //          ####
    //           ##
    // zu erzeugen.


    // 2d array anlegen
    String[][] field = new String[5][5];

    // verwende
    field = fillCanvas(field, "~");
    String[][] triangle = drawTriangle(field, "#");

    String[][] diamond = drawDiamondUsingRotations(triangle);
    print(diamond);

    diamond = drawDiamondsUsingMirror(triangle);
    print(diamond);
}

    // merke static davor schreiben sonst gehts nicht. was das ist, siehe objektorientierung.
    static void print(String[][] field) {
        for (int i = 0; i < field.length; i++) {
            for (int j = 0; j < field.length; j++) {
                System.out.print(field[i][j]);
            }
            System.out.println();
        }
    }

    static String[][] fillCanvas(String[][] field, String symbol) {
        String[][] ret = new String[field.length][field.length];

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = symbol;
            }
        }

        return ret;
    }

    static String[][] drawTriangle(String[][] field, String symbol) {
        String[][] ret = copy(field);

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
//            for (int j = 0; j <= i; j++) { //INFO: Es kann auch hier j <= i abgefragt werden! Wir gehen quasi "smarter". Wir gehen nur jene fielder ab, die wir auf symbol setzen wollen. Wir sparen uns dadurch das folgende IF.
                if(j <= i) {
                    ret[i][j] = symbol;
                }
            }
        }

        return ret;
    }

    static String[][] copy(String[][] field) {
        String[][] ret = new String[field.length][field.length];

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = field[i][j];
            }
        }

        return ret;
    }

    static String[][] drehen(String[][] field) {
        return transpose(mirrorX(field));
    }

    // vertausche x mit y
    static String[][] transpose(String[][] field) {
        String[][] ret = copy(field);

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = field[j][i];
            }
        }

        return ret;
    }

    // spiegle entlang der x achse
    static String[][] mirrorX(String[][] field) {
        String[][] ret = copy(field);

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = field[ret.length - 1 - i][j];
            }
        }

        return ret;
    }

    // spiegle entlang der y achse
    static String[][] mirrorY(String[][] field) {
        String[][] ret = copy(field);

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = field[i][ret.length - 1 - j];
            }
        }

        return ret;
    }

    static String[][] combineForm(String[][] diamond, String[][] triangle, Position position) {
        diamond = copy(diamond);
        int offset = triangle.length;

        for (int i = 0; i < triangle.length; i++) {
            for (int j = 0; j < triangle.length; j++) {
                switch (position) {
                    case TOP_LEFT  -> diamond[i][j] = triangle[i][j];
                    case BOT_RIGHT -> diamond[i + offset][j + offset] = triangle[i][j];
                    case BOT_LEFT  -> diamond[i + offset][j] = triangle[i][j];
                    case TOP_RIGHT -> diamond[i][j + offset] = triangle[i][j];
                }
            }
        }

        return diamond;
    }

    static String[][] drawDiamondUsingRotations(String[][] field) {
        // Streng genommen ist drehen hier falsch, wir wollen es eigentlich immer spiegeln.
        // Denke an ein objekt mit mehr spalten wie zeilen und drehe es vs. spielgel es.
        // Wir haben deshalb auch die Methoden für spiegeln (mirrorX und MirrorY) implementiert.
        String[][] topRight = copy(field);
        String[][] botRight = drehen(field);
        String[][] botLeft  = drehen(drehen(field));
        String[][] topLeft  = drehen(drehen(drehen(field)));

        String[][] ret = new String[2 * field.length][2 * field.length];

        ret = combineForm(ret, topRight, Position.TOP_RIGHT);
        ret = combineForm(ret, botRight, Position.BOT_RIGHT);
        ret = combineForm(ret, botLeft, Position.BOT_LEFT);
        ret = combineForm(ret, topLeft, Position.TOP_LEFT);

        return ret;
    }

    static String[][] drawDiamondsUsingMirror(String[][] field) {
        // Streng genommen ist drehen hier falsch, wir wollen es eigentlich immer spiegeln.
        // Denke an ein objekt mit mehr spalten wie zeilen und drehe es vs. spielgel es.
        // Wir haben deshalb auch die Methoden für spiegeln (mirrorX und MirrorY) implementiert.
        String[][] topRight = copy(field);
        String[][] botRight = mirrorX(field);
        String[][] botLeft  = mirrorY(botRight);
        String[][] topLeft  = mirrorX(botLeft);

        String[][] ret = new String[2 * field.length][2 * field.length];

        ret = combineForm(ret, topRight, Position.TOP_RIGHT);
        ret = combineForm(ret, botRight, Position.BOT_RIGHT);
        ret = combineForm(ret, botLeft, Position.BOT_LEFT);
        ret = combineForm(ret, topLeft, Position.TOP_LEFT);

        return ret;
    }
}

enum Position {
    TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT
}
