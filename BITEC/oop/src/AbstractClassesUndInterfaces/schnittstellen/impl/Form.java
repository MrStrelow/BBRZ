package AbstractClassesUndInterfaces.schnittstellen.impl;

import AbstractClassesUndInterfaces.schnittstellen.exceptions.FormDoesNotFitException;
import AbstractClassesUndInterfaces.schnittstellen.interfaces.Kombinierbar;

public class Form implements Kombinierbar {
    protected String[][] feld;
    protected int hoehe;
    protected int breite;
    protected String background;
    protected String filler;

    // Konstruktor
    public Form(int hoehe, int breite, String background, String filler) {
        this.hoehe = hoehe;
        this.breite = breite;
        this.background = background;
        this.filler = filler;

        this.feld = new String[hoehe][breite];
        fillCanvas();
    }

    // Copy Constructor
    public Form(Form toCopy) {
        this(toCopy.hoehe, toCopy.breite, toCopy.background, toCopy.filler);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][j] = toCopy.feld[i][j];
            }
        }
    }

    // Methoden

    protected Form fillCanvas() {
        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][j] = background;
            }
        }

        return this;
    }

    // Methoden für Drehen und Spiegeln
    public Form drehen() {
        return spiegelnX().transponieren();
    }

    public Form spiegelnX() {
        String[][] copy = new String[hoehe][breite];
//        Form copy = new Form(this);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                copy[i][j] = feld[hoehe - 1 - i][j];
            }
        }

        this.feld = copy;

        return this;
    }

    public Form spiegelnY() {
//        Form copy = new Form(this);
        String[][] copy = new String[hoehe][breite];

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                copy[i][breite - 1 - j] = feld[i][j];
            }
        }

        this.feld = copy;
        return this;
    }

    public Form transponieren() {
        Form flipped = new Form(breite, hoehe, background, filler);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                flipped.feld[j][i] = feld[i][j];
            }
        }

        return flipped;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                sb.append(feld[i][j]);
            }
            sb.append("\n");
        }

        return sb.toString();
    }

    @Override
    public Form attach(Form toBeAttached, Orientation orientation) throws FormDoesNotFitException {
        return switch (orientation) {
            case NORTH -> attachNorth(toBeAttached);
            case EAST  -> attachEast(toBeAttached);
            case SOUTH -> attachSouth(toBeAttached);
            case WEST  -> attachWest(toBeAttached);
        };
    }

    public Form attachNorth(Form north) throws FormDoesNotFitException {
        if (breite != north.breite) {
            throw new FormDoesNotFitException("Breite muss gleich sein!");
        }

        Form combined = new Form(this.hoehe + north.hoehe, breite, background, filler);

        for (int b = 0; b < breite; b++) {
            for (int h = 0; h < north.hoehe; h++) {
                combined.feld[h][b] = north.feld[h][b];
            }

            for (int h = north.hoehe; h < combined.hoehe; h++) {
                combined.feld[h][b] = feld[h-hoehe][b];
            }
        }

        return combined;
    }

    public Form attachEast(Form east) throws FormDoesNotFitException {
        return east.attachWest(this);
    }

    public Form attachSouth(Form south) throws FormDoesNotFitException {
        return south.attachNorth(this);
    }

    public Form attachWest(Form west) throws FormDoesNotFitException {
        Form me = this.drehen();
        west = west.drehen();

        return west.attachSouth(me).drehen();
    }
}
