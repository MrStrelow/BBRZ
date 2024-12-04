package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.impl;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.exceptions.FormDoesNotFitException;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.interfaces.Kombinierbar;

public class Form implements Kombinierbar {
    protected String[][] feld;
    protected int hoehe;
    protected int breite;
    protected String background;
    protected String filler;

    public Form(int hoehe, int breite, String background, String filler) {
        this.hoehe = hoehe;
        this.breite = breite;
        this.background = background;
        this.filler = filler;

        this.feld = new String[hoehe][breite];
        fillCanvas(background);
    }

    protected Form(Form toCopy) {
        this(toCopy.hoehe, toCopy.breite, toCopy.background, toCopy.filler);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][j] = toCopy.feld[i][j];
            }
        }
    }

    // Methoden für Drehen und Spiegeln
    public Form drehen() {
        return spiegelnX().transponieren();
    }

    public Form spiegelnX() {
//        String[][] copy = new String[hoehe][breite];
        Form copy = new Form(this);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][j] = copy.feld[hoehe - 1 - i][j];
            }
        }

        return this;
    }

    public Form spiegelnY() {
        Form copy = new Form(this);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][breite - 1 - j] = copy.feld[i][j];
            }
        }

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

    protected Form fillCanvas(String symbol) {
        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][j] = symbol;
            }
        }
        return this;
    }

//    public void duplicateFormInSquare(Form form, Quadrants quadrants) {
//        for (int i = 0; i < form.hoehe; i++) {
//            for (int j = 0; j < form.breite; j++) {
//                switch (quadrants) {
//                    case TOP_LEFT  -> feld[i][j] = form.feld[i][j];
//                    case BOT_RIGHT -> feld[i + hoehe][j + breite] = form.feld[i][j];
//                    case BOT_LEFT  -> feld[i + hoehe][j] = form.feld[i][j];
//                    case TOP_RIGHT -> feld[i][j + breite] = form.feld[i][j];
//                }
//            }
//        }
//    }

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
            throw new FormDoesNotFitException("Höhe muss gleich sein!");
        }

        Form combined = new Form(this.hoehe + north.hoehe, breite, background, filler);

        for (int b = 0; b < breite; b++) {
            for (int h = 0; h < this.hoehe; h++) {
                combined.feld[h][b] = north.feld[h][b];
            }

            for (int h = hoehe; h < combined.hoehe; h++) {
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

    // Getter und Setter
    public String getBackground() {
        return background;
    }

    public void setBackground(String background) {
        this.background = background;
    }

    public String getFiller() {
        return filler;
    }

    public void setFiller(String filler) {
        this.filler = filler;
    }

    public int getHoehe() {
        return hoehe;
    }

    public int getBreite() {
        return breite;
    }
}