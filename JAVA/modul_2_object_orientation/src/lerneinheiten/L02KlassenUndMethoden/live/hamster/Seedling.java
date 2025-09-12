package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.util.Random;

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
            xWunsch = random.nextInt(0, _plane.getSize());
            yWunsch = random.nextInt(0, _plane.getSize());

            done = _plane.assignInitialPosition(this, xWunsch, yWunsch);
        } while (!done);

        xPosition = xWunsch;
        yPosition = yWunsch;
    }
}
