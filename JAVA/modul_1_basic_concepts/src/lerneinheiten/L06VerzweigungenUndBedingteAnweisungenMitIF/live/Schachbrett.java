package lerneinheiten.L06VerzweigungenUndBedingteAnweisungenMitIF.live;

public class Schachbrett {
    public static void main(String[] args) {
        // Schachbrett zeichnen.
        // -> Problem immer zerlegen.
        // -> 1.) Ausgabe-Infrastruktur: gib ein Symbol der Gleichen Farbe in einer Zeile 5 mal hintereinander aus.

        // Nullter Schritt: "5 mal printen" ...
//        System.out.print("🟩");
//        System.out.print("🟩");
//        System.out.print("🟩");
//        System.out.print("🟩");
//        System.out.print("🟩");

        // Erster Schritt: eine Zeile ausgeben fertig.
//        int maximaleHoehe = 5;
//        int maximaleBreite = 5;
//
//        for (int breite = 0; breite < maximaleBreite; breite++) {
//            System.out.print("🟩");
//        }

        // Zweiter Schritt: Brett fertig.
//        int maximaleHoehe = 5;
//        int maximaleBreite = 5;
//
//        for (int hoehe = 0; hoehe < maximaleHoehe; hoehe++) {
//            for (int breite = 0; breite < maximaleBreite; breite++) {
//                System.out.print("🟩");
//            }
//            System.out.println();
//        }

        int maximaleHoehe = 5;
        int maximaleBreite = 5;

        for (int hoehe = 0; hoehe < maximaleHoehe; hoehe++) {
            for (int breite = 0; breite < maximaleBreite; breite++) {
                boolean bausteinGerade = breite % 2 == 0 && hoehe % 2 == 0;
                boolean bausteinUngerade = breite % 2 == 1 && hoehe % 2 == 1;

                if (bausteinGerade || bausteinUngerade) {
//                if ((breite + hoehe) % 2 == 0) {
                    System.out.print("🖥️");
                } else {
                    System.out.print("🌳");
                }
            }
            System.out.println();
        }
    }
}
