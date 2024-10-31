package lerneinheiten.L02KlassenUndMethoden.klassen;

public class Pudel extends Hund {
    double fluff;

    public Pudel(String name, Double happiness, Double health, boolean chipped, Integer alter, HundeBesitzer besitzer, double fluff) {
        super(name, happiness, health, chipped, alter, besitzer);
        this.fluff = fluff;
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
