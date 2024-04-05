package hemstr;

import java.util.Random;

public class Spielfeld {
    // Attribute
    private String[][] spielfeld;
    private String bodenSymbol = "🟫";
    private String samenSymbol = "🌱";
    private String hamsterSymbol = "🐹"; //Character.toString( 58660 );
    private int groesse = 5;

    // hat-Relationen
    private Samen[] samen;
    private Hamster[] hamsters;

    // Konstruktor

    public Spielfeld() {
        // hier ist die Logik der Darstellung drinnen
        spielfeld = new String[groesse][groesse];

        // spielfeld mit leerzeichen befüllen
        for (int i = 0; i < groesse; i++) {
            for (int j = 0; j < groesse; j++) {
                spielfeld[i][j] = bodenSymbol;
            }
        }

        // hier ist Logik ohne spezielle Darstellung vorhanden.
        // fuer Samen
        samen = new Samen[groesse*groesse-1];

        Random random = new Random();
        Integer anzahlSamen = random.nextInt(1, groesse * groesse - 1);

        for (int i = 0; i < anzahlSamen; i++) {
            samen[i] = new Samen(this);
        }

        // fuer Hamster
        hamsters = new Hamster[groesse*groesse-1];

        Integer anzahlHamster = random.nextInt(1, groesse * groesse - anzahlSamen);

        for (int i = 0; i < anzahlHamster; i++) {
            hamsters[i] = new Hamster(this);
        }
    }


    // methoden
    public void weiseSamenZu(Samen samen) {
        Random random = new Random();
        int x = random.nextInt(groesse);
        int y = random.nextInt(groesse);

        if(spielfeld[y][x].equals(bodenSymbol)){
            samen.setX(x);
            samen.setY(y);

            spielfeld[y][x] = samenSymbol;
        } else {

            // rekursion!!! wenns spielfeld bereits voll ist, probiers nocheinmal.
            weiseSamenZu(samen);

        }
    }

    public void weiseHamsterZu(Hamster hamster) {
        Random random = new Random();
        int x = random.nextInt(groesse);
        int y = random.nextInt(groesse);

        if(spielfeld[y][x].equals(bodenSymbol)){
            hamster.setX(x);
            hamster.setY(y);

            spielfeld[y][x] = hamsterSymbol;
        } else {

            // rekursion!!! wenns spielfeld bereits voll ist, probiers nocheinmal.
            weiseHamsterZu(hamster);

        }
    }

    public void bewegeHamster(Hamster hamster, Richtung richtung) {
        switch (richtung) {
            case rechts -> {
                if(groesse-1 != hamster.getX()) {
                    spielfeld[hamster.getY()][hamster.getX()] = hamster.getFeldZumMerken();
                    hamster.setX(hamster.getX() + 1);
                    hamster.setFeldZumMerken( spielfeld[hamster.getY()][hamster.getX()] );
                    spielfeld[hamster.getY()][hamster.getX()] = hamsterSymbol;
                }
            }
            case links -> {
                if(0 != hamster.getX()) {
                    spielfeld[hamster.getY()][hamster.getX()] = hamster.getFeldZumMerken();
                    hamster.setX(hamster.getX() - 1);
                    hamster.setFeldZumMerken( spielfeld[hamster.getY()][hamster.getX()] );
                    spielfeld[hamster.getY()][hamster.getX()] = hamsterSymbol;
                }
            }
            case oben -> {
                if(0 != hamster.getY()) {
                    spielfeld[hamster.getY()][hamster.getX()] = hamster.getFeldZumMerken();
                    hamster.setY(hamster.getY() - 1);
                    hamster.setFeldZumMerken( spielfeld[hamster.getY()][hamster.getX()] );
                    spielfeld[hamster.getY()][hamster.getX()] = hamsterSymbol;
                }
            }
            case unten -> {
                if(groesse-1 != hamster.getY()) {
                    spielfeld[hamster.getY()][hamster.getX()] = hamster.getFeldZumMerken();
                    hamster.setY(hamster.getY() + 1);
                    hamster.setFeldZumMerken( spielfeld[hamster.getY()][hamster.getX()] );
                    spielfeld[hamster.getY()][hamster.getX()] = hamsterSymbol;
                }
            }
        };
    }


    public void hamsterIsstSamen(Hamster hamster) {
        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.setFeldZumMerken(bodenSymbol);
    }



    public void printSpielfeld() {
        for (int i = 0; i < groesse; i++) {
            for (int j = 0; j < groesse; j++) {
                System.out.print(spielfeld[i][j]);
            }
            System.out.println();
        }
    }

    // getter-setter


    public Hamster[] getHamsters() {
        return hamsters;
    }

    public void setHamsters(Hamster[] hamsters) {
        this.hamsters = hamsters;
    }

    public String getBodenSymbol() {
        return bodenSymbol;
    }

    public String getHamsterSymbol() {
        return hamsterSymbol;
    }

    public String getSamenSymbol() {
        return samenSymbol;
    }

    public Samen[] getSamen() {
        return samen;
    }
}
