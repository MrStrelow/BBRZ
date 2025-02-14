package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.interfaces;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.exceptions.FormDoesNotFitException;
import lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.schnittstellen.implementation.Form;

public interface Kombinierbar {
    Form attach(Form form, Orientation orientation) throws FormDoesNotFitException;

    enum Orientation {
        NORTH, EAST, SOUTH, WEST
    }
}
