package lerneinheiten.L05InterfacesUndAbstrakteKlassen.live.klassen;

public abstract class Form {
    // Feld
    protected String[][] darstellung;
    protected int hoehe;
    protected int breite;
    protected String background;
    protected String foreground;

    // Hat-Beziehung
    // Methoden
    public abstract Form generateForm();

    public String toString() {
        StringBuilder sb = new StringBuilder();

        for (int zeilen = 0; zeilen < breite; zeilen++) {
            for (int spalten = 0; spalten < hoehe; spalten++) {
                sb.append(darstellung[zeilen][spalten]);
            }
            sb.append("\n");
        }

        return sb.toString();
    }

    public Form spiegelnY() {
        String[][] copy = new String[hoehe][breite];

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                copy[i][j] = darstellung[i][breite - 1 - j];
            }
        }

        darstellung = copy;

        return this;
    }

    public Form spiegelnX() {
        String[][] copy = new String[hoehe][breite];

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                copy[i][j] = darstellung[hoehe - 1 - i][j];
            }
        }

        darstellung = copy;

        return this;
    }

    public Form fillCanvas(String symbol) {

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                darstellung[i][j] = symbol;
            }
        }

        return this;
    }

    // gleich TODO:

    // Konstruktor
    // Get- Set-Methoden
}
