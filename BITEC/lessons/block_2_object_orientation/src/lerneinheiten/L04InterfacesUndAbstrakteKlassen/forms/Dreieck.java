package lerneinheiten.L04InterfacesUndAbstrakteKlassen.forms;

public class Dreieck extends Form {

    public Dreieck(int dimension) {
        super(dimension);
    }

    public Dreieck(Form toCopy) {
        super(toCopy);
    }

    @Override
    protected void erzeugeForm() {
        // feld mit muster befüllen
        for (int zeile = 0; zeile < feld.length; zeile++) {
            for (int spalte = 0; spalte < feld.length; spalte++) {
                if (spalte <= zeile) {
                    feld[zeile][spalte] = filler;
                }
            }
        }
    }
}
