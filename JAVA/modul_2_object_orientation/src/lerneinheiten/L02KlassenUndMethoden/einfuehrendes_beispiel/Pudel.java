package lerneinheiten.L02KlassenUndMethoden.einfuehrendes_beispiel;

public class Pudel extends Hund {
    double fluff;

    public Pudel(String name, Integer alter, String geschlecht, Double health, boolean chipped, double fluff) {
        super(name, alter, geschlecht, health, chipped);
        this.fluff = fluff;
    }

    public Pudel(String name, Integer alter, String geschlecht, Double health, boolean chipped, double fluff, HundeBesitzer besitzer, Hund spielFreund) {
        this(name, alter, geschlecht, health, chipped, fluff);
        this.setBesitzer(besitzer);
        this.setSpielFreund(spielFreund);
    }

    public Pudel(String name, Integer alter, String geschlecht, Double health, boolean chipped, double fluff, HundeBesitzer besitzer) {
        this(name, alter, geschlecht, health, chipped, fluff);
        this.setBesitzer(besitzer);
    }

    public Pudel(String name, Integer alter, String geschlecht, Double health, boolean chipped, double fluff, Hund spielFreund) {
        this(name, alter, geschlecht, health, chipped, fluff);
        this.setSpielFreund(spielFreund);
    }

    public void winseln() {
        System.out.println(".... ewww");
        setHealth(getHealth() - 1);
    }

    public double getFluff() {
        return fluff;
    }

    public void setFluff(double fluff) {
        this.fluff = fluff;
    }
}
