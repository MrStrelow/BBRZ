package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.util.ArrayList;

public class Hamster {
    // Felder
    int xPosition;
    int yPosition;
    String _representation;
    final static String _hungryRepresentation = "🤬";
    final static String _fedRepresentation = "🐹";
    boolean isHungry;
    ArrayList<Seedling> _mouth = new ArrayList<>();

    // Hat-Beziehungen
    Plane _plane;
    // -----------------------------
    // Methoden
    // Konstruktor
    Hamster(Plane plane) {
        _plane = plane;
        _representation = _hungryRepresentation;
        isHungry = true;


    }
}
