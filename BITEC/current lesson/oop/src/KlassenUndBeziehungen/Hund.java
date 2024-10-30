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

    public void spielen() {
        System.out.println("Mein Spielfreund: " + spielFreund[0].name + " spielt mit ... mir: " + this.name);
    }

    public void fressen(Essen essen) {

    }

    public void weglaufen() {

    }
}
