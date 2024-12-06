package FreitagNachmittag;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        Spielfeld spielfeld = new Spielfeld(5);

        while (true) {
            for(var hamster : spielfeld.getHamster()) {
                hamster.bewegen();
            }
            spielfeld.printSpielfeld();
            System.out.println("+++++++++++++++++++++++++++++++");
            Thread.sleep(1000);
        }
    }
}
