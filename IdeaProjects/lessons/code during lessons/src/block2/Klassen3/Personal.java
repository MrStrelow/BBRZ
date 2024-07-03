package block2.Klassen3;

public abstract class Personal {
    // Attribute
    private Integer alter;
    private Double lohn;
    private String name;
    private Boolean angestellt;

    // --------------------- Konstruktor ---------------------

    public Personal(Integer alter, String name) {
        this.alter = alter;
        this.name = name;
        this.lohn = 100*alter + 1000.;
        this.angestellt = true;
    }

    // --------------------- Methoden ---------------------

    public void kuendigen() {
        if (alter > 64) {

            this.angestellt = false;

        } else {

            System.out.println("Du darfst nicht kuendigen! (das ist aber eine Luege)");

        }
    }

    // --------------------- Get-Set-Methoden ---------------------

    public Integer getAlter() {
        return alter;
    }

    public void setAlter(Integer alter) {
        this.alter = alter;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Boolean getAngestellt() {
        return angestellt;
    }

    public Double getLohn() {
        return lohn;
    }
}
