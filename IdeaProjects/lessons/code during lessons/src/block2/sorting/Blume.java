package block2.sorting;

public class Blume implements Comparable {
    public int hoehe;
    public int breite;

    public Blume(int hoehe, int breite) {
        this.hoehe = hoehe;
        this.breite = breite;
    }

    @Override
    public int compareTo(Object o) {
        if(hoehe > ((Blume) o).hoehe) {
            return 1;
        } else if (hoehe < ((Blume) o).hoehe) {
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
