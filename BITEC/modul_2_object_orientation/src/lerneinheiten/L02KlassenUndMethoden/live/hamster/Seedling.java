package lerneinheiten.L02KlassenUndMethoden.live.hamster;

public class Seedling {
    // Felder
    int xPosition;
    int yPosition;
    static final String _representation = "🌱";

    // Hat-Beziehungen
    Plane _plane;
    // -----------------------------
    // Methoden
    // Konstruktor
    Seedling(Plane plane) {
        _plane = plane;
    }
}
