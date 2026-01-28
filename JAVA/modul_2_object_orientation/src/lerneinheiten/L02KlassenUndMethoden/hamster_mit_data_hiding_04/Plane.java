package lerneinheiten.L02KlassenUndMethoden.hamster_mit_data_hiding_04;

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

    public Seedling getSeedlingOn(int x, int y) {
        for (Seedling seedlingAusListe : _seedlings) {
            if (seedlingAusListe.getxPosition() == x && seedlingAusListe.getyPosition() == y) {
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
    public void bewegeHamster(Hamster hamster, Direction wunschDirection) {
        // ist bewegung des hamster gültig? was heist das?
        // bitte nicht verwenden -> grafische darstellung soll nicht für zustandslogik verwendet werden.
//        _planeDarstellung[hamster.yPosition][hamster.xPosition] = hamster.feldZuMerken;

        // switch mit allen richtungen
        switch (wunschDirection) {
            // case oben
            case OBEN -> {
            //      was mach ich in diesem case? kann ich nach oben gehen?
            //      wenn ja, dann mach es.
                if (hamster.getyPosition() > 0) {
                    hamster.setyPosition(hamster.getyPosition() - 1);
                }

            }
            // case unten
            case UNTEN -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster.getyPosition() < _size - 1) {
                    hamster.setyPosition(hamster.getyPosition() + 1);
                }

            }
            // gehe links
            case LINKS -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster.getxPosition() > 0) {
                    hamster.setxPosition(hamster.getxPosition() - 1);
                }
            }
            // gehe rechts
            case RECHTS -> {
                //      was mach ich in diesem case? kann ich nach oben gehen?
                //      wenn ja, dann mach es.
                if (hamster.getxPosition() < _size - 1) {
                    hamster.setxPosition(hamster.getxPosition() + 1);
                }
            }
        }

        _planeDarstellung[hamster.getyPosition()][hamster.getxPosition()] = hamster.getRepresentation();
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
            _planeDarstellung[seedling.getyPosition()][seedling.getxPosition()] = Seedling._representation;
        }

        // male hamster neu hin
        for (Hamster hamster : _hamsters) {
            _planeDarstellung[hamster.getyPosition()][hamster.getxPosition()] = hamster.getRepresentation();
        }
    }

    public boolean assignInitialPosition(Hamster hamster, int xWunsch, int yWunsch) {
        if (!tileTakenByHamster(xWunsch, yWunsch) && !tileTakenBySeedling(xWunsch, yWunsch)) {
            _planeDarstellung[xWunsch][yWunsch] = hamster.getRepresentation();

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

    public boolean tileTakenByHamster(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Hamstern? (gleiche Position).
        for (Hamster hamsterAusListe : _hamsters) {
            if (hamsterAusListe.getxPosition() == xWunsch && hamsterAusListe.getyPosition() == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    public boolean tileTakenBySeedling(int xWunsch, int yWunsch) {
        // Findest du ein Problem mit den Seedlings? (gleiche Position).
        for (Seedling seedlingAusListe : _seedlings) {
            if (seedlingAusListe.getxPosition() == xWunsch && seedlingAusListe.getyPosition() == yWunsch) {
                return true; // early exit: schau nicht alles in der Liste an.
            }
        }

        return false;
    }

    public void hamsterIsEatingSeedlings(Hamster hamster) {
        for (int i = 0; i < _seedlings.size(); i++) {
            if (_seedlings.get(i).getxPosition() == hamster.getxPosition() && _seedlings.get(i).getyPosition() == hamster.getyPosition()) {
                _seedlings.remove(i);
                break; // Wir haben die Liste nun verändert. Wir brechen ab.
            }
        }
    }

    public void hamsterIsStoringSeedlings(Hamster hamster) {
        hamsterIsEatingSeedlings(hamster);
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


