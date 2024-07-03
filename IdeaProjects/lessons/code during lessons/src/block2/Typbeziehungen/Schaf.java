package block2.Typbeziehungen;

public class Schaf {
    private String name;
    // von wem wird das schaf gehuetet?

    public Schaf(String name) {
        this.name = name;
    }

    public void wirdGehuetet(Hund hund) {
        System.out.println("Ich bin ein Schaf, mit Namen " + name + " und werde von hund " + hund + " gehuetet.");
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String toString() {
        return this.name;
    }
}
