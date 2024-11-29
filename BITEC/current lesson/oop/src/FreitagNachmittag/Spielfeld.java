package FreitagNachmittag;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

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
        Random random = new Random();
        int anzahlSamen = random.nextInt(1, groesse*groesse);

        for (int i = 0; i < anzahlSamen; i++) {
            samen.add(new Samen(this));
        }

        // wir brauchen hamster
        // TODO: die liste von Hamster anlegen
        hamster = new ArrayList<>();

        // TODO: zufälligen Anzahl der Hamster erstellen und füge es der liste hinzu.
        int anzahlHamster = random.nextInt(1, groesse*groesse - anzahlSamen + 1);

        for (int i = 0; i < anzahlHamster; i++) {
            hamster.add(new Hamster(this));
        }

//        for (var elem : hamster) {
//            System.out.println(elem);
//        }
//
//        for (var elem : samen) {
//            System.out.println(elem);
//        }
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

    }

    public void bewegeHamster(Hamster hamster, Richtung richtung) {
        // TODO: bewege hamster ein feld nach rechts.

        // TODO: bewege hamster in ein feld der "Richtung richtung" welche als parameter übergeben wird.

        // TODO: bewege den Hamster so, dass er nicht von der Karte fällt.
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
