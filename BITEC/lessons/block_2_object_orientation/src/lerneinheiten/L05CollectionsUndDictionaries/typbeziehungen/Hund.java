package lerneinheiten.L05CollectionsUndDictionaries.typbeziehungen;

public class Hund {

    private Integer alter;
    private String name;

    public Hund(Integer alter, String name) throws Exception {

        if (alter > 6) {
            throw new ZuAltException();
        }

        if (alter < 3) {
            throw new ZuJungException();
        }

        this.alter = alter;
        this.name = name;
    }

    public void hueten(Schaf schaf) {
        System.out.println("Ich bin ein Hund, mit Namen " + name + " und bin " + alter + " alt und huete heute das Schaf " + schaf);
    }

    public String toString() {
        return getName() + " - " +  getAlter();
    }

    public boolean equals(Object object) {
        if (object == null) {
            return false;
        }

        if (!(object instanceof Hund)) {
            return false;
        }

        boolean istNameGleich = this.name.equals(((Hund) object).name);
        boolean istAlterGleich = this.alter.equals(((Hund) object).alter);

        return istNameGleich && istAlterGleich;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Integer getAlter() {
        return alter;
    }

    public void setAlter(Integer alter) {
        this.alter = alter;
    }
}
