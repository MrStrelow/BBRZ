package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.util.ArrayList;
import java.util.Random;

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
        boolean done;
        _plane = plane;
        _representation = _hungryRepresentation;
        isHungry = true;

        // zufällig den Hamster positionieren.
        Random random = new Random();
        int xWunsch = random.nextInt(0, _plane._size);
        int yWunsch = random.nextInt(0, _plane._size);

        done = _plane.AssignInitialPosition(this, xWunsch, yWunsch);
    }
}
