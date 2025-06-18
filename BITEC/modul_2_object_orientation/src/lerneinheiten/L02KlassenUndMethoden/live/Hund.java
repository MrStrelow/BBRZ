package lerneinheiten.L02KlassenUndMethoden.live;

public class Hund {
    // Felder
    int _alter;
    String _farbe;

    // Hat-Beziehung
    Besitzer besitzer;

    // --------------------------------
    // Methoden
    void essen() {

    }

    void bellen() {
        System.out.println("wuf.");
    }

    // Konstruktor
    Hund(int alter, String farbe) {
        _alter = alter;
        _farbe = farbe;
    }
}
