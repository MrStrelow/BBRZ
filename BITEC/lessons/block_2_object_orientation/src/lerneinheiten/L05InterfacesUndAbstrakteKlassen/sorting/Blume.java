package lerneinheiten.L05InterfacesUndAbstrakteKlassen.sorting;

public class Blume implements Comparable<Blume> {
    public int hoehe;
    public int breite;

    public Blume(int hoehe, int breite) {
        this.hoehe = hoehe;
        this.breite = breite;
    }

    @Override
    public int compareTo(Blume blume) {
        if(hoehe > blume.hoehe) {
            return 1;
        } else if (hoehe < blume.hoehe) {
            return -1;
        } else {
            return 0;
        }
    }

    @Override
    public String toString() {
        return "h:" + hoehe;
    }
}
