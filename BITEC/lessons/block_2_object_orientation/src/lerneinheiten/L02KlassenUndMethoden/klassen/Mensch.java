package lerneinheiten.L02KlassenUndMethoden.klassen;

public class Mensch {
    // Attribute sind nomen
    private String name;
    private double happiness;
    private int age;

    // Konstruktor
    public Mensch(String name, double happiness, int age) {
        this.name = name;
        this.happiness = happiness;
        this.age = age;
    }

    //Methoden sind verben
    public Hundebesitzer hundKaufen() {
        return null;
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

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }
}
