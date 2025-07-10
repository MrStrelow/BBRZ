package lerneinheiten.L05InterfacesUndAbstrakteKlassen.optional.erweiterung_von_collections;

public class Main {
    public static void main(String[] args) {
        Herde herde = new Herde();
        herde.add(new Schaf("S1", 3));
        herde.add(new Schaf("S2", 5));

        Horde horde = new Horde(2);
        horde.add(new Schaefer("Schaefer1", 4));
        horde.add(new Schaefer("Schaefer2", 6));

        int result = horde.compareTo(herde);
        if (result > 0) {
            System.out.println("horde is bigger!");

        } else if (result < 0) {
            System.out.println("herde is bigger!");

        } else {
            System.out.println("draw!");
        }
    }
}