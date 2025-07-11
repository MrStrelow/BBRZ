package lerneinheiten.L02KlassenUndMethoden.hamster;

import java.util.ArrayList;
import java.util.Random;

public class Hamster {
    // Felder
    int _xPosition;
    int _yPosition;
    String _representation;
    final static String _hungryRepresentation = "🤬";
    final static String _fedRepresentation = "🐹";
    boolean _isHungry;
    ArrayList<Seedling> _mouth = new ArrayList<>();

    // Hat-Beziehungen
    Plane _plane;
    // -----------------------------
    // Methoden
    void nahrungsVerhalten() {
        Random random = new Random();

        // Zufällig hungrig werden
        if (random.nextDouble() < 0.1)
        {
            _isHungry = true;
            _representation = _hungryRepresentation;
        }

        boolean tileHasSeedling = _plane.tileTakenBySeedling(_xPosition, _yPosition);

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

    void eat() {
        _representation = _fedRepresentation;
        _isHungry = false;
    }

    void eatSeedlingFromMouth()
    {
        eat();
        _mouth.remove(0);
    }

    void eatSeedlingFromTile()
    {
        eat();
        _plane.hamsterIsEatingSeedlings(this);
    }

    void storeInMouth()
    {
        Seedling seedling = _plane.getSeedlingOn(_xPosition, _yPosition);
        _mouth.add(seedling);
        _plane.hamsterIsStoringSeedlings(this);
    }

    void bewegen() {
        Random random = new Random();
        int index = random.nextInt(0, Direction.values().length);
        Direction direction = Direction.values()[index];

        _plane.bewegeHamster(this, direction);
    }

    // Konstruktor
    Hamster(Plane plane) {
        boolean done;
        _plane = plane;
        _representation = _hungryRepresentation;
        _isHungry = true;
        int xWunsch;
        int yWunsch;

        // zufällig den Hamster positionieren.
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
