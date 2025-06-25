package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.sql.Array;
import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;

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

    void print() {
        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                System.out.print(_plane[zeilen][spalten]);
            }
            System.out.println();
        }
    }

    // Konstruktor
    Plane(int size) {
        // felder initialisieren
        _size = size;
        _plane = new String[_size][_size];

        // * Darstellung der Plane (String[][]) mit dem earthsymbol auf allen stellen belegen
        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                _plane[zeilen][spalten] = _earthRepresentation;
            }
        }

        // ein wenig logik:
        // * Hamster mit zufälliger Anzahl erstellen
        Random random = new Random();
        int numberOfHamsters = random.nextInt( 1, _size * _size);

        for (int i = 0; i < numberOfHamsters; i++) {
            // * diese der Liste hinzufügen
            _hamsters.add(new Hamster());
        }

        // * Seedlings mit zufälliger Anzahl erstellen
        int freiePlaetze = _size * _size - numberOfHamsters + 1;
        int numberOfSeedlings = random.nextInt(1, freiePlaetze);

        for (int i = 0; i < numberOfSeedlings; i++) {
            // * diese der Liste hinzufügen
            _seedlings.add(new Seedling());
        }

        System.out.println(_size*_size);
        System.out.println(_hamsters.size());
        System.out.println(_seedlings.size());
    }
}


