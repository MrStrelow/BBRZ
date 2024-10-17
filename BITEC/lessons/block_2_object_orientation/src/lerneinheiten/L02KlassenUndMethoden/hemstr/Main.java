package lerneinheiten.L02KlassenUndMethoden.hemstr;

public class Main {
    public static void main(String[] args) {
        Spielfeld meinFeld = new Spielfeld();

        while (true) {
            for (Hamster hamster : meinFeld.getHamsters()) {
                hamster.verstoffwechselen();
                hamster.bewegen();
            }

            meinFeld.printSpielfeld();
            System.out.println("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }

        }
    }
}
