package FreitagNachmittag;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Hamster {
    // Felder
    private int x;
    private int y;
    private String darstellung;
    private boolean hatHunger;

    // (hat) Beziehungen
    private Spielfeld spielfeld;
    private List<Samen> backenSpeicher;

    // Konstruktor
    public Hamster(Spielfeld spielfeld) {
        hatHunger = false;
        darstellung = "🐹";

        backenSpeicher = new ArrayList<>();
        this.spielfeld = spielfeld;

        spielfeld.weiseHamsterZu(this);
        platziereMichAufFeld();
    }

    private void platziereMichAufFeld() {
        Random random = new Random();
        // TODO: Frage ab, ob im Spielfeld ein Bodensymbol auf den Koordinaten x und y ist.
        //  Wenn ja, setze den Hamster dort hin.
        //  Wenn nein, probier es nochmal.
        //  Konzepte: while und if (oder denke an ein do-while für kürzeren Code.)
//        boolean platziert = false;
//        while (!platziert) {
//            x = random.nextInt(spielfeld.getGroesse());
//            y = random.nextInt(spielfeld.getGroesse());
//
//            if (spielfeld.getSpielfeld()[y][x].equals(spielfeld.getBodenSymbol())) {
//               platziert = true;
//            }
//        }

        // aber vl. besser das hier:
        var bodensymbol = spielfeld.getBodenSymbol();
        var feld = spielfeld.getSpielfeld();

        do {
            x = random.nextInt(spielfeld.getGroesse());
            y = random.nextInt(spielfeld.getGroesse());
        } while (!feld[y][x].equals(bodensymbol));

        spielfeld.getSpielfeld()[y][x] = darstellung;
    }

    // Methoden
    public void bewegen() {
        Random random = new Random();
        int index = random.nextInt(0, Richtung.values().length);
        Richtung richtung = Richtung.values()[index];

        spielfeld.bewegeHamster(this, richtung);
    }

    public void metabolismn() {
        // werde zufällig hungrig

        // stehe ich auf einem Feld mit essen?
        // wenn ja, dann rufe methode essen auf
        // ansonsten rufe methode hamstern auf
    }

    public void essen() {
        // hamster wird nicht mehr hungrig.
        hatHunger = false;
        // hamster sagt dem spielfeld, der samen ist weg
        spielfeld.hamsterIsstSamen(this);
    }

    public void hamstern() {
        // hamster merkt sich, dass ein neues Samen Objekt gespeichtert wird.
        // hamster sagt dem spielfeld, der samen ist weg
        spielfeld.hamsterHamstertSamen(this);
    }

    @Override
    public String toString() {
        return darstellung;
    }

    // get-set Methoden
    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }

    public String getDarstellung() {
        return darstellung;
    }

    public void setDarstellung(String darstellung) {
        this.darstellung = darstellung;
    }

    public boolean isHatHunger() {
        return hatHunger;
    }

    public void setHatHunger(boolean hatHunger) {
        this.hatHunger = hatHunger;
    }

    public Spielfeld getSpielfeld() {
        return spielfeld;
    }

    public void setSpielfeld(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;
    }

    public List<Samen> getBackenSpeicher() {
        return backenSpeicher;
    }

    public void setBackenSpeicher(List<Samen> backenSpeicher) {
        this.backenSpeicher = backenSpeicher;
    }
}
