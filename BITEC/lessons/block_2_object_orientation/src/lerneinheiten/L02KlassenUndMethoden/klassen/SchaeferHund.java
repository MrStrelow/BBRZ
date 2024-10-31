package lerneinheiten.L02KlassenUndMethoden.klassen;

public class SchaeferHund extends Hund {
    // Felder
    public int capacity;

    // Beziehungen
    public Hund[] behueteteHunde;

    // Konstruktor
    public SchaeferHund(String name, Double happiness, Double health, boolean chipped, Integer alter, HundeBesitzer besitzer, int capacity, Hund[] behuetendeHunde) {
        super(name, happiness, health, chipped, alter, besitzer);

        if(capacity < behueteteHunde.length) {
            return;
        }

        this.capacity = capacity;
        this.behueteteHunde = behuetendeHunde;
    }

    // Methoden
    public void hueten(){
        for (Hund behueteterHund : behueteteHunde) {
            System.out.println("ich: " + this.getName() + " behuete " + behueteterHund.getName());
        }
    }

    // get und set Methoden
    public int getCapacity() {
        return capacity;
    }

    public void setCapacity(int capacity) {
        this.capacity = capacity;
    }
}
