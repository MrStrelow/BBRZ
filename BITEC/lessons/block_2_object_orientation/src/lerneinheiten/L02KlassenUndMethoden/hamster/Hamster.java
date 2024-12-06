package lerneinheiten.L02KlassenUndMethoden.hamster;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Hamster {
    // Attribute
    private String namen;
    private String darstellung;
    private static String normaleDarstellung = "🐹"; //Character.toString( 58660 );
    private static String hungrigeDarstellung = "😡";
    private Integer x;
    private Integer y;
    private String feldZumMerken;
    private Boolean istHungrig;

    // hat-Relationen
    private Spielfeld spielfeld;
    private List<Samen> backenSpeicher;

    // Konstruktor
    public Hamster(Spielfeld spielfeld) {
        backenSpeicher = new ArrayList<>();
        this.istHungrig = false;

        this.spielfeld = spielfeld;
        this.feldZumMerken = spielfeld.getBodenSymbol();
        darstellung = normaleDarstellung;

        this.spielfeld.weiseHamsterZu(this);
    }

    // hier wird der hamster dem spielfeld zugewiesen. Siehe Samen.
    // wo wird der hamster im spielfeld hingesetzt?

    // methoden
    public void bewegen() {
        Random random = new Random();
        Richtung[] values = Richtung.values();
        Richtung richtung = values[random.nextInt(values.length)];

        spielfeld.bewegeHamster(this, richtung);
    }

    public void verstoffwechselen() {
        wirdZufaelligHungrig();

        boolean stehtAufEssen = feldZumMerken.equals(Samen.getSamenSymbol());
        if (istHungrig && stehtAufEssen) {
            essen();
        }

        if (!istHungrig && stehtAufEssen) {
            hamstern();
        }
    }

    private void wirdZufaelligHungrig() {
        Random random = new Random();
        if (random.nextDouble() < 0.1) {
            istHungrig = true;
            darstellung = hungrigeDarstellung;
        }
    }

    private void essen() {
        istHungrig = false;
        darstellung = normaleDarstellung;
        spielfeld.hamsterIsstSamen(this);
    }

    private void hamstern() {
        spielfeld.hamsterHamstertSamen(this);
    }

    //TODO 3: nicht passierbare felder einbauen (wie steine oder, ab jetzt dann hamster! -  mit exception)
    //TODO 4: verschiedene typen von hamstern bzw. essen

    // getter-setter
    public Integer getX() {
        return x;
    }

    public void setX(Integer x) {
        this.x = x;
    }

    public Integer getY() {
        return y;
    }

    public void setY(Integer y) {
        this.y = y;
    }

    public void setFeldZumMerken(String feldZumMerken) {
        this.feldZumMerken = feldZumMerken;
    }

    public String getFeldZumMerken() {
        return this.feldZumMerken;
    }

    public Boolean getIstHungrig() {
        return istHungrig;
    }

    public void setIstHungrig(Boolean istHungrig) {
        this.istHungrig = istHungrig;
    }

    public List<Samen> getBackenSpeicher() {
        return backenSpeicher;
    }

    public String getDarstellung() {
        return darstellung;
    }

    public void setDarstellung(String darstellung) {
        this.darstellung = darstellung;
    }

    public String getHungrigeDarstellung() {
        return hungrigeDarstellung;
    }

    public String getNormaleDarstellung() {
        return normaleDarstellung;
    }
}
