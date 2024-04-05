package hemstr;

import java.util.Random;

public class Main {
    public static void main(String[] args) {
        Spielfeld meinFeld = new Spielfeld();

        while (true) {
            for (Hamster hamster : meinFeld.getHamsters()) {

                boolean stehtAufEssen = hamster.getFeldZumMerken().equals(meinFeld.getSamenSymbol());

                if (hamster.getIstHungrig() && stehtAufEssen) {
                    hamster.essen();
                }

                if (!hamster.getIstHungrig() && stehtAufEssen) {
                    hamster.hamstern();
                }

                Random random = new Random();
                if( random.nextDouble() < 0.1) {
                    hamster.setIstHungrig(true);
                }

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
