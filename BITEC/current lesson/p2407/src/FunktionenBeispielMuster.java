public class FunktionenBeispielMuster {
    public static void main(String[] args) {
        String[][] feld = fillCanvas(new String[6][6], "~");
        String[][] dreieck = drawTriangle(feld, "#");
        String[][] diamant = drawDiamant(dreieck);
        print(diamant);
    }

    // Achtung! static immer vor die Funktion schreiben. Brauchen wir hier wegen der Objektorientierung. Das lernen wir später kennen.
    // funktion welche ein 2d Array auf die Console ausgibt
    static void print(String[][] feld) {

    }

    // funktion welche in ein 2d Array eine Raute(Diamant) zeichnet

    // funktion welche in ein 2d Array ein Dreieck zeichnet

    // funktion welche ein 2d Array mit einem Symbol befüllt

    // funktion um alles zusammenzufügen - diese funktion wird in der drawDiamant aufgerufen

    // funktion welche muster um x achse spiegelt - diese funktion wird in der drawDiamant aufgerufen

    // funktion welche muster um y achse spiegelt - diese funktion wird in der drawDiamant aufgerufen


}
