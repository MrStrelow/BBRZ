package lerneinheiten.L02KlassenUndMethoden.klassen;

public class SchaeferHund extends Hund {
    // Felder
    public int capacity;

    // Konstruktor
    public SchaeferHund(String name, Double happiness, Double health, boolean chipped, Integer alter, Hundebesitzer besitzer, int capacity) {
        super(name, happiness, health, chipped, alter, besitzer);
        this.capacity = capacity;
    }

    // Methoden
    public void hueten(){

    }

    // get und set Methoden

    public int getCapacity() {
        return capacity;
    }

    public void setCapacity(int capacity) {
        this.capacity = capacity;
    }
}
