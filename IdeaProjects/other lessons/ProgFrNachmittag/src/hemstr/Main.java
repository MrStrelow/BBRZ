package hemstr;

public class Main {
    public static void main(String[] args) {
        Spielfeld meinFeld = new Spielfeld();

        while (true) {
            for (int i = 0; i < meinFeld.getHamsters().length; i++) {
                if(meinFeld.getHamsters()[i] != null) {
                    meinFeld.getHamsters()[i].bewegen();
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
