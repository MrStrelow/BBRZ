package hemstr;

import javax.security.sasl.SaslException;
import java.nio.channels.WritableByteChannel;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Hamster {
    // Attribute
    private String namen;
    private String darstellung;
    private String normaleDarstellung;
    private String hungrigeDarstellung;
    private Integer x;
    private Integer y;
    private String feldZumMerken;
    private Boolean istHungrig;

    // hat-Relationen
    private Spielfeld spielfeld;
    private List<Samen> backenSpeicher;

    // Konstruktor
    public Hamster(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;
        this.spielfeld.weiseHamsterZu(this);
        this.feldZumMerken = spielfeld.getBodenSymbol();

        normaleDarstellung = "🐹"; //Character.toString( 58660 );
        hungrigeDarstellung = "🐰";

        this.istHungrig = false;
        darstellung = normaleDarstellung;

        backenSpeicher = new ArrayList<>();
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

    public void essen() {
        istHungrig = false;
        darstellung = normaleDarstellung;
        spielfeld.hamsterIsstSamen(this);
    }

    public void hamstern() {
        spielfeld.hamsterHamstertSamen(this);
    }

    //TODO 2: hamstern (wenn kein hunger da ist)
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
        if(!feldZumMerken.equals(normaleDarstellung) || !feldZumMerken.equals(hungrigeDarstellung)) {
            this.feldZumMerken = feldZumMerken;
        }
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
