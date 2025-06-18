package lerneinheiten.L02KlassenUndMethoden.live;

public class Main {
    public static void main(String[] args) {
        // Objekte erstellen
        Hund lertl = new Hund(15, "gelb");
        Hund frido = new Hund(5, "rot", "wÜf~");

        Besitzer hans = new Besitzer(5, frido, lertl);

        // dessen Methoden aufrufen
        hans.spazieren();
        hans.fuettern();
    }
}
