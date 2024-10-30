package KlassenUndBeziehungen;

public class Hund {
    // Felder
    public String name;
    public int alter;
    public String geschlecht;
    public boolean chipped;
    public double health;

    // hat-Beziehungen
    public Hund[] spielFreund;

    // Methoden
    public String bellen() {
        return "";
    }

    // Konstruktor
    public Hund(String name, int alter, String geschlecht, boolean chipped, double health, Hund[] spielFreunde){
        this.name = name;
        this.alter = alter;
        this.geschlecht = geschlecht;
        this.chipped = chipped;
        this.health = health;
        this.spielFreund = spielFreund;
    }

    public void spielen() {
        System.out.println("Mein Spielfreund: " + spielFreund[0].name + " spielt mit ... mir: " + this.name);
    }

    public void fressen(Essen essen) {

    }

    public void weglaufen() {

    }
}
