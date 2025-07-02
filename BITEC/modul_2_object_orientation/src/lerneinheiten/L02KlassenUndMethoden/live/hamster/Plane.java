package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.util.ArrayList;
import java.util.Random;

public class Plane {
    // Felder ("globale"-Variable)
    int _size;
    String _earthRepresentation = "🟫";
    String[][] _planeDarstellung;

    // Hat-Beziehungen
    ArrayList<Hamster> _hamsters = new ArrayList<>();
    ArrayList<Seedling> _seedlings = new ArrayList<>();
    // -----------------------------
    // Methoden
    void simulateHamster() {
        for (Hamster hamster : _hamsters) {
            // bewegen
            hamster.bewegen();

            // essen
            // TODO:
        }
    }

    void simulateSeedling() {

    }

    // Nimm den Wunsch EINES Hamster entgegen und überprüfe, ob diese Bewegung möglich ist.
    void bewegeHamster() {

    }

    void print() {
        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                System.out.print(_planeDarstellung[zeilen][spalten]);
            }
            System.out.println();
        }
    }

    boolean AssignInitialPosition(Hamster hamster, int xWunsch, int yWunsch) {
        if (!TileTakenByHamster(xWunsch, yWunsch) && !TileTakenBySeedling(xWunsch, yWunsch)) {
            _planeDarstellung[xWunsch][yWunsch] = hamster._representation;

            return true;
        }

        return false;
    }

    boolean AssignInitialPosition(Seedling seedling, int xWunsch, int yWunsch) {
        if (!TileTakenByHamster(xWunsch, yWunsch) && !TileTakenBySeedling(xWunsch, yWunsch)) {
            _planeDarstellung[xWunsch][yWunsch] = Seedling._representation;

            return true;
        }

        return false;
    }

    boolean TileTakenByHamster(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Hamstern? (gleiche Position).
        for (Hamster hamsterAusListe : _hamsters) {
            if (hamsterAusListe.xPosition == xWunsch && hamsterAusListe.yPosition == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    boolean TileTakenBySeedling(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Seedlings? (gleiche Position).
        for (Seedling seedlingAusListe : _seedlings) {
            if (seedlingAusListe.xPosition == xWunsch && seedlingAusListe.yPosition == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    // Konstruktor
    Plane(int size) {
        // felder initialisieren
        _size = size;
        _planeDarstellung = new String[_size][_size];

        // * Darstellung der Plane (String[][]) mit dem earthsymbol auf allen stellen belegen
        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                _planeDarstellung[zeilen][spalten] = _earthRepresentation;
            }
        }

        // ein wenig logik:
        // * Hamster mit zufälliger Anzahl erstellen
        Random random = new Random();
        int numberOfHamsters = random.nextInt( 1, _size * _size);

        for (int i = 0; i < numberOfHamsters; i++) {
            // * diese der Liste hinzufügen
            _hamsters.add(new Hamster(this)); // Wir brauchen this! Ohne dem geht das nicht.
        }

        // * Seedlings mit zufälliger Anzahl erstellen
        int freiePlaetze = _size * _size - numberOfHamsters + 1;
        int numberOfSeedlings = random.nextInt(1, freiePlaetze);

        for (int i = 0; i < numberOfSeedlings; i++) {
            // * diese der Liste hinzufügen
            _seedlings.add(new Seedling(this));
        }
    }
}


