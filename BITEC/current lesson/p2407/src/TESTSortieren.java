import java.util.Arrays;

public class TESTSortieren {
    public static void main(String[] args) {
// erzuegt null pointer exception: Fehler, belege zuerst die Positionen mit Zahlen dass nicht mehr null drinnen steht.
//        Integer[] zahlenzwei = new Integer[5];
//        zahlenzwei[0].doubleValue();
//        System.out.println(Arrays.toString(zahlenzwei));

        Integer[] zahlen = {28, 26, 6, 4, 2};

        Integer platzhalter;

        // Schritt 3: Wiederhole 2. solange bis alle Zahlen sortiert sind.
        // Wir lassen also jede Zahl nach rechts "aufsteigen", bis diese an der richtigen Position ist.
        // Wie oft müssen wir diesen Algorithmus wiederholen?
//        for (int j = zahlen.length; j > 0; j--) {
        for (int j = 0; j < zahlen.length - 1; j++) {
            System.out.println((j+1) + " Durchlauf");

            // Schritt 2: Wiederhole 1. für alle Paare mit Index 0 und 1, 1 und 2, 2 und 3, 3 und 4.
            for (int i = 0; i < zahlen.length - 1 - j; i++) {
                // Schritt 1: Vergleiche die 1. (Index 0) und 2. (Index 1) Zahl im Array.
                // Falls die 1. größer ist wie die 2., dann vertausche diese, andernfalls mach nichts.
                if (zahlen[i] > zahlen[i+1]) {
                    platzhalter = zahlen[i];
                    zahlen[i] = zahlen[i+1];
                    zahlen[i+1] = platzhalter;
                }

                System.out.println((i + 1) + " Paar" + Arrays.toString(zahlen));
            }

        }




    }
}
