package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.impl;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.interfaces.Strukturierbar;

public class Dreieck extends Form implements Strukturierbar {
    private final Orientation orientation;

    public Dreieck(int hoehe, int breite, String background, String filler) {
        super(hoehe, breite, background, filler);
        this.orientation = Orientation.BOT_LEFT;

        this.generiereForm();
    }

    public Dreieck(int hoehe, int breite, String background, String filler, Orientation orientation) {
        super(hoehe, breite, background, filler);
        this.orientation = orientation;

        this.generiereForm();
    }

    public Dreieck(Dreieck basis, Orientation orientation) {
        super(basis);
        this.orientation = orientation;

        this.generiereForm();
    }

    public Dreieck(Dreieck toCopy) {
        super(toCopy);
        this.orientation = toCopy.orientation;
    }

    @Override
    public Form generiereForm() {
        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j <= i; j++) {
                feld[i][j] = filler;
            }
        }

        switch (orientation) {
            case TOP_LEFT  -> this.spiegelnX();
            case TOP_RIGHT -> this.spiegelnX().spiegelnY();
//            case TOP_RIGHT -> this.spiegelnX().transponieren(); // Warum geht das nicht? Hinweis: werde ich selber verändert oder wird ein neues Objekt verändert?
            case BOT_RIGHT -> this.spiegelnY();
        }

        return this;
    }

    public enum Orientation {
        // Rechter winkel zeigt wohin?
        TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT
    }
}
