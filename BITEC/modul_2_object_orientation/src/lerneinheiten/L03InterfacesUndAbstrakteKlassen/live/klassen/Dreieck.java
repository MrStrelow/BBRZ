package lerneinheiten.L05InterfacesUndAbstrakteKlassen.live.klassen;

import lerneinheiten.L05InterfacesUndAbstrakteKlassen.live.klassen.Form;

public class Dreieck extends Form {

    // Feld
    private Direction orientation;
    // Hat-Beziehung
    // Methode
    public Form generateForm() {
        for (int zeilen = 0; zeilen < breite; zeilen++) {
            for (int spalten = 0; spalten < hoehe; spalten++) {
                if (spalten <= zeilen) {
                    darstellung[zeilen][spalten] = foreground;
                }
            }
        }

        switch (orientation) {
            case BOT_LEFT -> spiegelnX();
            case BOT_RIGHT -> spiegelnY();
            case TOP_RIGHT -> spiegelnX().spiegelnY();
        }

        return this;
    }
    // Konstruktor
    // Get- Set-Methoden
}
