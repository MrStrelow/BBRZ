package block2.Klassen3;

public class Tiere {
    // --------------------- Attribute ---------------------

    private Integer groesse;
    private Integer alter;
    private Boolean aggressiv;
    private Boolean amLeben;
    private Boolean kastriert;

    // --------------------- Konstruktor ---------------------
    public Tiere(Integer groesse, Integer alter, Boolean aggressiv) {
        this.groesse = groesse;
        this.alter = alter;
        this.aggressiv = aggressiv;
        this.amLeben = true;
        this.kastriert = false;
    }

    // --------------------- Methoden ---------------------


    // --------------------- Get-Set-Methoden ---------------------
    public Integer getGroesse() {
        return groesse;
    }

    public void setGroesse(Integer groesse) {
        this.groesse = groesse;
    }

    public Integer getAlter() {
        return alter;
    }

    public void setAlter(Integer alter) {
        this.alter = alter;
    }

    public Boolean getAggressiv() {
        return aggressiv;
    }

    public void setAggressiv(Boolean aggressiv) {
        this.aggressiv = aggressiv;
    }

    public Boolean getAmLeben() {
        return amLeben;
    }

    public void setAmLeben(Boolean amLeben) {
        this.amLeben = amLeben;
    }

    public Boolean getKastriert() {
        return kastriert;
    }

    public void setKastriert(Boolean kastriert) {
        this.kastriert = kastriert;
    }
}
