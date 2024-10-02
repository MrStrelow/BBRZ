package block1.test1;

public class Dreieck {

    private String[][] feld;
    private int hoehe;
    private int laenge;

    public Dreieck(int dimension) {
        this.feld = new String[dimension][dimension];
        this.hoehe = feld.length;
        this.laenge = feld[0].length;

        this.befuellen();
        this.dreieckErzeugen();
    }

    public Dreieck(Dreieck toCopy) {
        this.feld = toCopy.feld;
        this.laenge = toCopy.laenge;
        this.hoehe = toCopy.hoehe;
    }

    private void dreieckErzeugen() {
        // feld mit muster befüllen
        for (int zeile = 0; zeile < feld.length; zeile++) {
            for (int spalte = 0; spalte < feld.length; spalte++) {
                if (spalte <= zeile) {
                    feld[zeile][spalte] = "#";
                }
            }
        }
    }

    // ############ Fall 2 - Basisfeld spiegeln (x-achse) ############
    // spiegeln über die x achse - wir ziehen Usereingabe von den zeilen ab und lassen spalten gleich
    private Dreieck spiegeln() {
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

    // ############ Fall 3 - Basisfeld transponieren ############
    // transponieren wir basisfeld (vertauschen zeilen mit spalten)
    private Dreieck tranponieren() {
        Dreieck toReturn = new Dreieck(this);

        for (int zeile = 0; zeile < hoehe; zeile++) {
            for (int spalte = 0; spalte < hoehe; spalte++) {
                toReturn.feld[zeile][spalte] = feld[spalte][zeile];
            }
        }

        return toReturn;
    }


    // ############ Fall 4 - Basisfeld transponieren und dann spiegeln ############
    // wir verwenden hier gleich das transponierte und spiegeln das
        for (int zeile = 0; zeile < hoehe; zeile++) {
        for (int spalte = 0; spalte < hoehe; spalte++) {
            basisfeldTransponiertGespiegelt[zeile][spalte] = basisfeldTransponiert[hoehe-zeile-1][spalte];
        }
    }

    public void drehen() {

    }

    private void befuellen() {
        // feld mit leerzeichen befüllen
        for (int zeile = 0; zeile < this.feld.length; zeile++) {
            for (int spalte = 0; spalte < this.feld.length; spalte++) {
                this.feld[zeile][spalte] = " ";
            }
        }
    }

    public String[][] getFeld() {
        return feld;
    }

    public void setFeld(String[][] feld) {
        this.feld = feld;
    }
}
