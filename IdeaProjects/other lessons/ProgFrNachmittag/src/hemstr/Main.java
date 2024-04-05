package hemstr;

public class Main {
    public static void main(String[] args) {
        Spielfeld meinFeld = new Spielfeld();

        while (true) {
            for (int i = 0; i < meinFeld.getHamsters().length; i++) {
                if(meinFeld.getHamsters()[i] != null) {
                    Hamster hamster = meinFeld.getHamsters()[i];

                    if (hamster.getIstHungrig()) {

                        // zugriff auf samen array vom spielfeld -> samen hat x und y koordinate
                        for (int samenIndex = 0; samenIndex < meinFeld.getSamen().length; samenIndex++) {
                            Samen samen = meinFeld.getSamen()[samenIndex];

                            // steht der hamster auf einem samen -> hamster hat x und y koordinate
                            // vergleiche die koordinaten, wenn ja, dann isst der hamster den samen.
                            if (hamster.getX() == samen.getX() && hamster.getY() == samen.getY()) {
                                hamster.essen();
                            }
                        }

                        //TODO: Das ist sehr "rechen" intensiv -  können wir es mithilfe von FeldZumMerken einfacher machen?
                    }

                    //TODO: wann wird hamster hungrig? Der hunger wird nie gesetzt! ist also null wenn ein hamster erzeugt wird.

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
