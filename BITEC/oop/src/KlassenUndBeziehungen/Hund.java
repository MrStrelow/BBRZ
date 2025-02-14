package KlassenUndBeziehungen;

public class Hund {
    // Felder
    public String name;
    public int alter;
    public String geschlecht;
    public boolean chipped;
    public double health;

    // hat-Beziehungen
    public Hund spielFreund;

    // Methoden
    public String bellen() {
        String sound = "wüf";
        System.out.println(sound);

        return sound;
    }

    // Konstruktor
    public Hund(String name, int alter, String geschlecht, boolean chipped, double health){
        this.name = name;
        this.alter = alter;
        this.geschlecht = geschlecht;
        this.chipped = chipped;
        this.health = health;
    }

    public void spielen() {
        System.out.println("Mein Spielfreund: " + spielFreund.name + " spielt mit ... mir: " + this.name);
    }

    public void fressen(Essen essen) {
        health++;
        System.out.println("Ich: " + this.name + " frisst " + essen);
        bellen();
    }

    public void weglaufen() {

    }
}
