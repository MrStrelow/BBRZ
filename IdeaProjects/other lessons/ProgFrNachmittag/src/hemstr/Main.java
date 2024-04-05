package hemstr;

import java.util.Random;

public class Main {
    public static void main(String[] args) {
        Spielfeld meinFeld = new Spielfeld();

        while (true) {
            for (int i = 0; i < meinFeld.getHamsters().length; i++) {
                if(meinFeld.getHamsters()[i] != null) {
                    Hamster hamster = meinFeld.getHamsters()[i];

                    if (hamster.getIstHungrig() && hamster.getFeldZumMerken().equals(meinFeld.getSamenSymbol())) {

                        hamster.essen();

                        //TODO: Das ist sehr "rechen" intensiv -  können wir es mithilfe von FeldZumMerken einfacher machen?
                    }

                    Random random = new Random();
                    if( random.nextDouble() < 0.1) {
                        hamster.setIstHungrig(true);
                    }

                    hamster.bewegen();

                }
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
