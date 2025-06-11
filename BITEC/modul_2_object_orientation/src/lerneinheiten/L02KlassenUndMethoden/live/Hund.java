package lerneinheiten.L02KlassenUndMethoden.live;

public class Hund {
    // Felder
    int alter;
    String rasse;
    boolean gechipped;
    String geräusch;

    // Hat-Beziehung
    Besitzer meinBesitzer;

//  -----------------------------------------------------
    // Methoden

    void fressen() {

    }

    String bellen() {
        System.out.println(geräusch);
        return geräusch;
    }

    // Konstruktor
    Hund(String _geräusch, boolean gechipped, int alter, String rasse) {
        geräusch = _geräusch;
        gechipped = gechipped;
        alter = alter;
        rasse = rasse;
    }
}
