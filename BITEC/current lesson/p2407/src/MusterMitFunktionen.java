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

        feld = fillCanvas(feld, "");
        feld = drawTriangle(feld, "#");
        print(feld);
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
                if(j <= i) {
                    ret[i][j] = feld[i][j];
                }
            }
        }
    }

    static String[][] drehen() {
        return null;
    }

    // vertausche x mit y
    static String[][] transpose() {
        return null;
    }

    // spiegle entlang der y achse
    static String[][] mirror() {
        return null;
    }

}
