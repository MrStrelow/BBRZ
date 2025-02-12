import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Objects;

public class Test {
    public static void main(String[] args) { // Snippet: main
        System.out.println("hallo"); // Wert: String
        System.out.println(6); // Wert: Integer
        System.out.println(5.5); // Wert: Double

        // <Typ> <Name> <Zuweisungsoperator> <Wert oder existierende Variable>;
        // Definition einer Variable.
        Integer meineZahl = 15;
        Double meinFloat = 5.5;
        String meinString = "hallo";
        Boolean A = true;
        Boolean B = true;
        System.out.println(meineZahl); //Snippet: sout

        // Deklaration einer Variable.
        Integer eineZahl;
        eineZahl = meineZahl;
        System.out.println(eineZahl);

        // Operatoren verbinden variablen
        boolean a = A && A;
        System.out.println(a);

        a = (!A || B) && A; // 1.
//        a = (!true || true) && true; // 2.
//        a = (false || true) && true; // 3.
//        a = true && true; // 3.
//        a = true; // 3.
        System.out.println(a);

        a = !A || (A && A);

        System.out.println(5 / 3);
        System.out.println(5 % 3);
        System.out.println(5. / 3);

        String[][] feld = new String[5][5];

        for (int zeile = 0; zeile < feld.length; zeile++) {
            for (int spalte = 0; spalte < feld.length; spalte++) {
//                if ( (zeile % 2 == 0 && spalte % 2 == 0) || (zeile % 2 == 1 && spalte % 2 == 1) ) {
                if ( (zeile + spalte) % 2 == 0 ) {
                    System.out.print("🟦");
                } else {
                    System.out.print("⬜");
                }
            }
            System.out.print("\n");
        }
    }
}
