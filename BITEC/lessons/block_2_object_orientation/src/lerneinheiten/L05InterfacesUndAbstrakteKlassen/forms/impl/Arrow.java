package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.impl;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.exceptions.FormDoesNotFitException;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.interfaces.Strukturierbar;

import static lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.impl.Dreieck.Orientation.*;
import static lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.interfaces.Kombinierbar.Orientation.*;

public class Arrow extends Form implements Strukturierbar {
    Orientation orientation;
    public Arrow(int hoehe, int breite, String background, String filler, Orientation orientation) {
        super(hoehe, breite, background, filler);
        this.orientation = orientation;

        generiereForm();
    }

    protected Arrow(Arrow toCopy) {
        super(toCopy);
        this.orientation = toCopy.orientation;
    }

    @Override
    public Form generiereForm() {
        Dreieck botLeft = new Dreieck(hoehe/2, breite/2, background, filler, BOT_LEFT);
        Dreieck topLeft = new Dreieck(botLeft, TOP_LEFT);
        Dreieck topRight = new Dreieck(botLeft, TOP_RIGHT);
        Dreieck botRight = new Dreieck(botLeft, BOT_RIGHT);

        try {
            Form leftSide = botRight.attach(topLeft, SOUTH);
            Form rightSide = topRight.attach(botLeft, NORTH);
            Form form = leftSide.attach(rightSide, EAST);

            this.feld = form.feld;

        } catch (FormDoesNotFitException e) {
            e.printStackTrace();
        }

        return this;
    }

    public enum Orientation {
        UP, DOWN, LEFT, RIGHT
    }
}
