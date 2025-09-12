package lerneinheiten.L02KlassenUndMethoden.hamster;

import java.util.ArrayList;
import java.util.Random;

class Plane {
    // Felder ("globale"-Variable)
    final int _size;
    // lesezugriff

    static String _earthRepresentation = "🟫";
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
            hamster.nahrungsVerhalten();
        }
    }

    Seedling getSeedlingOn(int x, int y) {
        for (Seedling seedlingAusListe : _seedlings) {
            if (seedlingAusListe._xPosition == x && seedlingAusListe._yPosition == y) {
                return seedlingAusListe;
            }
        }

        return null;
    }

    /***
     da kann ich beschreiben was meine methode macht.
     */
    void simulateSeedling() {
        // nachwachsen
        // 1. genug seedling sollen erzeuget werden um alle hamster zu füttern.
        int freieFelder = _size * _size - _hamsters.size() - _seedlings.size();

        for (int i = 0; i < freieFelder; i++) {
            _seedlings.add(new Seedling(this));
        }
    }

    // Nimm den Wunsch EINES Hamster entgegen und überprüfe, ob diese Bewegung möglich ist.
    void bewegeHamster(Hamster hamster, Direction wunschDirection) {
        // ist bewegung des hamster gültig? was heist das?
        // bitte nicht verwenden -> grafische darstellung soll nicht für zustandslogik verwendet werden.
//        _planeDarstellung[hamster.yPosition][hamster.xPosition] = hamster.feldZuMerken;

        // switch mit allen richtungen
        switch (wunschDirection) {
            // case oben
            case OBEN -> {
            //      was mach ich in diesem case? kann ich nach oben gehen?
            //      wenn ja, dann mach es.
                if (hamster._yPosition > 0) {
                    hamster._yPosition--;
                }

            }
            // case unten
            case UNTEN -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster._yPosition < _size - 1) {
                    hamster._yPosition++;
                }

            }
            // gehe links
            case LINKS -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster._xPosition > 0) {
                    hamster._xPosition--;
                }
            }
            // gehe rechts
            case RECHTS -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster._xPosition < _size - 1) {
                    hamster._xPosition++;
                }
            }
        }

        // bitte nicht verwenden -> grafische darstellung soll nicht für zustandslogik verwendet werden.
//        hamster.feldZuMerken = _planeDarstellung[hamster.yPosition][hamster.xPosition];
        _planeDarstellung[hamster._yPosition][hamster._xPosition] = hamster._representation;
    }

    void print() {
        resetDarstellung();

        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                System.out.print(_planeDarstellung[zeilen][spalten]);
            }
            System.out.println();
        }
    }

    void resetDarstellung() {
        // alles ist erde
        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                _planeDarstellung[zeilen][spalten] = _earthRepresentation;
            }
        }

        // male seedlings neu hin
        for (Seedling seedling : _seedlings) {
            _planeDarstellung[seedling._yPosition][seedling._xPosition] = Seedling._representation;
        }

        // male hamster neu hin
        for (Hamster hamster : _hamsters) {
            _planeDarstellung[hamster._yPosition][hamster._xPosition] = hamster._representation;
        }
    }

    boolean assignInitialPosition(Hamster hamster, int xWunsch, int yWunsch) {
        if (!tileTakenByHamster(xWunsch, yWunsch) && !tileTakenBySeedling(xWunsch, yWunsch)) {
            _planeDarstellung[xWunsch][yWunsch] = hamster._representation;

            return true;
        }

        return false;
    }

    boolean assignInitialPosition(Seedling seedling, int xWunsch, int yWunsch) {
        if (!tileTakenByHamster(xWunsch, yWunsch) && !tileTakenBySeedling(xWunsch, yWunsch)) {
            _planeDarstellung[xWunsch][yWunsch] = Seedling._representation;

            return true;
        }

        return false;
    }

    boolean tileTakenByHamster(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Hamstern? (gleiche Position).
        for (Hamster hamsterAusListe : _hamsters) {
            if (hamsterAusListe._xPosition == xWunsch && hamsterAusListe._yPosition == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    boolean tileTakenBySeedling(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Seedlings? (gleiche Position).
        for (Seedling seedlingAusListe : _seedlings) {
            if (seedlingAusListe._xPosition == xWunsch && seedlingAusListe._yPosition == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    void hamsterIsEatingSeedlings(Hamster hamster) {
        for (int i = 0; i < _seedlings.size(); i++) {
            if(_seedlings.get(i)._xPosition == hamster._xPosition && _seedlings.get(i)._yPosition == hamster._yPosition) {
                _seedlings.remove(i);
                break; // Wir haben die Liste nun verändert. Wir brechen ab.
            }
        }

        // was passiert, wenn kein Seedling am Feld ist?
    }

    void hamsterIsStoringSeedlings(Hamster hamster) {
        hamsterIsEatingSeedlings(hamster);
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


