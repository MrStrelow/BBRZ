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
    void bewegen() {
        Random random = new Random();
        int index = random.nextInt(0, Richtung.values().length);
//        Richtung richtung = Richtung.OBEN;
        Richtung richtung = Richtung.values()[index];

        _plane.bewegeHamster(this, richtung);
    }

    // Konstruktor
    Hamster(Plane plane) {
        boolean done;
        _plane = plane;
        _representation = _hungryRepresentation;
        isHungry = true;
        int xWunsch;
        int yWunsch;

        // zufällig den Hamster positionieren.
        do {
            Random random = new Random();
            xWunsch = random.nextInt(0, _plane._size);
            yWunsch = random.nextInt(0, _plane._size);

            done = _plane.AssignInitialPosition(this, xWunsch, yWunsch);
        } while (!done);

        xPosition = xWunsch;
        yPosition = yWunsch;
    }
}
