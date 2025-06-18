package lerneinheiten.L02KlassenUndMethoden.live;

public class Besitzer {
    // Felder
    int _alter;
    int _capacity;

    // Hat-Beziehung
    Hund[] hunde;

    // Methoden
    void spazieren() {
        // Rufe für jeden hund in hunde die folgende Zeile auf.
        System.out.println(hashCode() + " spaziert mit " + hund.hashCode());

    }

    void fuettern() {
        System.out.println(hashCode() + " spaziert.");
    }

    // Konstruktor
    Besitzer(int alter) {
        // hier muss ich noch was mit hunde machen!

        if (alter > 18) {
            _alter = alter;

        } else {
            _alter = 18;
            System.out.println("Wurde automatisch auf 18 gesetzt, da es nicht geringer sein darf.");
        }

        _capacity = 5;
    }
}
