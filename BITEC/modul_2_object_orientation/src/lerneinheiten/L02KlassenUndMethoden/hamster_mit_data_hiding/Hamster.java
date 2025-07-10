package lerneinheiten.L02KlassenUndMethoden.hamster_mit_data_hiding;

import java.util.ArrayList;
import java.util.Random;

public class Hamster {
    // Felder
    private int xPosition;
    private int yPosition;
    private String _representation;
    private final static String _hungryRepresentation = "🤬";
    private final static String _fedRepresentation = "🐹";
    private boolean _isHungry;
    private ArrayList<Seedling> _mouth = new ArrayList<>();
    private final Random _random = new Random();

    // Hat-Beziehungen
    Plane _plane;
    // -----------------------------
    // Methoden
    public void nahrungsVerhalten() {
        // Zufällig hungrig werden
        if (_random.nextDouble() < 0.1)
        {
            _isHungry = true;
            _representation = _hungryRepresentation;
        }

        boolean tileHasSeedling = _plane.tileTakenBySeedling(xPosition, yPosition);

        if (tileHasSeedling)
        {
            if (_isHungry)
            {
                eatSeedlingFromTile();
            }
            else
            {
                storeInMouth();
            }
        }
        else
        {
            if (_isHungry && !_mouth.isEmpty())
            {
                eatSeedlingFromMouth();
            }
        }
    }

    private void eat() {
        _representation = _fedRepresentation;
        _isHungry = false;
    }

    private void eatSeedlingFromMouth()
    {
        eat();
        _mouth.remove(0);
    }

    private void eatSeedlingFromTile()
    {
        eat();
        _plane.hamsterIsEatingSeedlings(this);
    }

    private void storeInMouth()
    {
        Seedling seedling = _plane.getSeedlingOn(xPosition, yPosition);
        _mouth.add(seedling);
        _plane.hamsterIsStoringSeedlings(this);
    }

    void bewegen() {
        int index = _random.nextInt(0, Direction.values().length);
        Direction direction = Direction.values()[index];

        _plane.bewegeHamster(this, direction);
    }

    // Konstruktor
    public Hamster(Plane plane) {
        boolean done;
        _plane = plane;
        _representation = _hungryRepresentation;
        _isHungry = true;
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

    public String getRepresentation() {
        return _representation;
    }

    public void setRepresentation(String _representation) {
        this._representation = _representation;
    }

    public boolean getIsHungry() {
        return _isHungry;
    }

    public void setIsHungry(boolean _isHungry) {
        this._isHungry = _isHungry;
    }

    public ArrayList<Seedling> getMouth() {
        return _mouth;
    }

    public void setMouth(ArrayList<Seedling> _mouth) {
        this._mouth = _mouth;
    }

    public Plane getPlane() {
        return _plane;
    }

    public void setPlane(Plane _plane) {
        this._plane = _plane;
    }
}
