package lerneinheiten.L02KlassenUndMethoden.hamster;

import java.util.Random;

public class Seedling {
    // Felder
    int _xPosition;
    int _yPosition;
    static final String _representation = "🌱";

    // Hat-Beziehungen
    Plane _plane;
    // -----------------------------
    // Methoden
    // Konstruktor

    /***
     Wir positionieren einen Seedling auf einem freien Platz.
     */
    Seedling(Plane plane) {
        _plane = plane;

        boolean done;
        int xWunsch;
        int yWunsch;

        // zufällig den Seedling positionieren.
        do {
            Random random = new Random();
            xWunsch = random.nextInt(0, _plane._size);
            yWunsch = random.nextInt(0, _plane._size);

            done = _plane.assignInitialPosition(this, xWunsch, yWunsch);
        } while (!done);

        _xPosition = xWunsch;
        _yPosition = yWunsch;
    }
}
