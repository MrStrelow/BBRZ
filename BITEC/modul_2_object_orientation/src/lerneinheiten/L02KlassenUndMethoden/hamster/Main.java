package lerneinheiten.L02KlassenUndMethoden.hamster;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        Spielfeld spielfeld = new Spielfeld(5);

        while (true) {
            spielfeld.simulateHamster();
            spielfeld.simulateSamen();

            spielfeld.printSpielfeld();

            System.out.println("+++++++++++++++++++++++++++++++");
            Thread.sleep(1000);
        }
    }
}

