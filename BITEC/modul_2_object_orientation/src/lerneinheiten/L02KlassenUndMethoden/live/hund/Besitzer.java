package lerneinheiten.L02KlassenUndMethoden.live.hund;

public class Besitzer {
    // Felder
    int _alter;
    int _capacity;

    // Hat-Beziehung
    Hund[] hunde;

    // Methoden
    void spazieren() {
        // Rufe für jeden hund in hunde die folgende Zeile auf.
//        for (int i = 0; i < hunde.length; i++) {
//            if (hunde[i] != null) {
//                System.out.println(hashCode() + " spaziert mit " + hunde[i].hashCode());
//                hunde[i].bellen();
//            }
//        }

        for (Hund hund : hunde) {
            if (hund != null) {
                System.out.println(hashCode() + " spaziert mit " + hund.hashCode());
                hund.bellen();
            }
        }
    }

    void fuettern() {
        for (Hund hund : hunde) {
            if (hund != null) {
                System.out.println(hashCode() + " füttert " + hund.hashCode());
                hund.essen();

                hund.bellen();
                hund.bellen();
            }
        }
    }

    // Konstruktor
    Besitzer(int alter, Hund ersteHund, Hund zweiterHund) {
        _capacity = 5;

        // hier muss ich noch was mit hunde machen!
        hunde = new Hund[_capacity];
        hunde[0] = ersteHund;
        hunde[1] = zweiterHund;

        if (alter > 18) {
            _alter = alter;

        } else {
            _alter = 18;
            System.out.println("Das Alter wurde automatisch auf 18 gesetzt, da es nicht geringer sein darf.");
        }
    }
}
