package lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung;

import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Direction.*;
import static lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation.*;

public class Arrow extends Form {
    // Feld
    // Hat-Beziehung
    private Dreieck _topLeft;
    private Dreieck _topRight;
    private Dreieck _botLeft;
    private Dreieck _botRight;
    private Orientation _orientation;

    // Methode
    // Konstruktor
    public Arrow(int hoehe, int breite, String background, String foreground, Orientation orientation) {
        _hoehe = hoehe;
        _breite = breite;
        _background = background;
        _foreground = foreground;
        _orientation = orientation;

        _darstellung = new String[_hoehe][_breite];

        generateForm();

        switch (_orientation) {
            case EAST  -> drehen();
            case SOUTH -> drehen().drehen();
            case WEST  -> drehen().drehen().drehen();
        }
    }

    public Form generateForm() {
        _topLeft = new Dreieck(_hoehe/2, _breite/2, _background, _foreground, TOP_LEFT);
        _topRight = new Dreieck(_hoehe/2, _breite/2, _background, _foreground, TOP_RIGHT);
        _botLeft = new Dreieck(_hoehe/2, _breite/2, _background, _foreground, BOT_RIGHT);
        _botRight = new Dreieck(_hoehe/2, _breite/2, _background, _foreground, BOT_LEFT);

        Form left = _topLeft.attach(_botLeft, SOUTH);
//        Form right = left.spiegelnY();
        Form right = _topRight.attach(_botRight, SOUTH);

        // mit variable
//        String[][] meinDiamantDarstellung = left.attach(right, EAST)._darstellung;
//        _darstellung = meinDiamantDarstellung;

        // ohne variable
        _darstellung = left.attach(right, EAST)._darstellung;

        return this;
    }

    // Get- Set-Methoden
}
