package lerneinheiten.L02KlassenUndMethoden.live.hamster;

import java.util.ArrayList;
import java.util.Random;

public class Plane {
    // Felder ("globale"-Variable)
    private final int _size;
    // lesezugriff

    private static String _earthRepresentation = "🟫";
    private String[][] _planeDarstellung;

    // Hat-Beziehungen
    private ArrayList<Hamster> _hamsters = new ArrayList<>();
    private ArrayList<Seedling> _seedlings = new ArrayList<>();
    // -----------------------------
    // Methoden
    public void simulateHamster() {
        for (Hamster hamster : _hamsters) {
            // bewegen
            hamster.bewegen();

            // essen
            hamster.nahrungsVerhalten();
        }
    }

    public Seedling getSeedlingOnPosition(int x, int y) {
        for (Seedling seedlingAusListe : _seedlings) {
            if (seedlingAusListe.xPosition == x && seedlingAusListe.yPosition == y) {
                return seedlingAusListe;
            }
        }

        return null;
    }

    /***
     da kann ich beschreiben was meine methode macht.
     */
    public void simulateSeedling() {
        // nachwachsen
        // 1. genug seedling sollen erzeuget werden um alle hamster zu füttern.
        int freieFelder = _size * _size - _hamsters.size() - _seedlings.size();

        for (int i = 0; i < freieFelder; i++) {
            _seedlings.add(new Seedling(this));
        }
    }

    // Nimm den Wunsch EINES Hamster entgegen und überprüfe, ob diese Bewegung möglich ist.
    public void bewegeHamster(Hamster hamster, Richtung wunschRichtung) {
        // ist bewegung des hamster gültig? was heist das?
        // bitte nicht verwenden -> grafische darstellung soll nicht für zustandslogik verwendet werden.
//        _planeDarstellung[hamster.yPosition][hamster.xPosition] = hamster.feldZuMerken;

        // switch mit allen richtungen
        switch (wunschRichtung) {
            // case oben
            case OBEN -> {
            //      was mach ich in diesem case? kann ich nach oben gehen?
            //      wenn ja, dann mach es.
                if (hamster.yPosition > 0) {
                    hamster.yPosition--;
                }

            }
            // case unten
            case UNTEN -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster.yPosition < _size - 1) {
                    hamster.yPosition++;
                }

            }
            // gehe links
            case LINKS -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster.xPosition > 0) {
                    hamster.xPosition--;
                }
            }
            // gehe rechts
            case RECHTS -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster.xPosition < _size - 1) {
                    hamster.xPosition++;
                }
            }
        }

        // bitte nicht verwenden -> grafische darstellung soll nicht für zustandslogik verwendet werden.
//        hamster.feldZuMerken = _planeDarstellung[hamster.yPosition][hamster.xPosition];
        _planeDarstellung[hamster.yPosition][hamster.xPosition] = hamster._representation;
    }

    public void print() {
        resetDarstellung();

        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                System.out.print(_planeDarstellung[zeilen][spalten]);
            }
            System.out.println();
        }
    }

    public void resetDarstellung() {
        // alles ist erde
        for (int zeilen = 0; zeilen < _size; zeilen++) {
            for (int spalten = 0; spalten < _size; spalten++) {
                _planeDarstellung[zeilen][spalten] = _earthRepresentation;
            }
        }

        // male seedlings neu hin
        for (Seedling seedling : _seedlings) {
            _planeDarstellung[seedling.yPosition][seedling.xPosition] = Seedling._representation;
        }

        // male hamster neu hin
        for (Hamster hamster : _hamsters) {
            _planeDarstellung[hamster.yPosition][hamster.xPosition] = hamster._representation;
        }
    }

    public boolean assignInitialPosition(Hamster hamster, int xWunsch, int yWunsch) {
        if (!tileTakenByHamster(xWunsch, yWunsch) && !tileTakenBySeedling(xWunsch, yWunsch)) {
            _planeDarstellung[xWunsch][yWunsch] = hamster._representation;

            return true;
        }

        return false;
    }

    public boolean assignInitialPosition(Seedling seedling, int xWunsch, int yWunsch) {
        if (!tileTakenByHamster(xWunsch, yWunsch) && !tileTakenBySeedling(xWunsch, yWunsch)) {
            _planeDarstellung[xWunsch][yWunsch] = Seedling._representation;

            return true;
        }

        return false;
    }

    private boolean tileTakenByHamster(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Hamstern? (gleiche Position).
        for (Hamster hamsterAusListe : _hamsters) {
            if (hamsterAusListe.xPosition == xWunsch && hamsterAusListe.yPosition == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    // TODO: private machen und für den hamster eine neue methode in der Plane schreiben
    public boolean tileTakenBySeedling(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Seedlings? (gleiche Position).
        for (Seedling seedlingAusListe : _seedlings) {
            if (seedlingAusListe.xPosition == xWunsch && seedlingAusListe.yPosition == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    // Konstruktor
    public Plane(int size) {
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

    // Get-Set Methoden
    public int getSize() {
        return _size;
    }

    // schreibzugriff
//    public void setSize(int size) {
//        if (size < 0) {
//            System.out.println("Fehler! hat nicht funktionier da negativ.");
//            return;
//        }
//        _size = size;
//    }

    public static String getEarthRepresentation() {
        return _earthRepresentation;
    }

    public String[][] getPlaneDarstellung() {
        return _planeDarstellung;
    }

    public ArrayList<Hamster> getHamsters() {
        return _hamsters;
    }

    public ArrayList<Seedling> getSeedlings() {
        return _seedlings;
    }
}


