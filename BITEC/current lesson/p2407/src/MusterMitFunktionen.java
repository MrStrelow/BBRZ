import java.util.Arrays;

public class MusterMitFunktionen {

    public static void main(String[] args) {
        // wir wollen einen Diamanten aus dreiecken bauen.
        // #
        // ##
        // ###
        // ####

        // 2d array anlegen
        String[][] feld = new String[5][5];

        feld = fillCanvas(feld, "~");
        String[][] triangle = drawTriangle(feld, "#");
        String[][] diamond = drawDiamond(triangle);
        print(diamond);
    }

    // merke static davor schreiben sonst gehts nicht. was das ist, siehe objektorientierung.
    static void print(String[][] feld) {
        for (int i = 0; i < feld.length; i++) {
            for (int j = 0; j < feld.length; j++) {
                System.out.print(feld[i][j]);
            }
            System.out.println();
        }
    }

    static String[][] fillCanvas(String[][] feld, String symbol) {
        String[][] ret = new String[feld.length][feld.length];

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = symbol;
            }
        }

        return ret;
    }

    static String[][] drawTriangle(String[][] feld, String symbol) {
        String[][] ret = copy(feld);

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                if(j <= i) {
                    ret[i][j] = symbol;
                }
            }
        }

        return ret;
    }

    static String[][] copy(String[][] feld) {
        String[][] ret = new String[feld.length][feld.length];

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = feld[i][j];
            }
        }

        return ret;
    }

    static String[][] drehen(String[][] feld) {
        return transpose(mirror(feld));
    }

    // vertausche x mit y
    static String[][] transpose(String[][] feld) {
        String[][] ret = copy(feld);

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = feld[j][i];
            }
        }

        return ret;
    }

    // spiegle entlang der x achse
    static String[][] mirror(String[][] feld) {
        String[][] ret = copy(feld);

        for (int i = 0; i < ret.length; i++) {
            for (int j = 0; j < ret.length; j++) {
                ret[i][j] = feld[ret.length - 1 - i][j];
            }
        }

        return ret;
    }

    static String[][] drawDiamond(String[][] feld) {
        String[][] rechtsOben  = feld;
        String[][] rechtsUnten = drehen(feld);
        String[][] linksUnten  = drehen(drehen(feld));
        String[][] linksOben   = drehen(drehen(drehen(feld)));

        String[][] ret = new String[2 * feld.length][2 * feld.length];

        for (int i = 0; i < feld.length; i++) {
            for (int j = feld.length; j < 2 * feld.length; j++) {
                ret[i][j] = rechtsOben[i][j - feld.length];
            }
        }

        for (int i = feld.length; i < 2 * feld.length; i++) {
            for (int j = feld.length; j < 2 * feld.length; j++) {
                ret[i][j] = rechtsUnten[i - feld.length][j - feld.length];
            }
        }

        for (int i = feld.length; i < 2 * feld.length; i++) {
            for (int j = 0; j < feld.length; j++) {
                ret[i][j] = linksUnten[i - feld.length][j];
            }
        }

        for (int i = 0; i < feld.length; i++) {
            for (int j = 0; j < feld.length; j++) {
                ret[i][j] = linksOben[i][j];
            }
        }

        return ret;
    }

}
