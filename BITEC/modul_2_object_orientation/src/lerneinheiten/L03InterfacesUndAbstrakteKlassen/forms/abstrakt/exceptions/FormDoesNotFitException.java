package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.abstrakt.exceptions;

public class FormDoesNotFitException extends Exception {
    // TODO: include some information about the form.
    public FormDoesNotFitException(String message) {
        super(message);
    }
}
