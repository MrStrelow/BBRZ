public class MusterUe {
    public static void main(String[] args) {
//        Aufgabe 1:
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ##
//        ###
//        ####
//        #####
//        ######

        Integer limit = 6;

        for (int i = 1; i <= limit; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.print("#");
                //  + i + " " + j
            }
            System.out.println();
        }

//        Aufgabe 1.5:
//        Gib folgendes Muster mithilfe von Schleifen in der Konsole aus.
//        #
//        ####
//        ######
//        ########
//        ##########
//        ############

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

        for (int i = 0; i < limit; i++) {
            System.out.println("#".repeat(i));
        }

        for (int i = limit; i >= 0; i--) {
            System.out.println("#".repeat(i));
        }
    }
}
