package FreitagNachmittag;

import java.util.ArrayList;
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
        for (int i = 0; i < groesse; i++) {
            for (int j = 0; j < groesse; j++) {
                spielfeld[i][j] = bodenSymbol;
            }
        }

        // wir brauchen samen
        // TODO: die liste von Samen anlegen
        samen = new ArrayList<>();

        // TODO: zufälligen Anzahl der Samen erstellen und füge es der liste hinzu.
        for (int i = 0; i < 5; i++) {
            samen.add(new Samen(0,0, this));
        }

        for (var elem : samen) {
            System.out.println(elem);
        }

        // wir brauchen hamster
        // TODO: die liste von Hamster anlegen
        // TODO: zufälligen Anzahl der Hamster erstellen und füge es der liste hinzu.
    }

    // Methoden
    public void printSpielfeld() {
        for (int i = 0; i < groesse; i++) {
            for (int j = 0; j < groesse; j++) {
                System.out.print(spielfeld[i][j]);
            }
            System.out.println();
        }
    }

    public void weiseHamsterZu(Hamster hamster) {
        for (int i = 0; ; i++) {

        }
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
