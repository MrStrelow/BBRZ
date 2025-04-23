package lerneinheiten.L09SchleifenFor.live;

public class B01Square {
    public static void main(String[] args) {
        String RESET = "\u001B[0m";
        String BLACK = "\u001B[30m";
        String RED = "\u001B[31m";
        String GREEN = "\u001B[32m";
        String BLUE = "\u001B[34m";

        for (int zeilen = 0; zeilen < 6; zeilen++) {
            for (int spalten = 0; spalten < 6; spalten++) {
                if (zeilen == 0) {
                    System.out.print(BLUE + (spalten + 1) + RESET);
                } else if (zeilen == 6 - 1) {
                    System.out.print(GREEN + (6 - spalten) + RESET);
                } else if (spalten == 5 && 1 < zeilen && zeilen < 6 - 1 ) {
                    System.out.print(RED + (6 - zeilen) + RESET);
                }
            }

            System.out.println();
        }
    }
}
