//package test1;
//
//public class Dreieck {
//
//    private String[][] feld;
//
//    public Dreieck(int dimension) {
//        this.feld = new String[dimension][dimension];
//        this.befuellen();
//        this.dreieckErzeugen();
//    }
//
//    private void dreieckErzeugen() {
//        // feld mit muster befüllen
//        for (int zeile = 0; zeile < feld.length; zeile++) {
//            for (int spalte = 0; spalte < feld.length; spalte++) {
//                if (spalte <= zeile) {
//                    feld[zeile][spalte] = "#";
//                }
//            }
//        }
//    }
//
//    public Dreieck spiegeln() {
//        return null;
//    }
//
//    public Dreieck tranponieren() {
//        return null;
//    }
//
//    // ############ Fall 1 - Basisfeld ############
//
//
//    // ############ Fall 2 - Basisfeld spiegeln (x-achse) ############
//    // spiegeln über die x achse - wir ziehen Usereingabe von den zeilen ab und lassen spalten gleich
//        for (int zeile = 0; zeile < hoehe; zeile++) {
//        for (int spalte = 0; spalte < hoehe; spalte++) {
//            basisfeldGespiegelt[zeile][spalte] = basisfeld[hoehe-zeile-1][spalte];
//        }
//    }
//
//    // ############ Fall 3 - Basisfeld transponieren ############
//    // transponieren wir basisfeld (vertauschen zeilen mit spalten)
//        for (int zeile = 0; zeile < hoehe; zeile++) {
//        for (int spalte = 0; spalte < hoehe; spalte++) {
//            basisfeldTransponiert[zeile][spalte] = basisfeld[spalte][zeile];
//        }
//    }
//
//    // ############ Fall 4 - Basisfeld transponieren und dann spiegeln ############
//    // wir verwenden hier gleich das transponierte und spiegeln das
//        for (int zeile = 0; zeile < hoehe; zeile++) {
//        for (int spalte = 0; spalte < hoehe; spalte++) {
//            basisfeldTransponiertGespiegelt[zeile][spalte] = basisfeldTransponiert[hoehe-zeile-1][spalte];
//        }
//    }
//
//    public void drehen() {
//
//    }
//
//    private void befuellen() {
//        // feld mit leerzeichen befüllen
//        for (int zeile = 0; zeile < this.feld.length; zeile++) {
//            for (int spalte = 0; spalte < this.feld.length; spalte++) {
//                this.feld[zeile][spalte] = " ";
//            }
//        }
//    }
//
//    public String[][] getFeld() {
//        return feld;
//    }
//
//    public void setFeld(String[][] feld) {
//        this.feld = feld;
//    }
//}
