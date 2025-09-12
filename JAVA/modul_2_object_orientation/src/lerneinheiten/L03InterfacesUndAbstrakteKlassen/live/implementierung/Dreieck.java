package lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung;

public class Dreieck extends Form {

    // Feld
    private Direction _direction;

    // Hat-Beziehung
    // Methode
    public Form generateForm() {
        for (int zeilen = 0; zeilen < _breite; zeilen++) {
            for (int spalten = 0; spalten < _hoehe; spalten++) {
                if (spalten <= zeilen) {
                    _darstellung[zeilen][spalten] = _foreground;
                } else {
                    _darstellung[zeilen][spalten] = _background;
                }
            }
        }

        switch (_direction) {
            case BOT_RIGHT -> spiegelnX();
            case TOP_LEFT -> spiegelnY();
            case BOT_LEFT -> spiegelnX().spiegelnY();
        }

        return this;
    }

    // Konstruktor
    public Dreieck(
            int hoehe, int breite, String background,
            String foreground, Direction direction
    ) {
        _hoehe = hoehe;
        _breite = breite;
        _darstellung = new String[hoehe][breite];
        _background = background;
        _foreground = foreground;
        _direction = direction;

        generateForm();
    }

    // Get- Set-Methoden
}
