package FreitagNachmittag;

import java.util.Random;

public class Samen {
    // Felder
    private int x;
    private int y;
    private double nährstoffe;
    private String darstellung;

    // (hat) Beziehungen
    private Spielfeld spielfeld;

    // Konstruktor
    public Samen(int x, int y, Spielfeld spielfeld) {
        this.x = x;
        this.y = y;
        this.nährstoffe = new Random().nextDouble();
        this.darstellung = "🌱";
        this.spielfeld = spielfeld;
        spielfeld.weiseSamenZu(this);
    }

    // Methoden
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

    public String getDarstellung() {
        return darstellung;
    }

    public void setDarstellung(String darstellung) {
        this.darstellung = darstellung;
    }

    public Spielfeld getSpielfeld() {
        return spielfeld;
    }

    public void setSpielfeld(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;
    }
}
