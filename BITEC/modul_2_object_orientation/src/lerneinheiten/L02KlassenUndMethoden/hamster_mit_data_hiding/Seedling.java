package lerneinheiten.L02KlassenUndMethoden.hamster_mit_data_hiding;

import java.util.Random;

public class Seedling {
    // Felder
    private int xPosition;
    private int yPosition;
    public final static String _representation = "🌱";

    // Hat-Beziehungen
    Plane _plane;
    // -----------------------------
    // Methoden
    // Konstruktor

    /***
     Wir positionieren einen Seedling auf einem freien Platz.
     */
    public Seedling(Plane plane) {
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

    // Get- und Set-Methoden

    public int getxPosition() {
        return xPosition;
    }

    public void setxPosition(int xPosition) {
        this.xPosition = xPosition;
    }

    public int getyPosition() {
        return yPosition;
    }

    public void setyPosition(int yPosition) {
        this.yPosition = yPosition;
    }

    public Plane getPlane() {
        return _plane;
    }

    public void setPlane(Plane _plane) {
        this._plane = _plane;
    }
}
