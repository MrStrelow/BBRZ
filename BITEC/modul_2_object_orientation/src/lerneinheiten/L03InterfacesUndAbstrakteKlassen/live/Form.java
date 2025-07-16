package lerneinheiten.L03InterfacesUndAbstrakteKlassen.live;

import lerneinheiten.L03InterfacesUndAbstrakteKlassen.live.implementierung.Orientation;

public abstract class Form {
    // Feld
    protected String[][] _darstellung;
    protected int _hoehe;
    protected int _breite;
    protected String _background;
    protected String _foreground;

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

        for (int zeilen = 0; zeilen < _breite; zeilen++) {
            for (int spalten = 0; spalten < _hoehe; spalten++) {
                sb.append(_darstellung[zeilen][spalten]);
            }
            sb.append("\n");
        }

        return sb.toString();
    }

    public Form spiegelnY() {
        String[][] copy = new String[_hoehe][_breite];

        for (int i = 0; i < _hoehe; i++) {
            for (int j = 0; j < _breite; j++) {
                copy[i][j] = _darstellung[i][_breite - 1 - j];
            }
        }

        _darstellung = copy;

        return this;
    }

    public Form spiegelnX() {
        String[][] copy = new String[_hoehe][_breite];

        for (int i = 0; i < _hoehe; i++) {
            for (int j = 0; j < _breite; j++) {
                copy[i][j] = _darstellung[_hoehe - 1 - i][j];
            }
        }

        _darstellung = copy;

        return this;
    }

    public Form fillCanvas(String symbol) {

        for (int i = 0; i < _hoehe; i++) {
            for (int j = 0; j < _breite; j++) {
                _darstellung[i][j] = symbol;
            }
        }

        return this;
    }

    public Form drehen() {
        return spiegelnX().transponieren();
    }

    private Form transponieren() {
        String[][] flipped = new String[_breite][_hoehe];
        int tmp = _hoehe;
        this._hoehe = _breite;
        this._breite = tmp;

        for (int i = 0; i < _hoehe; i++) {
            for (int j = 0; j < _breite; j++) {
                flipped[i][j] = _darstellung[j][i];
            }
        }

        this._darstellung = flipped;

        return this;
    }

    public Form attach(Form toBeAttached, Orientation orientation) {
        return switch (orientation) {
            case NORTH -> attachNorth(toBeAttached);
            case EAST -> attachEast(toBeAttached);
            case WEST -> attachWest(toBeAttached);
            case SOUTH -> attachSouth(toBeAttached);
        };
    }

    private Form attachNorth(Form north) {
        return north.attachSouth(this);
    }

    private Form attachEast(Form east) {
        return east.attachWest(this);
    }

    private Form attachWest(Form west) {
        // drehe zuerst mich selbst
        Form me = drehen();

        // drehe das was ich im Westen hinzufügen will
        Form westGedreht = west.drehen();

        // füge im Süden hinzu, da wir alles um 90° nach rechts gedreht haben. Westen ist also Süden.
        Form imSuedenAngefuegt = me.attachSouth(westGedreht);

        return imSuedenAngefuegt.drehen().drehen().drehen();
    }

    private Form attachSouth(Form south) {
        String[][] combined = new String[_hoehe + south._hoehe][_breite];

        // gehe meine darstellung ab und kopiere inhalt in combined an gleicher Stelle.
        for (int i = 0; i < _hoehe; i++) {
            for (int j = 0; j < _breite; j++) {
                combined[i][j] = _darstellung[i][j];
            }
        }

        // gehe die andere darstellung ab welche im Süden von mir sein soll und kopiere inhalt in combined an gleicher Stelle.
        for (int i = 0; i < south._hoehe; i++) {
            for (int j = 0; j < south._breite; j++) {
                combined[i + _hoehe][j] = south._darstellung[i][j];
            }
        }

        // ehhhh. wir wollen eigentlich eine neuer form machen.
        _darstellung = combined;
        _hoehe = combined.length;
        _breite = combined[0].length;

        return this;
    }

    // Konstruktor


    // Get- Set-Methoden
}
