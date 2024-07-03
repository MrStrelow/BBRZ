package block1;

import java.util.Scanner;

public class SchleifenWhile {
    /*
        Wenn (ANMERKUNG) neben einer Zeile steht, dann ist hier eine Kleinigkeit, welche praktisch sein kann,
        aber fuers prinzipielle Verstaendnis nicht unbedingt notwendig ist, gemeint.

        Wenn (MERKE) neben einer Zeile steht, dann gibt es hier eine Kleinigkeit, welche praktisch ist und sehr wohl zum Verständnis beiträgt.
    */
    public static void main(String[] args) {

        // Eine While Schleife ist eine Schleife. Bedeutet also wir wiederholen so lange einen Teil des Codes bis eine Bedingung nicht mehr erfüllt wird.
        // Die Bedingungne könnne hier beliebig sein, jedoch wichtig ist, dass am Schluss ein boolescher Wert rauskommt.
        // Hier ist dies i < 3. Solange diese Schleifenbedingung erfüllt ist, also auf true auswertet, wird der Code welcher unter der
        // While Schleife steht, ausgeführt. Dies ist hier  System.out.println(" :) "); und i = i + 1;

        Integer i = 0; // i = 1;
        while (i < 3) { // i <= 3;
            System.out.println(" :) ");
            i = i + 1;
        }

        // Hier ist i eine Zählvariable, und zählt wie oft die Schleife ausgeführt wurde. Meistens wenn gezählt wird und mit
        // der Zählvariable nicht wilde Dinge passieren (erhöht, und dann verringert in einem nicht vorhersehbaren Ausmaß),
        // dann ist eine For Schleife besser geeignet. Siehe ForSchleife.java. Wenn aber nicht klar ist, wie oft etwas ausgeführt wird,
        // also eben wilde Dinge mit der Zählvariable passieren, oder wir einfach nicht wissen wann z.B. der User mit einer Ausgabe zufireden ist,
        // dann wird eine While Schleife benötigt.

        // Beachte hier, dass es nur wichtig ist, wie oft etwas ausgeführt wird und nicht was der Wert der Zählvariable ist.
        // Es ist also wichtig, dass 3 Mal die Schleife ausgeführt wird. Der Unterschied zwischen der ersten Zuweisung von i (i=1) und
        // deren Abbruchbedingung mit dem "<" Operator (i <= 3 wird i < 4) ergibt die Anzahl der Schleifendurchläufe. Also 4-1 = 3.
        i = 1; // i = 101;
        while (i <= 3) { // i <= 103;
            System.out.println(" :) ");
            i = i + 1;
        }


        // Hier wird das Alter vom User eingegeben und erst wenn diese In Ordnung ist
        Scanner scanner = new Scanner(System.in);
        Integer alter;

        System.out.print("Bitte Alter eingeben: ");
        alter = Integer.parseInt(scanner.nextLine());

        while ( alter < 5 || alter > 100) {
            System.out.print("Bitte Alter eingeben: ");
            alter = Integer.parseInt(scanner.nextLine());
        }

        // Beachte hier die Bedingung der Schleife! Sind die beiden Bedingungen die gleichen?
        // Versuche es mit einer Wahrheitstabelle zu überprüfen!
        System.out.print("Bitte Alter eingeben: ");
        alter = Integer.parseInt(scanner.nextLine());

        while ( !(alter >= 5 && alter <= 100) ) {
            System.out.print("Bitte Alter eingeben: ");
            alter = Integer.parseInt(scanner.nextLine());
        }

        // Achtung! Mit While Schleifen können endlose Programme entstehen!
        // Damit ist gemeint dass die Schleifenbedingung immer true ist.
//        while (true) {
//            System.out.println("erste loop");
//        }

        // Wir können aber mit dem Befehlt "break" aus einer Schleife rausspringen, wenn nötig.
        // Bedeutet also, wenn wir in einer Schleife "break" sagen, ist egal, ob die Schleifenbedingung erfüllt ist, diese Beendet.
        while (true) {
            System.out.println("erste loop");
            while (true) {
                System.out.println("zweite loop");
                if (true) {
                    break;
                }
            }
            break;
        }

        // es gibt auch den Befehlt "condinue", dieser ist ähnlich wie "break", jedoch beenden wir nicht die Schleife, sondern
        // gebinnen sie von oben wieder. Hier wird also nie das print verwendet.
//        i = 0;

//        while (i<10) {
//            System.out.println("Hallo " + i);
//            i++;
//            continue;
//            System.out.println("ich bin nicht bei Hallo 5 da");
//        }

        i = 0;

        // Hier nochmal aber mit einer Bedingung für das continue. break und continue sind immer in einem if vorzufinden.
        // Im allgemeinen, sind, wenn es geht, break und continue zu vermeiden.
        while (i<10) {
            System.out.println("Hallo " + i);
            i++;
            if (i == 6){
                continue;
            }
            System.out.println("ich bin nicht bei Hallo 5 da");
        }
    }
}
