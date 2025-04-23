package lerneinheiten.L09SchleifenFor.live;

public class B01Square {
    public static void main(String[] args) {
        String RESET = "\u001B[0m";
        String BLACK = "\u001B[30m";
        String RED = "\u001B[31m";
        String GREEN = "\u001B[32m";
        String BLUE = "\u001B[34m";

        for (int zeile = 0; zeile < 6; zeile++) {
            for (int spalte = 0; spalte < 6; spalte++) {
                if (zeile == 0) {
                    System.out.print(BLUE + (spalte + 1) + RESET);
                } else if (zeile == 6 - 1) {
                    System.out.print(GREEN + (6 - spalte) + RESET);
                } else if (spalte == 5 && 1 <= zeile && zeile <= 6 - 2 ) {
                    System.out.print(RED + (6 - zeile) + RESET);
                } else if (spalte == 0 && 1 <= zeile && zeile <= 6 - 2) {

                }
            }

            System.out.println();
        }
    }
}
