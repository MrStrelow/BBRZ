package FreitagNachmittag;

import java.util.Random;

public class Samen {
    // Felder
    private int x;
    private int y;
    private double nährstoffe;
    private static String darstellung = "🌱";

    // (hat) Beziehungen
    private Spielfeld spielfeld;

    // Konstruktor
    public Samen(Spielfeld spielfeld) {
        this.nährstoffe = new Random().nextDouble();
        this.spielfeld = spielfeld;

        platziereMichAufFeld();
    }

    private void platziereMichAufFeld() {
        // TODO: Verwende die Logik aus der Klasse Hamster, Methode platziereMichAufFeld
        //  um einen samen am spielfeld zu plazieren.
        Random random = new Random();
        var bodensymbol = spielfeld.getBodenSymbol();
        var feld = spielfeld.getSpielfeld();

        do {
            x = random.nextInt(spielfeld.getGroesse());
            y = random.nextInt(spielfeld.getGroesse());
        } while (!feld[y][x].equals(bodensymbol));

        spielfeld.getSpielfeld()[y][x] = darstellung;
    }

    // Methoden
    // wir überschreiben die toString methode von der Klasse Object.
    // Wir erben von der Klasse Object, deshalb haben wir diese Methode.
    // Überschreiben bedeutet, wenn wir eine Variable vom Typ Samen haben,
    // (ein Objekt von der Klasse samen), dann rufen wir unsere eigene toString()
    // Methode auf.
    // z.B. bei System.out.println(samen); würden wir "🟫" als output bekommen.
    // Wenn wir nicht toString so überschreiben wird "FreitagNachmittag.Samen@5b480cf9" ausgeben.
    @Override
    public String toString() {
        return darstellung;
    }

    // get-set Methoden
    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }

    public double getNährstoffe() {
        return nährstoffe;
    }

    public void setNährstoffe(double nährstoffe) {
        this.nährstoffe = nährstoffe;
    }

    public static String getDarstellung() {
        return darstellung;
    }

    public Spielfeld getSpielfeld() {
        return spielfeld;
    }

    public void setSpielfeld(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;
    }
}
