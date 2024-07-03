package block2.Klassen;

public class Hund {
    // attribute sind meistens privat. nicht von außen veränderbar
    // attribute werden über methoden verändert! deshalb private
    private Integer alter;
    private Double health;

    // Konstruktor - setzt initiale werte für die attribute
    public Hund(Integer alter, Double health) {
        this.alter = alter;
    }

    Double bellen(){
        // TODO:
        System.out.println("wüf~");
        return null;
    }

    Double schlafen() {
        // TODO:
        System.out.println("ZzzzZZZz");
        return null;
    }

    void essen(String essen) {
        // TODO:

    }

    void gehen() {
        // TODO:
    }

    public Integer getAlter() {
        return alter;
    }

    public void setAlter(Integer alter) {
        this.alter = alter;
    }

    public Double getHealth() {
        return health;
    }

    public void setHealth(Double health) {
        this.health = health;
    }
}
