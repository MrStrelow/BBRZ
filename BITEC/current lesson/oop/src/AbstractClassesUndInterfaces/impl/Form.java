package AbstractClassesUndInterfaces.impl;

public abstract class Form {
    protected String[][] feld;
    protected int hoehe;
    protected int breite;
    protected String background;
    protected String filler;
    
    protected Form fillCanvas() {
        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                feld[i][j] = background;
            }
        }

        return this;
    }

    // Methoden für Drehen und Spiegeln
    public Form drehen() {
        return spiegelnX().transponieren();
    }

    public Form spiegelnX() {
        String[][] copy = new String[hoehe][breite];
//        Form copy = new Form(this);

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                copy[i][j] = feld[hoehe - 1 - i][j];
            }
        }

        this.feld = copy;

        return this;
    }

    public Form spiegelnY() {
//        Form copy = new Form(this);
        String[][] copy = new String[hoehe][breite];

        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j < breite; j++) {
                copy[i][breite - 1 - j] = feld[i][j];
            }
        }

        this.feld = copy;
        return this;
    }

    public Form transponieren() {
//        Form flipped = new Form(breite, hoehe, background, filler);
//
//        for (int i = 0; i < hoehe; i++) {
//            for (int j = 0; j < breite; j++) {
//                flipped.feld[j][i] = feld[i][j];
//            }
//        }
//
        return null;
    }

    protected abstract Form generiereForm();

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
}
