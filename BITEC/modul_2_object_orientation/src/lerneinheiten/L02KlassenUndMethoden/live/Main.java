package lerneinheiten.L02KlassenUndMethoden.live;

public class Main {
    public static void main(String[] args) {
        // Objekte erstellen
        Hund frido = new Hund(5, "rot");
        Hund frodo = new Hund(15, "gelb");

        Besitzer hans = new Besitzer(5, frido, frodo);

        // dessen Methoden aufrufen
        hans.spazieren();
        hans.fuettern();
    }
}
