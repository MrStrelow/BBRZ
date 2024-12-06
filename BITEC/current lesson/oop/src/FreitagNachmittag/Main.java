package FreitagNachmittag;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        Spielfeld spielfeld = new Spielfeld(5);

        while (true) {
            spielfeld.printSpielfeld();
            for(var hamster : spielfeld.getHamster()) {
                hamster.bewegen();
                hamster.nahrungsVerhalten();
            }
            System.out.println("+++++++++++++++++++++++++++++++");
            Thread.sleep(750);
        }
    }
}
