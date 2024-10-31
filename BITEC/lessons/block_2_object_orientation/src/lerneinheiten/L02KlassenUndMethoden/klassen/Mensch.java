package lerneinheiten.L02KlassenUndMethoden.klassen;

public class Mensch {
    // Attribute sind nomen
    private String name;
    private double happiness;
    private int alter;

    // Konstruktor
    public Mensch(String name, double happiness, int alter) {
        this.name = name;
        this.happiness = happiness;
        this.alter = alter;
    }

    //Methoden sind verben
    public HundeBesitzer hundKaufen(Hund hund, boolean hatHundeFuehrerschein, int capacity) {
       return new HundeBesitzer(this, hatHundeFuehrerschein, hund, capacity);
    }

    public HundeBesitzer mehrereHundeKaufen(Hund[] hunde, boolean hatHundeFuehrerschein, int capacity) {
        return new HundeBesitzer(this, hatHundeFuehrerschein, hunde, capacity);
    }

    // get und set methoden
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
