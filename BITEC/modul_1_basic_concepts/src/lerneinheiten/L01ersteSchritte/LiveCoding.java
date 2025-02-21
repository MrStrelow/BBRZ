package lerneinheiten.L01ersteSchritte;

public class LiveCoding {

    // Verwende Snippet um public static void main(String[] args) schreiben zu können: main
    public static void main(String[] args) {

        // Verwende Snippet um System.out.println schreiben zu können: sout
        // Ausgabe von Werten auf der Console
        System.out.println("hallo"); // Wert: String
        System.out.println(6); // Wert: Integer
        System.out.println(5.5); // Wert: Double
        System.out.println(true); // Wert: Boolean

        // <Typ> <Name> <Zuweisungsoperator> <Wert oder existierende Variable>;
        // Definition + Initialisierung einer Variable.
        Integer meineZahl = 15;
        Double meinFloat = 5.5;
        String meinString = "hallo";
        Boolean A = true;
        Boolean B = true;

        System.out.println(meineZahl);

        // Definition einer Variable. Ist ein Versprechen diese später zu initialisieren.
        Integer eineZahl;

        // Spätere Initialisierung der Variable
        eineZahl = meineZahl;

        System.out.println(eineZahl);

        // Operatoren verbinden Variablen - Logische Operatoren: boolesche Werte werden erzeugt.
        boolean a = A && A;
        System.out.println(a);

        a = (!A || B) && A; // 1. Vereinfachung von einer Formel
//        a = (!true || true) && true; // 2.
//        a = (false || true) && true; // 3.
//        a = true && true; // 3.
//        a = true; // 3.
        System.out.println(a);

        a = !A || (A && A);

        System.out.println(5 / 3);
        System.out.println(5 % 3);
        System.out.println(5. / 3);

        // Einführendes Beispiel:
        // Ist noch nicht verständlich und dient nur als Gefühl wie logische Formeln in einem Programm verwendet werden können!
        int length = 5;

        for (int zeile = 0; zeile < length; zeile++) {
            for (int spalte = 0; spalte < length; spalte++) {
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
