package lerneinheiten.L02KlassenUndMethoden.live.hamster;

public class Hamster {
    // Felder
    int xPosition;
    int yPosition;
    String _representation;
    final static String _hungryRepresentation = "🤬";
    final static String _fedRepresentation = "🐹";
    boolean isHungry;

    // Hat-Beziehungen
    Plane _plane;
    // -----------------------------
    // Methoden
    // Konstruktor
    Hamster(Plane plane) {
        _plane = plane;
    }
}
