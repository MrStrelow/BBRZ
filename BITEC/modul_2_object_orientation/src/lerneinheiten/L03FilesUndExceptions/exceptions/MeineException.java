package lerneinheiten.L03FilesUndExceptions.exceptions;

public class MeineException extends Exception {
    public MeineException() {
        super("Meine Fehlermeldung");
    }

    public void weitereInfoMeinesFehlers() {
        System.out.println("mehr info");
    }
}
