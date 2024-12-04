package AbstractClassesUndInterfaces.impl;

public class Dreieck {
    // Felder
    private String[][] feld;
    private int hoehe;
    private int breite;
    private String background;
    private String filler;
    Orientierung orientierung;

    // hat-Beziehungen

    // Konstruktor

    public Dreieck(int hoehe, int breite, String background, String filler, Orientierung orientierung) {
        this.hoehe = hoehe;
        this.breite = breite;
        this.background = background;
        this.filler = filler;
        this.orientierung = orientierung;

        this.feld = new String[hoehe][breite];

        fillCanvas().generiereDreieck();
    }

    private Dreieck generiereDreieck() {
        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j <= i; j++) {
                feld[i][j] = filler;
            }
        }

        // Warum hier keine Ist-Beziehung? dann ersparen wir uns dieses switch mit der orientierung?
        // Antwort: es kann beides sinnvoll sein. Wir gehen aber davon aus, dass ein Dreieck nicht nur in 90° Orten einen rechten winkel hat.
        // Wie implementieren wir aber einen beliebigen rechten winkel? Das haben wir auch hier nicht gemacht, mit dem enum Orientierung.
        // Jedoch soll das hier als Denkanstoß dafür dienen.
        switch (orientierung) {
            case TOP_LEFT  -> this.spiegelnX();
            case TOP_RIGHT -> this.spiegelnX().spiegelnY();
//            case TOP_RIGHT -> this.spiegelnX().transponieren(); // Warum geht das nicht? Hinweis: werde ich selber verändert oder wird ein neues Objekt verändert?
            case BOT_RIGHT -> this.spiegelnY();
        }

        return this;
    }

    private Dreieck fillCanvas() {
        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][j] = background;
            }
        }

        return this;
    }

    // Methoden für Drehen und Spiegeln
    public Dreieck drehen() {
        return spiegelnX().transponieren();
    }

    public Dreieck spiegelnX() {
        String[][] copy = new String[hoehe][breite];
//        Dreieck copy = new Dreieck(this);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                copy[i][j] = feld[hoehe - 1 - i][j];
            }
        }

        this.feld = copy;

        return this;
    }

    public Dreieck spiegelnY() {
//        Dreieck copy = new Dreieck(this);
        String[][] copy = new String[hoehe][breite];

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][breite - 1 - j] = copy[i][j];
            }
        }

        return this;
    }

    public Dreieck transponieren() {
        Dreieck flipped = new Dreieck(breite, hoehe, background, filler, orientierung);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                flipped.feld[j][i] = feld[i][j];
            }
        }

        return flipped;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                sb.append(feld[i][j]);
            }
            sb.append("\n");
        }

        return sb.toString();
    }

    // Methoden
    // get-set Methoden

    // Innere "Klasse"
    public static enum Orientierung {
        // Rechter winkel zeigt wohin?
        TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT
    }
}
