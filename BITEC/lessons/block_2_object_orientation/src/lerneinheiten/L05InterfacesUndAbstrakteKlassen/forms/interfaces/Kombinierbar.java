package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.interfaces;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.exceptions.FormDoesNotFitException;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.impl.Form;

public interface Kombinierbar {
    Form attach(Form form, Orientation orientation) throws FormDoesNotFitException;

    enum Orientation {
        NORTH, EAST, SOUTH, WEST
    }
}
