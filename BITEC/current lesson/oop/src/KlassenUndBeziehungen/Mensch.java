package KlassenUndBeziehungen;

public class Mensch {
    // Felder
    private String name;
    private double happiness;
    private int alter;

    public Mensch(String name, double happiness, int alter) {
        this.name = name;
        this.happiness = happiness;
        this.alter = alter;
    }

    public HundeBesitzer hundeBesitzer(Hund hund) {
        return null;
    }

    // get und set Methoden
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getHappiness() {
        return happiness;
    }

    public void setHappiness(double happiness) {
        this.happiness = happiness;
    }

    public int getAlter() {
        return alter;
    }

    public void setAlter(int alter) {
        this.alter = alter;
    }
}
