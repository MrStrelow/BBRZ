package lerneinheiten.L09SchleifenFor.live;

public class Dreieck {
    // EIGENSCHAFTEN - Wer bin ich?
    private String _foreground;
    private String _background;
    private String[][] _darstellung;
    private int _size;

    // METHODEN
    // * Konstruktor - keinen Rückgabe-Typ
    public Dreieck(String foreground, String background, int size) {
        _foreground = foreground;
        _background = background;
        _size = size;

        _darstellung = new String[_size][_size];

        createTriangle();
    }

    // * Methoden - Was mach ich?
    // Zuständigkeit: gib das 2D-Array (Eingangs-Parameter) auf der console aus. gib nichts zurück (Rückgabe-Parameter).
    public void printForm() {
        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < _darstellung.length; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < _darstellung[0].length; spalte++) {
                System.out.print(_darstellung[zeile][spalte]);
            }
            System.out.println();
        }
    }

    // Zuständigkeit: generiere die form "dreieck".
    //
    private void createTriangle() {
        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < _size; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < _size; spalte++) {
                // Zuständigkeiten: wann wird ein symbol ausgegeben für unser dreieck?
                if (zeile >= spalte) {
                    _darstellung[zeile][spalte] = _foreground; // mit windows und punkt kann ein emoji menü aufgerufen werden.
                } else {
                    _darstellung[zeile][spalte] = _background;
                }
            }
        }
    }

    // Zuständigkeit: drehen ein beliebiges 2D-String-Array 90°, 180° oder 270° nach rechts.
    private void drehenRechts() {
        mirrorY();
        transponieren();
    }

    private void drehenLinks() {
        mirrorX();
        transponieren();
    }

    // Zuständigkeit: spielgeln in X eines 2D-String-Arrays.
    private void mirrorX() {
        String[][] mirrored = new String[_size][_size];

        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < _size; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < _darstellung[0].length; spalte++) {
                mirrored[_size - 1 - zeile][spalte] = _darstellung[zeile][spalte];
            }
        }

        _darstellung = mirrored;
    }

    // Zuständigkeit: spielgeln in Y eines 2D-String-Arrays.
    private void mirrorY() {
        String[][] mirrored = new String[_size][_size];

        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < _size; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < _darstellung[0].length; spalte++) {
                mirrored[zeile][_size - 1 - spalte] = _darstellung[zeile][spalte];
            }
        }

        _darstellung = mirrored;
    }

    // Zuständigkeit:  vertausche x und y koordinaten eines 2D-Arrays.
    private void transponieren() {
        String[][] transposed = new String[_size][_size];

        // Zuständigkeiten: wie viele zeilen soll es geben?
        for (int zeile = 0; zeile < _size; zeile++) {
            // Zuständigkeiten: wie viele spalten soll es geben?
            for (int spalte = 0; spalte < _size; spalte++) {
                transposed[spalte][zeile] = _darstellung[zeile][spalte];
            }
        }

        _darstellung = transposed;
    }

    // Zuständigkeit: Der user soll angeben in welche Richtung und wie weit das 2D-Array gedreht werden soll.
    public Dreieck drehen(Richtung richtung, Winkel winkel) {
        switch (richtung) {
            case RECHTS -> {
                switch (winkel) {
                    case d90 -> {
                        drehenRechts();
                    }
                    case d180 -> {
                        drehenRechts();
                        drehenRechts();
                    }
                    case d270 -> {
                        drehenRechts();
                        drehenRechts();
                        drehenRechts();
                    }
                }
            }
            case LINKS -> {
                switch (winkel) {
                    case d90 -> {
                        drehenLinks();
                    }
                    case d180 -> {
                        drehenLinks();
                        drehenLinks();
                    }
                    case d270 -> {
                        drehenLinks();
                        drehenLinks();
                        drehenLinks();
                    }
                }
            }
        }

        return this;
    }
}
