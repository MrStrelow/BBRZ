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

        for (int i = 0; i < feld.length; i++) {
            for (int j = 0; j < feld.length; j++) {
                feld[i][j] = "";
            }
        }

        // anstatt der ausgabe ins array das dreieck schreiben.
        for (int i = 0; i < feld.length; i++) {
            for (int j = 0; j < feld.length; j++) {
                if(j <= i) {
                    feld[i][j] = "#";
                }
            }
        }

        // array ausgeben - sollte gleich ausschauen wie der code mit "sout".
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

}
