package block2.Klassen;

public class Tagesablauf {
    private Hund hund;

    public Tagesablauf(Hund hund) {
        this.hund = hund;
    }
    public void postWirdGebracht() {
        hund.bellen();
    }
}
