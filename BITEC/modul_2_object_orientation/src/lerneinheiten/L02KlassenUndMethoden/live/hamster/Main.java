package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.util.Arrays;

public class Main {
    public static void main(String[] args) {
        // variable spielfeld vom Typ Plane anlegen.
        Plane spielfeld = new Plane(6);

        while (true) {
            // hamster macht was
            spielfeld.simulateHamster();

            // seedling macht was
            spielfeld.simulateSeedling();

            // stelle jede bewegung dar, wenn diese für alle Hamster abgeschlossen wurde
            spielfeld.print();
            System.out.println("####################################");
        }
    }
}
