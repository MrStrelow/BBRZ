package FreitagNachmittag;

import java.util.List;

public class Spielfeld {
    // Felder
    private String[][] spielfeld;
    private int groesse;
    private String bodenSymbol = "🟫";

    // (hat) Beziehungen
    private List<Samen> samen;
    private List<Hamster> hamster;

    // Konstruktor
    public Spielfeld(int groesse) {
        this.groesse = groesse;
        spielfeld = new String[groesse][groesse];

        // wir belegen das spielfeld mit bodensymoble
        // TODO: jedes element von spielfeld soll mit dem bodensymbol belegt werden
        // TODO: gib spielfeld aus in eigener Methode!! (Achtung! diese haben wir noch nicht erstellt!)

        // wir brauchen samen
        // TODO: die liste von Samen anlegen
        // TODO: zufälligen Anzahl der Samen erstellen und füge es der liste hinzu.

        // wir brauchen hamster
        // TODO: die liste von Hamster anlegen
        // TODO: zufälligen Anzahl der Hamster erstellen und füge es der liste hinzu.
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

    public int getGroesse() {
        return groesse;
    }

    public void setGroesse(int groesse) {
        this.groesse = groesse;
    }

    public String getBodenSymbol() {
        return bodenSymbol;
    }

    public void setBodenSymbol(String bodenSymbol) {
        this.bodenSymbol = bodenSymbol;
    }
}
