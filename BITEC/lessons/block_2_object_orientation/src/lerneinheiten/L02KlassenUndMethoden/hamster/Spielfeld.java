package lerneinheiten.L02KlassenUndMethoden.hamster;

import java.util.*;

public class Spielfeld {
    // Felder
    private String[][] spielfeld;
    private int groesse;
    private static String bodenSymbol = "🟫";

    // (hat) Beziehungen
    private Map<Tuple<Integer, Integer>, Samen> samen = new HashMap<>();
    private List<Hamster> hamster = new ArrayList<>();

    // Konstruktor
    public Spielfeld(int groesse) {
        Random random = new Random();
        this.groesse = groesse;
        spielfeld = new String[groesse][groesse];

        // wir belegen das spielfeld mit Bodensymbole
        for (int i = 0; i < groesse; i++) {
            for (int j = 0; j < groesse; j++) {
                spielfeld[i][j] = bodenSymbol;
            }
        }

        // wir brauchen Samen
        int anzahlSamen = random.nextInt(1, groesse * groesse);
        for (int i = 0; i < anzahlSamen; i++) {
            new Samen(this);
        }

        // wir brauchen Hamster
        int anzahlHamster = random.nextInt(1, groesse * groesse - anzahlSamen + 1);
        for (int i = 0; i < anzahlHamster; i++) {
            new Hamster(this);
        }
    }

    // Methoden
    public void simulateSamen() {
        nachwachsen();
    }

    public void simulateHamster() {
        for (var hamster : hamster) {
            hamster.bewegen();
            hamster.nahrungsVerhalten();
        }
    }

    public void printSpielfeld() {
        for (int i = 0; i < groesse; i++) {
            for (int j = 0; j < groesse; j++) {
                System.out.print(spielfeld[i][j]);
            }
            System.out.println();
        }
    }

    public void bewegeHamster(Hamster hamster, Richtung richtung) {
        spielfeld[hamster.getY()][hamster.getX()] = hamster.getFeldZumMerken();

        switch (richtung) {
            case OBEN -> {
                if (hamster.getY() > 0) {
                    hamster.setY(hamster.getY() - 1);
                }
            }
            case UNTEN -> {
                if (hamster.getY() < groesse - 1) {
                    hamster.setY(hamster.getY() + 1);
                }
            }
            case LINKS -> {
                if (hamster.getX() > 0) {
                    hamster.setX(hamster.getX() - 1);
                }
            }
            case RECHTS -> {
                if (hamster.getX() < groesse - 1) {
                    hamster.setX(hamster.getX() + 1);
                }
            }
        }

        String hamsterSymbol = spielfeld[hamster.getY()][hamster.getX()];
        boolean keinHamsterAufDemFeld =
                hamsterSymbol.equals(Hamster.getNormaleDarstellung()) ||
                hamsterSymbol.equals(Hamster.getHungrigeDarstellung());

        if (!keinHamsterAufDemFeld) {
            hamster.setFeldZumMerken(spielfeld[hamster.getY()][hamster.getX()]);
        }

        spielfeld[hamster.getY()][hamster.getX()] = hamster.getDarstellung();
    }

    public void hamsterIsstSamen(Hamster hamster) {
        samen.remove(new Tuple<>(hamster.getX(), hamster.getY()));

        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.setFeldZumMerken(bodenSymbol);
    }

    public void hamsterHamstertSamen(Hamster hamster) {
        samen.remove(new Tuple<>(hamster.getX(), hamster.getY()));

        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.setFeldZumMerken(bodenSymbol);
    }

    public void nachwachsen() {
        Random random = new Random();
        int x, y;
        boolean istFeldFrei;
        Tuple<Integer, Integer> key;

        int potentialGrowth = hamster.size() / samen.size();
        int freeTiles = groesse * groesse - hamster.size() - samen.size(); //not considering stacked hamsters

        int bound = Math.min(potentialGrowth, freeTiles);

        for (int i = 0; i < bound; i++) {
            do {
                x = random.nextInt(groesse);
                y = random.nextInt(groesse);
                key = new Tuple<>(x,y);

                istFeldFrei = samen.get(key) == null && !istHamsterAmFeld(key);

            } while (istFeldFrei);

            samen.put(key, new Samen(this));
            spielfeld[y][x] = Samen.getDarstellung();
        }

    }

    public boolean weiseHamsterZu(Hamster zuPlatzieren, Tuple<Integer, Integer> key) {
        boolean istFeldFrei = samen.get(key) == null && !istHamsterAmFeld(key);

        if (istFeldFrei) {
            spielfeld[key.getY()][key.getX()] = zuPlatzieren.getDarstellung();
            hamster.add(zuPlatzieren);
        }

        return istFeldFrei;
    }

    private boolean istHamsterAmFeld(Tuple<Integer, Integer> key) {
        boolean istAmFeld = false;

        for (var hamster : hamster) {
            if(hamster.getPosition().equals(key)) {
                istAmFeld = true;
                break;
            }
        }

        return istAmFeld;
    }

    public boolean weiseSamenZu(Samen zuPlatzieren, Tuple<Integer, Integer> key) {
        boolean istFeldFrei = samen.get(key) == null && !istHamsterAmFeld(key);

        if (istFeldFrei) {
            spielfeld[key.getY()][key.getX()] = Samen.getDarstellung();
            samen.put(key, zuPlatzieren);
        }

        return istFeldFrei;
    }


    // get-set Methoden
    public Samen getSamen(Tuple<Integer, Integer> key) {
        return samen.get(key);
    }

    public int getGroesse() {
        return groesse;
    }

    public static String getBodenSymbol() {
        return bodenSymbol;
    }
}
