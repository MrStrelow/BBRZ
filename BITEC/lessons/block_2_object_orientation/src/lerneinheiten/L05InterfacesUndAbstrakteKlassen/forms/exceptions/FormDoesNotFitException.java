package lerneinheiten.L05InterfacesUndAbstrakteKlassen.forms.exceptions;

public class FormDoesNotFitException extends Exception {
    // TODO: include some information about the form.
    public FormDoesNotFitException(String message) {
        super(message);
    }
}
