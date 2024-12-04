package AbstractClassesUndInterfaces.schnittstellen.impl;

import AbstractClassesUndInterfaces.schnittstellen.interfaces.Strukturierbar;
import AbstractClassesUndInterfaces.schnittstellen.exceptions.FormDoesNotFitException;

import static AbstractClassesUndInterfaces.schnittstellen.impl.Dreieck.Orientierung.*;
import static AbstractClassesUndInterfaces.schnittstellen.interfaces.Kombinierbar.Orientation.*;

public class Diamant extends Form implements Strukturierbar {
    public Diamant(Form toCopy) {
        super(toCopy);
    }

    public Diamant(int hoehe, int breite, String background, String filler)  {
        super(hoehe, breite, background, filler);
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
            e.printStackTrace(); //TODO: nicht so :)
        }

        return this;
    }
}
