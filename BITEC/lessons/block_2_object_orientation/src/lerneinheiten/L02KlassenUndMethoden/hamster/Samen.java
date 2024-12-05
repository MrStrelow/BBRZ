package lerneinheiten.L02KlassenUndMethoden.hamster;

public class Samen{
    // Attribute
    private Integer x;
    private Integer y;
    private static String samenSymbol = "🌱";

    // hat-Relation
    private Spielfeld spielfeld;

    // Konstruktor {

    public Samen(Spielfeld spielfeld) {
        this.spielfeld = spielfeld;
        this.spielfeld.weiseSamenZu(this);
    }

    // methoden
    // getter-setter Methoden

    public Integer getX() {
        return x;
    }

    public void setX(Integer x) {
        this.x = x;
    }

    public Integer getY() {
        return y;
    }

    public void setY(Integer y) {
        this.y = y;
    }

    public static String getSamenSymbol() {
        return samenSymbol;
    }
}
