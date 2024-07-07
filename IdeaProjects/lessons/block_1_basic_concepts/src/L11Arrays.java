import java.util.Random;
import java.util.Scanner;

public class L11Arrays {

    /*
        Wenn (ANMERKUNG) neben einer Zeile steht, dann ist hier eine Kleinigkeit, welche praktisch sein kann,
        aber fuers prinzipielle Verstaendnis nicht unbedingt notwendig ist, gemeint.

        Wenn (MERKE) neben einer Zeile steht, dann gibt es hier eine Kleinigkeit, welche praktisch ist und sehr wohl zum Verständnis beiträgt.
    */

    public static void main(String[] args) {

        // Bis jetzt waren Variablen nur Zuständig einen bestimmten Wert zu halten. Wie z.B. int a = 5;.
        // Mit Arrays können nun mehrere Werte in einer Variable gespeichert werden. Ein Wert in einem Array wird unter anderem Element genannt.
        // Arrays gibts es von allen Variablen, welche wir bis jetzt behandelt haben. Also Boolean, bool, Integer, int, usw.
        // und auch noch von selbst erstellten block2.Klassen. Werden wir aber sehen, wenn wir Objektorientierung behandeln.

        // Hier wird ein Array von bekannten Strings erzeugt. Die Größe des Arrays muss immer am Anfang bekannt sein.
        // Hier ist es einfach die Anzahl an Wörtern. Zusätzlich ist die Dimension hier 1. Bedeutet wir haben eine Kette an Strings.
        // Für eine 2. Dimension könnten wir ein Array aus Arrays machen. Siehe ganz unten.
        String[] woerterAnfang = {"Dog", "Tree", "Cat", "Fish", "Orange", "Gauda Cheese",
                "Scarf", "Laptop", "JAVA", "Mouse", "BBRZ", "Christmas"};

        // Wenn wir nicht wissen, was im Array sein soll, dann können wir es so anlegen. Die Größe ist hier 12.
        String[] worterAnfangBig = new String[12];

        // Wenn wir nun Elemente ansprechen wollen, können wir dies auch mit der eckigen Klammer tun.
        // Wir brauchen dazu einen Index. Dieser ist hier 0, also das 1. Element im Array. Wenn wir das 2. Element im Array
        // ansprechen wollen, dann müssen wir dies mit dem Index 1 tun.
        System.out.println(woerterAnfang[0]);

        // Wenn wir Elemente im Array neu belegen wollen, also neu beschreiben, dann ist dies so möglich.
        woerterAnfang[0] = "Dogette";
        System.out.println(woerterAnfang[0]);

        String[] woerterMitte = {"empowers", "adores", "carries", "heats", "froze", "ate",
                "blames", "injures"};

        String[] woerterEnde = woerterAnfang;

        Scanner scanner = new Scanner(System.in);
        Boolean zufrieden;

        // Das folgende Programm erzeugt zufällig Zahlen, welche von 0 bis "Länge des Arrays minus 1" gehen (da wir bei 0 Anfangen zu zählen, minus 1).
        // und nimmt dann Elemente aus dem Array, kombiniert Sie und gibt Sie aus bis der User zufrieden ist.
        // die Bedingung, "bis der User zufrieden ist" wird mit einer Do-While Schleife umgesetzt, da wir eine Ausgabe mit sicherheit brauchen, bevor wir die Schleife abbrechen können.
        do {
            Random rand = new Random();
            Integer erstesWort = rand.nextInt(0, woerterAnfang.length - 1);
            Integer zweitesWort = rand.nextInt(0, woerterMitte.length - 1);
            Integer drittesWort = rand.nextInt(0, woerterEnde.length - 1);

            String phrase = woerterAnfang[erstesWort] + " " + woerterMitte[zweitesWort] + " " + woerterEnde[drittesWort];

            System.out.println("Breaking News! " + phrase);

            System.out.print("More News?: ");
            zufrieden = switch (scanner.nextLine()) {
                case "yes" -> true;
                case "no" -> false;
                default -> false;
            };

        } while (zufrieden);

        // Arrays können auch verwendet werden um "Dinge" in mehreren "Dimensionen" zu behandeln. Bedeutet, ein Schachbrett,
        // welches eine x- und y-Achse hat, also 2-Dimensionen, kann in einem Array mit Dimension 2 gespeichert werden.
        // Wir müssen dazu ein Array anlegen welches wieder Arrays als Elemente hat, um diese Schachtelung von Dimensionen
        // darstellen zu können. Im folgenden Code ist ein Brett dargestellt, welches an jeder Position ein Symbol beinhaltet.
        // (für Schachbrett siehe ForSchleife.java)

        int dimension = 2;
        String[][] brett = new String[dimension][dimension];

        // Achtung! hier wieder bei 0 anfangen zu zählen! die Größe 2 bedeutet, dass wir mit index 0 und 1 die Elemente im Array ansprechen können.
        brett[0][0] = "*";
        brett[0][1] = "~";
        brett[1][0] = "%";
        brett[1][1] = "§";

        System.out.print(brett[0][0]);
        System.out.print(brett[0][1]);

        System.out.println();

        System.out.print(brett[1][0]);
        System.out.print(brett[1][1]);

        // Um ein Array "durchlaufen" zu können, kann eine Schleife verwendet werden. Eine For-Schleife ist dazu meist die Beste Wahl.
        // dazu mehr in ForSchleife.java - Aufgabe 7.
        // Hier jedoch mit einer While-Schleife.

        int i = 0;
        int j = 0;

        while (i < 5) {
            while (j < 5) {
                brett[i][j] = "~";
                j++;
            }
            i++;
        }

        // und hier für die Ausgabe
        i = 0;
        j = 0;

        while (i < 5) {
            while (j < 5) {
                System.out.print(brett[i][j]);
                j++;
            }
            System.out.println();
            i++;
        }
    }
}
