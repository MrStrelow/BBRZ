package AbstractClassesUndInterfaces.schnittstellen.impl;

import AbstractClassesUndInterfaces.schnittstellen.interfaces.Strukturierbar;

public class Dreieck extends Form implements Strukturierbar {
    // Felder
    Orientierung orientierung;

    // hat-Beziehungen

    // Konstruktor

    public Dreieck(int hoehe, int breite, String background, String filler, Orientierung orientierung) {
        super(hoehe, breite, background, filler);
        this.orientierung = orientierung;

        this.generiereForm();
    }

    public Dreieck(Dreieck basis, Orientierung orientierung) {
        super(basis);
        this.orientierung = orientierung;

        this.generiereForm();
    }

    @Override
    public Form generiereForm() {
        for (int i = 0; i < hoehe; i++) {
            for (int j = 0; j <= i; j++) {
                feld[i][j] = filler;
            }
        }

        // Warum hier keine Ist-Beziehung? dann ersparen wir uns dieses switch mit der orientierung?
        // Antwort: es kann beides sinnvoll sein. Wir gehen aber davon aus, dass ein Dreieck nicht nur in 90° Orten einen rechten winkel hat.
        // Wie implementieren wir aber einen beliebigen rechten winkel? Das haben wir auch hier nicht gemacht, mit dem enum Orientierung.
        // Jedoch soll das hier als Denkanstoß dafür dienen.
        switch (orientierung) {
            case TOP_LEFT  -> this.spiegelnX();
            case TOP_RIGHT -> this.spiegelnX().spiegelnY();
//            case TOP_RIGHT -> this.spiegelnX().transponieren(); // Warum geht das nicht? Hinweis: werde ich selber verändert oder wird ein neues Objekt verändert?
            case BOT_RIGHT -> this.spiegelnY();
        }

        return this;
    }

    // Methoden
    // get-set Methoden

    // Innere "Klasse"
    public static enum Orientierung {
        // Rechter winkel zeigt wohin?
        TOP_RIGHT, TOP_LEFT, BOT_RIGHT, BOT_LEFT
    }
}
