package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.implementation;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.exceptions.FormDoesNotFitException;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.interfaces.Strukturierbar;

import static lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.abstrakt.implementation.Dreieck.Orientation.*;
import static lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.abstrakt.interfaces.Kombinierbar.Orientation.*;

public class Diamant extends Form implements Strukturierbar {
    // TODO: hier 4 dreieck objekte haben. erlaubt uns swap aufzurufen! naaaha denk nomal nach
    // TODO: nur ganze gerade zahlen sind als hoehe und breite erlaubt!
    public Diamant(int hoehe, int breite, String background, String filler)  {
        super(hoehe, breite, background, filler);
        generiereForm();
    }

    public Diamant(Diamant toCopy) {
        super(toCopy);
    }

    public Diamant(Dreieck dreieck, int scalingDimensions) {
        super(dreieck);
        //TODO: dreieick.hoehe geht nicht, wenn wir Form aus dem package geben!
        hoehe = dreieck.hoehe * scalingDimensions;
        breite = dreieck.breite * scalingDimensions;

        generiereForm();
    }

    @Override
    public Form generiereForm() {
        Dreieck botLeft = new Dreieck(hoehe/2, breite/2, background, filler, BOT_LEFT);
        Dreieck topLeft = new Dreieck(botLeft, TOP_LEFT);
        Dreieck topRight = new Dreieck(botLeft, TOP_RIGHT);
        Dreieck botRight = new Dreieck(botLeft, BOT_RIGHT);

        try {
            Form rightSide = botLeft.attach(topLeft, SOUTH);
            Form leftSide = topRight.attach(botRight, NORTH);
            Form form = leftSide.attach(rightSide, EAST);
            this.feld = form.feld;

        } catch (FormDoesNotFitException e) {
            e.printStackTrace(); //TODO: zumindest erwähnen warum das nicht eine gute Idee ist.
        }

        return this;
    }
}