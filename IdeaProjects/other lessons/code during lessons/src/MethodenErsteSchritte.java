public class MethodenErsteSchritte {
    public static void main(String[] args) {

        String[][] brett = new String[4][3];

        //befuellen
//        String[][] brett_befuellt = befuellen(brett);

        brett = befuellen(brett);

        // muster angeben
        brett[0][0] = "X";
        brett[1][0] = "X";
        brett[2][1] = "X";
        brett[1][2] = "X";
        brett[3][2] = "X";

        String[][] vertauschtesBrett = transpose(brett);

        ausgabe(vertauschtesBrett);

    }


    static String[][] transpose(String[][] asciiArray) {
        return null;
    }

    static String[][] befuellen(String[][] asciiArray) {
        return null;
    }

    static void ausgabe(String[][] asciArray) {
        
    }

}
