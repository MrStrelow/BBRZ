package lerneinheiten.L02KlassenUndMethoden.hamster;

public class Main {
    public static void main(String[] args) throws InterruptedException {
        // variable spielfeld vom Typ Plane anlegen.
        Plane spielfeld = new Plane(5);

        while (true) {
            // hamster macht was - bewegen und essen
            spielfeld.simulateHamster();

            // seedling macht was - nachwachsen
            spielfeld.simulateSeedling();

            // stelle jede bewegung dar, wenn diese für alle Hamster abgeschlossen wurde
            spielfeld.print();
            System.out.println("####################################");
            Thread.sleep(1000);
        }
    }
}
