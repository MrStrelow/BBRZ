public class MusterUe {
    public static void main(String[] args) {

        Integer zaehlvariable = 0; // i

        while (zaehlvariable < 6) {
            System.out.println(zaehlvariable);

            zaehlvariable++;
        }

        // 3 Teile

        for (Integer i = 0; i < 6; i++) {
            System.out.println(i);
        }

//        Aufgabe 1:
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ##
//        ###
//        ####
//        #####
//        ######

        Integer limit = 6;

        for (int zeilen = 1; zeilen <= limit; zeilen++) {
            for (int spalten = 1; spalten <= zeilen; spalten++) {
                System.out.print("#");
                //  + zeilen + " " + spalten
            }
            System.out.println();
        }

        System.out.println();

//        Aufgabe 1.5:
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ##
//        ####
//        ######
//        ########
//        ##########

        for (int i = 0; i < limit; i++) {
            for (int j = 1; j <= 2*i; j++) {
                System.out.print("#");
                //  + i + " " + j
            }

            if (i == 0) {
                System.out.print("#");
            }

            System.out.println();
        }

        System.out.println();

//        Aufgabe 2
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ##
//        ###
//        ####
//        #####
//        ######
//        #####
//        ####
//        ###
//        ##
//        #

        limit = 6;

        for (int zeilen = 1; zeilen <= limit; zeilen++) {
            for (int spalten = 1; spalten <= zeilen; spalten++) {
                System.out.print("#");
                //  + zeilen + " " + spalten
            }
            System.out.println();
        }

        for (int zeilen = limit-1; zeilen >= 1; zeilen--) {
            for (int spalten = 1; spalten <= zeilen; spalten++) {
                System.out.print("#");
                //  + zeilen + " " + spalten
            }
            System.out.println();
        }

        // alternativ
        for (int i = 0; i < limit; i++) {
            System.out.println("#".repeat(i));
        }

        for (int i = limit; i >= 0; i--) {
            System.out.println("#".repeat(i));
        }


//        Aufgabe 4
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ###
//        ##
//        ####
//        ###
//        #####
//        ####
//        ######
//        #####
//        #######
//        ######
//        ########

        // Hier ist folgendes zu erkennen:
        // +++++++++++ 1.) +++++++++++
        // das Muster sieht sehr unregelmäßig aus, aber wenn wir jede 2. Zeile anschauen finden wir Folgendes:

        // für Zeilen mit geraden zeilen index (2,4,6,8,..)
        //        ###
        //        ####
        //        #####
        //        ######
        //        #######
        //        ########

        // und für ungerade (1,3,5,7,...)
        //        #
        //        ##
        //        ###
        //        ####
        //        #####
        //        ######

        // Das bedeutet um unser Muster aus der Angabe generieren zu können, müssen wir zuerst:
        // - die ERSTE Zeile aus dem UNGERADEN Muster verwenden, dann
        // - die ERSTE Zeile aus dem GERADEN Muster verwenden, dann
        // - die ZWEITE Zeile aus dem UNGERADEN Muster verwenden, dann
        // - die ZWEITE Zeile aus dem GERADEN Muster verwenden, usw.

        // Nur wie geht das?
        // Leider nicht so direkt mit hin und her springen. Aber wir können uns von dieser Idee des "jede 2. Zeile passiert was anderes"
        // inspirieren lassen.
        // Das bedeutet ein wenn, der zeilenindex modulo 2 ist gleich eins ist, haben wir das ungerade Muster, ansonsten das gerade.
        // also ein:
        //        if (i % 2 == 1) {
        //            // ungerade zeilen
        //        } else {
        //            // gerade zeilen
        //        }

        // innerhalb der Schleife.

        // +++++++++++ 2.) +++++++++++
        // Wir müssen uns die Aufgabe der Zählvariable überlegen.
        // i zählt die Zeilen und Spalten bis jetzt immer gleichzeitig. Da wir aber vorhaben die Anzahl der Symbole pro Spalten zu manipulieren,
        // ist es gefährlich das mit einer Variable zu tun.
        // Die Folge ist wir manipulieren nicht nur die Anzahl der Symbole pro Spalte, sondern auch die Anzahl der Zeilen.
        // Wir entkoppeln wir diese?
        // Indem wir eine Variable einführen und sagen:
        // Aufgabe j: zähle Spalten
        // Aufgabe i: zähle Zeilen (Schleifenvariable)

        // +++++++++++ 3.) +++++++++++
        // Nun können wir die Anzahl der Symbole pro Spalte manipulieren, ohne jene der Zeilen
        // und können mit der modulo Abfrage zwischen zwei Logiken "hin- und herschalten".
        // Nun müssen wir erkennen, dass die Symbole
        // in der 2. Zeile:
        //  - um 2 mehr sind als jene in der 1. Zeile und
        // in der 3. Zeile:
        //  - um 1 geringer sind als jene in der 2. Zeile.

        // Da wir zuerst die Symbole ausgeben und danach diese manipulieren, haben wir hier folgenden Code:

        System.out.println("AUFGABE 4");

        // Aufgabe j: zähle spalten
        int j = 1;

        // Aufgabe i: zähle zeilen
        for (int i = j; i <= limit * 2; i++) {

            System.out.println("#".repeat(j));

            // Springe von muster 1 zu muster 2
            if (i % 2 == 1) {
                // ungerade zeilen
                j += 2;

            } else {
                // gerade zeilen
                j -= 1;
            }
        }

// Teilmuster 1
//        for (int i = 1; i <= limit; i++) {
//            System.out.println("#".repeat(i));
//        }

// Teilmuster 2
//        for (int i = 3; i <= limit+2; i++) {
//            System.out.println("#".repeat(i));
//        }








    }
}
