package lerneinheiten.L03InterfacesUndAbstrakteKlassen.live;

import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Direction;

public abstract class Form {
    // Feld
    protected String[][] darstellung;
    protected int hoehe;
    protected int breite;
    protected String background;
    protected String foreground;

    // Hat-Beziehung
    // Methoden
    // Abstrakte methoden müssen in einer Unterklasse der Ist-Beziehung überschrieben werden. Hier ist das Dreieck, Diamant, etc.
    // Wenn wir abstrakt sind, nennen wir es implementiert, und nicht überschrieben, das ist aber ein sprachliches detail.
    // Die Idee ist jedoch dieselbe. Wir nennen beides, abstrakte Methoden implementieren und nicht abstrakte methoden überschreiben, einfachheitshalber überschreiben.
    public abstract Form generateForm();

    // Polymorphismus: Wir überschreiben die Methode toString aus der Klasse Object.
    // Jede Klasse was wir erstellen hat eine Ist-Beziehung zu der Klasse Object. Es muss aber nicht Form extends Object hingeschrieben werden.
    // Ohne einer Ist-Beziehung kann keine Methode überschreiben werden.
    // Wir sehen in Intellij wenn links neben der Methodendefinition ein blaues (o) für override steht.
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

    public Form drehen() {
        return spiegelnX().transponieren();
    }

    protected Form transponieren() {
        String[][] flipped = new String[breite][hoehe];
        int tmp = hoehe;
        this.hoehe = breite;
        this.breite = tmp;

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                flipped[i][j] = darstellung[j][i];
            }
        }

        this.darstellung = flipped;

        return this;
    }

    protected Form attach(Form toBeAttached, Direction orientation) {

    }

    private Form attachNorth(Form north) {

    }

    private Form attachEast(Form east) {

    }

    private Form attachSouth(Form south) {

    }

    private Form attachWest(Form west) {

    }

    // Konstruktor
    // Get- Set-Methoden
}
