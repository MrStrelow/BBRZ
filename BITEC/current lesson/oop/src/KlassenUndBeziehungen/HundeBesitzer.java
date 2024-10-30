package KlassenUndBeziehungen;

public class HundeBesitzer extends Mensch {

    // Felder
    private boolean hatHundeFuehrerschein;

    // Beziehungen
    private Hund[] hunde;

    // Konstruktor
    public HundeBesitzer(String name, double happiness, int alter, boolean hatHundeFuehrerschein, int capacity) {
        super(name, happiness, alter);
        this.hatHundeFuehrerschein = hatHundeFuehrerschein;
        this.hunde = new Hund[capacity];
    }

    // Methoden
    public void buersten() {

    }

    public void gassiGehen() {

    }

    public void fuettern() {

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
