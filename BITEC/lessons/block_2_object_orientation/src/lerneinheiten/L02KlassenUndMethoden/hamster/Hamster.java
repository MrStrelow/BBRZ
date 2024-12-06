package lerneinheiten.L02KlassenUndMethoden.hamster;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Hamster {
    // Felder
    private Tuple<Integer, Integer> position;
    private String darstellung;
    private static String hungrigeDarstellung = "😡";
    private static String normaleDarstellung = "🐹";
    private boolean hatHunger;

    private String feldZumMerken;

    // (hat) Beziehungen
    private Spielfeld spielfeld;
    private List<Samen> backenSpeicher;

    // Konstruktor
    public Hamster(Spielfeld spielfeld) {
        hatHunger = false;
        darstellung = normaleDarstellung;
        this.feldZumMerken = Spielfeld.getBodenSymbol();

        backenSpeicher = new ArrayList<>();
        this.spielfeld = spielfeld;

        plazierenUndVerwalteHamster();
    }

    private void plazierenUndVerwalteHamster() {
        Random random = new Random();
        boolean done;
        int x, y;

        do {
            x = random.nextInt(spielfeld.getGroesse());
            y = random.nextInt(spielfeld.getGroesse());

            done = spielfeld.weiseHamsterZu(this, new Tuple<>(x,y));
        } while (!done);

        position = new Tuple<>(x,y);
    }

    // Methoden
    public void bewegen() {
        Random random = new Random();
        int index = random.nextInt(0, Richtung.values().length);
        Richtung richtung = Richtung.values()[index];

        spielfeld.bewegeHamster(this, richtung);
    }

    public void nahrungsVerhalten() {
        // werde zufällig hungrig
        Random random = new Random();

        if (random.nextDouble() < 0.1) {
            hatHunger = true;
            darstellung = hungrigeDarstellung;
        }

        // stehe ich auf einem Feld mit essen?
        // TODO: Gehe in der Stunde auf folgendes ein:
        //  Die Abfragen beziehen sich auf die grafische Darstellung.
        //  Diese muss nicht konsistent mit der der logischen sein!
        //  Vermeide deshalb diese.
//        if (feldZumMerken.equals(Samen.getDarstellung())) { ... }

        // nutze anstatt dessen die HashMap und seine Eigenschaften!
        Samen einzelnerSamen = spielfeld.getSamen(position);

        // wenn null dann kein Samen auf meinem Feld
        if (einzelnerSamen != null) {
            // habe ich hunger?
            if (hatHunger) {
                // wenn ja, dann rufe methode essen auf
                essenVomBoden();
            } else {
                // ansonsten rufe methode hamstern auf
                hamstern();
            }

        } else {
            if (hatHunger && !backenSpeicher.isEmpty()) {
                essenVomBackenspeicher();
            }
        }
    }

    private void essenVomBackenspeicher() {
        essen();
        darstellung = normaleDarstellung;
        backenSpeicher.remove(0);
    }

    public void essenVomBoden() {
        // hamster wird nicht mehr hungrig.
        essen();

        // hamster sagt dem spielfeld, der samen ist weg
        spielfeld.hamsterIsstSamen(this);
    }

    private void essen() {
        hatHunger = false;
        darstellung = normaleDarstellung;
    }

    public void hamstern() {
        // hamster merkt sich, dass ein neues Samen Objekt gespeichtert wird.
        Samen samen = spielfeld.getSamen(position);
        backenSpeicher.add(samen);

        // hamster sagt dem spielfeld, der samen ist weg
        spielfeld.hamsterHamstertSamen(this);
    }

    @Override
    public String toString() {
        return darstellung;
    }

    // get-set Methoden
    public Tuple<Integer, Integer> getPosition() {
        return position;
    }

    public void setPosition(int x, int y) {
        position.setX(x);
        position.setY(y);
    }

    public void setPosition(Tuple<Integer, Integer> position) {
        this.position = position;
    }

    public int getX() {
        return position.getX();
    }

    public void setX(int x) {
        position.setX(x);
    }

    public int getY() {
        return position.getY();
    }

    public void setY(int y) {
        position.setY(y);
    }

    public void setY(Tuple<Integer, Integer> position) {
        this.position = position;
    }

    public String getDarstellung() {
        return darstellung;
    }

    public static String getHungrigeDarstellung() {
        return hungrigeDarstellung;
    }

    public static String getNormaleDarstellung() {
        return normaleDarstellung;
    }

    public String getFeldZumMerken() {
        return feldZumMerken;
    }

    public void setFeldZumMerken(String feldZumMerken) {
        this.feldZumMerken = feldZumMerken;
    }
}
