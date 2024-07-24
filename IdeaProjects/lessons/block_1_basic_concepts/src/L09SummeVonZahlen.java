public class L09SummeVonZahlen {
    public static void main(String[] args) {
        // Wir wollen die kumulierte Summe von Zahlen [1, 2, 3, 4, 5, 6] bilden.
        // Das heißt wir wollen 1 + 2 = 3 rechnen, das Ergebnis ausgeben.
        // Danach das Ergebnis 3 mit der nächsten Zahl, welche auch 3 ist zusammenzählen, welches 6 ist.
        // Das Ergebnis in jedem Schritt (z.B. 3) und jeder Summand (1 + 2) soll zusätzlich ausgeben werden.
        // Input:  [1, 2, 3, 4, 5, 6]
        // Output: [1+2=3, 3+3=6, 6+4=10, 10+5=15, 15+6=21]

        System.out.println("~~~~~~~~~~~~~~~~~~ 1 . Beispiel ~~~~~~~~~~~~~~~~~~");
//        int ergebnis = 1;
//        int vorherigesErgebnis = ergebnis;
//
//        for (int zahlvariable = 1; zahlvariable < 6; zahlvariable++ ) {
//            ergebnis = ergebnis + zahlvariable + 1;
//
//            System.out.println(ergebnis + " = " + vorherigesErgebnis + " + " + (zahlvariable + 1));
//
//            vorherigesErgebnis = ergebnis;
//        }

        System.out.println("~~~~~~~~~~~~~~~~~~ 2 . Beispiel ~~~~~~~~~~~~~~~~~~");

        // Wie 1. Aufgabe, aber wenn das vorherige Ergebnis in einem Schritt durch 3 teilbar ist,
        // dann zählen wir nicht die nächste Zahl dazu, sondern dessen Quadrat.
        // also nicht 3 + (2+1) sondern 3 + (2+1)^2. (wie schreibe ich das Quadrat einer Zahl in JAVA? Es ist leider nicht x^2.)
        // Input:  [1, 2, 3,  4,  5,  6]
        // Output: [1+2=3, 3+3^2=12, 12+4^2=28, 28+5=33, 33+6^2=69]
        //Notiz: hier ist 3, 12 und 33 durch 3 teilbar!

//        int ergebnis = 1;
//        int vorherigesErgebnis = 1;
//
//        for (int zaehlvariable = 1; zaehlvariable < 6; zaehlvariable++) {
//
//            if (vorherigesErgebnis % 3 == 0) {
//                ergebnis = vorherigesErgebnis + (zaehlvariable + 1)*(zaehlvariable + 1);
//                System.out.println( ergebnis + " = " + vorherigesErgebnis + " + " + (zaehlvariable + 1) * (zaehlvariable + 1) );
//            } else {
//                ergebnis = vorherigesErgebnis + zaehlvariable + 1;
//                System.out.println( ergebnis + " = " + vorherigesErgebnis + " + " + (zaehlvariable + 1) );
//            }
//            vorherigesErgebnis = ergebnis;
//        }

        // Wie 2. nur mit anderem Input. Wir können hier nicht mehr mit der for schleife die [95, 207, 34,  4,  1,  6] Zahlen erzeugen.
        // Davor konnten wir leicht [1, 2, 3, 4, 5, 6] mit der Schleifenvariable erzeugen.
        // Tipp: welches Sprachkonstrukt (Verzweigung, Schleife, ...) haben wir bis jetzt noch nicht verwendet?
        // Input:  [95, 207, 34,  4,  1,  6]
        // Output: [95+207=302, 302+34=336, 336+4^2=352, 352+1=353, 353+6=359]

        int[] schloss = {95, 207, 34,  4,  1,  6};
        int ergebnis = schloss[0];
        int vorherigesErgebnis = ergebnis;

        for (int schluessel = 0; schluessel < 5; schluessel++ ) {
            if (vorherigesErgebnis % 3 == 0) {
                ergebnis = ergebnis + schloss[schluessel + 1] * schloss[schluessel + 1];
                System.out.println(ergebnis + "\t = " + vorherigesErgebnis + "\t + " + schloss[schluessel + 1] + "^2" );
            } else {
                ergebnis = ergebnis + schloss[schluessel + 1];
                System.out.println(ergebnis + "\t = " + vorherigesErgebnis + "\t + " + schloss[schluessel + 1]);
            }

            vorherigesErgebnis = ergebnis;
        }
    }
}