package FreitagNachmittag;

import java.util.List;

public class Spielfeld {
    // Felder
    private String[][] spielfeld;
    private int groesse = 5;

    // (hat) Beziehungen
    private List<Samen> samen;
    private List<Hamster> hamster;

    // Konstruktor
    public Spielfeld(int groesse) {
        this.groesse = groesse;
        spielfeld = new String[groesse][groesse];
    }

    // Methoden
    public void weiseHamsterZu(Hamster hamster) {
    }

    public void bewegeHamster(Hamster hamster, Richtung richtung) {
    }

    public void hamsterIsstSamen(Hamster hamster) {
    }

    public void hamsterHamstertSamen(Hamster hamster) {
    }

    public void weiseSamenZu(Samen samen) {
    }

    // get-set Methoden
    public String[][] getSpielfeld() {
        return spielfeld;
    }

    public void setSpielfeld(String[][] spielfeld) {
        this.spielfeld = spielfeld;
    }

    public int getGroeße() {
        return groesse;
    }

    public void setGroeße(int groeße) {
        this.groesse = groesse;
    }

    public List<Samen> getSamen() {
        return samen;
    }

    public void setSamen(List<Samen> samen) {
        this.samen = samen;
    }

    public List<Hamster> getHamster() {
        return hamster;
    }

    public void setHamster(List<Hamster> hamster) {
        this.hamster = hamster;
    }
}
