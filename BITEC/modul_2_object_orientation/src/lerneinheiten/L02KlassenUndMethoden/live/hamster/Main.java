package lerneinheiten.L02KlassenUndMethoden.live.hamster;

public class Main {
    public static void main(String[] args) {
        // variable spielfeld vom Typ Plane anlegen.
        Plane spielfeld = new Plane(6);

        System.out.println(spielfeld._plane.length);
        while (true) {
            // hamster macht was
            spielfeld.simulateHamster();

            // seedling macht was
            spielfeld.simulateSeedling();
        }
    }
}
