public class GuardClauses {

    /*
        Wenn (ANMERKUNG) neben einer Zeile steht, dann ist hier eine Kleinigkeit, welche praktisch sein kann,
        aber fuers prinzipielle Verstaendnis nicht unbedingt notwendig ist, gemeint.

        Wenn (MERKE) neben einer Zeile steht, dann gibt es hier eine Kleinigkeit, welche praktisch ist und sehr wohl zum Verständnis beiträgt.
    */

    public static void main(String[] args) {

        // Wir verwenden hier den Zustand, dass durch die De-Morganschen Gesetze, also z.B. !(a && b) = !a || !b das selbe ist.
        // && kann auch als eine Schachtelung von if's dargestellt werden, sowie ein || als untereinanderschreiben von if's.
        // Dadruch kann eine lange Verschachtelung von if's in eine Kette von untereinandergeschriebenen, umgewandelt werden,
        // ohne die Logik des Programmes zu verändern!

        // Im allgemeinen, wenn es möglich ist, ist eine "Gurard Clause" also die !a || !b Variante (welches die untereinandergeschriebenen if's ist)
        // zu bevorzugen, da diese übersichtlicher und wartbarer ist.

        // Folgendes Programm ist also das gleiche wie...
        Boolean userExistiert = false;
        Boolean userIstAltGenug = false;
        Boolean userIstPremiumAccount = true;
        Boolean userIstUnauffaellig = true;

        Boolean ressourceExistiert = false;
        Boolean ressourceIstAmNeuestenStand = true;
        Boolean ressourceUnauffaellig = true;

        System.out.println("----------Verschachteltes IF----------");

        if (userExistiert) {
            if (userIstAltGenug) {
                if (userIstPremiumAccount) {
                    if (userIstUnauffaellig) {
                        if (ressourceExistiert) {
                            if (ressourceIstAmNeuestenStand) {
                                if (ressourceUnauffaellig) {
                                    System.out.println("Passt! User bekommt was er will.");
                                } else {
                                    System.out.println("Fehler 7!");
                                }
                            } else {
                                System.out.println("Fehler 6!");
                            }
                        } else {
                            System.out.println("Fehler 5!");
                        }
                    } else {
                        System.out.println("Fehler 4!");
                    }
                 } else {
                    System.out.println("Fehler 3!");
                }
            } else {
                System.out.println("Fehler 2!");
            }
        } else {
            System.out.println("Fehler 1!");
        }


        // ... dieses Programm hier.
        System.out.println("----------Guard Clauses----------");

        if (!userExistiert) {
            System.out.println("Fehler 1!");
            System.exit(0);
        }

        if (!userIstAltGenug) {
            System.out.println("Fehler 2!");
            System.exit(0);
        }

        if (!userIstPremiumAccount) {
            System.out.println("Fehler 3!");
            System.exit(0);
        }

        if (!ressourceExistiert) {
            System.out.println("Fehler 4!");
            System.exit(0);
        }

        if (!userIstUnauffaellig) {
            System.out.println("Fehler 5!");
            System.exit(0);
        }

        if (!ressourceIstAmNeuestenStand) {
            System.out.println("Fehler 6!");
            System.exit(0);
        }

        if (!ressourceUnauffaellig) {
            System.out.println("Fehler 7!");
            System.exit(0);
        }

        System.out.println("Passt! User bekommt was er will.");

    }
}
