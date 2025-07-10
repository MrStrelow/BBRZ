package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.util.ArrayList;
import java.util.Random;

public class Hamster {
    // Felder
    String feldZuMerken = Plane.getEarthRepresentation();
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
    void nahrungsVerhalten() {
        Random random = new Random();

        if (random.nextDouble() < 0.1) {
            isHungry = true;
            _representation = _hungryRepresentation;
        }

        boolean tileHasSeedling = _plane.tileTakenBySeedling(xPosition, yPosition);

        if (tileHasSeedling) {
            if (isHungry) {
                _representation = _fedRepresentation;
                isHungry = false;

                Seedling seedlingAmGleichenFeld = _plane.getSeedlingOnPosition(xPosition, yPosition);
                _plane.getSeedlings().remove(seedlingAmGleichenFeld);
                // hamster speicher seedling im mund...
            }
        }
    }

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
            xWunsch = random.nextInt(0, _plane.getSize());
            yWunsch = random.nextInt(0, _plane.getSize());

            done = _plane.assignInitialPosition(this, xWunsch, yWunsch);
        } while (!done);

        xPosition = xWunsch;
        yPosition = yWunsch;
    }
}
