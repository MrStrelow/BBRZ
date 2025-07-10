package lerneinheiten.L05InterfacesUndAbstrakteKlassen.live;

public class Form {
    // Feld
    private String[][] darstellung;
    private int hoehe;
    private int breite;
    private String background;
    private String foregrond;

    // Hat-Beziehung
    // Methoden
    public String toString() {
        StringBuilder sb = new StringBuilder();

        for (int zeilen = 0; zeilen < breite; zeilen++) {
            for (int spalten = 0; spalten < hoehe; spalten++) {
                sb.append(darstellung[zeilen][spalten]);
            }
            sb.append("\n");
        }

        return sb.toString();
    }

    // Konstruktor
    // Get- Set-Methoden
}
