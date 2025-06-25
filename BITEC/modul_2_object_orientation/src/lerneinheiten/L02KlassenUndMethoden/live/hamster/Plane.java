package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.sql.Array;
import java.util.ArrayList;
import java.util.Random;

public class Plane {
    // Felder ("globale"-Variable)
    int _size;
    String _earthRepresentation = "🟫";

    // Hat-Beziehungen
    ArrayList<Hamster> _hamsters = new ArrayList<>();
    ArrayList<Seedling> _seedlings = new ArrayList<>();
    // -----------------------------
    // Methoden
    // Konstruktor
    Plane(int size) {
        _size = size;
    }
}


