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
}
