package hemstr;

public class Main {
    public static void main(String[] args) {
        Spielfeld meinFeld = new Spielfeld();

        while (true) {
            for (int i = 0; i < meinFeld.getHamsters().length; i++) {
                if(meinFeld.getHamsters()[i] != null) {
                    Hamster hamster = meinFeld.getHamsters()[i];

                    if (hamster.getIstHungrig()) {
                        hamster.essen();

                        // zugriff auf samen array vom spielfeld -> samen hat x und y koordinate
                        // steht der hamster auf einem samen -> hamster hat x und y koordinate
                        // vergleiche die koordinaten, wenn ja, dann isst der hamster den samen.
                        // samen muss aus dem spielfeld gelöscht werden
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
