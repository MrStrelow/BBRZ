package KlassenUndBeziehungen;

import static KlassenUndBeziehungen.Essen.*;

public class HundeBesitzer extends Mensch {

    // Felder
    private boolean hatHundeFuehrerschein;

    // Beziehungen
    private Hund[] hunde;

    // Konstruktor
    public HundeBesitzer(String name, double happiness, int alter, boolean hatHundeFuehrerschein, Hund[] hunde) {
        super(name, happiness, alter);
        this.hatHundeFuehrerschein = hatHundeFuehrerschein;
        this.hunde = hunde;
    }

    // Methoden
    public void buersten() {

    }

    public void gassiGehen() {

    }

    public void fuettern() {
        for (Hund hund : hunde) {
            hund.fressen(FLEISCH);
        }
    }

    // get und set methoden
    public boolean isHatHundeFuehrerschein() {
        return hatHundeFuehrerschein;
    }

    public void setHatHundeFuehrerschein(boolean hatHundeFuehrerschein) {
        this.hatHundeFuehrerschein = hatHundeFuehrerschein;
    }

    public Hund[] getHunde() {
        return hunde;
    }

    public void setHunde(Hund[] hunde) {
        this.hunde = hunde;
    }
}
