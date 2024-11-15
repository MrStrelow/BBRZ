package FreitagNachmittag;

import FileReadWriteUndExceptions.SaveInCloud;

import java.util.ArrayList;
import java.util.List;

public class Hamster {
    // Felder
    private int x;
    private int y;
    private String darstellung;
    private boolean hatHunger;

    // (hat) Beziehungen
    private Spielfeld spielfeld;
    private List<Samen> backenSpeicher;

    // Konstruktor
    public Hamster(Spielfeld spielfeld) {
        backenSpeicher = new ArrayList<>();
        this.spielfeld = spielfeld;
        hatHunger = false;
        darstellung = "🐹";
        darstellung = "\uD83D\uDC39";
        darstellung = Character.toString( 58660 );;
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

    public String getDarstellung() {
        return darstellung;
    }

    public void setDarstellung(String darstellung) {
        this.darstellung = darstellung;
    }

    public boolean isHatHunger() {
        return hatHunger;
    }

    public void setHatHunger(boolean hatHunger) {
        this.hatHunger = hatHunger;
    }

    public Spielfeld getSpielfeld() {
        return spielfeld;
    }

    public void setSpielfeld(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;
    }

    public List<Samen> getBackenSpeicher() {
        return backenSpeicher;
    }

    public void setBackenSpeicher(List<Samen> backenSpeicher) {
        this.backenSpeicher = backenSpeicher;
    }
}
