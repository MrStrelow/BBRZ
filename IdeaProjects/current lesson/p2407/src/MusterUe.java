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

        for (int zeilen = 1; zeilen <= limit; zeilen++) {
            for (int spalten = 1; spalten <= zeilen; spalten++) {
                System.out.print("#");
                //  + zeilen + " " + spalten
            }
            System.out.println();
        }




//        for (int i = 0; i < limit; i++) {
//            System.out.println("#".repeat(i));
//        }
//
//        for (int i = limit; i >= 0; i--) {
//            System.out.println("#".repeat(i));
//        }
    }
}
