import java.util.Arrays;

public class Sortieren {
    public static void main(String[] args) {
        // 1. Block: Vergleiche die zwei ersten Zahlen eines Arrays miteinander.
        // Wenn die erste großer als die zweite ist, dann vertausche diese. Ansonsten nicht.

        // lege ein array mit zahlen 28, 6, 24, 4, 12

        // Variante 1: die wichtige. wir wissen nicht was ins array kommt.
//        Integer[] zuSortieren = new Integer[5];
//        zuSortieren[0] = 28;
//        zuSortieren[1] = 6;
//        zuSortieren[2] = 24;
//        zuSortieren[3] = 4;
//        zuSortieren[4] = 12;

        // Variante 2: die eher unwichtige. wir wissen was ins array kommt.
        Integer[] zuSortieren = {28, 26, 6, 4, 2};

        //frage ab ob die zahl bei position 0 großer als jene bei position 1 ist.

        // suche die nächste großere zahl und schiebe diese ein links von der großten
        for (int j = 0; j < zuSortieren.length - 1; j++) {
            // finde die großte zahl und schiebe sie ganz nach rechts
            System.out.println("j: " + j);

            for (int i = 0; i < zuSortieren.length - 1 - j; i++) {
                if (zuSortieren[i] > zuSortieren[i+1]) {
                    int hilfsvariable = zuSortieren[i+1];// meistens tmp genannt
                    zuSortieren[i+1] = zuSortieren[i];
                    zuSortieren[i] = hilfsvariable;
                }
                System.out.println("i:" + i + " - " + Arrays.toString(zuSortieren));
            }
        }

    }
}
