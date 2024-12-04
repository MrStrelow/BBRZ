package lerneinheiten.L02KlassenUndMethoden.grundlagen;

public class Mensch {
    // Attribute sind nomen
    private String name;
    private int alter;
    private double happiness;

    // hat-Beziehungen:
    // Die Beziehung "loveInterest" (geliebte/r) muss nicht gegenseitig sein (mutual).
    // Deshalb können viele eine Person als love interest haben und auch viele keinen haben welche love interested ist.
    private Mensch loveInterest;

    // Konstruktor
    public Mensch(String name, double happiness, int alter) {
        this.name = name;
        this.happiness = happiness;
        this.alter = alter;
    }

    public Mensch(String name, double happiness, int alter, Mensch loveInterest) {
        this(name, happiness, alter);
        this.loveInterest = loveInterest;
    }

    //Methoden sind verben
    public HundeBesitzer wirdEinHundeBesitzer(Hund hund, boolean hatHundeFuehrerschein, int capacity) {
        HundeBesitzer einGanzNeuerMensch = new HundeBesitzer(this, hatHundeFuehrerschein, capacity);
        einGanzNeuerMensch.kaufen(hund);

        return einGanzNeuerMensch;
    }

    public HundeBesitzer mehrereHundeKaufen(Hund[] hunde, boolean hatHundeFuehrerschein, int capacity) {
        HundeBesitzer einGanzNeuerMensch = new HundeBesitzer(this, hatHundeFuehrerschein, capacity);

        if (capacity <= hunde.length) {
            System.out.println("Fehler! Wir haben zu viele Hunde als wir betreuen können.");
            return null; // Achtung! Wir werden ein return null in Zukunft mit Exceptions ersetzen.
        }

        for (Hund hund : hunde) {
            einGanzNeuerMensch.kaufen(hund);
        }

        return einGanzNeuerMensch;
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

    public Mensch getLoveInterest() {
        return loveInterest;
    }

    public void setLoveInterest(Mensch loveInterest) {
        this.loveInterest = loveInterest;
    }
}
