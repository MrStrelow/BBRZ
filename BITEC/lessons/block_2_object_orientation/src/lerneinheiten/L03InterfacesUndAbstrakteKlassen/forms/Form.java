package lerneinheiten.L03InterfacesUndAbstrakteKlassen.forms;

public abstract class Form {
    // ############ FIELDS ############
    protected String[][] feld;
    protected int hoehe;
    protected int breite;

    protected String background;

    protected String filler;

    // ############ METHODS ############
    // ### Data-Hiding - public ###
    // Constructor - initialize

    public Form(int dimension) {
        this.feld = new String[dimension][dimension];
        this.hoehe = feld.length;
        this.breite = feld[0].length;

        this.assignBackground();
        this.assignFiller();
        this.befuellen();
        this.erzeugeForm();
    }

    // Constructor - Copy
    public Form(Form toCopy) {
        this.feld = toCopy.feld;
        this.breite = toCopy.breite;
        this.hoehe = toCopy.hoehe;
    }

    public Form drehen() {
        return spiegeln().tranponieren();
    }

    // Polymorphism - overwritten Methods
    public String toString(){
        StringBuilder toReturn = new StringBuilder();

        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                toReturn.append(feld[zeile][spalte]);
            }
            toReturn.append("\n");
        }

        return toReturn.toString();
}

    // ### Data-Hiding - private ###
    // create triangle with right angle at the lower left side.
    protected abstract void erzeugeForm();

    protected String assignBackground() {
        return background = " ";
    }

    protected String assignFiller() {
        return filler = "#";
    }

    protected Form append(Form toAppend, Direction direction) {
        String[][] feld;

        feld = switch (direction) {
            case EAST, WEST -> {
                if (toAppend.hoehe == hoehe) {
                    yield( new String[hoehe][breite + toAppend.breite] );
                } else {
                    yield( this.feld) ;
                }
            }
            case NORTH, SOUTH -> {
                if (toAppend.breite == breite) {
                    yield( new String[hoehe + toAppend.hoehe][breite] );
                } else {
                    yield( this.feld) ;
                }
            }
        };

        return this;
    }

    // transponieren wir basisfeld (vertauschen zeilen mit spalten)
    protected Dreieck tranponieren() {
        Dreieck toReturn = new Dreieck(this);

        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                toReturn.feld[zeile][spalte] = feld[spalte][zeile];
            }
        }

        return toReturn;
    }

    // spiegeln über die x achse - wir ziehen Usereingabe von den zeilen ab und lassen spalten gleich
    protected Form spiegeln() {
        // Denke dran was machen wir hier?
        Dreieck toReturn = new Dreieck(this);
//        Dreieck tmp = new Dreieck(this);

        for (int zeile = 0; zeile < feld.length; zeile++) {
            for (int spalte = 0; spalte < feld.length; spalte++) {
                toReturn.feld[zeile][spalte] = feld[feld.length-zeile-1][spalte];
//                feld[zeile][spalte] = tmp[feld.length-zeile-1][spalte];
            }
        }

        // was mache ich, wenn ich this zurückgebe?
        return toReturn;
//        return this;
    }

    protected void befuellen() {
        // feld mit leerzeichen befüllen
        for (int zeile = 0; zeile < this.feld.length; zeile++) {
            for (int spalte = 0; spalte < this.feld.length; spalte++) {
                this.feld[zeile][spalte] = filler;
            }
        }
    }

    // get - set
    public String[][] getFeld() {
        return feld;
    }

    public void setFeld(String[][] feld) {
        this.feld = feld;
    }
}
