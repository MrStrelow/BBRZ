package AbstractClassesUndInterfaces.schnittstellen.interfaces;

import AbstractClassesUndInterfaces.schnittstellen.exceptions.FormDoesNotFitException;
import AbstractClassesUndInterfaces.schnittstellen.impl.Form;

public interface Kombinierbar {
    Form attach(Form form, Orientation orientation) throws FormDoesNotFitException;

    enum Orientation {
        NORTH, EAST, SOUTH, WEST
    }
}
