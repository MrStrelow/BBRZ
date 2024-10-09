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

    static String[][] assignLeftUpper(String[][] feld, String[][] leftUpper) {
        String[][] ret = copy(feld);

        for (int i = 0; i < leftUpper.length; i++) {
            for (int j = 0; j < leftUpper.length; j++) {
                ret[i][j] = leftUpper[i][j];
            }
        }

        return ret;
    }

    static String[][] assignLeftLower(String[][] feld, String[][] leftLower) {
        String[][] ret = copy(feld);

        for (int i = leftLower.length; i < feld.length; i++) {
            for (int j = 0; j < leftLower.length; j++) {
                ret[i][j] = leftLower[i - leftLower.length][j];
            }
        }

        return ret;
    }

    static String[][] assignRightLower(String[][] feld, String[][] rightLower) {
        String[][] ret = copy(feld);

        for (int i = rightLower.length; i < feld.length; i++) {
            for (int j = rightLower.length; j < feld.length; j++) {
                ret[i][j] = rightLower[i - rightLower.length][j - rightLower.length];
            }
        }

        return ret;
    }

    static String[][] assignRightUpper(String[][] feld, String[][] rightUpper) {
        String[][] ret = copy(feld);

        for (int i = 0; i < rightUpper.length; i++) {
            for (int j = rightUpper.length; j < feld.length; j++) {
                ret[i][j] = rightUpper[i][j - rightUpper.length];
            }
        }

        return ret;
    }

    static String[][] drawDiamond(String[][] feld) {
        String[][] rightUpper = copy(feld);
        String[][] rightLower = drehen(feld);
        String[][] leftLower  = drehen(drehen(feld));
        String[][] leftUpper  = drehen(drehen(drehen(feld)));

        String[][] ret = new String[2 * feld.length][2 * feld.length];

        ret = assignRightUpper(ret, rightUpper);
        ret = assignRightLower(ret, rightLower);
        ret = assignLeftUpper(ret, leftUpper);
        ret = assignLeftLower(ret, leftLower);

        return ret;
    }

}
