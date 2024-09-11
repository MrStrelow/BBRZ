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


        System.out.println("AUFGABE 4");

        // Aufgabe j: zähle spalten
        int j = 1;

        // Aufgabe i: zähle zeilen
        for (int i = 1; i <= limit * 2; i++) {

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

//        for (int i = 1; i <= limit; i++) {
//            System.out.println("#".repeat(i));
//        }
//
//        for (int i = 3; i <= limit+2; i++) {
//            System.out.println("#".repeat(i));
//        }








    }
}
