package pruefung.alte_pruefungen.P202410;

public class TestVorlage_Aufgabe1 {
    public static void main(String[] args) {

        Integer[] zahlen = {28, 26, 6, 4, 2};
        Integer platzhalter;

        for (int j = 0; j < zahlen.length - 1; j++) {

            for (int i = 0; i < zahlen.length - 1; i++) {

                if (zahlen[i] > zahlen[i+1]) {

                    platzhalter = zahlen[i];
                    zahlen[i] = zahlen[i+1];
                    zahlen[i+1] = platzhalter;

                }

            }

        }

    }

}
