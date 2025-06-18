package lerneinheiten.L02KlassenUndMethoden.live;

import java.util.Random;

public class Hund {
    // Felder
    int _alter;
    String _farbe;
    String _geraeusch;
    String[] _zufallsbellen = {"würf", "bürf", "sürf", "kerf", "brrp"};

    // Hat-Beziehung
    Besitzer besitzer;

    // --------------------------------
    // Methoden
    void essen() {

    }

    void bellen() {
        System.out.println(_geraeusch);
    }

    Hund(int alter, String farbe) {
        _alter = alter;
        _farbe = farbe;

        Random random = new Random();
        int zufaellige_position = random.nextInt(0, _zufallsbellen.length);
        _geraeusch = _zufallsbellen[zufaellige_position];
    }

    // Konstruktoren
    Hund(int alter, String farbe, String geraeusch) {
        _alter = alter;
        _farbe = farbe;
        _geraeusch = geraeusch;
    }
}
