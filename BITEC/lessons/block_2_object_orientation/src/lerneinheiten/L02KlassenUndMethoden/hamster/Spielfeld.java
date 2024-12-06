package lerneinheiten.L02KlassenUndMethoden.hamster;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Spielfeld {
    // Attribute
    private String[][] spielfeld;
    private String bodenSymbol = "🟫";
    private int groesse = 5;

    // hat-Relationen
    private List<Samen> samen;
    private List<Hamster> hamsters;

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
        samen = new ArrayList<>();

        Random random = new Random();
        Integer anzahlSamen = random.nextInt(1, groesse * groesse - 1);

        for (int i = 0; i < anzahlSamen; i++) {
            samen.add(new Samen(this));
        }

        // fuer Hamster
        hamsters = new ArrayList<>();

        Integer anzahlHamster = random.nextInt(1, groesse * groesse - anzahlSamen + 1);

        for (int i = 0; i < anzahlHamster; i++) {
            hamsters.add(new Hamster(this));
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

            spielfeld[y][x] = Samen.getSamenSymbol();
        } else {

            // rekursion!!! wenns spielfeld bereits voll ist, probiers nocheinmal.
            weiseSamenZu(samen);

        }
    }

    public void weiseHamsterZu(Hamster hamster) {
        int x = hamster.getX();
        int y = hamster.getY();
        Random random = new Random();

        do {
            x = random.nextInt(groesse);
            y = random.nextInt(groesse);
        } while (!spielfeld[y][x].equals(bodenSymbol));

        spielfeld[y][x] = Samen.getSamenSymbol();
    }


    public void bewegeHamster(Hamster hamster, Richtung richtung) {
        // setze vorheriges Feld auf das Feld welches ich bald verlassen werde
        if (hamster.getFeldZumMerken() != null) {
            spielfeld[hamster.getY()][hamster.getX()] = hamster.getFeldZumMerken();
        }

        // ich bewege mich
        switch (richtung) {
            case rechts -> {
                if(groesse-1 != hamster.getX()) {
                    hamster.setX(hamster.getX() + 1);
                }
            }
            case links -> {
                if(0 != hamster.getX()) {
                    hamster.setX(hamster.getX() - 1);
                }
            }
            case oben -> {
                if(0 != hamster.getY()) {
                    hamster.setY(hamster.getY() - 1);
                }
            }
            case unten -> {
                if(groesse-1 != hamster.getY()) {
                    hamster.setY(hamster.getY() + 1);
                }
            }
        }

        // ist das neue Feld, auf das ich gehe ein Hamster?
        String hamsterSymbol = spielfeld[hamster.getY()][hamster.getX()];

        // wenn es kein Hamster ist, merke es dir
        // wenn es ein Hamster ist, vergiss dein gemerktes feld
        boolean keinHamsterAufDemFeld = hamsterSymbol.equals(hamster.getDarstellung());

        if (!keinHamsterAufDemFeld) {
            hamster.setFeldZumMerken(spielfeld[hamster.getY()][hamster.getX()]);
        }

        spielfeld[hamster.getY()][hamster.getX()] = hamster.getDarstellung();
    }


    public void hamsterIsstSamen(Hamster hamster) {
        for (Samen s : samen) {

            boolean hamsterStehtDrauf = hamster.getX().equals(s.getX()) && hamster.getY().equals(s.getY());

            if (hamsterStehtDrauf) {
                samen.remove(s);
                break;
            }
        }

        // symbol im spielfeld wird überschrieben mit dem standard symbol (boden)
        hamster.setFeldZumMerken(bodenSymbol);
    }

    public void hamsterHamstertSamen(Hamster hamster) {
        // wir wollen hier den backenspeicher mit einem essen befüllen
        for (Samen s : samen) {

            boolean hamsterStehtDrauf = hamster.getX().equals(s.getX()) && hamster.getY().equals(s.getY());

            if (hamsterStehtDrauf) {
                hamster.getBackenSpeicher().add(s);
                samen.remove(s);
                break;
            }
        }

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
    public List<Hamster> getHamsters() {
        return hamsters;
    }

    public String getBodenSymbol() {
        return bodenSymbol;
    }

    public List<Samen> getSamen() {
        return samen;
    }
}
