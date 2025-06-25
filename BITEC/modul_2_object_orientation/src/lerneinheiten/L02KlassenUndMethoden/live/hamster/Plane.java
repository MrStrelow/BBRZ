package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.sql.Array;
import java.util.ArrayList;
import java.util.Random;

public class Plane {
    // Felder ("globale"-Variable)
    int _size;
    String _earthRepresentation = "🟫";
    String[][] _plane;

    // Hat-Beziehungen
    ArrayList<Hamster> _hamsters = new ArrayList<>();
    ArrayList<Seedling> _seedlings = new ArrayList<>();
    // -----------------------------
    // Methoden
    void simulateHamster() {

    }

    void simulateSeedling() {

    }

    // Konstruktor
    Plane(int size) {
        // felder initialisieren
        _size = size;
        _plane = new String[_size][_size];

        // ein wenig logik:
        // * Darstellung der Plane (String[][]) mit dem earthsymbol auf allen stellen belegen

        // * Hamster mit zufälliger Anzahl erstellen
        // * diese der Liste hinzufügen

        // * Seedlings mit zufälliger Anzahl erstellen
        // * diese der Liste hinzufügen
    }
}


